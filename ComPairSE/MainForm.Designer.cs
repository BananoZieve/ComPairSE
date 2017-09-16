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
            this.btRnd = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRnd
            // 
            this.btRnd.Location = new System.Drawing.Point(12, 260);
            this.btRnd.Name = "btRnd";
            this.btRnd.Size = new System.Drawing.Size(96, 22);
            this.btRnd.TabIndex = 0;
            this.btRnd.Text = "Random Test";
            this.btRnd.UseVisualStyleBackColor = true;
            this.btRnd.Click += new System.EventHandler(this.btRnd_Click);
            // 
            // textBox1
            // 
            this.tbInput.AcceptsTab = true;
            this.tbInput.Location = new System.Drawing.Point(12, 12);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "textBox1";
            this.tbInput.Size = new System.Drawing.Size(246, 242);
            this.tbInput.TabIndex = 1;
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(114, 260);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 22);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 298);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btRnd);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComPairSE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRnd;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbInput;
    }
}

