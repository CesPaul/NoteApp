namespace NoteAppUI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.NoteAppLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.GithubLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.TgLabel = new System.Windows.Forms.Label();
            this.EmailLinkLabel = new System.Windows.Forms.LinkLabel();
            this.TgLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GithubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.AuthorNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoteAppLabel
            // 
            this.NoteAppLabel.AutoSize = true;
            this.NoteAppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteAppLabel.Location = new System.Drawing.Point(12, 9);
            this.NoteAppLabel.Name = "NoteAppLabel";
            this.NoteAppLabel.Size = new System.Drawing.Size(127, 31);
            this.NoteAppLabel.TabIndex = 0;
            this.NoteAppLabel.Text = "NoteApp";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VersionLabel.Location = new System.Drawing.Point(134, 16);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(60, 24);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v. 0.1";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthorLabel.Location = new System.Drawing.Point(15, 68);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(54, 17);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "Author:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailLabel.Location = new System.Drawing.Point(15, 103);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(51, 17);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "E-mail:";
            // 
            // GithubLabel
            // 
            this.GithubLabel.AutoSize = true;
            this.GithubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GithubLabel.Location = new System.Drawing.Point(15, 175);
            this.GithubLabel.Name = "GithubLabel";
            this.GithubLabel.Size = new System.Drawing.Size(56, 17);
            this.GithubLabel.TabIndex = 4;
            this.GithubLabel.Text = "GitHub:";
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CopyrightLabel.Location = new System.Drawing.Point(15, 265);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(162, 17);
            this.CopyrightLabel.TabIndex = 5;
            this.CopyrightLabel.Text = "2018 Pavel Gumennikov";
            // 
            // TgLabel
            // 
            this.TgLabel.AutoSize = true;
            this.TgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TgLabel.Location = new System.Drawing.Point(15, 139);
            this.TgLabel.Name = "TgLabel";
            this.TgLabel.Size = new System.Drawing.Size(72, 17);
            this.TgLabel.TabIndex = 6;
            this.TgLabel.Text = "Telegram:";
            // 
            // EmailLinkLabel
            // 
            this.EmailLinkLabel.AutoSize = true;
            this.EmailLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailLinkLabel.Location = new System.Drawing.Point(97, 103);
            this.EmailLinkLabel.Name = "EmailLinkLabel";
            this.EmailLinkLabel.Size = new System.Drawing.Size(198, 17);
            this.EmailLinkLabel.TabIndex = 10;
            this.EmailLinkLabel.TabStop = true;
            this.EmailLinkLabel.Text = "gumennikov.pavel@yandex.ru";
            this.EmailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EmailLinkLabel_LinkClicked);
            // 
            // TgLinkLabel
            // 
            this.TgLinkLabel.AutoSize = true;
            this.TgLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TgLinkLabel.Location = new System.Drawing.Point(97, 139);
            this.TgLinkLabel.Name = "TgLinkLabel";
            this.TgLinkLabel.Size = new System.Drawing.Size(91, 17);
            this.TgLinkLabel.TabIndex = 11;
            this.TgLinkLabel.TabStop = true;
            this.TgLinkLabel.Text = "t.me/CesPaul";
            this.TgLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TgLinkLabel_LinkClicked);
            // 
            // GithubLinkLabel
            // 
            this.GithubLinkLabel.AutoSize = true;
            this.GithubLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GithubLinkLabel.Location = new System.Drawing.Point(97, 175);
            this.GithubLinkLabel.Name = "GithubLinkLabel";
            this.GithubLinkLabel.Size = new System.Drawing.Size(133, 17);
            this.GithubLinkLabel.TabIndex = 12;
            this.GithubLinkLabel.TabStop = true;
            this.GithubLinkLabel.Text = "github.com/CesPaul";
            this.GithubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLinkLabel_LinkClicked);
            // 
            // AuthorNameLabel
            // 
            this.AuthorNameLabel.AutoSize = true;
            this.AuthorNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthorNameLabel.Location = new System.Drawing.Point(97, 68);
            this.AuthorNameLabel.Name = "AuthorNameLabel";
            this.AuthorNameLabel.Size = new System.Drawing.Size(126, 17);
            this.AuthorNameLabel.TabIndex = 14;
            this.AuthorNameLabel.Text = "Pavel Gumennikov";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(314, 291);
            this.Controls.Add(this.AuthorNameLabel);
            this.Controls.Add(this.GithubLinkLabel);
            this.Controls.Add(this.TgLinkLabel);
            this.Controls.Add(this.EmailLinkLabel);
            this.Controls.Add(this.TgLabel);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.GithubLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.NoteAppLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NoteAppLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label GithubLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Label TgLabel;
        private System.Windows.Forms.LinkLabel EmailLinkLabel;
        private System.Windows.Forms.LinkLabel TgLinkLabel;
        private System.Windows.Forms.LinkLabel GithubLinkLabel;
        private System.Windows.Forms.Label AuthorNameLabel;
    }
}