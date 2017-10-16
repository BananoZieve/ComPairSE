namespace ComPairSE.UI
{
    partial class ReceiptPage
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
            this.receiptView1 = new ComPairSE.UI.ReceiptView();
            this.SuspendLayout();
            // 
            // receiptView1
            // 
            this.receiptView1.Location = new System.Drawing.Point(0, 27);
            this.receiptView1.Name = "receiptView1";
            this.receiptView1.Receipt = null;
            this.receiptView1.Size = new System.Drawing.Size(225, 333);
            this.receiptView1.TabIndex = 2;
            // 
            // ReceiptPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.receiptView1);
            this.Name = "ReceiptPage";
            this.Controls.SetChildIndex(this.receiptView1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ReceiptView receiptView1;
    }
}
