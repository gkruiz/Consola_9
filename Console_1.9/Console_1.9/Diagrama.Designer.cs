namespace Console_1._9
{
    partial class Diagrama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagrama));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 449);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(489, 443);
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "files-empty.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folder-open.png");
            // 
            // Diagrama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 445);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(800, 100);
            this.Name = "Diagrama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Diagrama";
            this.Load += new System.EventHandler(this.Diagrama_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ImageList imageList1;
    }
}