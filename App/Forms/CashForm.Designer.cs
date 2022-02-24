namespace App.Forms
{
    partial class CashForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudPayment = new System.Windows.Forms.NumericUpDown();
            this.btPay = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vul het betaalde bedrag in:";
            // 
            // nudPayment
            // 
            this.nudPayment.DecimalPlaces = 2;
            this.nudPayment.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudPayment.Location = new System.Drawing.Point(177, 128);
            this.nudPayment.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudPayment.Name = "nudPayment";
            this.nudPayment.Size = new System.Drawing.Size(242, 63);
            this.nudPayment.TabIndex = 1;
            // 
            // btPay
            // 
            this.btPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btPay.Location = new System.Drawing.Point(354, 285);
            this.btPay.Name = "btPay";
            this.btPay.Size = new System.Drawing.Size(188, 55);
            this.btPay.TabIndex = 4;
            this.btPay.Text = "Betalen";
            this.btPay.UseVisualStyleBackColor = true;
            this.btPay.Click += new System.EventHandler(this.btPay_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCancel.Location = new System.Drawing.Point(12, 285);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(188, 55);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Annuleren";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // CashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 353);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btPay);
            this.Controls.Add(this.nudPayment);
            this.Controls.Add(this.label1);
            this.Name = "CashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CashForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private NumericUpDown nudPayment;
        private Button btPay;
        private Button btCancel;
    }
}