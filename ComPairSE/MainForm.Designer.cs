namespace ComPairSE
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.button_SearchItemsByTag = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.AcceptsTab = true;
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Location = new System.Drawing.Point(4, 4);
            this.tbInput.Margin = new System.Windows.Forms.Padding(4);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(487, 302);
            this.tbInput.TabIndex = 1;
            // 
            // btSubmit
            // 
            this.btSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSubmit.Location = new System.Drawing.Point(4, 310);
            this.btSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(182, 27);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Submit receipt";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // button_SearchItemsByTag
            // 
            this.button_SearchItemsByTag.Location = new System.Drawing.Point(330, 310);
            this.button_SearchItemsByTag.Margin = new System.Windows.Forms.Padding(4);
            this.button_SearchItemsByTag.Name = "button_SearchItemsByTag";
            this.button_SearchItemsByTag.Size = new System.Drawing.Size(161, 28);
            this.button_SearchItemsByTag.TabIndex = 3;
            this.button_SearchItemsByTag.Text = "Search items by tags";
            this.button_SearchItemsByTag.UseVisualStyleBackColor = true;
            this.button_SearchItemsByTag.Click += new System.EventHandler(this.button_SearchItemsByTag_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "OCR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickOcr);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 341);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_SearchItemsByTag);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbInput);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComPairSE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button button_SearchItemsByTag;
        private System.Windows.Forms.Button button1;
    }
}

