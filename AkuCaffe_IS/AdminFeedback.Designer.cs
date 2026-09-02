
namespace AkuCaffe_IS
{
    partial class AdminFeedback
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvFeedback = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblAvgFood = new System.Windows.Forms.Label();
            this.lblAvgClean = new System.Windows.Forms.Label();
            this.lblAvgSpeed = new System.Windows.Forms.Label();
            this.lblAvgStaff = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedback)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(311, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(215, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Feedback Report";
            // 
            // dgvFeedback
            // 
            this.dgvFeedback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeedback.Location = new System.Drawing.Point(28, 168);
            this.dgvFeedback.Name = "dgvFeedback";
            this.dgvFeedback.RowHeadersWidth = 62;
            this.dgvFeedback.RowTemplate.Height = 28;
            this.dgvFeedback.Size = new System.Drawing.Size(698, 286);
            this.dgvFeedback.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(38, 497);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 48);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblAvgFood
            // 
            this.lblAvgFood.AutoSize = true;
            this.lblAvgFood.ForeColor = System.Drawing.Color.Black;
            this.lblAvgFood.Location = new System.Drawing.Point(857, 195);
            this.lblAvgFood.Name = "lblAvgFood";
            this.lblAvgFood.Size = new System.Drawing.Size(81, 20);
            this.lblAvgFood.TabIndex = 3;
            this.lblAvgFood.Text = "Avg Food:";
            // 
            // lblAvgClean
            // 
            this.lblAvgClean.AutoSize = true;
            this.lblAvgClean.ForeColor = System.Drawing.Color.Black;
            this.lblAvgClean.Location = new System.Drawing.Point(857, 248);
            this.lblAvgClean.Name = "lblAvgClean";
            this.lblAvgClean.Size = new System.Drawing.Size(85, 20);
            this.lblAvgClean.TabIndex = 4;
            this.lblAvgClean.Text = "Avg Clean:";
            // 
            // lblAvgSpeed
            // 
            this.lblAvgSpeed.AutoSize = true;
            this.lblAvgSpeed.ForeColor = System.Drawing.Color.Black;
            this.lblAvgSpeed.Location = new System.Drawing.Point(857, 304);
            this.lblAvgSpeed.Name = "lblAvgSpeed";
            this.lblAvgSpeed.Size = new System.Drawing.Size(91, 20);
            this.lblAvgSpeed.TabIndex = 5;
            this.lblAvgSpeed.Text = "Avg Speed:";
            // 
            // lblAvgStaff
            // 
            this.lblAvgStaff.AutoSize = true;
            this.lblAvgStaff.ForeColor = System.Drawing.Color.Black;
            this.lblAvgStaff.Location = new System.Drawing.Point(857, 360);
            this.lblAvgStaff.Name = "lblAvgStaff";
            this.lblAvgStaff.Size = new System.Drawing.Size(79, 20);
            this.lblAvgStaff.TabIndex = 6;
            this.lblAvgStaff.Text = "Avg Staff:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(857, 416);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(123, 20);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total Feedback:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(795, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 286);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Average";
            // 
            // btnLogOut
            // 
            this.btnLogOut.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.Location = new System.Drawing.Point(948, 549);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(107, 54);
            this.btnLogOut.TabIndex = 9;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(818, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 54);
            this.button1.TabIndex = 10;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblAvgStaff);
            this.Controls.Add(this.lblAvgSpeed);
            this.Controls.Add(this.lblAvgClean);
            this.Controls.Add(this.lblAvgFood);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvFeedback);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "AdminFeedback";
            this.Text = "AdminFeedback";
            this.Load += new System.EventHandler(this.AdminFeedback_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvFeedback;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblAvgFood;
        private System.Windows.Forms.Label lblAvgClean;
        private System.Windows.Forms.Label lblAvgSpeed;
        private System.Windows.Forms.Label lblAvgStaff;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button button1;
    }
}