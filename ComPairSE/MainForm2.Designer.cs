namespace ComPairSE
{
    partial class MainForm2
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
            this.scanPage1 = new ComPairSE.UI.ScanPage();
            this.receiptPage1 = new ComPairSE.UI.ReceiptPage();
            this.homePage1 = new ComPairSE.UI.HomePage();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.btScan = new System.Windows.Forms.Button();
            this.searchPage1 = new ComPairSE.UI.SearchPage();
            this.cartPage1 = new ComPairSE.UI.CartPage();
            this.homePage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanPage1
            // 
            this.scanPage1.AllowDrop = true;
            this.scanPage1.DataManager = null;
            this.scanPage1.Location = new System.Drawing.Point(0, 0);
            this.scanPage1.MaximumSize = new System.Drawing.Size(225, 400);
            this.scanPage1.MinimumSize = new System.Drawing.Size(225, 400);
            this.scanPage1.Name = "scanPage1";
            this.scanPage1.NextPage = this.receiptPage1;
            this.scanPage1.NextText = "Read >";
            this.scanPage1.PreviousPage = this.homePage1;
            this.scanPage1.PreviousText = "< Home";
            this.scanPage1.Size = new System.Drawing.Size(225, 400);
            this.scanPage1.TabIndex = 1;
            this.scanPage1.Text = "scanPage1";
            this.scanPage1.Visible = false;
            // 
            // receiptPage1
            // 
            this.receiptPage1.Location = new System.Drawing.Point(0, 0);
            this.receiptPage1.MaximumSize = new System.Drawing.Size(225, 400);
            this.receiptPage1.MinimumSize = new System.Drawing.Size(225, 400);
            this.receiptPage1.Name = "receiptPage1";
            this.receiptPage1.NextText = "Next >";
            this.receiptPage1.PreviousPage = this.scanPage1;
            this.receiptPage1.PreviousText = "< Scan";
            this.receiptPage1.Receipt = null;
            this.receiptPage1.Size = new System.Drawing.Size(225, 400);
            this.receiptPage1.TabIndex = 3;
            this.receiptPage1.Text = "receiptPage1";
            this.receiptPage1.Visible = false;
            // 
            // homePage1
            // 
            this.homePage1.BrowsePage = null;
            this.homePage1.Controls.Add(this.btBrowse);
            this.homePage1.Controls.Add(this.btCreate);
            this.homePage1.Controls.Add(this.btScan);
            this.homePage1.Location = new System.Drawing.Point(0, 0);
            this.homePage1.MaximumSize = new System.Drawing.Size(225, 400);
            this.homePage1.MinimumSize = new System.Drawing.Size(225, 400);
            this.homePage1.Name = "homePage1";
            this.homePage1.NextText = "Next >";
            this.homePage1.PreviousText = "< Previous";
            this.homePage1.ScanPage = null;
            this.homePage1.SearchPage = null;
            this.homePage1.Size = new System.Drawing.Size(225, 400);
            this.homePage1.TabIndex = 0;
            this.homePage1.Text = "homePage1";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(62, 218);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(100, 23);
            this.btBrowse.TabIndex = 3;
            this.btBrowse.Text = "Browse Receipts";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(62, 189);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(100, 23);
            this.btCreate.TabIndex = 4;
            this.btCreate.Text = "Create a Receipt";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(62, 160);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(100, 23);
            this.btScan.TabIndex = 5;
            this.btScan.Text = "Scan receipt";
            this.btScan.UseVisualStyleBackColor = true;
            this.btScan.Click += new System.EventHandler(this.btScan_Click);
            // 
            // searchPage1
            // 
            this.searchPage1.DataManager = null;
            this.searchPage1.Location = new System.Drawing.Point(0, 0);
            this.searchPage1.MaximumSize = new System.Drawing.Size(225, 400);
            this.searchPage1.MinimumSize = new System.Drawing.Size(225, 400);
            this.searchPage1.Name = "searchPage1";
            this.searchPage1.NextPage = this.cartPage1;
            this.searchPage1.NextText = "Cart >";
            this.searchPage1.PreviousPage = this.homePage1;
            this.searchPage1.PreviousText = "< Home";
            this.searchPage1.Size = new System.Drawing.Size(225, 400);
            this.searchPage1.TabIndex = 2;
            this.searchPage1.Text = "searchPage1";
            this.searchPage1.Visible = false;
            // 
            // cartPage1
            // 
            this.cartPage1.Location = new System.Drawing.Point(0, 0);
            this.cartPage1.MaximumSize = new System.Drawing.Size(225, 400);
            this.cartPage1.MinimumSize = new System.Drawing.Size(225, 400);
            this.cartPage1.Name = "cartPage1";
            this.cartPage1.NextText = "Next >";
            this.cartPage1.PreviousPage = this.searchPage1;
            this.cartPage1.PreviousText = "< Search";
            this.cartPage1.Size = new System.Drawing.Size(225, 400);
            this.cartPage1.TabIndex = 3;
            this.cartPage1.Text = "cartPage1";
            this.cartPage1.Visible = false;
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 400);
            this.Controls.Add(this.homePage1);
            this.Controls.Add(this.cartPage1);
            this.Controls.Add(this.searchPage1);
            this.Controls.Add(this.scanPage1);
            this.Controls.Add(this.receiptPage1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm2";
            this.Text = "MainForm2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm2_FormClosing);
            this.homePage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UI.ScanPage scanPage1;
        private UI.SearchPage searchPage1;
        private UI.CartPage cartPage1;
        private UI.HomePage homePage1;
        private UI.ReceiptPage receiptPage1;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btScan;
    }
}