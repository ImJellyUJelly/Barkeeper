namespace App.Forms
{
    partial class AfrekenForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.cbIsMember = new System.Windows.Forms.CheckBox();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbCustomerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btFive = new System.Windows.Forms.Button();
            this.btTen = new System.Windows.Forms.Button();
            this.btTwenty = new System.Windows.Forms.Button();
            this.btFifty = new System.Windows.Forms.Button();
            this.btCash = new System.Windows.Forms.Button();
            this.btPin = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lvProducts);
            this.groupBox1.Controls.Add(this.cbIsMember);
            this.groupBox1.Controls.Add(this.tbComments);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbOrderDate);
            this.groupBox1.Controls.Add(this.lbCustomerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(507, 527);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPrice.Location = new System.Drawing.Point(409, 61);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(70, 25);
            this.lbPrice.TabIndex = 18;
            this.lbPrice.Text = "lbPrice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Prijs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Producten:";
            // 
            // lvProducts
            // 
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvProducts.Location = new System.Drawing.Point(5, 225);
            this.lvProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(496, 299);
            this.lvProducts.TabIndex = 15;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Prijs";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum toegevoegd";
            this.columnHeader3.Width = 225;
            // 
            // cbIsMember
            // 
            this.cbIsMember.AutoSize = true;
            this.cbIsMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbIsMember.Location = new System.Drawing.Point(5, 62);
            this.cbIsMember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIsMember.Name = "cbIsMember";
            this.cbIsMember.Size = new System.Drawing.Size(90, 25);
            this.cbIsMember.TabIndex = 14;
            this.cbIsMember.Text = "Is een lid";
            this.cbIsMember.UseVisualStyleBackColor = true;
            this.cbIsMember.CheckedChanged += new System.EventHandler(this.cbIsMember_CheckedChanged);
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(5, 111);
            this.tbComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(496, 60);
            this.tbComments.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Opmerkingen:";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(144, 38);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(96, 21);
            this.lbOrderDate.TabIndex = 3;
            this.lbOrderDate.Text = "lbOrderDate";
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.AutoSize = true;
            this.lbCustomerName.Location = new System.Drawing.Point(144, 17);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(133, 21);
            this.lbCustomerName.TabIndex = 2;
            this.lbCustomerName.Text = "lbCustomerName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Besteldatum:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klantnaam:";
            // 
            // btFive
            // 
            this.btFive.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btFive.Location = new System.Drawing.Point(764, 9);
            this.btFive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btFive.Name = "btFive";
            this.btFive.Size = new System.Drawing.Size(234, 80);
            this.btFive.TabIndex = 1;
            this.btFive.Text = "€ 5,-";
            this.btFive.UseVisualStyleBackColor = true;
            this.btFive.Click += new System.EventHandler(this.btFive_Click);
            // 
            // btTen
            // 
            this.btTen.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btTen.Location = new System.Drawing.Point(764, 94);
            this.btTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btTen.Name = "btTen";
            this.btTen.Size = new System.Drawing.Size(234, 80);
            this.btTen.TabIndex = 2;
            this.btTen.Text = "€ 10,-";
            this.btTen.UseVisualStyleBackColor = true;
            this.btTen.Click += new System.EventHandler(this.btTen_Click);
            // 
            // btTwenty
            // 
            this.btTwenty.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btTwenty.Location = new System.Drawing.Point(764, 178);
            this.btTwenty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btTwenty.Name = "btTwenty";
            this.btTwenty.Size = new System.Drawing.Size(234, 80);
            this.btTwenty.TabIndex = 3;
            this.btTwenty.Text = "€ 20,-";
            this.btTwenty.UseVisualStyleBackColor = true;
            this.btTwenty.Click += new System.EventHandler(this.btTwenty_Click);
            // 
            // btFifty
            // 
            this.btFifty.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btFifty.Location = new System.Drawing.Point(762, 262);
            this.btFifty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btFifty.Name = "btFifty";
            this.btFifty.Size = new System.Drawing.Size(234, 80);
            this.btFifty.TabIndex = 4;
            this.btFifty.Text = "€ 50,-";
            this.btFifty.UseVisualStyleBackColor = true;
            this.btFifty.Click += new System.EventHandler(this.btFifty_Click);
            // 
            // btCash
            // 
            this.btCash.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCash.Location = new System.Drawing.Point(764, 348);
            this.btCash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCash.Name = "btCash";
            this.btCash.Size = new System.Drawing.Size(234, 80);
            this.btCash.TabIndex = 5;
            this.btCash.Text = "Contant";
            this.btCash.UseVisualStyleBackColor = true;
            this.btCash.Click += new System.EventHandler(this.btCash_Click);
            // 
            // btPin
            // 
            this.btPin.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btPin.Location = new System.Drawing.Point(764, 433);
            this.btPin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btPin.Name = "btPin";
            this.btPin.Size = new System.Drawing.Size(234, 80);
            this.btPin.TabIndex = 6;
            this.btPin.Text = "Pinnen";
            this.btPin.UseVisualStyleBackColor = true;
            this.btPin.Click += new System.EventHandler(this.btPin_Click);
            // 
            // AfrekenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 545);
            this.Controls.Add(this.btPin);
            this.Controls.Add(this.btCash);
            this.Controls.Add(this.btFifty);
            this.Controls.Add(this.btTwenty);
            this.Controls.Add(this.btTen);
            this.Controls.Add(this.btFive);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AfrekenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bestelling afrekenen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label lbOrderDate;
        private Label lbCustomerName;
        private Label label2;
        private Label label1;
        private TextBox tbComments;
        private Label label3;
        private Label lbPrice;
        private Label label5;
        private Label label4;
        private ListView lvProducts;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private CheckBox cbIsMember;
        private Button btFive;
        private Button btTen;
        private Button btTwenty;
        private Button btFifty;
        private Button btCash;
        private Button btPin;
    }
}