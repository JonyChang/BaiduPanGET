namespace BaiduPanGET
{
    partial class MainForm
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
            this.LinkTXTBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GetBtn = new System.Windows.Forms.Button();
            this.Dltxt = new System.Windows.Forms.TextBox();
            this.downloadLinkLBL = new System.Windows.Forms.Label();
            this.captchaBox = new System.Windows.Forms.PictureBox();
            this.captchaSub = new System.Windows.Forms.Button();
            this.captchaTXT = new System.Windows.Forms.TextBox();
            this.md5TXT = new System.Windows.Forms.TextBox();
            this.md5LBL = new System.Windows.Forms.Label();
            this.CopyBTN = new System.Windows.Forms.Button();
            this.filenameTXT = new System.Windows.Forms.TextBox();
            this.filenameLBL = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.worker2 = new System.ComponentModel.BackgroundWorker();
            this.workingLBL = new System.Windows.Forms.Label();
            this.pwdTXT = new System.Windows.Forms.TextBox();
            this.pwdLBL = new System.Windows.Forms.Label();
            this.gtpwdCK = new System.Windows.Forms.CheckBox();
            this.AboutLBL = new System.Windows.Forms.Label();
            this.captchaLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.captchaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkTXTBOX
            // 
            this.LinkTXTBOX.Location = new System.Drawing.Point(102, 6);
            this.LinkTXTBOX.Name = "LinkTXTBOX";
            this.LinkTXTBOX.Size = new System.Drawing.Size(227, 20);
            this.LinkTXTBOX.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "链接 : ";
            // 
            // GetBtn
            // 
            this.GetBtn.Location = new System.Drawing.Point(44, 128);
            this.GetBtn.Name = "GetBtn";
            this.GetBtn.Size = new System.Drawing.Size(75, 23);
            this.GetBtn.TabIndex = 2;
            this.GetBtn.Text = "Get Link !";
            this.GetBtn.UseVisualStyleBackColor = true;
            this.GetBtn.Click += new System.EventHandler(this.GetBtn_Click);
            // 
            // Dltxt
            // 
            this.Dltxt.Location = new System.Drawing.Point(160, 99);
            this.Dltxt.Name = "Dltxt";
            this.Dltxt.ReadOnly = true;
            this.Dltxt.Size = new System.Drawing.Size(227, 20);
            this.Dltxt.TabIndex = 4;
            // 
            // downloadLinkLBL
            // 
            this.downloadLinkLBL.AutoSize = true;
            this.downloadLinkLBL.Location = new System.Drawing.Point(42, 102);
            this.downloadLinkLBL.Name = "downloadLinkLBL";
            this.downloadLinkLBL.Size = new System.Drawing.Size(112, 13);
            this.downloadLinkLBL.TabIndex = 5;
            this.downloadLinkLBL.Text = "获取到的下载链接 : ";
            // 
            // captchaBox
            // 
            this.captchaBox.Location = new System.Drawing.Point(475, 14);
            this.captchaBox.Name = "captchaBox";
            this.captchaBox.Size = new System.Drawing.Size(104, 32);
            this.captchaBox.TabIndex = 6;
            this.captchaBox.TabStop = false;
            this.captchaBox.Visible = false;
            // 
            // captchaSub
            // 
            this.captchaSub.Location = new System.Drawing.Point(475, 82);
            this.captchaSub.Name = "captchaSub";
            this.captchaSub.Size = new System.Drawing.Size(104, 23);
            this.captchaSub.TabIndex = 7;
            this.captchaSub.Text = "Captcha Submit";
            this.captchaSub.UseVisualStyleBackColor = true;
            this.captchaSub.Visible = false;
            this.captchaSub.Click += new System.EventHandler(this.captchaSub_Click);
            // 
            // captchaTXT
            // 
            this.captchaTXT.Location = new System.Drawing.Point(475, 53);
            this.captchaTXT.Name = "captchaTXT";
            this.captchaTXT.Size = new System.Drawing.Size(104, 20);
            this.captchaTXT.TabIndex = 8;
            this.captchaTXT.Visible = false;
            // 
            // md5TXT
            // 
            this.md5TXT.Location = new System.Drawing.Point(102, 76);
            this.md5TXT.Name = "md5TXT";
            this.md5TXT.ReadOnly = true;
            this.md5TXT.Size = new System.Drawing.Size(227, 20);
            this.md5TXT.TabIndex = 9;
            // 
            // md5LBL
            // 
            this.md5LBL.AutoSize = true;
            this.md5LBL.Location = new System.Drawing.Point(42, 82);
            this.md5LBL.Name = "md5LBL";
            this.md5LBL.Size = new System.Drawing.Size(39, 13);
            this.md5LBL.TabIndex = 10;
            this.md5LBL.Text = "MD5 : ";
            // 
            // CopyBTN
            // 
            this.CopyBTN.Location = new System.Drawing.Point(394, 96);
            this.CopyBTN.Name = "CopyBTN";
            this.CopyBTN.Size = new System.Drawing.Size(57, 23);
            this.CopyBTN.TabIndex = 11;
            this.CopyBTN.Text = "Copy";
            this.CopyBTN.UseVisualStyleBackColor = true;
            this.CopyBTN.Visible = false;
            this.CopyBTN.Click += new System.EventHandler(this.CopyBTN_Click);
            // 
            // filenameTXT
            // 
            this.filenameTXT.Location = new System.Drawing.Point(102, 53);
            this.filenameTXT.Name = "filenameTXT";
            this.filenameTXT.ReadOnly = true;
            this.filenameTXT.Size = new System.Drawing.Size(227, 20);
            this.filenameTXT.TabIndex = 12;
            // 
            // filenameLBL
            // 
            this.filenameLBL.AutoSize = true;
            this.filenameLBL.Location = new System.Drawing.Point(41, 60);
            this.filenameLBL.Name = "filenameLBL";
            this.filenameLBL.Size = new System.Drawing.Size(52, 13);
            this.filenameLBL.TabIndex = 13;
            this.filenameLBL.Text = "文件名 : ";
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // worker2
            // 
            this.worker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker2_DoWork);
            this.worker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker2_RunWorkerCompleted);
            // 
            // workingLBL
            // 
            this.workingLBL.AutoSize = true;
            this.workingLBL.Location = new System.Drawing.Point(-2, 154);
            this.workingLBL.Name = "workingLBL";
            this.workingLBL.Size = new System.Drawing.Size(74, 13);
            this.workingLBL.TabIndex = 14;
            this.workingLBL.Text = "Working.........";
            this.workingLBL.Visible = false;
            // 
            // pwdTXT
            // 
            this.pwdTXT.Location = new System.Drawing.Point(102, 26);
            this.pwdTXT.Name = "pwdTXT";
            this.pwdTXT.ReadOnly = true;
            this.pwdTXT.Size = new System.Drawing.Size(227, 20);
            this.pwdTXT.TabIndex = 15;
            // 
            // pwdLBL
            // 
            this.pwdLBL.AutoSize = true;
            this.pwdLBL.Location = new System.Drawing.Point(37, 30);
            this.pwdLBL.Name = "pwdLBL";
            this.pwdLBL.Size = new System.Drawing.Size(59, 13);
            this.pwdLBL.TabIndex = 16;
            this.pwdLBL.Text = "Password: ";
            // 
            // gtpwdCK
            // 
            this.gtpwdCK.AutoSize = true;
            this.gtpwdCK.Location = new System.Drawing.Point(335, 29);
            this.gtpwdCK.Name = "gtpwdCK";
            this.gtpwdCK.Size = new System.Drawing.Size(98, 17);
            this.gtpwdCK.TabIndex = 17;
            this.gtpwdCK.Text = "Got Password?";
            this.gtpwdCK.UseVisualStyleBackColor = true;
            this.gtpwdCK.CheckedChanged += new System.EventHandler(this.gtpwdCK_CheckedChanged);
            // 
            // AboutLBL
            // 
            this.AboutLBL.AutoSize = true;
            this.AboutLBL.Location = new System.Drawing.Point(490, 154);
            this.AboutLBL.Name = "AboutLBL";
            this.AboutLBL.Size = new System.Drawing.Size(89, 13);
            this.AboutLBL.TabIndex = 18;
            this.AboutLBL.Text = "By Jonathan Goh";
            this.AboutLBL.Click += new System.EventHandler(this.AboutLBL_Click);
            // 
            // captchaLBL
            // 
            this.captchaLBL.AutoSize = true;
            this.captchaLBL.Location = new System.Drawing.Point(413, 56);
            this.captchaLBL.Name = "captchaLBL";
            this.captchaLBL.Size = new System.Drawing.Size(56, 13);
            this.captchaLBL.TabIndex = 19;
            this.captchaLBL.Text = "Captcha : ";
            this.captchaLBL.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 169);
            this.Controls.Add(this.captchaLBL);
            this.Controls.Add(this.AboutLBL);
            this.Controls.Add(this.gtpwdCK);
            this.Controls.Add(this.pwdLBL);
            this.Controls.Add(this.pwdTXT);
            this.Controls.Add(this.workingLBL);
            this.Controls.Add(this.filenameLBL);
            this.Controls.Add(this.filenameTXT);
            this.Controls.Add(this.CopyBTN);
            this.Controls.Add(this.md5LBL);
            this.Controls.Add(this.md5TXT);
            this.Controls.Add(this.captchaTXT);
            this.Controls.Add(this.captchaSub);
            this.Controls.Add(this.captchaBox);
            this.Controls.Add(this.downloadLinkLBL);
            this.Controls.Add(this.Dltxt);
            this.Controls.Add(this.GetBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinkTXTBOX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "百度盘链接获取";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.captchaBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LinkTXTBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GetBtn;
        private System.Windows.Forms.TextBox Dltxt;
        private System.Windows.Forms.Label downloadLinkLBL;
        private System.Windows.Forms.PictureBox captchaBox;
        private System.Windows.Forms.Button captchaSub;
        private System.Windows.Forms.TextBox captchaTXT;
        private System.Windows.Forms.TextBox md5TXT;
        private System.Windows.Forms.Label md5LBL;
        private System.Windows.Forms.Button CopyBTN;
        private System.Windows.Forms.TextBox filenameTXT;
        private System.Windows.Forms.Label filenameLBL;
        private System.ComponentModel.BackgroundWorker worker;
        private System.ComponentModel.BackgroundWorker worker2;
        private System.Windows.Forms.Label workingLBL;
        private System.Windows.Forms.TextBox pwdTXT;
        private System.Windows.Forms.Label pwdLBL;
        private System.Windows.Forms.CheckBox gtpwdCK;
        private System.Windows.Forms.Label AboutLBL;
        private System.Windows.Forms.Label captchaLBL;

    }
}

