﻿namespace ComPairSE
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
            this.button_SearchItemsByTag = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRnd
            // 
            this.btRnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btRnd.Location = new System.Drawing.Point(29, 287);
            this.btRnd.Name = "btRnd";
            this.btRnd.Size = new System.Drawing.Size(96, 22);
            this.btRnd.TabIndex = 0;
            this.btRnd.Text = "Random Test";
            this.btRnd.UseVisualStyleBackColor = true;
            this.btRnd.Click += new System.EventHandler(this.btRnd_Click);
            // 
            // tbInput
            // 
            this.tbInput.AcceptsTab = true;
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Location = new System.Drawing.Point(3, 3);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(448, 280);
            this.tbInput.TabIndex = 1;
            // 
            // btSubmit
            // 
            this.btSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btSubmit.Location = new System.Drawing.Point(137, 287);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 22);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // button_SearchItemsByTag
            // 
            this.button_SearchItemsByTag.Location = new System.Drawing.Point(222, 287);
            this.button_SearchItemsByTag.Name = "button_SearchItemsByTag";
            this.button_SearchItemsByTag.Size = new System.Drawing.Size(120, 22);
            this.button_SearchItemsByTag.TabIndex = 3;
            this.button_SearchItemsByTag.Text = "Search items by tag";
            this.button_SearchItemsByTag.UseVisualStyleBackColor = true;
            this.button_SearchItemsByTag.Click += new System.EventHandler(this.button_SearchItemsByTag_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(351, 287);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 22);
            this.buttonCheck.TabIndex = 4;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 311);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.button_SearchItemsByTag);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btRnd);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComPairSE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRnd;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button button_SearchItemsByTag;
        private System.Windows.Forms.Button buttonCheck;
    }
}

