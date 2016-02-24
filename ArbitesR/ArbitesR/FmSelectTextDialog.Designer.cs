namespace ArbitesR
{
    partial class FmSelectTextDialog
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
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.lTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMain.Location = new System.Drawing.Point(15, 25);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(182, 215);
            this.flpMain.TabIndex = 3;
            this.flpMain.WrapContents = false;
            // 
            // lTip
            // 
            this.lTip.AutoSize = true;
            this.lTip.Location = new System.Drawing.Point(12, 9);
            this.lTip.Name = "lTip";
            this.lTip.Size = new System.Drawing.Size(101, 13);
            this.lTip.TabIndex = 2;
            this.lTip.Text = "Select a port below:";
            // 
            // FmSelectTextDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 248);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.lTip);
            this.Name = "FmSelectTextDialog";
            this.Text = "FmSelectTextDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Label lTip;
    }
}