namespace ComPairSEBack.UI
{
    partial class HomePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btBrowse = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.btScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(62, 218);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(100, 23);
            this.btBrowse.TabIndex = 6;
            this.btBrowse.Text = "Browse Receipts";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(62, 189);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(100, 23);
            this.btCreate.TabIndex = 7;
            this.btCreate.Text = "Create a Receipt";
            this.btCreate.UseVisualStyleBackColor = true;
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(62, 160);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(100, 23);
            this.btScan.TabIndex = 8;
            this.btScan.Text = "Scan receipt";
            this.btScan.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.btScan);
            this.Name = "HomePage";
            this.Controls.SetChildIndex(this.btScan, 0);
            this.Controls.SetChildIndex(this.btCreate, 0);
            this.Controls.SetChildIndex(this.btBrowse, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btScan;
    }
}
