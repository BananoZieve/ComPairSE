namespace ComPairSEBack.UI
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
            this.receiptView = new ComPairSEBack.UI.ReceiptView();
            this.SuspendLayout();
            // 
            // receiptView1
            // 
            this.receiptView.Location = new System.Drawing.Point(0, 27);
            this.receiptView.Name = "receiptView1";
            this.receiptView.Receipt = null;
            this.receiptView.Size = new System.Drawing.Size(225, 333);
            this.receiptView.TabIndex = 2;
            // 
            // ReceiptPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.receiptView);
            this.Name = "ReceiptPage";
            this.Controls.SetChildIndex(this.receiptView, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ReceiptView receiptView;
    }
}
