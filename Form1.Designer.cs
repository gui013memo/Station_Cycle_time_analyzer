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
            ExportCSV_btn = new Button();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // GetRawLogs_btn
            // 
            GetRawLogs_btn.Location = new Point(21, 215);
            GetRawLogs_btn.Name = "GetRawLogs_btn";
            GetRawLogs_btn.Size = new Size(115, 81);
            GetRawLogs_btn.TabIndex = 0;
            GetRawLogs_btn.Text = "Get raw logs";
            GetRawLogs_btn.UseVisualStyleBackColor = true;
            GetRawLogs_btn.Click += GetRawLogs_btn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 141);
            textBox1.TabIndex = 1;
            // 
            // ExportCSV_btn
            // 
            ExportCSV_btn.Location = new Point(208, 215);
            ExportCSV_btn.Name = "ExportCSV_btn";
            ExportCSV_btn.Size = new Size(115, 81);
            ExportCSV_btn.TabIndex = 2;
            ExportCSV_btn.Text = "Export CSV";
            ExportCSV_btn.UseVisualStyleBackColor = true;
            ExportCSV_btn.Click += ExportCSV_btn_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 173);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(321, 27);
            textBox2.TabIndex = 3;
            textBox2.Text = "OP20M1";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 317);
            Controls.Add(textBox2);
            Controls.Add(ExportCSV_btn);
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
        private Button ExportCSV_btn;
        private TextBox textBox2;
    }
}