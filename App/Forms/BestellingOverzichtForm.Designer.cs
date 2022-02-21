namespace App.Forms
{
    partial class BestellingOverzichtForm
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
            this.lvOrders = new System.Windows.Forms.ListView();
            this.chID = new System.Windows.Forms.ColumnHeader();
            this.chCustomerName = new System.Windows.Forms.ColumnHeader();
            this.chIsMember = new System.Windows.Forms.ColumnHeader();
            this.chOrderDate = new System.Windows.Forms.ColumnHeader();
            this.chIsPaid = new System.Windows.Forms.ColumnHeader();
            this.chIsFinished = new System.Windows.Forms.ColumnHeader();
            this.chProducts = new System.Windows.Forms.ColumnHeader();
            this.chComments = new System.Windows.Forms.ColumnHeader();
            this.btMergeOrders = new System.Windows.Forms.Button();
            this.btSplitOrder = new System.Windows.Forms.Button();
            this.btPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chCustomerName,
            this.chIsMember,
            this.chOrderDate,
            this.chIsPaid,
            this.chIsFinished,
            this.chProducts,
            this.chComments});
            this.lvOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.Location = new System.Drawing.Point(14, 107);
            this.lvOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(1126, 848);
            this.lvOrders.TabIndex = 0;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.SelectedIndexChanged += new System.EventHandler(this.lvOrders_SelectedIndexChanged);
            this.lvOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvOrders_KeyDown);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            // 
            // chCustomerName
            // 
            this.chCustomerName.Text = "Klantnaam";
            this.chCustomerName.Width = 180;
            // 
            // chIsMember
            // 
            this.chIsMember.Text = "Is lid?";
            this.chIsMember.Width = 80;
            // 
            // chOrderDate
            // 
            this.chOrderDate.Text = "Besteldatum";
            this.chOrderDate.Width = 150;
            // 
            // chIsPaid
            // 
            this.chIsPaid.Text = "Betaald?";
            this.chIsPaid.Width = 100;
            // 
            // chIsFinished
            // 
            this.chIsFinished.Text = "Afgerond?";
            this.chIsFinished.Width = 110;
            // 
            // chProducts
            // 
            this.chProducts.Text = "Aantal producten";
            this.chProducts.Width = 130;
            // 
            // chComments
            // 
            this.chComments.Text = "Opmerkingen";
            this.chComments.Width = 310;
            // 
            // btMergeOrders
            // 
            this.btMergeOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btMergeOrders.Location = new System.Drawing.Point(250, 5);
            this.btMergeOrders.Name = "btMergeOrders";
            this.btMergeOrders.Size = new System.Drawing.Size(112, 95);
            this.btMergeOrders.TabIndex = 1;
            this.btMergeOrders.Text = "Samen- voegen";
            this.btMergeOrders.UseVisualStyleBackColor = true;
            this.btMergeOrders.Click += new System.EventHandler(this.btMergeOrders_Click);
            // 
            // btSplitOrder
            // 
            this.btSplitOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSplitOrder.Location = new System.Drawing.Point(132, 5);
            this.btSplitOrder.Name = "btSplitOrder";
            this.btSplitOrder.Size = new System.Drawing.Size(112, 95);
            this.btSplitOrder.TabIndex = 2;
            this.btSplitOrder.Text = "Splitsen";
            this.btSplitOrder.UseVisualStyleBackColor = true;
            this.btSplitOrder.Click += new System.EventHandler(this.btSplitOrder_Click);
            // 
            // btPay
            // 
            this.btPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btPay.Location = new System.Drawing.Point(14, 5);
            this.btPay.Name = "btPay";
            this.btPay.Size = new System.Drawing.Size(112, 95);
            this.btPay.TabIndex = 3;
            this.btPay.Text = "Afrekenen";
            this.btPay.UseVisualStyleBackColor = true;
            this.btPay.Click += new System.EventHandler(this.button1_Click);
            // 
            // BestellingOverzichtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 972);
            this.Controls.Add(this.btPay);
            this.Controls.Add(this.btSplitOrder);
            this.Controls.Add(this.btMergeOrders);
            this.Controls.Add(this.lvOrders);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BestellingOverzichtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Overzicht bestellingen";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvOrders;
        private ColumnHeader chID;
        private ColumnHeader chCustomerName;
        private ColumnHeader chIsMember;
        private ColumnHeader chOrderDate;
        private ColumnHeader chProducts;
        private ColumnHeader chIsPaid;
        private Button btMergeOrders;
        private Button btSplitOrder;
        private ColumnHeader chComments;
        private ColumnHeader chIsFinished;
        private Button btPay;
    }
}