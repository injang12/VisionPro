namespace VisionProTest
{
    partial class FormToolPattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToolPattern));
            this.label_ToolTitle_Pattern = new System.Windows.Forms.Label();
            this.cogDisplay_Pattern = new Cognex.VisionPro.Display.CogDisplay();
            this.BtnMasking = new System.Windows.Forms.Button();
            this.BtnTrain = new System.Windows.Forms.Button();
            this.BtnTrainRegion = new System.Windows.Forms.Button();
            this.txtScaleHigh = new System.Windows.Forms.TextBox();
            this.txtScaleLow = new System.Windows.Forms.TextBox();
            this.txtAngleHigh = new System.Windows.Forms.TextBox();
            this.txtAngleLow = new System.Windows.Forms.TextBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHighSensitivity = new System.Windows.Forms.CheckBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnFind = new System.Windows.Forms.Button();
            this.BtnSearchRegion = new System.Windows.Forms.Button();
            this.txtApprox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ModelToolName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Pattern)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ToolTitle_Pattern
            // 
            this.label_ToolTitle_Pattern.AutoSize = true;
            this.label_ToolTitle_Pattern.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ToolTitle_Pattern.Location = new System.Drawing.Point(5, 5);
            this.label_ToolTitle_Pattern.Name = "label_ToolTitle_Pattern";
            this.label_ToolTitle_Pattern.Size = new System.Drawing.Size(104, 18);
            this.label_ToolTitle_Pattern.TabIndex = 5;
            this.label_ToolTitle_Pattern.Text = "Pattern Tool ";
            this.label_ToolTitle_Pattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cogDisplay_Pattern
            // 
            this.cogDisplay_Pattern.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Pattern.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay_Pattern.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay_Pattern.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay_Pattern.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay_Pattern.DoubleTapZoomCycleLength = 2;
            this.cogDisplay_Pattern.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay_Pattern.Location = new System.Drawing.Point(9, 32);
            this.cogDisplay_Pattern.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay_Pattern.MouseWheelSensitivity = 1D;
            this.cogDisplay_Pattern.Name = "cogDisplay_Pattern";
            this.cogDisplay_Pattern.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay_Pattern.OcxState")));
            this.cogDisplay_Pattern.Size = new System.Drawing.Size(348, 306);
            this.cogDisplay_Pattern.TabIndex = 55;
            // 
            // BtnMasking
            // 
            this.BtnMasking.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMasking.Location = new System.Drawing.Point(505, 218);
            this.BtnMasking.Name = "BtnMasking";
            this.BtnMasking.Size = new System.Drawing.Size(86, 26);
            this.BtnMasking.TabIndex = 73;
            this.BtnMasking.Text = "Masking";
            this.BtnMasking.UseVisualStyleBackColor = true;
            this.BtnMasking.Click += new System.EventHandler(this.BtnMasking_Click);
            // 
            // BtnTrain
            // 
            this.BtnTrain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTrain.Location = new System.Drawing.Point(402, 245);
            this.BtnTrain.Name = "BtnTrain";
            this.BtnTrain.Size = new System.Drawing.Size(189, 26);
            this.BtnTrain.TabIndex = 71;
            this.BtnTrain.Text = "Train";
            this.BtnTrain.UseVisualStyleBackColor = true;
            this.BtnTrain.Click += new System.EventHandler(this.BtnTrain_Click);
            // 
            // BtnTrainRegion
            // 
            this.BtnTrainRegion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTrainRegion.Location = new System.Drawing.Point(402, 218);
            this.BtnTrainRegion.Name = "BtnTrainRegion";
            this.BtnTrainRegion.Size = new System.Drawing.Size(103, 26);
            this.BtnTrainRegion.TabIndex = 70;
            this.BtnTrainRegion.Text = "Train Region";
            this.BtnTrainRegion.UseVisualStyleBackColor = true;
            this.BtnTrainRegion.Click += new System.EventHandler(this.BtnTrainRegion_Click);
            // 
            // txtScaleHigh
            // 
            this.txtScaleHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScaleHigh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScaleHigh.Location = new System.Drawing.Point(538, 118);
            this.txtScaleHigh.Name = "txtScaleHigh";
            this.txtScaleHigh.Size = new System.Drawing.Size(55, 22);
            this.txtScaleHigh.TabIndex = 83;
            this.txtScaleHigh.Text = "1.0";
            this.txtScaleHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtScaleLow
            // 
            this.txtScaleLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScaleLow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScaleLow.Location = new System.Drawing.Point(482, 118);
            this.txtScaleLow.Name = "txtScaleLow";
            this.txtScaleLow.Size = new System.Drawing.Size(55, 22);
            this.txtScaleLow.TabIndex = 82;
            this.txtScaleLow.Text = "1.0";
            this.txtScaleLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAngleHigh
            // 
            this.txtAngleHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAngleHigh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngleHigh.Location = new System.Drawing.Point(538, 95);
            this.txtAngleHigh.Name = "txtAngleHigh";
            this.txtAngleHigh.Size = new System.Drawing.Size(55, 22);
            this.txtAngleHigh.TabIndex = 81;
            this.txtAngleHigh.Text = "0.0";
            this.txtAngleHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAngleLow
            // 
            this.txtAngleLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAngleLow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAngleLow.Location = new System.Drawing.Point(482, 95);
            this.txtAngleLow.Name = "txtAngleLow";
            this.txtAngleLow.Size = new System.Drawing.Size(55, 22);
            this.txtAngleLow.TabIndex = 80;
            this.txtAngleLow.Text = "0.0";
            this.txtAngleLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThreshold
            // 
            this.txtThreshold.BackColor = System.Drawing.Color.YellowGreen;
            this.txtThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThreshold.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThreshold.Location = new System.Drawing.Point(482, 141);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(111, 22);
            this.txtThreshold.TabIndex = 79;
            this.txtThreshold.Text = "0.5";
            this.txtThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(538, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 78;
            this.label5.Text = "High";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(482, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 77;
            this.label4.Text = "Low";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(406, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 22);
            this.label3.TabIndex = 76;
            this.label3.Text = "Scale";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(406, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 75;
            this.label2.Text = "Angle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(406, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 74;
            this.label1.Text = "Threshold";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkHighSensitivity
            // 
            this.chkHighSensitivity.AutoSize = true;
            this.chkHighSensitivity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkHighSensitivity.Location = new System.Drawing.Point(407, 168);
            this.chkHighSensitivity.Name = "chkHighSensitivity";
            this.chkHighSensitivity.Size = new System.Drawing.Size(181, 18);
            this.chkHighSensitivity.TabIndex = 90;
            this.chkHighSensitivity.Text = "Patmax - High Sensitivity";
            this.chkHighSensitivity.UseVisualStyleBackColor = true;
            // 
            // BtnApply
            // 
            this.BtnApply.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApply.Location = new System.Drawing.Point(402, 307);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(189, 31);
            this.BtnApply.TabIndex = 86;
            this.BtnApply.Text = "Save";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFind.Location = new System.Drawing.Point(505, 275);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(86, 31);
            this.BtnFind.TabIndex = 85;
            this.BtnFind.Text = "Find";
            this.BtnFind.UseVisualStyleBackColor = true;
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // BtnSearchRegion
            // 
            this.BtnSearchRegion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchRegion.Location = new System.Drawing.Point(402, 275);
            this.BtnSearchRegion.Name = "BtnSearchRegion";
            this.BtnSearchRegion.Size = new System.Drawing.Size(103, 31);
            this.BtnSearchRegion.TabIndex = 84;
            this.BtnSearchRegion.Text = "Search Region";
            this.BtnSearchRegion.UseVisualStyleBackColor = true;
            this.BtnSearchRegion.Click += new System.EventHandler(this.BtnSearchRegion_Click);
            // 
            // txtApprox
            // 
            this.txtApprox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprox.Location = new System.Drawing.Point(302, 5);
            this.txtApprox.Name = "txtApprox";
            this.txtApprox.Size = new System.Drawing.Size(55, 22);
            this.txtApprox.TabIndex = 91;
            this.txtApprox.Text = "1";
            this.txtApprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(246, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 92;
            this.label6.Text = "approx";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModelToolName
            // 
            this.ModelToolName.Location = new System.Drawing.Point(493, 5);
            this.ModelToolName.Name = "ModelToolName";
            this.ModelToolName.Size = new System.Drawing.Size(100, 21);
            this.ModelToolName.TabIndex = 93;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(451, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 14);
            this.label7.TabIndex = 94;
            this.label7.Text = "Name";
            // 
            // FormToolPattern
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ModelToolName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtApprox);
            this.Controls.Add(this.chkHighSensitivity);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.BtnFind);
            this.Controls.Add(this.BtnSearchRegion);
            this.Controls.Add(this.txtScaleHigh);
            this.Controls.Add(this.txtScaleLow);
            this.Controls.Add(this.txtAngleHigh);
            this.Controls.Add(this.txtAngleLow);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnMasking);
            this.Controls.Add(this.BtnTrain);
            this.Controls.Add(this.BtnTrainRegion);
            this.Controls.Add(this.cogDisplay_Pattern);
            this.Controls.Add(this.label_ToolTitle_Pattern);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormToolPattern";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormToolPattern";
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay_Pattern)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ToolTitle_Pattern;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay_Pattern;
        private System.Windows.Forms.Button BtnMasking;
        private System.Windows.Forms.Button BtnTrain;
        private System.Windows.Forms.Button BtnTrainRegion;
        private System.Windows.Forms.TextBox txtScaleHigh;
        private System.Windows.Forms.TextBox txtScaleLow;
        private System.Windows.Forms.TextBox txtAngleHigh;
        private System.Windows.Forms.TextBox txtAngleLow;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHighSensitivity;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.Button BtnSearchRegion;
        private System.Windows.Forms.TextBox txtApprox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ModelToolName;
        private System.Windows.Forms.Label label7;
    }
}