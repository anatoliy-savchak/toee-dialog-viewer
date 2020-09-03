using System.Drawing;

namespace DialogViewer
{
    partial class FormDialogViewver
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
            this.gpSettings = new System.Windows.Forms.GroupBox();
            this.bLoad = new System.Windows.Forms.Button();
            this.bBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.tvContent = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gpSettings.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSettings
            // 
            this.gpSettings.Controls.Add(this.bLoad);
            this.gpSettings.Controls.Add(this.bBrowse);
            this.gpSettings.Controls.Add(this.label1);
            this.gpSettings.Controls.Add(this.tbFileName);
            this.gpSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpSettings.Location = new System.Drawing.Point(0, 0);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(708, 50);
            this.gpSettings.TabIndex = 0;
            this.gpSettings.TabStop = false;
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(631, 10);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(75, 23);
            this.bLoad.TabIndex = 3;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(601, 8);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(23, 23);
            this.bBrowse.TabIndex = 2;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(39, 10);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(556, 20);
            this.tbFileName.TabIndex = 0;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.tbDetails);
            this.gbDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbDetails.Location = new System.Drawing.Point(0, 670);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(708, 144);
            this.gbDetails.TabIndex = 1;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details";
            // 
            // tbDetails
            // 
            this.tbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetails.Location = new System.Drawing.Point(3, 16);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetails.Size = new System.Drawing.Size(702, 125);
            this.tbDetails.TabIndex = 0;
            // 
            // tvContent
            // 
            this.tvContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContent.FullRowSelect = true;
            this.tvContent.Location = new System.Drawing.Point(0, 50);
            this.tvContent.Name = "tvContent";
            this.tvContent.Size = new System.Drawing.Size(708, 620);
            this.tvContent.TabIndex = 2;
            this.tvContent.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvContent_AfterExpand);
            this.tvContent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvContent_AfterSelect);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dlg";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormDialogViewver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 814);
            this.Controls.Add(this.tvContent);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gpSettings);
            this.Name = "FormDialogViewver";
            this.Text = "Dialog Viewer";
            this.Shown += new System.EventHandler(this.FormDialogViewver_Shown);
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.TreeView tvContent;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

