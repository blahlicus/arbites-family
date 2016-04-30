namespace Arbites4
{
    partial class FmMain
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
            this.test = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.flpOSwitches = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.nudx = new System.Windows.Forms.NumericUpDown();
            this.nudy = new System.Windows.Forms.NumericUpDown();
            this.nudz = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudz)).BeginInit();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(12, 9);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(29, 13);
            this.test.TabIndex = 0;
            this.test.Text = "Start";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Begin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Command:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "uniqueksetkey";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(689, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pMain
            // 
            this.pMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMain.Location = new System.Drawing.Point(13, 40);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1471, 447);
            this.pMain.TabIndex = 5;
            // 
            // flpOSwitches
            // 
            this.flpOSwitches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpOSwitches.AutoScroll = true;
            this.flpOSwitches.Location = new System.Drawing.Point(12, 493);
            this.flpOSwitches.Name = "flpOSwitches";
            this.flpOSwitches.Size = new System.Drawing.Size(1472, 215);
            this.flpOSwitches.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12"});
            this.comboBox1.Location = new System.Drawing.Point(770, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(978, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(897, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nudx
            // 
            this.nudx.Location = new System.Drawing.Point(527, 7);
            this.nudx.Name = "nudx";
            this.nudx.Size = new System.Drawing.Size(48, 20);
            this.nudx.TabIndex = 10;
            this.nudx.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // nudy
            // 
            this.nudy.Location = new System.Drawing.Point(581, 7);
            this.nudy.Name = "nudy";
            this.nudy.Size = new System.Drawing.Size(48, 20);
            this.nudy.TabIndex = 11;
            this.nudy.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudz
            // 
            this.nudz.Location = new System.Drawing.Point(635, 7);
            this.nudz.Name = "nudz";
            this.nudz.Size = new System.Drawing.Size(48, 20);
            this.nudz.TabIndex = 12;
            this.nudz.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 720);
            this.Controls.Add(this.nudz);
            this.Controls.Add(this.nudy);
            this.Controls.Add(this.nudx);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.flpOSwitches);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.test);
            this.KeyPreview = true;
            this.Name = "FmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FmMain_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nudx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.FlowLayoutPanel flpOSwitches;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown nudx;
        private System.Windows.Forms.NumericUpDown nudy;
        private System.Windows.Forms.NumericUpDown nudz;
    }
}

