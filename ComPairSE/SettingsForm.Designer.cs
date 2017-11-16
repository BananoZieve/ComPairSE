namespace ComPairSEBack
{
    partial class SettingsForm
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
            this.receiptsData = new System.Windows.Forms.CheckBox();
            this.backButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // receiptsData
            // 
            this.receiptsData.Location = new System.Drawing.Point(12, 12);
            this.receiptsData.Name = "receiptsData";
            this.receiptsData.Size = new System.Drawing.Size(210, 40);
            this.receiptsData.TabIndex = 1;
            this.receiptsData.Text = "Allow to anonymously collect receipts data";
            this.receiptsData.UseVisualStyleBackColor = true;
            this.receiptsData.Click += new System.EventHandler(this.OnCheck);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 89);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 28);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(150, 89);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 28);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 128);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.receiptsData);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox receiptsData;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button applyButton;
    }
}