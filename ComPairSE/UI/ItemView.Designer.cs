namespace ComPairSEBack
{
    partial class ItemView
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
            this.lbItemName = new System.Windows.Forms.Label();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbItemName.Location = new System.Drawing.Point(3, 3);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(83, 20);
            this.lbItemName.TabIndex = 0;
            this.lbItemName.Text = "ItemName";
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Enabled = false;
            this.btRemove.Image = global::ComPairSEBack.Properties.Resources.ex16;
            this.btRemove.Location = new System.Drawing.Point(192, 3);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(24, 24);
            this.btRemove.TabIndex = 1;
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Visible = false;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::ComPairSEBack.Properties.Resources.plus16;
            this.btAdd.Location = new System.Drawing.Point(192, 3);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 24);
            this.btAdd.TabIndex = 1;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // ItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.lbItemName);
            this.Name = "ItemView";
            this.Size = new System.Drawing.Size(219, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
    }
}
