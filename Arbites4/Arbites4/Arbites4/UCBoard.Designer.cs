namespace Arbites4
{
    partial class UCBoard
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
            this.label1 = new System.Windows.Forms.Label();
            this.lKeyboardType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lMicrocontroller = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lLayers = new System.Windows.Forms.Label();
            this.btNewLayer = new System.Windows.Forms.Button();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keyboard Type:";
            // 
            // lKeyboardType
            // 
            this.lKeyboardType.AutoSize = true;
            this.lKeyboardType.Location = new System.Drawing.Point(94, 6);
            this.lKeyboardType.Name = "lKeyboardType";
            this.lKeyboardType.Size = new System.Drawing.Size(127, 13);
            this.lKeyboardType.TabIndex = 1;
            this.lKeyboardType.Text = "NANANANANANANANA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Microcontroller:";
            // 
            // lMicrocontroller
            // 
            this.lMicrocontroller.AutoSize = true;
            this.lMicrocontroller.Location = new System.Drawing.Point(312, 6);
            this.lMicrocontroller.Name = "lMicrocontroller";
            this.lMicrocontroller.Size = new System.Drawing.Size(127, 13);
            this.lMicrocontroller.TabIndex = 3;
            this.lMicrocontroller.Text = "NANANANANANANANA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Layers:";
            // 
            // lLayers
            // 
            this.lLayers.AutoSize = true;
            this.lLayers.Location = new System.Drawing.Point(492, 6);
            this.lLayers.Name = "lLayers";
            this.lLayers.Size = new System.Drawing.Size(40, 13);
            this.lLayers.TabIndex = 5;
            this.lLayers.Text = "lLayers";
            // 
            // btNewLayer
            // 
            this.btNewLayer.Location = new System.Drawing.Point(538, 1);
            this.btNewLayer.Name = "btNewLayer";
            this.btNewLayer.Size = new System.Drawing.Size(75, 23);
            this.btNewLayer.TabIndex = 6;
            this.btNewLayer.Text = "New Layer";
            this.btNewLayer.UseVisualStyleBackColor = true;
            this.btNewLayer.Click += new System.EventHandler(this.btNewLayer_Click);
            // 
            // flpMain
            // 
            this.flpMain.Location = new System.Drawing.Point(3, 28);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1062, 606);
            this.flpMain.TabIndex = 7;
            // 
            // UCBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.btNewLayer);
            this.Controls.Add(this.lLayers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lMicrocontroller);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lKeyboardType);
            this.Controls.Add(this.label1);
            this.Name = "UCBoard";
            this.Size = new System.Drawing.Size(1068, 637);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lKeyboardType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lMicrocontroller;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lLayers;
        private System.Windows.Forms.Button btNewLayer;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}
