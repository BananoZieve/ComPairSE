namespace ComPairSE.UI
{
    partial class Page
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
            this.btPrev = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.lbPageTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btPrev
            // 
            this.btPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPrev.Location = new System.Drawing.Point(3, 374);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(75, 23);
            this.btPrev.TabIndex = 0;
            this.btPrev.Text = "Previous";
            this.btPrev.UseVisualStyleBackColor = true;
            this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Location = new System.Drawing.Point(147, 374);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 0;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // lbPageTitle
            // 
            this.lbPageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lbPageTitle.Name = "lbPageTitle";
            this.lbPageTitle.Size = new System.Drawing.Size(225, 24);
            this.lbPageTitle.TabIndex = 1;
            this.lbPageTitle.Text = "PageTitle";
            this.lbPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPageTitle);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btPrev);
            this.MaximumSize = new System.Drawing.Size(225, 400);
            this.MinimumSize = new System.Drawing.Size(225, 400);
            this.Name = "Page";
            this.Size = new System.Drawing.Size(225, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Label lbPageTitle;
    }
}
