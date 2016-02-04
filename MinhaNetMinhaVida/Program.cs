/*
 * Minha Net Minha Vida
 * Copyright (C) 2016  Érycson Nóbrega <egdn2004@gmail.com>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Device.Location;
using System.Configuration;

using Tweetinvi;
using MinhaNetMinhaVida.SpeedTest;
using System.Collections.Specialized;
using System.Net.Cache;

namespace MinhaNetMinhaVida
{
    class Program
    {
        public static string AppPath;
        public static Program Instance;

        private NotifyIcon notify;
        private IContainer components;
        private ContextMenu context;
        private MenuItem menuExit;
        private MenuItem menuAction;
        private MenuItem menuSettings;
        private MenuItem menuTestNow;

        private Server[] servers;
        private Server bestServer;
        private double latitude;
        private double longitude;
        private SettingsForm frmSettings;

        private System.Windows.Forms.Timer timer;
        private NameValueCollection settings = ConfigurationManager.AppSettings;
        private bool checkingInternetSpeed = false;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Program.AppPath = Path.GetFullPath(Application.UserAppDataPath + @"\..\..\");
            Program.Instance = new Program();
            Application.Run();
        }

        public Program()
        {
            HttpWebRequest.DefaultCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            this.components = new Container();
            this.context = new ContextMenu();

            // Start & Stop
            this.menuAction = new MenuItem();
            this.menuAction.Index = 0;
            this.menuAction.Text = "Iniciar";
            this.menuAction.Enabled = false;
            this.menuAction.Click += (s1, e1) =>
            {
                if (this.menuAction.Text == "Iniciar")
                {
                    this.timer = new System.Windows.Forms.Timer();
                    this.timer.Interval = Convert.ToInt32(settings["INTERVAL"] ?? "1") * 3600000;
                    this.timer.Tick += (s2, e2) => this.CheckInternetSpeed();
                    this.timer.Start();
                    this.menuAction.Text = "Parar";
                    this.CheckInternetSpeed();
                }
                else
                {
                    this.timer.Stop();
                    this.timer = null;
                    this.menuAction.Text = "Iniciar";
                }
            };

            // Test Now
            this.menuTestNow = new MenuItem();
            this.menuTestNow.Index = 1;
            this.menuTestNow.Text = "Testar Agora";
            this.menuTestNow.Enabled = false;
            this.menuTestNow.Click += (s, e) => this.CheckInternetSpeed();

            // Settings
            this.menuSettings = new MenuItem();
            this.menuSettings.Index = 2;
            this.menuSettings.Text = "Configurações";
            this.menuSettings.Enabled = true;
            this.menuSettings.Click += (s1, e1) =>
            {
                this.frmSettings = new SettingsForm();
                this.frmSettings.FormClosed += (s2, e2) =>
                {
                    if (this.timer != null)
                    {
                        this.timer.Stop();
                        this.timer.Interval = Convert.ToInt32(settings["INTERVAL"] ?? "1") * 3600000;
                        this.timer.Start();
                    }

                    this.frmSettings = null;
                    this.CheckSettings();
                };
                this.frmSettings.Show();
            };

            // Exit
            this.menuExit = new MenuItem();
            this.menuExit.Index = 3;
            this.menuExit.Text = "Sair";
            this.menuExit.Enabled = true;
            this.menuExit.Click += (s, e) => Application.Exit();

            this.context.MenuItems.AddRange(new MenuItem[] {
                this.menuAction,
                this.menuTestNow,
                this.menuSettings,
                this.menuExit
            });

            this.notify = new NotifyIcon(this.components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new System.Drawing.Icon("icon.ico"),
                Text = "Minha Net Minha Vida",
                Visible = true,
            };
            this.notify.Icon = new System.Drawing.Icon("icon.ico");
            this.notify.ContextMenu = this.context;

            this.DownloadServersList();
            this.GetUserPostion();
        }
        
        public void DownloadServersList()
        {
            if (File.Exists("./speedtest-servers.xml"))
            {
                FileInfo fi = new FileInfo("./speedtest-servers.xml");
                if ((DateTime.Now - fi.CreationTime).TotalDays <= 7)
                {
                    FileStream fStream = fi.OpenRead();
                    XmlSerializer serializer = new XmlSerializer(typeof(SpeedTest.Settings));
                    this.servers = ((Settings)serializer.Deserialize(fStream)).Server;
                    fStream.Close();
                    return;
                }
                else
                {
                    fi.Delete();
                }
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.speedtest.net/speedtest-servers.php");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36";

                System.IO.Stream stream = request.GetResponse().GetResponseStream();

                string response = new StreamReader(stream).ReadToEnd();
                File.WriteAllText("./speedtest-servers.xml", response);

                XmlSerializer serializer = new XmlSerializer(typeof(SpeedTest.Settings));
                this.servers = ((Settings)serializer.Deserialize(stream)).Server;

            }
            catch (Exception ex)
            {
                Thread.Sleep(60000);
                this.DownloadServersList();
            }
        }

        public void GetUserPostion()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>((s, e) =>
            {
                latitude = e.Position.Location.Latitude;
                longitude = e.Position.Location.Longitude;
                watcher.Stop();

                this.GetBestServer();
            });
            watcher.Start();
        }

        private void GetBestServer()
        {
            this.bestServer = (
                from s 
                in this.servers
                orderby new GeoCoordinate(this.latitude, this.longitude).GetDistanceTo(new GeoCoordinate(s.Latitude, s.Longitude))
                select s
            ).First();

            if (!this.CheckSettings())
                MessageBox.Show("Suas configurações não são válidas");
            
        }

        private async void CheckInternetSpeed()
        {
            if (this.checkingInternetSpeed)
                return;

            string url = new Uri(new Uri(this.bestServer.Url), ".").ToString();
            long length = 0;

            DateTime timeStart = DateTime.Now;
            try
            {
                this.checkingInternetSpeed = true;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + this.GetFileNameForSpeedTest());
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36";

                length = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd().Length;
            }
            catch(Exception ex)
            {
                this.checkingInternetSpeed = false;
                Thread.Sleep(60000);
                this.CheckInternetSpeed();
            }

            // to Kb/s
            double speed = Math.Round((length / 1024) / (DateTime.Now - timeStart).TotalSeconds, 2);

            this.checkingInternetSpeed = false;
            this.CheckResults(speed * 8); // convert Kb/s to bits/s
        }

        private void CheckResults(double downloadSpeed)
        {
            string twitter = settings["TWITTER"];

            int speed = Convert.ToInt32(settings["SPEED"]);
            int speedAvarage = Convert.ToInt32(settings["SPEED_AVG"]);
            int speedMinimun = Convert.ToInt32(settings["SPEED_MIN"]);

            string tweet = null;
            if (downloadSpeed < speed * (speedMinimun / 100))
            {
                tweet = String.Format(
                    "Olá @{0}, pago por {1} e recebo {2}, e a Resolução nº 574? #MinhaNetMinhaVida @Anatel_Informa",
                    twitter,
                    FormatDownloadSpeed(speed),
                    FormatDownloadSpeed(downloadSpeed)
                );
            }
            else if (downloadSpeed < speed * (speedAvarage / 100))
            {
                tweet = String.Format(
                    "Olá @{0}, pago por {1} e recebo {2}. #MinhaNetMinhaVida @Anatel_Informa",
                    twitter,
                    FormatDownloadSpeed(speed),
                    FormatDownloadSpeed(downloadSpeed)
                );
            }

            if (tweet != null)
                this.SendTweet(tweet);
        }

        private void SendTweet(string tweet)
        {
            string consumerKey = settings["CONSUMER_KEY"] ?? "";
            string consumerSecret = settings["CONSUMER_SECRET"] ?? "";
            string accessToken = settings["ACCESS_TOKEN"] ?? "";
            string accessTokenSecret = settings["ACCESS_TOKEN_SECRET"] ?? "";

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            Tweet.PublishTweet(tweet);
        }

        private bool CheckSettings()
        {
            ConfigurationManager.RefreshSection("appSettings");
            settings = ConfigurationManager.AppSettings;

            string twitter = settings["TWITTER"] ?? "";

            string speed = settings["SPEED"] ?? "0";
            string speedAvarage = settings["SPEED_AVG"] ?? "0";
            string speedMinimun = settings["SPEED_MIN"] ?? "0";
            string interval = settings["INTERVAL"] ?? "1";

            string consumerKey = settings["CONSUMER_KEY"] ?? "";
            string consumerSecret = settings["CONSUMER_SECRET"] ?? "";
            string accessToken = settings["ACCESS_TOKEN"] ?? "";
            string accessTokenSecret = settings["ACCESS_TOKEN_SECRET"] ?? "";

            if (twitter.Length == 0 || twitter.Length > 25)
                return false;

            if (speed.Length == 0 || Convert.ToInt32(speed) <= 0)
                return false;
            if (speedAvarage.Length == 0 || Convert.ToInt32(speedAvarage) <= 0)
                return false;
            if (speedMinimun.Length == 0 || Convert.ToInt32(speedMinimun) <= 0 || Convert.ToInt32(speedMinimun) > Convert.ToInt32(speedAvarage))
                return false;
            if (interval.Length == 0 || Convert.ToInt32(interval) <= 0)
                return false;

            if (consumerKey.Length == 0)
                return false;
            if (consumerSecret.Length == 0)
                return false;
            if (accessToken.Length == 0)
                return false;
            if (accessTokenSecret.Length == 0)
                return false;

            this.menuAction.Enabled = true;
            this.menuTestNow.Enabled = true;

            return true;
        }

        private string FormatDownloadSpeed(double speed)
        {
            string formated = "";

            if (speed < 1024)
                formated = speed + "Kb/s";
            else 
                formated = Math.Round(speed / 1024, 2) + "Mb/s";

            return formated;
        }

        private string GetFileNameForSpeedTest()
        {
            int speed = Convert.ToInt32(settings["SPEED"]);

            if (speed < 256)
                return "random350x350.jpg";
            else if (speed < 512)
                return "random500x500.jpg";
            else if (speed < 1024)
                return "random1000x1000.jpg";
            else if (speed < 2048)
                return "random1500x1500.jpg";
            else if (speed < 5120)
                return "random2500x2500.jpg";
            else if (speed < 10240)
                return "random3000x3000.jpg";
            else if (speed < 10240)
                return "random3000x3000.jpg";
            else if (speed < 20480)
                return "random3500x3500.jpg";

            return "random4000x4000.jpg";
        }
    }
}
