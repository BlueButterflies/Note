namespace BlockNote
{
    partial class Info
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelLicense = new System.Windows.Forms.Label();
            this.labelCopyRight = new System.Windows.Forms.Label();
            this.pictureBrand = new System.Windows.Forms.PictureBox();
            this.pictureCopy = new System.Windows.Forms.PictureBox();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(236, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.Navy;
            this.labelVersion.Location = new System.Drawing.Point(253, 76);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(89, 21);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version:  1.6";
            // 
            // labelLicense
            // 
            this.labelLicense.AutoSize = true;
            this.labelLicense.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelLicense.Location = new System.Drawing.Point(177, 157);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(156, 23);
            this.labelLicense.TabIndex = 4;
            this.labelLicense.Text = "License to:  SoftPlume";
            // 
            // labelCopyRight
            // 
            this.labelCopyRight.AutoSize = true;
            this.labelCopyRight.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelCopyRight.Location = new System.Drawing.Point(194, 107);
            this.labelCopyRight.Name = "labelCopyRight";
            this.labelCopyRight.Size = new System.Drawing.Size(238, 26);
            this.labelCopyRight.TabIndex = 3;
            this.labelCopyRight.Text = "Copyright 2020 - All rights reserved";
            this.labelCopyRight.UseCompatibleTextRendering = true;
            // 
            // pictureBrand
            // 
            this.pictureBrand.Image = global::BlockNote.Properties.Resources.iconfinder_photoshop_33703;
            this.pictureBrand.Location = new System.Drawing.Point(339, 146);
            this.pictureBrand.Name = "pictureBrand";
            this.pictureBrand.Size = new System.Drawing.Size(58, 44);
            this.pictureBrand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBrand.TabIndex = 6;
            this.pictureBrand.TabStop = false;
            // 
            // pictureCopy
            // 
            this.pictureCopy.Image = global::BlockNote.Properties.Resources.iconfinder_BT_copyright_905542;
            this.pictureCopy.Location = new System.Drawing.Point(161, 102);
            this.pictureCopy.Name = "pictureCopy";
            this.pictureCopy.Size = new System.Drawing.Size(31, 31);
            this.pictureCopy.TabIndex = 5;
            this.pictureCopy.TabStop = false;
            // 
            // pictureIcon
            // 
            this.pictureIcon.Image = global::BlockNote.Properties.Resources.iconfinder_blog_465048;
            this.pictureIcon.InitialImage = null;
            this.pictureIcon.Location = new System.Drawing.Point(-1, 15);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(156, 175);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 1;
            this.pictureIcon.TabStop = false;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(436, 210);
            this.Controls.Add(this.pictureBrand);
            this.Controls.Add(this.pictureCopy);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.labelCopyRight);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.ShowIcon = false;
            this.Text = "Info Block Note";
            this.Load += new System.EventHandler(this.Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyRight;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.PictureBox pictureCopy;
        private System.Windows.Forms.PictureBox pictureBrand;
    }
}