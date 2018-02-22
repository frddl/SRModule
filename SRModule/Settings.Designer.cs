namespace SRModule
{
    partial class Settings
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.N = new System.Windows.Forms.TextBox();
            this.K = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.scale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputBeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inputBlocks = new System.Windows.Forms.TextBox();
            this.inputSc = new System.Windows.Forms.TextBox();
            this.inputL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LpcP = new System.Windows.Forms.TextBox();
            this.liftMFCC = new System.Windows.Forms.CheckBox();
            this.msMFCC = new System.Windows.Forms.CheckBox();
            this.liftLPC = new System.Windows.Forms.CheckBox();
            this.msLPC = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.coefFIR = new System.Windows.Forms.TextBox();
            this.vad_panel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LifterPar = new System.Windows.Forms.TextBox();
            this.z1 = new System.Windows.Forms.TextBox();
            this.Z = new System.Windows.Forms.TextBox();
            this.fstart = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sample_rate = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.vad_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(24, 500);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(100, 23);
            this.ok.TabIndex = 12;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(355, 500);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // N
            // 
            this.N.Location = new System.Drawing.Point(25, 55);
            this.N.Name = "N";
            this.N.Size = new System.Drawing.Size(73, 20);
            this.N.TabIndex = 14;
            this.N.Text = "400";
            // 
            // K
            // 
            this.K.Location = new System.Drawing.Point(127, 55);
            this.K.Name = "K";
            this.K.Size = new System.Drawing.Size(73, 20);
            this.K.TabIndex = 15;
            this.K.Text = "160";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Frame Length";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Frame Step";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Scale";
            // 
            // scale
            // 
            this.scale.Location = new System.Drawing.Point(474, 306);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(73, 20);
            this.scale.TabIndex = 19;
            this.scale.Text = "5840";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "MFCC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(292, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "LPC";
            // 
            // inputBeta
            // 
            this.inputBeta.Location = new System.Drawing.Point(312, 44);
            this.inputBeta.Name = "inputBeta";
            this.inputBeta.Size = new System.Drawing.Size(34, 20);
            this.inputBeta.TabIndex = 27;
            this.inputBeta.Text = "0,8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Blocks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Scale";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "L";
            // 
            // inputBlocks
            // 
            this.inputBlocks.Location = new System.Drawing.Point(223, 44);
            this.inputBlocks.Name = "inputBlocks";
            this.inputBlocks.Size = new System.Drawing.Size(34, 20);
            this.inputBlocks.TabIndex = 21;
            this.inputBlocks.Text = "5";
            // 
            // inputSc
            // 
            this.inputSc.Location = new System.Drawing.Point(127, 44);
            this.inputSc.Name = "inputSc";
            this.inputSc.Size = new System.Drawing.Size(34, 20);
            this.inputSc.TabIndex = 22;
            this.inputSc.Text = "1000";
            // 
            // inputL
            // 
            this.inputL.Location = new System.Drawing.Point(39, 44);
            this.inputL.Name = "inputL";
            this.inputL.Size = new System.Drawing.Size(34, 20);
            this.inputL.TabIndex = 23;
            this.inputL.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Beta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(474, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "LpcP";
            // 
            // LpcP
            // 
            this.LpcP.Location = new System.Drawing.Point(477, 418);
            this.LpcP.Name = "LpcP";
            this.LpcP.Size = new System.Drawing.Size(64, 20);
            this.LpcP.TabIndex = 31;
            this.LpcP.Text = "12";
            // 
            // liftMFCC
            // 
            this.liftMFCC.AutoSize = true;
            this.liftMFCC.Location = new System.Drawing.Point(34, 160);
            this.liftMFCC.Name = "liftMFCC";
            this.liftMFCC.Size = new System.Drawing.Size(63, 17);
            this.liftMFCC.TabIndex = 38;
            this.liftMFCC.Text = "Liftering";
            this.liftMFCC.UseVisualStyleBackColor = true;
            // 
            // msMFCC
            // 
            this.msMFCC.AutoSize = true;
            this.msMFCC.Location = new System.Drawing.Point(34, 192);
            this.msMFCC.Name = "msMFCC";
            this.msMFCC.Size = new System.Drawing.Size(110, 17);
            this.msMFCC.TabIndex = 39;
            this.msMFCC.Text = "Mean Subtraction";
            this.msMFCC.UseVisualStyleBackColor = true;
            // 
            // liftLPC
            // 
            this.liftLPC.AutoSize = true;
            this.liftLPC.Location = new System.Drawing.Point(308, 160);
            this.liftLPC.Name = "liftLPC";
            this.liftLPC.Size = new System.Drawing.Size(63, 17);
            this.liftLPC.TabIndex = 38;
            this.liftLPC.Text = "Liftering";
            this.liftLPC.UseVisualStyleBackColor = true;
            // 
            // msLPC
            // 
            this.msLPC.AutoSize = true;
            this.msLPC.Location = new System.Drawing.Point(308, 192);
            this.msLPC.Name = "msLPC";
            this.msLPC.Size = new System.Drawing.Size(110, 17);
            this.msLPC.TabIndex = 39;
            this.msLPC.Text = "Mean Subtraction";
            this.msLPC.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 239);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "FIR Coef [0.95,1]";
            // 
            // coefFIR
            // 
            this.coefFIR.Location = new System.Drawing.Point(24, 255);
            this.coefFIR.Name = "coefFIR";
            this.coefFIR.Size = new System.Drawing.Size(100, 20);
            this.coefFIR.TabIndex = 41;
            this.coefFIR.Text = "0,97";
            // 
            // vad_panel
            // 
            this.vad_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vad_panel.Controls.Add(this.label16);
            this.vad_panel.Controls.Add(this.inputL);
            this.vad_panel.Controls.Add(this.inputSc);
            this.vad_panel.Controls.Add(this.inputBlocks);
            this.vad_panel.Controls.Add(this.label5);
            this.vad_panel.Controls.Add(this.label4);
            this.vad_panel.Controls.Add(this.label3);
            this.vad_panel.Controls.Add(this.label6);
            this.vad_panel.Controls.Add(this.inputBeta);
            this.vad_panel.Location = new System.Drawing.Point(24, 290);
            this.vad_panel.Name = "vad_panel";
            this.vad_panel.Size = new System.Drawing.Size(412, 84);
            this.vad_panel.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(7, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "VAD Parametrs";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(472, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Lifter Par";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(471, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "N of cepstral";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "N of channels";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(110, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "FStart";
            // 
            // LifterPar
            // 
            this.LifterPar.Location = new System.Drawing.Point(475, 461);
            this.LifterPar.Name = "LifterPar";
            this.LifterPar.Size = new System.Drawing.Size(73, 20);
            this.LifterPar.TabIndex = 41;
            this.LifterPar.Text = "13";
            // 
            // z1
            // 
            this.z1.Location = new System.Drawing.Point(474, 361);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(64, 20);
            this.z1.TabIndex = 40;
            this.z1.Text = "13";
            // 
            // Z
            // 
            this.Z.Location = new System.Drawing.Point(23, 55);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(54, 20);
            this.Z.TabIndex = 39;
            this.Z.Text = "24";
            // 
            // fstart
            // 
            this.fstart.Location = new System.Drawing.Point(113, 55);
            this.fstart.Name = "fstart";
            this.fstart.Size = new System.Drawing.Size(52, 20);
            this.fstart.TabIndex = 38;
            this.fstart.Text = "64";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.fstart);
            this.panel1.Controls.Add(this.Z);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(253, 389);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 91);
            this.panel1.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(7, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "MEL Filtering Parametrs";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.sample_rate);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.N);
            this.panel2.Controls.Add(this.K);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(24, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 91);
            this.panel2.TabIndex = 47;
            // 
            // sample_rate
            // 
            this.sample_rate.AutoSize = true;
            this.sample_rate.Location = new System.Drawing.Point(124, 10);
            this.sample_rate.Name = "sample_rate";
            this.sample_rate.Size = new System.Drawing.Size(55, 13);
            this.sample_rate.TabIndex = 19;
            this.sample_rate.Text = "some_text";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(7, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Framing Parametrs";
            // 
            // Settings
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(571, 535);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vad_panel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.coefFIR);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.msLPC);
            this.Controls.Add(this.msMFCC);
            this.Controls.Add(this.LifterPar);
            this.Controls.Add(this.liftLPC);
            this.Controls.Add(this.z1);
            this.Controls.Add(this.liftMFCC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LpcP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Location = new System.Drawing.Point(200, 0);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.vad_panel.ResumeLayout(false);
            this.vad_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox N;
        private System.Windows.Forms.TextBox K;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox scale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputBeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputBlocks;
        private System.Windows.Forms.TextBox inputSc;
        private System.Windows.Forms.TextBox inputL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox LpcP;
        private System.Windows.Forms.CheckBox liftMFCC;
        private System.Windows.Forms.CheckBox msMFCC;
        private System.Windows.Forms.CheckBox liftLPC;
        private System.Windows.Forms.CheckBox msLPC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox coefFIR;
        private System.Windows.Forms.Panel vad_panel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox LifterPar;
        private System.Windows.Forms.TextBox z1;
        private System.Windows.Forms.TextBox Z;
        private System.Windows.Forms.TextBox fstart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label sample_rate;
    }
}

