﻿using System;

namespace NoteAppUI
{
    partial class AddAndEditNoteForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAndEditNoteForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.ModifiedLabel = new System.Windows.Forms.Label();
            this.ContentTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CreatedDateTimeLabel = new System.Windows.Forms.Label();
            this.ModifiedDateTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title:";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(12, 35);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 1;
            this.CategoryLabel.Text = "Category:";
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.AutoSize = true;
            this.CreatedLabel.Location = new System.Drawing.Point(12, 62);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(47, 13);
            this.CreatedLabel.TabIndex = 2;
            this.CreatedLabel.Text = "Created:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(70, 6);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(410, 20);
            this.TitleTextBox.TabIndex = 3;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(70, 32);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(139, 21);
            this.CategoryComboBox.TabIndex = 4;
            // 
            // ModifiedLabel
            // 
            this.ModifiedLabel.AutoSize = true;
            this.ModifiedLabel.Location = new System.Drawing.Point(230, 62);
            this.ModifiedLabel.Name = "ModifiedLabel";
            this.ModifiedLabel.Size = new System.Drawing.Size(50, 13);
            this.ModifiedLabel.TabIndex = 7;
            this.ModifiedLabel.Text = "Modified:";
            // 
            // ContentTextBox
            // 
            this.ContentTextBox.Location = new System.Drawing.Point(15, 85);
            this.ContentTextBox.Multiline = true;
            this.ContentTextBox.Name = "ContentTextBox";
            this.ContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContentTextBox.Size = new System.Drawing.Size(465, 428);
            this.ContentTextBox.TabIndex = 8;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(324, 519);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(405, 519);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreatedDateTimeLabel
            // 
            this.CreatedDateTimeLabel.AutoSize = true;
            this.CreatedDateTimeLabel.Location = new System.Drawing.Point(67, 62);
            this.CreatedDateTimeLabel.Name = "CreatedDateTimeLabel";
            this.CreatedDateTimeLabel.Size = new System.Drawing.Size(90, 13);
            this.CreatedDateTimeLabel.TabIndex = 11;
            this.CreatedDateTimeLabel.Text = "CreatedDateTime";
            // 
            // ModifiedDateTimeLabel
            // 
            this.ModifiedDateTimeLabel.AutoSize = true;
            this.ModifiedDateTimeLabel.Location = new System.Drawing.Point(295, 62);
            this.ModifiedDateTimeLabel.Name = "ModifiedDateTimeLabel";
            this.ModifiedDateTimeLabel.Size = new System.Drawing.Size(93, 13);
            this.ModifiedDateTimeLabel.TabIndex = 12;
            this.ModifiedDateTimeLabel.Text = "ModifiedDateTime";
            // 
            // AddAndEditNoteForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 554);
            this.Controls.Add(this.ModifiedDateTimeLabel);
            this.Controls.Add(this.CreatedDateTimeLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ContentTextBox);
            this.Controls.Add(this.ModifiedLabel);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.CreatedLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddAndEditNoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label ModifiedLabel;
        private System.Windows.Forms.TextBox ContentTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ToolTip OkButtonToolTip;
        private System.Windows.Forms.ToolTip CancelButtonToolTip;
        private System.Windows.Forms.Label CreatedDateTimeLabel;
        private System.Windows.Forms.Label ModifiedDateTimeLabel;
    }
}