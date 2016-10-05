namespace Arbites4
{
    partial class UCLayer
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
            this.lLayer = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lLayer
            // 
            this.lLayer.AutoSize = true;
            this.lLayer.Location = new System.Drawing.Point(3, 8);
            this.lLayer.Name = "lLayer";
            this.lLayer.Size = new System.Drawing.Size(35, 13);
            this.lLayer.TabIndex = 0;
            this.lLayer.Text = "lLayer";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Set All Layers";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // UCLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lLayer);
            this.Name = "UCLayer";
            this.Size = new System.Drawing.Size(1100, 455);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lLayer;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
