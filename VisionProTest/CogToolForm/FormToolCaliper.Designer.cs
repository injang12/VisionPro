namespace VisionProTest
{
    partial class FormToolCaliper
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
            this.label_ToolTitle_Pattern = new System.Windows.Forms.Label();
            this.comboPolarity = new System.Windows.Forms.ComboBox();
            this.txtFilterSize = new System.Windows.Forms.TextBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnFind = new System.Windows.Forms.Button();
            this.BtnSearchRegion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPolarity2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEdgePairWidth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ModelToolName = new System.Windows.Forms.TextBox();
            this.DoubleEdged = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_ToolTitle_Pattern
            // 
            this.label_ToolTitle_Pattern.AutoSize = true;
            this.label_ToolTitle_Pattern.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ToolTitle_Pattern.Location = new System.Drawing.Point(4, 5);
            this.label_ToolTitle_Pattern.Name = "label_ToolTitle_Pattern";
            this.label_ToolTitle_Pattern.Size = new System.Drawing.Size(204, 18);
            this.label_ToolTitle_Pattern.TabIndex = 60;
            this.label_ToolTitle_Pattern.Text = "Caliper Tool Configuration";
            this.label_ToolTitle_Pattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboPolarity
            // 
            this.comboPolarity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPolarity.FormattingEnabled = true;
            this.comboPolarity.Items.AddRange(new object[] {
            "Dark to Light",
            "Light to Dark",
            "Don\'t Care"});
            this.comboPolarity.Location = new System.Drawing.Point(98, 120);
            this.comboPolarity.Name = "comboPolarity";
            this.comboPolarity.Size = new System.Drawing.Size(110, 24);
            this.comboPolarity.TabIndex = 59;
            this.comboPolarity.Text = "Don\'t Care";
            // 
            // txtFilterSize
            // 
            this.txtFilterSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterSize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterSize.Location = new System.Drawing.Point(98, 169);
            this.txtFilterSize.Name = "txtFilterSize";
            this.txtFilterSize.Size = new System.Drawing.Size(111, 23);
            this.txtFilterSize.TabIndex = 58;
            this.txtFilterSize.Text = "2";
            this.txtFilterSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThreshold
            // 
            this.txtThreshold.BackColor = System.Drawing.Color.White;
            this.txtThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThreshold.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThreshold.Location = new System.Drawing.Point(98, 145);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(111, 23);
            this.txtThreshold.TabIndex = 57;
            this.txtThreshold.Text = "5";
            this.txtThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnApply
            // 
            this.BtnApply.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApply.Location = new System.Drawing.Point(473, 265);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(110, 45);
            this.BtnApply.TabIndex = 56;
            this.BtnApply.Text = "Save";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFind.Location = new System.Drawing.Point(473, 215);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(110, 45);
            this.BtnFind.TabIndex = 55;
            this.BtnFind.Text = "Find";
            this.BtnFind.UseVisualStyleBackColor = true;
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // BtnSearchRegion
            // 
            this.BtnSearchRegion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchRegion.Location = new System.Drawing.Point(473, 165);
            this.BtnSearchRegion.Name = "BtnSearchRegion";
            this.BtnSearchRegion.Size = new System.Drawing.Size(110, 45);
            this.BtnSearchRegion.TabIndex = 54;
            this.BtnSearchRegion.Text = "Search Region";
            this.BtnSearchRegion.UseVisualStyleBackColor = true;
            this.BtnSearchRegion.Click += new System.EventHandler(this.BtnSearchRegion_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 53;
            this.label3.Text = "Filter Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 52;
            this.label1.Text = "Threshold";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 51;
            this.label2.Text = "Polarity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 65;
            this.label4.Text = "Caliper Mod";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboPolarity2
            // 
            this.comboPolarity2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPolarity2.FormattingEnabled = true;
            this.comboPolarity2.Items.AddRange(new object[] {
            "Dark to Light",
            "Light to Dark",
            "Don\'t Care"});
            this.comboPolarity2.Location = new System.Drawing.Point(214, 120);
            this.comboPolarity2.Name = "comboPolarity2";
            this.comboPolarity2.Size = new System.Drawing.Size(110, 24);
            this.comboPolarity2.TabIndex = 68;
            this.comboPolarity2.Text = "Don\'t Care";
            this.comboPolarity2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Edge 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "Edge 2";
            this.label6.Visible = false;
            // 
            // txtEdgePairWidth
            // 
            this.txtEdgePairWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdgePairWidth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdgePairWidth.Location = new System.Drawing.Point(133, 193);
            this.txtEdgePairWidth.Name = "txtEdgePairWidth";
            this.txtEdgePairWidth.Size = new System.Drawing.Size(76, 23);
            this.txtEdgePairWidth.TabIndex = 72;
            this.txtEdgePairWidth.Text = "10";
            this.txtEdgePairWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEdgePairWidth.Visible = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DimGray;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(20, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 23);
            this.label11.TabIndex = 71;
            this.label11.Text = "Edge Pair Width";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(445, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 96;
            this.label7.Text = "Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModelToolName
            // 
            this.ModelToolName.Location = new System.Drawing.Point(493, 5);
            this.ModelToolName.Name = "ModelToolName";
            this.ModelToolName.Size = new System.Drawing.Size(100, 21);
            this.ModelToolName.TabIndex = 95;
            // 
            // DoubleEdged
            // 
            this.DoubleEdged.AutoSize = true;
            this.DoubleEdged.Location = new System.Drawing.Point(23, 85);
            this.DoubleEdged.Name = "DoubleEdged";
            this.DoubleEdged.Size = new System.Drawing.Size(96, 16);
            this.DoubleEdged.TabIndex = 97;
            this.DoubleEdged.Text = "Double Edge";
            this.DoubleEdged.UseVisualStyleBackColor = true;
            this.DoubleEdged.CheckedChanged += new System.EventHandler(this.DoubleEdged_CheckedChanged);
            // 
            // FormToolCaliper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.ControlBox = false;
            this.Controls.Add(this.DoubleEdged);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ModelToolName);
            this.Controls.Add(this.txtEdgePairWidth);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboPolarity2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_ToolTitle_Pattern);
            this.Controls.Add(this.comboPolarity);
            this.Controls.Add(this.txtFilterSize);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.BtnFind);
            this.Controls.Add(this.BtnSearchRegion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormToolCaliper";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormToolCaliper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_ToolTitle_Pattern;
        private System.Windows.Forms.ComboBox comboPolarity;
        private System.Windows.Forms.TextBox txtFilterSize;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.Button BtnSearchRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboPolarity2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEdgePairWidth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ModelToolName;
        private System.Windows.Forms.CheckBox DoubleEdged;
    }
}