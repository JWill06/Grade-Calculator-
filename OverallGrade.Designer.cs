namespace GradeCalculator
{
    partial class OverallGrade
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lb_percentageOverall = new System.Windows.Forms.Label();
            this.lb_letterGradeOverall = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Overall Grade";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "Letter Grade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "Percentage:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lb_percentageOverall
            // 
            this.lb_percentageOverall.AutoSize = true;
            this.lb_percentageOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_percentageOverall.Location = new System.Drawing.Point(161, 94);
            this.lb_percentageOverall.Name = "lb_percentageOverall";
            this.lb_percentageOverall.Size = new System.Drawing.Size(46, 18);
            this.lb_percentageOverall.TabIndex = 26;
            this.lb_percentageOverall.Text = "label1";
            this.lb_percentageOverall.Visible = false;
            // 
            // lb_letterGradeOverall
            // 
            this.lb_letterGradeOverall.AutoSize = true;
            this.lb_letterGradeOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_letterGradeOverall.Location = new System.Drawing.Point(161, 133);
            this.lb_letterGradeOverall.Name = "lb_letterGradeOverall";
            this.lb_letterGradeOverall.Size = new System.Drawing.Size(46, 18);
            this.lb_letterGradeOverall.TabIndex = 27;
            this.lb_letterGradeOverall.Text = "label2";
            this.lb_letterGradeOverall.Visible = false;
            // 
            // OverallGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_letterGradeOverall);
            this.Controls.Add(this.lb_percentageOverall);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "OverallGrade";
            this.Size = new System.Drawing.Size(267, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lb_percentageOverall;
        private System.Windows.Forms.Label lb_letterGradeOverall;
    }
}
