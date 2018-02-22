namespace SRModule
{
    partial class Recognition_Form
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
            this.ms_result = new System.Windows.Forms.Label();
            this.lpc_result = new System.Windows.Forms.Label();
            this.mfcc_result = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ms_result
            // 
            this.ms_result.AutoSize = true;
            this.ms_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ms_result.Location = new System.Drawing.Point(156, 171);
            this.ms_result.Name = "ms_result";
            this.ms_result.Size = new System.Drawing.Size(0, 20);
            this.ms_result.TabIndex = 28;
            // 
            // lpc_result
            // 
            this.lpc_result.AutoSize = true;
            this.lpc_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lpc_result.Location = new System.Drawing.Point(156, 137);
            this.lpc_result.Name = "lpc_result";
            this.lpc_result.Size = new System.Drawing.Size(0, 20);
            this.lpc_result.TabIndex = 29;
            // 
            // mfcc_result
            // 
            this.mfcc_result.AutoSize = true;
            this.mfcc_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mfcc_result.Location = new System.Drawing.Point(156, 103);
            this.mfcc_result.Name = "mfcc_result";
            this.mfcc_result.Size = new System.Drawing.Size(0, 20);
            this.mfcc_result.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(56, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Microsoft:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(55, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "LPC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(56, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "MFCC:";
            // 
            // Recognition_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 289);
            this.Controls.Add(this.ms_result);
            this.Controls.Add(this.lpc_result);
            this.Controls.Add(this.mfcc_result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Recognition_Form";
            this.Text = "Recognition_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label ms_result;
        public System.Windows.Forms.Label lpc_result;
        public System.Windows.Forms.Label mfcc_result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}