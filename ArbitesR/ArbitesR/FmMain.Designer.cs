namespace ArbitesR
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spcEditLayout = new System.Windows.Forms.SplitContainer();
            this.lPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btUpload = new System.Windows.Forms.Button();
            this.btSelectCom = new System.Windows.Forms.Button();
            this.btSelectDevice = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcEditLayout)).BeginInit();
            this.spcEditLayout.Panel1.SuspendLayout();
            this.spcEditLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 572);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.spcEditLayout);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Edit Layout";
            // 
            // spcEditLayout
            // 
            this.spcEditLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcEditLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcEditLayout.IsSplitterFixed = true;
            this.spcEditLayout.Location = new System.Drawing.Point(3, 3);
            this.spcEditLayout.Name = "spcEditLayout";
            this.spcEditLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcEditLayout.Panel1
            // 
            this.spcEditLayout.Panel1.Controls.Add(this.lPort);
            this.spcEditLayout.Panel1.Controls.Add(this.label1);
            this.spcEditLayout.Panel1.Controls.Add(this.btUpload);
            this.spcEditLayout.Panel1.Controls.Add(this.btSelectCom);
            this.spcEditLayout.Panel1.Controls.Add(this.btSelectDevice);
            this.spcEditLayout.Size = new System.Drawing.Size(994, 540);
            this.spcEditLayout.SplitterDistance = 40;
            this.spcEditLayout.SplitterWidth = 1;
            this.spcEditLayout.TabIndex = 0;
            // 
            // lPort
            // 
            this.lPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(695, 8);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(28, 13);
            this.lPort.TabIndex = 4;
            this.lPort.Text = "lPort";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected Port:";
            // 
            // btUpload
            // 
            this.btUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpload.Location = new System.Drawing.Point(914, 3);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(75, 23);
            this.btUpload.TabIndex = 2;
            this.btUpload.Text = "Upload";
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // btSelectCom
            // 
            this.btSelectCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectCom.Location = new System.Drawing.Point(809, 3);
            this.btSelectCom.Name = "btSelectCom";
            this.btSelectCom.Size = new System.Drawing.Size(99, 23);
            this.btSelectCom.TabIndex = 1;
            this.btSelectCom.Text = "Select Port";
            this.btSelectCom.UseVisualStyleBackColor = true;
            this.btSelectCom.Click += new System.EventHandler(this.btSelectCom_Click);
            // 
            // btSelectDevice
            // 
            this.btSelectDevice.Location = new System.Drawing.Point(5, 3);
            this.btSelectDevice.Name = "btSelectDevice";
            this.btSelectDevice.Size = new System.Drawing.Size(99, 23);
            this.btSelectDevice.TabIndex = 0;
            this.btSelectDevice.Text = "Select Device";
            this.btSelectDevice.UseVisualStyleBackColor = true;
            this.btSelectDevice.Click += new System.EventHandler(this.btSelectDevice_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create Keyboard";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1000, 546);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Animus Builder";
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 572);
            this.Controls.Add(this.tabControl1);
            this.Name = "FmMain";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.spcEditLayout.Panel1.ResumeLayout(false);
            this.spcEditLayout.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcEditLayout)).EndInit();
            this.spcEditLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer spcEditLayout;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.Button btSelectCom;
        private System.Windows.Forms.Button btSelectDevice;
    }
}

