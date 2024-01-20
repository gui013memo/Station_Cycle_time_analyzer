namespace Station_Cycle_time_analyzer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GetRawLogs_btn = new Button();
            textBox1 = new TextBox();
            monthCalendar1 = new MonthCalendar();
            SuspendLayout();
            // 
            // GetRawLogs_btn
            // 
            GetRawLogs_btn.Location = new Point(78, 357);
            GetRawLogs_btn.Name = "GetRawLogs_btn";
            GetRawLogs_btn.Size = new Size(165, 81);
            GetRawLogs_btn.TabIndex = 0;
            GetRawLogs_btn.Text = "Get raw logs";
            GetRawLogs_btn.UseVisualStyleBackColor = true;
            GetRawLogs_btn.Click += GetRawLogs_btn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(0, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(798, 351);
            textBox1.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(29, 76);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(monthCalendar1);
            Controls.Add(textBox1);
            Controls.Add(GetRawLogs_btn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GetRawLogs_btn;
        private TextBox textBox1;
        private MonthCalendar monthCalendar1;
    }
}