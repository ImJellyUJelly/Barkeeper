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
            this.chProducts = new System.Windows.Forms.ColumnHeader();
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
            this.chProducts});
            this.lvOrders.Location = new System.Drawing.Point(12, 80);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(619, 637);
            this.lvOrders.TabIndex = 0;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            // 
            // chCustomerName
            // 
            this.chCustomerName.Text = "Klantnaam";
            this.chCustomerName.Width = 150;
            // 
            // chIsMember
            // 
            this.chIsMember.Text = "Is lid?";
            // 
            // chOrderDate
            // 
            this.chOrderDate.Text = "Besteldatum";
            this.chOrderDate.Width = 150;
            // 
            // chIsPaid
            // 
            this.chIsPaid.Text = "Betaald?";
            // 
            // chProducts
            // 
            this.chProducts.Text = "Aantal producten";
            this.chProducts.Width = 100;
            // 
            // BestellingOverzichtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 729);
            this.Controls.Add(this.lvOrders);
            this.Name = "BestellingOverzichtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BestellingOverzichtForm";
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
    }
}