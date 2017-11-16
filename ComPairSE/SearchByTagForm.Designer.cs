namespace ComPairSEBack
{
    partial class SearchByTagForm
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
            this.label_Tag = new System.Windows.Forms.Label();
            this.textBox_ForSearching = new System.Windows.Forms.TextBox();
            this.button_SearchByTag = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Tag
            // 
            this.label_Tag.AutoSize = true;
            this.label_Tag.Location = new System.Drawing.Point(9, 9);
            this.label_Tag.Name = "label_Tag";
            this.label_Tag.Size = new System.Drawing.Size(29, 13);
            this.label_Tag.TabIndex = 0;
            this.label_Tag.Text = "Tag:";
            this.label_Tag.Click += new System.EventHandler(this.label_Tag_Click);
            // 
            // textBox_ForSearching
            // 
            this.textBox_ForSearching.Location = new System.Drawing.Point(41, 7);
            this.textBox_ForSearching.Name = "textBox_ForSearching";
            this.textBox_ForSearching.Size = new System.Drawing.Size(148, 20);
            this.textBox_ForSearching.TabIndex = 1;
            this.textBox_ForSearching.TextChanged += new System.EventHandler(this.textBox_ForSearching_TextChanged);
            // 
            // button_SearchByTag
            // 
            this.button_SearchByTag.Location = new System.Drawing.Point(195, 5);
            this.button_SearchByTag.Name = "button_SearchByTag";
            this.button_SearchByTag.Size = new System.Drawing.Size(75, 23);
            this.button_SearchByTag.TabIndex = 2;
            this.button_SearchByTag.Text = "Search";
            this.button_SearchByTag.UseVisualStyleBackColor = true;
            this.button_SearchByTag.Click += new System.EventHandler(this.button_SearchByTag_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 20);
            this.textBox1.TabIndex = 3;
            // 
            // SearchByTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_SearchByTag);
            this.Controls.Add(this.textBox_ForSearching);
            this.Controls.Add(this.label_Tag);
            this.Name = "SearchByTagForm";
            this.Text = "SearchByTagForm";
            this.Load += new System.EventHandler(this.SearchByTagForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Tag;
        private System.Windows.Forms.TextBox textBox_ForSearching;
        private System.Windows.Forms.Button button_SearchByTag;
        private System.Windows.Forms.TextBox textBox1;
    }
}