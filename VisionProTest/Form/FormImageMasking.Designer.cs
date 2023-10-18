namespace VisionProTest
{
    partial class FormImageMasking
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
            this.cogImageMaskingEditV2 = new Cognex.VisionPro.CogImageMaskEditV2();
            this.BtnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cogImageMaskingEditV2
            // 
            this.cogImageMaskingEditV2.Location = new System.Drawing.Point(0, 0);
            this.cogImageMaskingEditV2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cogImageMaskingEditV2.Name = "cogImageMaskingEditV2";
            this.cogImageMaskingEditV2.Size = new System.Drawing.Size(991, 750);
            this.cogImageMaskingEditV2.TabIndex = 0;
            // 
            // BtnApply
            // 
            this.BtnApply.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApply.Location = new System.Drawing.Point(414, 765);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(158, 38);
            this.BtnApply.TabIndex = 2;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // FormImageMasking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 815);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.cogImageMaskingEditV2);
            this.Name = "FormImageMasking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormImageMasking";
            this.Load += new System.EventHandler(this.FormImageMasking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Cognex.VisionPro.CogImageMaskEditV2 cogImageMaskingEditV2;
        private System.Windows.Forms.Button BtnApply;
    }
}