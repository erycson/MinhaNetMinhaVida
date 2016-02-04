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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhaNetMinhaVida
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void linkLaw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.anatel.gov.br/legislacao/resolucoes/26-2011/57-resolucao-574");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string twitter = txtTwitter.Text;

            int speed = Convert.ToInt32(nudSpeed.Value);
            string speedMult = cmbSpeed.Text;
            int speedAvarage = Convert.ToInt32(nudSpeedAvarage.Value);
            int speedMinimum = Convert.ToInt32(nudSpeedMinimum.Value);
            int interval = Convert.ToInt32(nudInterval.Value);

            string consumerKey = txtConsumerKey.Text;
            string consumerSecret = txtConsumerSecret.Text;
            string accessToken = txtAccessToken.Text;
            string accessTokenSecret = txtAccessTokenSecret.Text;

            if (speedMinimum > speedAvarage)
            {
                MessageBox.Show("A velocidade mínima não pode ser maior que a velocidade média");
                return;
            }
            else if (twitter.Length > 25)
            {
                MessageBox.Show("O Twitter pode ter no maximo 25 caracteres");
                return;
            }

            if (speedMult == "Mb/s")
                speed *= 1024;

            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

            if (settings["TWITTER"] == null)
                settings.Add("TWITTER", twitter);
            else
                settings["TWITTER"].Value = twitter;

            if (settings["SPEED"] == null)
                settings.Add("SPEED", speed.ToString());
            else
                settings["SPEED"].Value = speed.ToString();

            if (settings["SPEED_AVG"] == null)
                settings.Add("SPEED_AVG", speedAvarage.ToString());
            else
                settings["SPEED_AVG"].Value = speedAvarage.ToString();

            if (settings["SPEED_MIN"] == null)
                settings.Add("SPEED_MIN", speedMinimum.ToString());
            else
                settings["SPEED_MIN"].Value = speedMinimum.ToString();

            if (settings["INTERVAL"] == null)
                settings.Add("INTERVAL", interval.ToString());
            else
                settings["INTERVAL"].Value = interval.ToString();

            if (settings["CONSUMER_KEY"] == null)
                settings.Add("CONSUMER_KEY", consumerKey);
            else
                settings["CONSUMER_KEY"].Value = consumerKey;

            if (settings["CONSUMER_SECRET"] == null)
                settings.Add("CONSUMER_SECRET", consumerSecret);
            else
                settings["CONSUMER_SECRET"].Value = consumerSecret;

            if (settings["ACCESS_TOKEN"] == null)
                settings.Add("ACCESS_TOKEN", accessToken);
            else
                settings["ACCESS_TOKEN"].Value = accessToken;

            if (settings["ACCESS_TOKEN_SECRET"] == null)
                settings.Add("ACCESS_TOKEN_SECRET", accessTokenSecret);
            else
                settings["ACCESS_TOKEN_SECRET"].Value = accessTokenSecret;

            try
            {
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                MessageBox.Show("As configurações foram salvas com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível salvar as configurações");
            }

            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;

            string twitter = settings["TWITTER"] ?? "";
            int speed = Convert.ToInt32(settings["SPEED"] ?? "0");
            int speed_avg = Convert.ToInt32(settings["SPEED_AVG"] ?? "80");
            int speed_min = Convert.ToInt32(settings["SPEED_MIN"] ?? "40");
            int interval = Convert.ToInt32(settings["INTEVAL"] ?? "1");

            string consumer_key = settings["CONSUMER_KEY"] ?? "";
            string consumer_secret = settings["CONSUMER_SECRET"] ?? "";
            string access_token = settings["ACCESS_TOKEN"] ?? "";
            string access_token_secret = settings["ACCESS_TOKEN_SECRET"] ?? "";
            
            txtTwitter.Text = twitter;

            nudSpeedAvarage.Value = speed_avg;
            nudSpeedMinimum.Value = speed_min;
            nudInterval.Value = interval;

            txtConsumerKey.Text = consumer_key;
            txtConsumerSecret.Text = consumer_secret;
            txtAccessToken.Text = access_token;
            txtAccessTokenSecret.Text = access_token_secret;

            if (speed / 1024 == Math.Round(speed / 1024f, 3))
            {
                nudSpeed.Value = speed / 1024;
                cmbSpeed.Text = "Mb/s";
            }
            else
            {
                nudSpeed.Value = speed;
                cmbSpeed.Text = "Kb/s";
            }
        }
    }
}
