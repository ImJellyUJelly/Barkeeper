namespace App.Forms
{
    partial class SplitBestellingForm
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
            this.cbIsFinished = new System.Windows.Forms.CheckBox();
            this.cbIsPaid = new System.Windows.Forms.CheckBox();
            this.cbIsMember = new System.Windows.Forms.CheckBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.lbCustomerName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSplitOrder = new System.Windows.Forms.Button();
            this.lbCustomer1 = new System.Windows.Forms.Label();
            this.tbCustomer1 = new System.Windows.Forms.TextBox();
            this.lbPrice1 = new System.Windows.Forms.Label();
            this.nudCustomer1 = new System.Windows.Forms.NumericUpDown();
            this.lbEuro1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudCustomer2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btAddCustomer = new System.Windows.Forms.Button();
            this.cbCustomerName1 = new System.Windows.Forms.ComboBox();
            this.cbCustomerName2 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomer2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIsFinished);
            this.groupBox1.Controls.Add(this.cbIsPaid);
            this.groupBox1.Controls.Add(this.cbIsMember);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.lbId);
            this.groupBox1.Controls.Add(this.lbCustomerName);
            this.groupBox1.Controls.Add(this.lbPrice);
            this.groupBox1.Controls.Add(this.lbOrderDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1128, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Originele bestelling";
            // 
            // cbIsFinished
            // 
            this.cbIsFinished.AutoSize = true;
            this.cbIsFinished.Enabled = false;
            this.cbIsFinished.Location = new System.Drawing.Point(253, 159);
            this.cbIsFinished.Name = "cbIsFinished";
            this.cbIsFinished.Size = new System.Drawing.Size(132, 32);
            this.cbIsFinished.TabIndex = 15;
            this.cbIsFinished.Text = "Is afgerond";
            this.cbIsFinished.UseVisualStyleBackColor = true;
            // 
            // cbIsPaid
            // 
            this.cbIsPaid.AutoSize = true;
            this.cbIsPaid.Enabled = false;
            this.cbIsPaid.Location = new System.Drawing.Point(129, 159);
            this.cbIsPaid.Name = "cbIsPaid";
            this.cbIsPaid.Size = new System.Drawing.Size(118, 32);
            this.cbIsPaid.TabIndex = 14;
            this.cbIsPaid.Text = "Is betaald";
            this.cbIsPaid.UseVisualStyleBackColor = true;
            // 
            // cbIsMember
            // 
            this.cbIsMember.AutoSize = true;
            this.cbIsMember.Enabled = false;
            this.cbIsMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbIsMember.Location = new System.Drawing.Point(6, 159);
            this.cbIsMember.Name = "cbIsMember";
            this.cbIsMember.Size = new System.Drawing.Size(110, 32);
            this.cbIsMember.TabIndex = 13;
            this.cbIsMember.Text = "Is een lid";
            this.cbIsMember.UseVisualStyleBackColor = true;
            // 
            // tbComment
            // 
            this.tbComment.Enabled = false;
            this.tbComment.Location = new System.Drawing.Point(667, 64);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(454, 129);
            this.tbComment.TabIndex = 12;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(136, 29);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(46, 28);
            this.lbId.TabIndex = 8;
            this.lbId.Text = "lbId";
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.AutoSize = true;
            this.lbCustomerName.Location = new System.Drawing.Point(136, 59);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(165, 28);
            this.lbCustomerName.TabIndex = 7;
            this.lbCustomerName.Text = "lbCustomerName";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(136, 115);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(71, 28);
            this.lbPrice.TabIndex = 6;
            this.lbPrice.Text = "lbPrice";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(136, 85);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(121, 28);
            this.lbOrderDate.TabIndex = 5;
            this.lbOrderDate.Text = "lbOrderDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Opmerkingen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prijs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Besteldatum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naam:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // btSplitOrder
            // 
            this.btSplitOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSplitOrder.Location = new System.Drawing.Point(1007, 220);
            this.btSplitOrder.Name = "btSplitOrder";
            this.btSplitOrder.Size = new System.Drawing.Size(133, 85);
            this.btSplitOrder.TabIndex = 0;
            this.btSplitOrder.Text = "Bestelling splitsen";
            this.btSplitOrder.UseVisualStyleBackColor = true;
            this.btSplitOrder.Click += new System.EventHandler(this.btSplitOrder_Click);
            // 
            // lbCustomer1
            // 
            this.lbCustomer1.AutoSize = true;
            this.lbCustomer1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbCustomer1.Location = new System.Drawing.Point(18, 232);
            this.lbCustomer1.Name = "lbCustomer1";
            this.lbCustomer1.Size = new System.Drawing.Size(68, 28);
            this.lbCustomer1.TabIndex = 3;
            this.lbCustomer1.Text = "Naam:";
            // 
            // tbCustomer1
            // 
            this.tbCustomer1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCustomer1.Location = new System.Drawing.Point(91, 229);
            this.tbCustomer1.Name = "tbCustomer1";
            this.tbCustomer1.Size = new System.Drawing.Size(0, 34);
            this.tbCustomer1.TabIndex = 1;
            // 
            // lbPrice1
            // 
            this.lbPrice1.AutoSize = true;
            this.lbPrice1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPrice1.Location = new System.Drawing.Point(653, 232);
            this.lbPrice1.Name = "lbPrice1";
            this.lbPrice1.Size = new System.Drawing.Size(52, 28);
            this.lbPrice1.TabIndex = 5;
            this.lbPrice1.Text = "Prijs:";
            // 
            // nudCustomer1
            // 
            this.nudCustomer1.DecimalPlaces = 2;
            this.nudCustomer1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudCustomer1.Location = new System.Drawing.Point(738, 232);
            this.nudCustomer1.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCustomer1.Name = "nudCustomer1";
            this.nudCustomer1.Size = new System.Drawing.Size(101, 34);
            this.nudCustomer1.TabIndex = 10;
            // 
            // lbEuro1
            // 
            this.lbEuro1.AutoSize = true;
            this.lbEuro1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbEuro1.Location = new System.Drawing.Point(711, 232);
            this.lbEuro1.Name = "lbEuro1";
            this.lbEuro1.Size = new System.Drawing.Size(23, 28);
            this.lbEuro1.TabIndex = 7;
            this.lbEuro1.Text = "€";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(711, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 28);
            this.label8.TabIndex = 12;
            this.label8.Text = "€";
            // 
            // nudCustomer2
            // 
            this.nudCustomer2.DecimalPlaces = 2;
            this.nudCustomer2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudCustomer2.Location = new System.Drawing.Point(738, 272);
            this.nudCustomer2.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCustomer2.Name = "nudCustomer2";
            this.nudCustomer2.Size = new System.Drawing.Size(101, 34);
            this.nudCustomer2.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(653, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 28);
            this.label9.TabIndex = 10;
            this.label9.Text = "Prijs:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(18, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 28);
            this.label10.TabIndex = 8;
            this.label10.Text = "Naam:";
            // 
            // btAddCustomer
            // 
            this.btAddCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddCustomer.Location = new System.Drawing.Point(1007, 311);
            this.btAddCustomer.Name = "btAddCustomer";
            this.btAddCustomer.Size = new System.Drawing.Size(133, 85);
            this.btAddCustomer.TabIndex = 0;
            this.btAddCustomer.Text = "Nog iemand toevoegen";
            this.btAddCustomer.UseVisualStyleBackColor = true;
            this.btAddCustomer.Click += new System.EventHandler(this.btAddCustomer_Click);
            // 
            // cbCustomerName1
            // 
            this.cbCustomerName1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCustomerName1.FormattingEnabled = true;
            this.cbCustomerName1.Location = new System.Drawing.Point(91, 229);
            this.cbCustomerName1.Name = "cbCustomerName1";
            this.cbCustomerName1.Size = new System.Drawing.Size(527, 36);
            this.cbCustomerName1.TabIndex = 13;
            // 
            // cbCustomerName2
            // 
            this.cbCustomerName2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCustomerName2.FormattingEnabled = true;
            this.cbCustomerName2.Location = new System.Drawing.Point(91, 269);
            this.cbCustomerName2.Name = "cbCustomerName2";
            this.cbCustomerName2.Size = new System.Drawing.Size(527, 36);
            this.cbCustomerName2.TabIndex = 14;
            // 
            // SplitBestellingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 411);
            this.Controls.Add(this.cbCustomerName2);
            this.Controls.Add(this.cbCustomerName1);
            this.Controls.Add(this.btAddCustomer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudCustomer2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbEuro1);
            this.Controls.Add(this.nudCustomer1);
            this.Controls.Add(this.lbPrice1);
            this.Controls.Add(this.tbCustomer1);
            this.Controls.Add(this.lbCustomer1);
            this.Controls.Add(this.btSplitOrder);
            this.Controls.Add(this.groupBox1);
            this.Name = "SplitBestellingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splits bestelling";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private CheckBox cbIsFinished;
        private CheckBox cbIsPaid;
        private CheckBox cbIsMember;
        private TextBox tbComment;
        private Label lbId;
        private Label lbCustomerName;
        private Label lbPrice;
        private Label lbOrderDate;
        private Label label5;
        private Button btSplitOrder;
        private Label lbCustomer1;
        private TextBox tbCustomer1;
        private Label lbPrice1;
        private NumericUpDown nudCustomer1;
        private Label lbEuro1;
        private Label label8;
        private NumericUpDown nudCustomer2;
        private Label label9;
        private Label label10;
        private Button btAddCustomer;
        private ComboBox cbCustomerName1;
        private ComboBox cbCustomerName2;
    }
}