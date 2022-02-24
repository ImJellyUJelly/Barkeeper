namespace App.Forms
{
    partial class TeruggaveForm
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
            this.lbAmount = new System.Windows.Forms.Label();
            this.btContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terug te geven aan de klant:";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbAmount.Location = new System.Drawing.Point(177, 128);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(247, 67);
            this.lbAmount.TabIndex = 1;
            this.lbAmount.Text = "lbAmount";
            // 
            // btContinue
            // 
            this.btContinue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btContinue.Location = new System.Drawing.Point(354, 286);
            this.btContinue.Name = "btContinue";
            this.btContinue.Size = new System.Drawing.Size(188, 55);
            this.btContinue.TabIndex = 3;
            this.btContinue.Text = "Doorgaan";
            this.btContinue.UseVisualStyleBackColor = true;
            this.btContinue.Click += new System.EventHandler(this.btContinue_Click);
            // 
            // TeruggaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 353);
            this.Controls.Add(this.btContinue);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.label1);
            this.Name = "TeruggaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeruggaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lbAmount;
        private Button btContinue;
    }
}