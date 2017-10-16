namespace ComPairSE.UI
{
    partial class ReceiptView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReceipt = new System.Windows.Forms.DataGridView();
            this.ColumnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbShop = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.AllowUserToAddRows = false;
            this.dgvReceipt.AllowUserToDeleteRows = false;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItem,
            this.ColumnPrice});
            this.dgvReceipt.Location = new System.Drawing.Point(3, 23);
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.ReadOnly = true;
            this.dgvReceipt.RowHeadersVisible = false;
            this.dgvReceipt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvReceipt.Size = new System.Drawing.Size(219, 280);
            this.dgvReceipt.TabIndex = 0;
            // 
            // ColumnItem
            // 
            this.ColumnItem.HeaderText = "Item";
            this.ColumnItem.Name = "ColumnItem";
            this.ColumnItem.ReadOnly = true;
            this.ColumnItem.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnItem.Width = 150;
            // 
            // ColumnPrice
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            this.ColumnPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPrice.Width = 66;
            // 
            // lbShop
            // 
            this.lbShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lbShop.Location = new System.Drawing.Point(0, 0);
            this.lbShop.Name = "lbShop";
            this.lbShop.Size = new System.Drawing.Size(225, 20);
            this.lbShop.TabIndex = 1;
            this.lbShop.Text = "label1";
            this.lbShop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 309);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(107, 312);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(34, 13);
            this.lbTotal.TabIndex = 1;
            this.lbTotal.Text = "Total:";
            // 
            // ReceiptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lbShop);
            this.Controls.Add(this.dgvReceipt);
            this.Name = "ReceiptView";
            this.Size = new System.Drawing.Size(225, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceipt;
        private System.Windows.Forms.Label lbShop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
    }
}
