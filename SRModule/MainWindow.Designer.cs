namespace SRModule
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.open = new System.Windows.Forms.Button();
            this.play2 = new System.Windows.Forms.Button();
            this.stop_play = new System.Windows.Forms.Button();
            this.record = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.inputList = new System.Windows.Forms.ComboBox();
            this.inputFormat = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.play3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.extract_button = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.inputName = new System.Windows.Forms.TextBox();
            this.recording_timer = new System.Windows.Forms.Timer(this.components);
            this.time_label = new System.Windows.Forms.Label();
            this.radio_checklist = new System.Windows.Forms.RadioButton();
            this.radio_digits = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mfcc_result = new System.Windows.Forms.Label();
            this.lpc_result = new System.Windows.Forms.Label();
            this.microResultLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.radio_sosna_checklist = new System.Windows.Forms.RadioButton();
            this.button9 = new System.Windows.Forms.Button();
            this.open_command_list = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.stream_record = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.calibrate_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(23, 210);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(73, 23);
            this.open.TabIndex = 5;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // play2
            // 
            this.play2.Location = new System.Drawing.Point(323, 296);
            this.play2.Name = "play2";
            this.play2.Size = new System.Drawing.Size(129, 23);
            this.play2.TabIndex = 7;
            this.play2.Text = "Play";
            this.play2.UseVisualStyleBackColor = true;
            this.play2.Click += new System.EventHandler(this.play2_Click);
            // 
            // stop_play
            // 
            this.stop_play.Location = new System.Drawing.Point(517, 296);
            this.stop_play.Name = "stop_play";
            this.stop_play.Size = new System.Drawing.Size(129, 23);
            this.stop_play.TabIndex = 8;
            this.stop_play.Text = "Stop";
            this.stop_play.UseVisualStyleBackColor = true;
            this.stop_play.Click += new System.EventHandler(this.stop_play_Click);
            // 
            // record
            // 
            this.record.Location = new System.Drawing.Point(28, 64);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(71, 23);
            this.record.TabIndex = 1;
            this.record.Text = "Record";
            this.record.UseVisualStyleBackColor = true;
            this.record.Click += new System.EventHandler(this.record_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(184, 64);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(79, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // inputList
            // 
            this.inputList.FormattingEnabled = true;
            this.inputList.Location = new System.Drawing.Point(29, 138);
            this.inputList.Name = "inputList";
            this.inputList.Size = new System.Drawing.Size(234, 21);
            this.inputList.TabIndex = 2;
            // 
            // inputFormat
            // 
            this.inputFormat.FormattingEnabled = true;
            this.inputFormat.Location = new System.Drawing.Point(29, 102);
            this.inputFormat.Name = "inputFormat";
            this.inputFormat.Size = new System.Drawing.Size(234, 21);
            this.inputFormat.TabIndex = 9;
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            this.chart1.Location = new System.Drawing.Point(323, 29);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(527, 96);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            this.chart2.Location = new System.Drawing.Point(323, 184);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(527, 97);
            this.chart2.TabIndex = 12;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.exit_Click);
            // 
            // chart3
            // 
            chartArea9.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea9);
            this.chart3.Location = new System.Drawing.Point(323, 345);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(527, 97);
            this.chart3.TabIndex = 12;
            this.chart3.Text = "chart2";
            this.chart3.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(517, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.stop_play_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(323, 138);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Play";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.play1_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(517, 456);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.stop_play_Click);
            // 
            // play3
            // 
            this.play3.Location = new System.Drawing.Point(323, 456);
            this.play3.Name = "play3";
            this.play3.Size = new System.Drawing.Size(129, 23);
            this.play3.TabIndex = 7;
            this.play3.Text = "Play";
            this.play3.UseVisualStyleBackColor = true;
            this.play3.Click += new System.EventHandler(this.play3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // extract_button
            // 
            this.extract_button.Location = new System.Drawing.Point(102, 210);
            this.extract_button.Name = "extract_button";
            this.extract_button.Size = new System.Drawing.Size(73, 23);
            this.extract_button.TabIndex = 17;
            this.extract_button.Text = "Recognize";
            this.extract_button.UseVisualStyleBackColor = true;
            this.extract_button.Click += new System.EventHandler(this.extract_button_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(105, 64);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(73, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Play";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.play1_Click);
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(29, 29);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(234, 20);
            this.inputName.TabIndex = 19;
            this.inputName.Text = "temp";
            // 
            // recording_timer
            // 
            this.recording_timer.Tick += new System.EventHandler(this.recording_timer_Tick);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(35, 179);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(28, 13);
            this.time_label.TabIndex = 20;
            this.time_label.Text = "0:00";
            // 
            // radio_checklist
            // 
            this.radio_checklist.AutoSize = true;
            this.radio_checklist.Location = new System.Drawing.Point(706, 302);
            this.radio_checklist.Name = "radio_checklist";
            this.radio_checklist.Size = new System.Drawing.Size(68, 17);
            this.radio_checklist.TabIndex = 21;
            this.radio_checklist.Text = "Checklist";
            this.radio_checklist.UseVisualStyleBackColor = true;
            this.radio_checklist.Visible = false;
            this.radio_checklist.MouseHover += new System.EventHandler(this.listCommands);
            // 
            // radio_digits
            // 
            this.radio_digits.AutoSize = true;
            this.radio_digits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_digits.Location = new System.Drawing.Point(190, 294);
            this.radio_digits.Name = "radio_digits";
            this.radio_digits.Size = new System.Drawing.Size(107, 24);
            this.radio_digits.TabIndex = 22;
            this.radio_digits.Text = "Azeri Digits";
            this.radio_digits.UseVisualStyleBackColor = true;
            this.radio_digits.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "MFCC:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "LPC:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Microsoft:";
            this.label3.Visible = false;
            // 
            // mfcc_result
            // 
            this.mfcc_result.AutoSize = true;
            this.mfcc_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mfcc_result.Location = new System.Drawing.Point(126, 345);
            this.mfcc_result.Name = "mfcc_result";
            this.mfcc_result.Size = new System.Drawing.Size(0, 17);
            this.mfcc_result.TabIndex = 24;
            this.mfcc_result.Visible = false;
            // 
            // lpc_result
            // 
            this.lpc_result.AutoSize = true;
            this.lpc_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lpc_result.Location = new System.Drawing.Point(126, 379);
            this.lpc_result.Name = "lpc_result";
            this.lpc_result.Size = new System.Drawing.Size(0, 17);
            this.lpc_result.TabIndex = 24;
            this.lpc_result.Visible = false;
            // 
            // microResultLabel
            // 
            this.microResultLabel.AutoSize = true;
            this.microResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.microResultLabel.Location = new System.Drawing.Point(126, 413);
            this.microResultLabel.Name = "microResultLabel";
            this.microResultLabel.Size = new System.Drawing.Size(0, 17);
            this.microResultLabel.TabIndex = 24;
            this.microResultLabel.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(386, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "Cut Files";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.Cut_Files);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(517, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 26;
            this.button8.Text = "Delete Files";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.Delete_Files);
            // 
            // radio_sosna_checklist
            // 
            this.radio_sosna_checklist.AutoSize = true;
            this.radio_sosna_checklist.Checked = true;
            this.radio_sosna_checklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_sosna_checklist.Location = new System.Drawing.Point(23, 295);
            this.radio_sosna_checklist.Name = "radio_sosna_checklist";
            this.radio_sosna_checklist.Size = new System.Drawing.Size(149, 24);
            this.radio_sosna_checklist.TabIndex = 27;
            this.radio_sosna_checklist.TabStop = true;
            this.radio_sosna_checklist.Text = "Cessna Checklist";
            this.radio_sosna_checklist.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(647, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 25;
            this.button9.Text = "Extract Files";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.ExtractFiles);
            // 
            // open_command_list
            // 
            this.open_command_list.Location = new System.Drawing.Point(23, 339);
            this.open_command_list.Name = "open_command_list";
            this.open_command_list.Size = new System.Drawing.Size(103, 23);
            this.open_command_list.TabIndex = 28;
            this.open_command_list.Text = "Show Commands";
            this.open_command_list.UseVisualStyleBackColor = true;
            this.open_command_list.Click += new System.EventHandler(this.open_command_list_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(242, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 23);
            this.button10.TabIndex = 29;
            this.button10.Text = "Define Length";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // stream_record
            // 
            this.stream_record.Location = new System.Drawing.Point(23, 249);
            this.stream_record.Name = "stream_record";
            this.stream_record.Size = new System.Drawing.Size(75, 23);
            this.stream_record.TabIndex = 30;
            this.stream_record.Text = "Stream Record";
            this.stream_record.UseVisualStyleBackColor = true;
            this.stream_record.Click += new System.EventHandler(this.stream_record_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(105, 249);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 31;
            this.button11.Text = "Stop Stream";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // calibrate_button
            // 
            this.calibrate_button.Location = new System.Drawing.Point(190, 249);
            this.calibrate_button.Name = "calibrate_button";
            this.calibrate_button.Size = new System.Drawing.Size(75, 23);
            this.calibrate_button.TabIndex = 32;
            this.calibrate_button.Tag = "Calibrate";
            this.calibrate_button.Text = "Calibrate";
            this.calibrate_button.UseVisualStyleBackColor = true;
            this.calibrate_button.Click += new System.EventHandler(this.calibrate_button_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 502);
            this.Controls.Add(this.calibrate_button);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.stream_record);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.open_command_list);
            this.Controls.Add(this.radio_sosna_checklist);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.microResultLabel);
            this.Controls.Add(this.lpc_result);
            this.Controls.Add(this.mfcc_result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radio_digits);
            this.Controls.Add(this.radio_checklist);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.extract_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.inputFormat);
            this.Controls.Add(this.inputList);
            this.Controls.Add(this.open);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.play3);
            this.Controls.Add(this.play2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.record);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.stop_play);
            this.Name = "MainWindow";
            this.Text = "SRModule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button play2;
        private System.Windows.Forms.Button stop_play;
        private System.Windows.Forms.Button record;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.ComboBox inputList;
        private System.Windows.Forms.ComboBox inputFormat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button play3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button extract_button;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Timer recording_timer;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.RadioButton radio_checklist;
        private System.Windows.Forms.RadioButton radio_digits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label mfcc_result;
        private System.Windows.Forms.Label lpc_result;
        private System.Windows.Forms.Label microResultLabel;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RadioButton radio_sosna_checklist;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button open_command_list;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button stream_record;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button calibrate_button;
    }
}
