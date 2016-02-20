namespace ArbitesR
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
            this.btSave = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btAddLayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(1266, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Save Layout";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(1347, 3);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "Load Layout";
            this.btLoad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keyboard Type: Terminus Mini BLAHBLAH";
            // 
            // flpMain
            // 
            this.flpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMain.AutoScroll = true;
            this.flpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpMain.Location = new System.Drawing.Point(6, 32);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1416, 542);
            this.flpMain.TabIndex = 4;
            this.flpMain.WrapContents = false;
            // 
            // btAddLayer
            // 
            this.btAddLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddLayer.Location = new System.Drawing.Point(6, 580);
            this.btAddLayer.Name = "btAddLayer";
            this.btAddLayer.Size = new System.Drawing.Size(1416, 23);
            this.btAddLayer.TabIndex = 5;
            this.btAddLayer.Text = "Add Layer";
            this.btAddLayer.UseVisualStyleBackColor = true;
            // 
            // UCBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btAddLayer);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btSave);
            this.Name = "UCBoard";
            this.Size = new System.Drawing.Size(1425, 606);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Button btAddLayer;
    }
}
