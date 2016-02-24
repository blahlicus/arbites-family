namespace ArbitesR
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
            this.cbAllLayers = new System.Windows.Forms.CheckBox();
            this.lLayerCount = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbAllLayers
            // 
            this.cbAllLayers.AutoSize = true;
            this.cbAllLayers.Location = new System.Drawing.Point(121, 7);
            this.cbAllLayers.Name = "cbAllLayers";
            this.cbAllLayers.Size = new System.Drawing.Size(107, 17);
            this.cbAllLayers.TabIndex = 0;
            this.cbAllLayers.Text = "Apply to all layers";
            this.cbAllLayers.UseVisualStyleBackColor = true;
            // 
            // lLayerCount
            // 
            this.lLayerCount.AutoSize = true;
            this.lLayerCount.Location = new System.Drawing.Point(3, 8);
            this.lLayerCount.Name = "lLayerCount";
            this.lLayerCount.Size = new System.Drawing.Size(35, 13);
            this.lLayerCount.TabIndex = 1;
            this.lLayerCount.Text = "label1";
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(550, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 2;
            this.btDelete.Text = "Delete Layer";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // UCLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lLayerCount);
            this.Controls.Add(this.cbAllLayers);
            this.Name = "UCLayer";
            this.Size = new System.Drawing.Size(628, 475);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAllLayers;
        private System.Windows.Forms.Label lLayerCount;
        private System.Windows.Forms.Button btDelete;
    }
}
