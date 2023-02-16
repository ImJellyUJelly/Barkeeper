namespace App.Forms
{
    partial class BeheerderForm
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
            this.cbEvent = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvSessions = new System.Windows.Forms.ListView();
            this.Id = new System.Windows.Forms.ColumnHeader();
            this.startDate = new System.Windows.Forms.ColumnHeader();
            this.endDate = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEvent
            // 
            this.cbEvent.AutoSize = true;
            this.cbEvent.Location = new System.Drawing.Point(6, 26);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(150, 25);
            this.cbEvent.TabIndex = 0;
            this.cbEvent.Text = "Is een evenement";
            this.cbEvent.UseVisualStyleBackColor = true;
            this.cbEvent.Click += new System.EventHandler(this.cbEvent_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvSessions);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 217);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bestaande sessies";
            // 
            // lvSessions
            // 
            this.lvSessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.startDate,
            this.endDate});
            this.lvSessions.Location = new System.Drawing.Point(6, 22);
            this.lvSessions.Name = "lvSessions";
            this.lvSessions.Size = new System.Drawing.Size(431, 189);
            this.lvSessions.TabIndex = 0;
            this.lvSessions.UseCompatibleStateImageBehavior = false;
            this.lvSessions.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            // 
            // startDate
            // 
            this.startDate.Text = "Start datum";
            this.startDate.Width = 180;
            // 
            // endDate
            // 
            this.endDate.Text = "Eind datum";
            this.endDate.Width = 180;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEvent);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Huidige sessie";
            // 
            // BeheerderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 299);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BeheerderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sessie beheer";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox cbEvent;
        private GroupBox groupBox2;
        private ListView lvSessions;
        private ColumnHeader Id;
        private ColumnHeader startDate;
        private ColumnHeader endDate;
        private GroupBox groupBox1;
    }
}