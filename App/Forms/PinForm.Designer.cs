namespace App.Forms
{
    partial class PinForm
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
            this.btContinue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.nudPayment = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // btContinue
            // 
            this.btContinue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btContinue.Location = new System.Drawing.Point(309, 213);
            this.btContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btContinue.Name = "btContinue";
            this.btContinue.Size = new System.Drawing.Size(164, 41);
            this.btContinue.TabIndex = 6;
            this.btContinue.Text = "Doorgaan";
            this.btContinue.UseVisualStyleBackColor = true;
            this.btContinue.Click += new System.EventHandler(this.btContinue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(60, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Voer het bedrag in op het pin apparaat:";
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCancel.Location = new System.Drawing.Point(12, 213);
            this.btCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(164, 41);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Terug";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // nudPayment
            // 
            this.nudPayment.DecimalPlaces = 2;
            this.nudPayment.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudPayment.Location = new System.Drawing.Point(206, 109);
            this.nudPayment.Name = "nudPayment";
            this.nudPayment.Size = new System.Drawing.Size(117, 43);
            this.nudPayment.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(168, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "€";
            // 
            // PinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 265);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudPayment);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btContinue);
            this.Controls.Add(this.label1);
            this.Name = "PinForm";
            this.Text = "PinForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btContinue;
        private Label label1;
        private Button btCancel;
        private NumericUpDown nudPayment;
        private Label label2;
    }
}