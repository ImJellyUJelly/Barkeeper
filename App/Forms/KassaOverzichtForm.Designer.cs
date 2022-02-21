﻿namespace App.Forms
{
    partial class KassaOverzichtForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIsMember = new System.Windows.Forms.CheckBox();
            this.btDeleteProduct = new System.Windows.Forms.Button();
            this.lbOrderPrice = new System.Windows.Forms.Label();
            this.btPay = new System.Windows.Forms.Button();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestellingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestellingOverzichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klantenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overzichtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overzichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.btSelectCustomer = new System.Windows.Forms.Button();
            this.pProducts = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbIsMember);
            this.groupBox2.Controls.Add(this.btDeleteProduct);
            this.groupBox2.Controls.Add(this.lbOrderPrice);
            this.groupBox2.Controls.Add(this.btPay);
            this.groupBox2.Controls.Add(this.lvProducts);
            this.groupBox2.Controls.Add(this.lbOrderDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(14, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(424, 785);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bestelling info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(191, 740);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 37);
            this.label5.TabIndex = 10;
            this.label5.Text = "Totaal:";
            // 
            // cbIsMember
            // 
            this.cbIsMember.AutoSize = true;
            this.cbIsMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbIsMember.Location = new System.Drawing.Point(13, 134);
            this.cbIsMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbIsMember.Name = "cbIsMember";
            this.cbIsMember.Size = new System.Drawing.Size(117, 32);
            this.cbIsMember.TabIndex = 9;
            this.cbIsMember.Text = "VZOD Lid";
            this.cbIsMember.UseVisualStyleBackColor = true;
            this.cbIsMember.Click += new System.EventHandler(this.cbIsMember_Click);
            // 
            // btDeleteProduct
            // 
            this.btDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btDeleteProduct.Location = new System.Drawing.Point(7, 728);
            this.btDeleteProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDeleteProduct.Name = "btDeleteProduct";
            this.btDeleteProduct.Size = new System.Drawing.Size(42, 49);
            this.btDeleteProduct.TabIndex = 8;
            this.btDeleteProduct.Text = "-";
            this.btDeleteProduct.UseVisualStyleBackColor = true;
            this.btDeleteProduct.Click += new System.EventHandler(this.btDeleteProduct_Click);
            // 
            // lbOrderPrice
            // 
            this.lbOrderPrice.AutoSize = true;
            this.lbOrderPrice.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbOrderPrice.Location = new System.Drawing.Point(291, 737);
            this.lbOrderPrice.Name = "lbOrderPrice";
            this.lbOrderPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbOrderPrice.Size = new System.Drawing.Size(97, 41);
            this.lbOrderPrice.TabIndex = 7;
            this.lbOrderPrice.Text = "€ 0,00";
            // 
            // btPay
            // 
            this.btPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btPay.Location = new System.Drawing.Point(304, 150);
            this.btPay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btPay.Name = "btPay";
            this.btPay.Size = new System.Drawing.Size(114, 49);
            this.btPay.TabIndex = 5;
            this.btPay.Text = "Afrekenen";
            this.btPay.UseVisualStyleBackColor = true;
            this.btPay.Click += new System.EventHandler(this.btPay_Click);
            // 
            // lvProducts
            // 
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvProducts.Location = new System.Drawing.Point(7, 207);
            this.lvProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvProducts.MultiSelect = false;
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(411, 512);
            this.lvProducts.TabIndex = 6;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.SelectedIndexChanged += new System.EventHandler(this.lvProducts_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Prijs";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum";
            this.columnHeader3.Width = 175;
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbOrderDate.Location = new System.Drawing.Point(142, 92);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(121, 28);
            this.lbOrderDate.TabIndex = 5;
            this.lbOrderDate.Text = "lbOrderDate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(7, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bestel datum:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbName.Location = new System.Drawing.Point(7, 53);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(176, 28);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "lbCustomerName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Naam:";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDate.Location = new System.Drawing.Point(888, 37);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(70, 28);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "lbDate";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bestellingenToolStripMenuItem,
            this.klantenToolStripMenuItem,
            this.productenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1152, 30);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.fileToolStripMenuItem.Text = "Bestand";
            // 
            // bestellingenToolStripMenuItem
            // 
            this.bestellingenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestellingOverzichtToolStripMenuItem});
            this.bestellingenToolStripMenuItem.Name = "bestellingenToolStripMenuItem";
            this.bestellingenToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.bestellingenToolStripMenuItem.Text = "Bestellingen";
            // 
            // bestellingOverzichtToolStripMenuItem
            // 
            this.bestellingOverzichtToolStripMenuItem.Name = "bestellingOverzichtToolStripMenuItem";
            this.bestellingOverzichtToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.bestellingOverzichtToolStripMenuItem.Text = "Overzicht";
            this.bestellingOverzichtToolStripMenuItem.Click += new System.EventHandler(this.bestellingOverzichtToolStripMenuItem_Click);
            // 
            // klantenToolStripMenuItem
            // 
            this.klantenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overzichtToolStripMenuItem1});
            this.klantenToolStripMenuItem.Name = "klantenToolStripMenuItem";
            this.klantenToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.klantenToolStripMenuItem.Text = "Klanten";
            // 
            // overzichtToolStripMenuItem1
            // 
            this.overzichtToolStripMenuItem1.Enabled = false;
            this.overzichtToolStripMenuItem1.Name = "overzichtToolStripMenuItem1";
            this.overzichtToolStripMenuItem1.Size = new System.Drawing.Size(154, 26);
            this.overzichtToolStripMenuItem1.Text = "Overzicht";
            // 
            // productenToolStripMenuItem
            // 
            this.productenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overzichtToolStripMenuItem});
            this.productenToolStripMenuItem.Name = "productenToolStripMenuItem";
            this.productenToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.productenToolStripMenuItem.Text = "Producten";
            // 
            // overzichtToolStripMenuItem
            // 
            this.overzichtToolStripMenuItem.Enabled = false;
            this.overzichtToolStripMenuItem.Name = "overzichtToolStripMenuItem";
            this.overzichtToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.overzichtToolStripMenuItem.Text = "Overzicht";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(813, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Zoek klant of maak aan:";
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(14, 68);
            this.cbCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(424, 36);
            this.cbCustomerName.TabIndex = 14;
            this.cbCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCustomerName_KeyDown);
            // 
            // btSelectCustomer
            // 
            this.btSelectCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSelectCustomer.Location = new System.Drawing.Point(318, 112);
            this.btSelectCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSelectCustomer.Name = "btSelectCustomer";
            this.btSelectCustomer.Size = new System.Drawing.Size(114, 48);
            this.btSelectCustomer.TabIndex = 15;
            this.btSelectCustomer.Text = "Selecteer";
            this.btSelectCustomer.UseVisualStyleBackColor = true;
            this.btSelectCustomer.Click += new System.EventHandler(this.btSelectCustomer_Click);
            // 
            // pProducts
            // 
            this.pProducts.Location = new System.Drawing.Point(444, 69);
            this.pProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pProducts.Name = "pProducts";
            this.pProducts.Size = new System.Drawing.Size(700, 888);
            this.pProducts.TabIndex = 16;
            // 
            // KassaOverzichtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 972);
            this.Controls.Add(this.pProducts);
            this.Controls.Add(this.btSelectCustomer);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.cbCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KassaOverzichtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kassa";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox groupBox2;
        private Label lbDate;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem productenToolStripMenuItem;
        private ToolStripMenuItem bestellingenToolStripMenuItem;
        private Label lbOrderDate;
        private Label label3;
        private Label lbName;
        private Label label2;
        private Label label1;
        private Button btPay;
        private ListView lvProducts;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label lbOrderPrice;
        private Button btDeleteProduct;
        private Label label4;
        private ComboBox cbCustomerName;
        private Button btSelectCustomer;
        private ToolStripMenuItem overzichtToolStripMenuItem;
        private ToolStripMenuItem bestellingOverzichtToolStripMenuItem;
        private ToolStripMenuItem klantenToolStripMenuItem;
        private ToolStripMenuItem overzichtToolStripMenuItem1;
        private Panel pProducts;
        private CheckBox cbIsMember;
        private Label label5;
        private ColumnHeader columnHeader3;
    }
}