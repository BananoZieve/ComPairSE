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
            this.components = new System.ComponentModel.Container();
            this.btRnd = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.button_SearchItemsByTag = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btBrowse = new System.Windows.Forms.Button();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.rbInput = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRnd
            // 
            this.btRnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRnd.Enabled = false;
            this.btRnd.Location = new System.Drawing.Point(3, 291);
            this.btRnd.Name = "btRnd";
            this.btRnd.Size = new System.Drawing.Size(96, 22);
            this.btRnd.TabIndex = 0;
            this.btRnd.Text = "Random Test";
            this.btRnd.UseVisualStyleBackColor = true;
            this.btRnd.Visible = false;
            this.btRnd.Click += new System.EventHandler(this.btRnd_Click);
            // 
            // tbInput
            // 
            this.tbInput.AcceptsTab = true;
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbInput.Location = new System.Drawing.Point(3, 75);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(265, 213);
            this.tbInput.TabIndex = 1;
            // 
            // btSubmit
            // 
            this.btSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSubmit.Location = new System.Drawing.Point(105, 291);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 22);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Submit receipt";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // button_SearchItemsByTag
            // 
            this.button_SearchItemsByTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_SearchItemsByTag.Location = new System.Drawing.Point(186, 291);
            this.button_SearchItemsByTag.Name = "button_SearchItemsByTag";
            this.button_SearchItemsByTag.Size = new System.Drawing.Size(82, 23);
            this.button_SearchItemsByTag.TabIndex = 3;
            this.button_SearchItemsByTag.Text = "Search items by tags";
            this.button_SearchItemsByTag.UseVisualStyleBackColor = true;
            this.button_SearchItemsByTag.Click += new System.EventHandler(this.button_SearchItemsByTag_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "OCR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickOcr);
            //
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(216, 24);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(52, 23);
            this.btBrowse.TabIndex = 4;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(3, 3);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(67, 17);
            this.rbFile.TabIndex = 5;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "From file:";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(3, 26);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(207, 20);
            this.tbFile.TabIndex = 6;
            // 
            // rbInput
            // 
            this.rbInput.AutoSize = true;
            this.rbInput.Location = new System.Drawing.Point(3, 52);
            this.rbInput.Name = "rbInput";
            this.rbInput.Size = new System.Drawing.Size(72, 17);
            this.rbInput.TabIndex = 5;
            this.rbInput.TabStop = true;
            this.rbInput.Text = "Input text:";
            this.rbInput.UseVisualStyleBackColor = true;
            this.rbInput.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 316);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.rbInput);
            this.Controls.Add(this.rbFile);
            this.Controls.Add(this.button_SearchItemsByTag);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btRnd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.RadioButton rbInput;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

