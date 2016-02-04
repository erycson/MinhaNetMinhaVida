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

namespace MinhaNetMinhaVida
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTwitter = new System.Windows.Forms.Label();
            this.lblConsumerKey = new System.Windows.Forms.Label();
            this.lblConsumerSecret = new System.Windows.Forms.Label();
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.lblAccessTokenSecret = new System.Windows.Forms.Label();
            this.txtTwitter = new System.Windows.Forms.TextBox();
            this.txtConsumerKey = new System.Windows.Forms.TextBox();
            this.txtConsumerSecret = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.txtAccessTokenSecret = new System.Windows.Forms.TextBox();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudSpeedMinimum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSpeedAvarage = new System.Windows.Forms.NumericUpDown();
            this.linkLaw = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedAvarage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(143, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salvar e Fechar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(9, 362);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Fechar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTwitter
            // 
            this.lblTwitter.AutoSize = true;
            this.lblTwitter.Location = new System.Drawing.Point(9, 9);
            this.lblTwitter.Name = "lblTwitter";
            this.lblTwitter.Size = new System.Drawing.Size(162, 13);
            this.lblTwitter.TabIndex = 2;
            this.lblTwitter.Text = "Twitter da sua empresa (sem @):";
            // 
            // lblConsumerKey
            // 
            this.lblConsumerKey.AutoSize = true;
            this.lblConsumerKey.Location = new System.Drawing.Point(12, 165);
            this.lblConsumerKey.Name = "lblConsumerKey";
            this.lblConsumerKey.Size = new System.Drawing.Size(78, 13);
            this.lblConsumerKey.TabIndex = 3;
            this.lblConsumerKey.Text = "Consumer Key:";
            // 
            // lblConsumerSecret
            // 
            this.lblConsumerSecret.AutoSize = true;
            this.lblConsumerSecret.Location = new System.Drawing.Point(11, 204);
            this.lblConsumerSecret.Name = "lblConsumerSecret";
            this.lblConsumerSecret.Size = new System.Drawing.Size(91, 13);
            this.lblConsumerSecret.TabIndex = 4;
            this.lblConsumerSecret.Text = "Consumer Secret:";
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(11, 243);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(79, 13);
            this.lblAccessToken.TabIndex = 5;
            this.lblAccessToken.Text = "Access Token:";
            // 
            // lblAccessTokenSecret
            // 
            this.lblAccessTokenSecret.AutoSize = true;
            this.lblAccessTokenSecret.Location = new System.Drawing.Point(8, 282);
            this.lblAccessTokenSecret.Name = "lblAccessTokenSecret";
            this.lblAccessTokenSecret.Size = new System.Drawing.Size(113, 13);
            this.lblAccessTokenSecret.TabIndex = 6;
            this.lblAccessTokenSecret.Text = "Access Token Secret:";
            // 
            // txtTwitter
            // 
            this.txtTwitter.Location = new System.Drawing.Point(29, 25);
            this.txtTwitter.MaxLength = 25;
            this.txtTwitter.Name = "txtTwitter";
            this.txtTwitter.Size = new System.Drawing.Size(243, 20);
            this.txtTwitter.TabIndex = 7;
            // 
            // txtConsumerKey
            // 
            this.txtConsumerKey.Location = new System.Drawing.Point(11, 181);
            this.txtConsumerKey.Name = "txtConsumerKey";
            this.txtConsumerKey.Size = new System.Drawing.Size(260, 20);
            this.txtConsumerKey.TabIndex = 8;
            // 
            // txtConsumerSecret
            // 
            this.txtConsumerSecret.Location = new System.Drawing.Point(11, 220);
            this.txtConsumerSecret.Name = "txtConsumerSecret";
            this.txtConsumerSecret.Size = new System.Drawing.Size(260, 20);
            this.txtConsumerSecret.TabIndex = 9;
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(11, 259);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(260, 20);
            this.txtAccessToken.TabIndex = 10;
            // 
            // txtAccessTokenSecret
            // 
            this.txtAccessTokenSecret.Location = new System.Drawing.Point(11, 298);
            this.txtAccessTokenSecret.Name = "txtAccessTokenSecret";
            this.txtAccessTokenSecret.Size = new System.Drawing.Size(260, 20);
            this.txtAccessTokenSecret.TabIndex = 11;
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "Kb/s",
            "Mb/s"});
            this.cmbSpeed.Location = new System.Drawing.Point(145, 64);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(127, 21);
            this.cmbSpeed.TabIndex = 12;
            this.cmbSpeed.Text = "Mb/s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Velocidade Contratada:";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(12, 65);
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(126, 20);
            this.nudSpeed.TabIndex = 15;
            // 
            // nudSpeedMinimum
            // 
            this.nudSpeedMinimum.Location = new System.Drawing.Point(145, 104);
            this.nudSpeedMinimum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeedMinimum.Name = "nudSpeedMinimum";
            this.nudSpeedMinimum.Size = new System.Drawing.Size(126, 20);
            this.nudSpeedMinimum.TabIndex = 16;
            this.nudSpeedMinimum.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Velocidade Mínima  (%):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Velocidade Média (%):";
            // 
            // nudSpeedAvarage
            // 
            this.nudSpeedAvarage.Location = new System.Drawing.Point(12, 104);
            this.nudSpeedAvarage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeedAvarage.Name = "nudSpeedAvarage";
            this.nudSpeedAvarage.Size = new System.Drawing.Size(126, 20);
            this.nudSpeedAvarage.TabIndex = 19;
            this.nudSpeedAvarage.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // linkLaw
            // 
            this.linkLaw.AutoSize = true;
            this.linkLaw.Location = new System.Drawing.Point(9, 332);
            this.linkLaw.Name = "linkLaw";
            this.linkLaw.Size = new System.Drawing.Size(264, 13);
            this.linkLaw.TabIndex = 21;
            this.linkLaw.TabStop = true;
            this.linkLaw.Text = "Limites mínimos de velocidade da banda larga (Anatel)";
            this.linkLaw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLaw_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "@";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Intervalo das Verificações (em horas):";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(12, 143);
            this.nudInterval.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(257, 20);
            this.nudInterval.TabIndex = 23;
            this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 396);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLaw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSpeedAvarage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudSpeedMinimum);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSpeed);
            this.Controls.Add(this.txtAccessTokenSecret);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.txtConsumerSecret);
            this.Controls.Add(this.txtConsumerKey);
            this.Controls.Add(this.txtTwitter);
            this.Controls.Add(this.lblAccessTokenSecret);
            this.Controls.Add(this.lblAccessToken);
            this.Controls.Add(this.lblConsumerSecret);
            this.Controls.Add(this.lblConsumerKey);
            this.Controls.Add(this.lblTwitter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Name = "SettingsForm";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedAvarage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTwitter;
        private System.Windows.Forms.Label lblConsumerKey;
        private System.Windows.Forms.Label lblConsumerSecret;
        private System.Windows.Forms.Label lblAccessToken;
        private System.Windows.Forms.Label lblAccessTokenSecret;
        private System.Windows.Forms.TextBox txtTwitter;
        private System.Windows.Forms.TextBox txtConsumerKey;
        private System.Windows.Forms.TextBox txtConsumerSecret;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.TextBox txtAccessTokenSecret;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeedMinimum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSpeedAvarage;
        private System.Windows.Forms.LinkLabel linkLaw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudInterval;
    }
}