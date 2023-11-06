namespace VisionProTest
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLive = new System.Windows.Forms.Button();
            this.BtnSaveImage = new System.Windows.Forms.Button();
            this.BtnLoadImage = new System.Windows.Forms.Button();
            this.btnAcquire = new System.Windows.Forms.Button();
            this.btnTriggerChange = new System.Windows.Forms.Button();
            this.PnlMouse = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDisplay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDisplayClear = new System.Windows.Forms.Button();
            this.BtnSetupLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBoardType = new System.Windows.Forms.Label();
            this.contrastUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.brightnessUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.exposureUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnbStrobe = new System.Windows.Forms.CheckBox();
            this.hwNameTxt = new System.Windows.Forms.TextBox();
            this.hwNameCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCountClear = new System.Windows.Forms.Button();
            this.VidFormatComboBox = new System.Windows.Forms.ComboBox();
            this.pnlDisplay = new System.Windows.Forms.FlowLayoutPanel();
            this.displayLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CameraTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnRun = new System.Windows.Forms.Button();
            this.PnlMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureUpDown)).BeginInit();
            this.pnlDisplay.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLive
            // 
            this.btnLive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLive.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLive.Location = new System.Drawing.Point(3, 3);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(144, 59);
            this.btnLive.TabIndex = 1;
            this.btnLive.Text = "라이브 시작";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.BtnLive_Click);
            // 
            // BtnSaveImage
            // 
            this.BtnSaveImage.Enabled = false;
            this.BtnSaveImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.BtnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnSaveImage.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnSaveImage.Location = new System.Drawing.Point(453, 3);
            this.BtnSaveImage.Name = "BtnSaveImage";
            this.BtnSaveImage.Size = new System.Drawing.Size(144, 59);
            this.BtnSaveImage.TabIndex = 5;
            this.BtnSaveImage.Text = "이미지 저장";
            this.BtnSaveImage.UseVisualStyleBackColor = true;
            this.BtnSaveImage.Click += new System.EventHandler(this.BtnSaveImage_Click);
            // 
            // BtnLoadImage
            // 
            this.BtnLoadImage.Enabled = false;
            this.BtnLoadImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.BtnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnLoadImage.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnLoadImage.Location = new System.Drawing.Point(303, 3);
            this.BtnLoadImage.Name = "BtnLoadImage";
            this.BtnLoadImage.Size = new System.Drawing.Size(144, 59);
            this.BtnLoadImage.TabIndex = 6;
            this.BtnLoadImage.Text = "이미지 불러오기";
            this.BtnLoadImage.UseVisualStyleBackColor = true;
            this.BtnLoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            // 
            // btnAcquire
            // 
            this.btnAcquire.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnAcquire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcquire.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAcquire.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAcquire.Location = new System.Drawing.Point(153, 3);
            this.btnAcquire.Name = "btnAcquire";
            this.btnAcquire.Size = new System.Drawing.Size(144, 59);
            this.btnAcquire.TabIndex = 10;
            this.btnAcquire.Text = "촬영";
            this.btnAcquire.UseVisualStyleBackColor = true;
            this.btnAcquire.Click += new System.EventHandler(this.BtnAcquire_Click);
            // 
            // btnTriggerChange
            // 
            this.btnTriggerChange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnTriggerChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriggerChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTriggerChange.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTriggerChange.Location = new System.Drawing.Point(1066, 3);
            this.btnTriggerChange.Name = "btnTriggerChange";
            this.btnTriggerChange.Size = new System.Drawing.Size(144, 59);
            this.btnTriggerChange.TabIndex = 14;
            this.btnTriggerChange.Text = "H/W Trigger";
            this.btnTriggerChange.UseVisualStyleBackColor = true;
            this.btnTriggerChange.Click += new System.EventHandler(this.BtnTriggerChange_Click);
            // 
            // PnlMouse
            // 
            this.PnlMouse.ColumnCount = 11;
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 407F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.PnlMouse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.PnlMouse.Controls.Add(this.BtnDisplay, 5, 0);
            this.PnlMouse.Controls.Add(this.btnExit, 10, 0);
            this.PnlMouse.Controls.Add(this.btnDisplayClear, 9, 0);
            this.PnlMouse.Controls.Add(this.BtnSetupLoad, 6, 0);
            this.PnlMouse.Controls.Add(this.btnLive, 0, 0);
            this.PnlMouse.Controls.Add(this.btnAcquire, 1, 0);
            this.PnlMouse.Controls.Add(this.BtnLoadImage, 2, 0);
            this.PnlMouse.Controls.Add(this.BtnSaveImage, 3, 0);
            this.PnlMouse.Controls.Add(this.btnTriggerChange, 7, 0);
            this.PnlMouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMouse.Location = new System.Drawing.Point(0, 0);
            this.PnlMouse.Name = "PnlMouse";
            this.PnlMouse.RowCount = 1;
            this.PnlMouse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlMouse.Size = new System.Drawing.Size(1920, 67);
            this.PnlMouse.TabIndex = 2;
            this.PnlMouse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlMouse_MouseDown);
            this.PnlMouse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlMouse_MouseMove);
            this.PnlMouse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlMouse_MouseUp);
            // 
            // BtnDisplay
            // 
            this.BtnDisplay.Enabled = false;
            this.BtnDisplay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.BtnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnDisplay.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnDisplay.Location = new System.Drawing.Point(766, 3);
            this.BtnDisplay.Name = "BtnDisplay";
            this.BtnDisplay.Size = new System.Drawing.Size(144, 59);
            this.BtnDisplay.TabIndex = 43;
            this.BtnDisplay.Text = "디스플레이 설정";
            this.BtnDisplay.UseVisualStyleBackColor = true;
            this.BtnDisplay.Click += new System.EventHandler(this.BtnDisplay_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.Location = new System.Drawing.Point(1773, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 59);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnDisplayClear
            // 
            this.btnDisplayClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnDisplayClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplayClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDisplayClear.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDisplayClear.Location = new System.Drawing.Point(1623, 3);
            this.btnDisplayClear.Name = "btnDisplayClear";
            this.btnDisplayClear.Size = new System.Drawing.Size(144, 59);
            this.btnDisplayClear.TabIndex = 16;
            this.btnDisplayClear.Text = "화면 지우기";
            this.btnDisplayClear.UseVisualStyleBackColor = true;
            this.btnDisplayClear.Click += new System.EventHandler(this.BtnDisplayClear_Click);
            // 
            // BtnSetupLoad
            // 
            this.BtnSetupLoad.Enabled = false;
            this.BtnSetupLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.BtnSetupLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetupLoad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnSetupLoad.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnSetupLoad.Location = new System.Drawing.Point(916, 3);
            this.BtnSetupLoad.Name = "BtnSetupLoad";
            this.BtnSetupLoad.Size = new System.Drawing.Size(144, 59);
            this.BtnSetupLoad.TabIndex = 31;
            this.BtnSetupLoad.Text = "Setup";
            this.BtnSetupLoad.UseVisualStyleBackColor = true;
            this.BtnSetupLoad.Click += new System.EventHandler(this.BtnSetupLoad_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "Board Type: ";
            this.label2.Visible = false;
            // 
            // lblBoardType
            // 
            this.lblBoardType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBoardType.AutoSize = true;
            this.lblBoardType.ForeColor = System.Drawing.Color.White;
            this.lblBoardType.Location = new System.Drawing.Point(254, 54);
            this.lblBoardType.Name = "lblBoardType";
            this.lblBoardType.Size = new System.Drawing.Size(57, 12);
            this.lblBoardType.TabIndex = 17;
            this.lblBoardType.Text = "Unknown";
            this.lblBoardType.Visible = false;
            // 
            // contrastUpDown
            // 
            this.contrastUpDown.DecimalPlaces = 1;
            this.contrastUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.contrastUpDown.Location = new System.Drawing.Point(84, 47);
            this.contrastUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.contrastUpDown.Name = "contrastUpDown";
            this.contrastUpDown.Size = new System.Drawing.Size(106, 21);
            this.contrastUpDown.TabIndex = 23;
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(3, 48);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 15);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Contrast";
            // 
            // brightnessUpDown
            // 
            this.brightnessUpDown.DecimalPlaces = 1;
            this.brightnessUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.brightnessUpDown.Location = new System.Drawing.Point(84, 25);
            this.brightnessUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brightnessUpDown.Name = "brightnessUpDown";
            this.brightnessUpDown.Size = new System.Drawing.Size(106, 21);
            this.brightnessUpDown.TabIndex = 21;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(3, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 17);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "Brightness";
            // 
            // exposureUpDown
            // 
            this.exposureUpDown.DecimalPlaces = 1;
            this.exposureUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.exposureUpDown.Location = new System.Drawing.Point(84, 3);
            this.exposureUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.exposureUpDown.Name = "exposureUpDown";
            this.exposureUpDown.Size = new System.Drawing.Size(106, 21);
            this.exposureUpDown.TabIndex = 25;
            this.exposureUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Exposure";
            // 
            // chkEnbStrobe
            // 
            this.chkEnbStrobe.AutoSize = true;
            this.chkEnbStrobe.ForeColor = System.Drawing.Color.White;
            this.chkEnbStrobe.Location = new System.Drawing.Point(3, 3);
            this.chkEnbStrobe.Name = "chkEnbStrobe";
            this.chkEnbStrobe.Size = new System.Drawing.Size(60, 15);
            this.chkEnbStrobe.TabIndex = 26;
            this.chkEnbStrobe.Text = "Strobe";
            this.chkEnbStrobe.UseVisualStyleBackColor = true;
            // 
            // hwNameTxt
            // 
            this.hwNameTxt.Location = new System.Drawing.Point(76, 3);
            this.hwNameTxt.Name = "hwNameTxt";
            this.hwNameTxt.Size = new System.Drawing.Size(102, 21);
            this.hwNameTxt.TabIndex = 27;
            // 
            // hwNameCombo
            // 
            this.hwNameCombo.FormattingEnabled = true;
            this.hwNameCombo.Items.AddRange(new object[] {
            "bmp",
            "png",
            "jpg"});
            this.hwNameCombo.Location = new System.Drawing.Point(184, 3);
            this.hwNameCombo.Name = "hwNameCombo";
            this.hwNameCombo.Size = new System.Drawing.Size(64, 20);
            this.hwNameCombo.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "H/W Name";
            // 
            // btnCountClear
            // 
            this.btnCountClear.Location = new System.Drawing.Point(382, 3);
            this.btnCountClear.Name = "btnCountClear";
            this.btnCountClear.Size = new System.Drawing.Size(51, 20);
            this.btnCountClear.TabIndex = 30;
            this.btnCountClear.Text = "초기화";
            this.btnCountClear.UseVisualStyleBackColor = true;
            this.btnCountClear.Click += new System.EventHandler(this.BtnCountClear);
            // 
            // VidFormatComboBox
            // 
            this.VidFormatComboBox.Location = new System.Drawing.Point(3, 3);
            this.VidFormatComboBox.Name = "VidFormatComboBox";
            this.VidFormatComboBox.Size = new System.Drawing.Size(242, 20);
            this.VidFormatComboBox.TabIndex = 18;
            this.VidFormatComboBox.Text = "Video Format";
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.displayLabel);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDisplay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 67);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(1063, 1013);
            this.pnlDisplay.TabIndex = 35;
            // 
            // displayLabel
            // 
            this.displayLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.displayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.displayLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.displayLabel.Location = new System.Drawing.Point(3, 0);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(320, 16);
            this.displayLabel.TabIndex = 8;
            this.displayLabel.Text = "Inspection Name";
            this.displayLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.displayLabel.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.4049F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.5951F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblBoardType, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.CameraTypeComboBox, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1063, 67);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(857, 94);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // CameraTypeComboBox
            // 
            this.CameraTypeComboBox.Location = new System.Drawing.Point(3, 77);
            this.CameraTypeComboBox.Name = "CameraTypeComboBox";
            this.CameraTypeComboBox.Size = new System.Drawing.Size(242, 20);
            this.CameraTypeComboBox.TabIndex = 19;
            this.CameraTypeComboBox.Text = "Camera Connect";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.VidFormatComboBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1063, 161);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(857, 25);
            this.tableLayoutPanel3.TabIndex = 37;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.451575F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.54842F));
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.Label4, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.exposureUpDown, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.brightnessUpDown, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.contrastUpDown, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1063, 186);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(857, 68);
            this.tableLayoutPanel4.TabIndex = 38;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.chkEnbStrobe, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1063, 254);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(857, 21);
            this.tableLayoutPanel5.TabIndex = 39;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 5;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.518086F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.6021F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.284714F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81914F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.65928F));
            this.tableLayoutPanel6.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.hwNameTxt, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.hwNameCombo, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnCountClear, 4, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1063, 275);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(857, 28);
            this.tableLayoutPanel6.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(295, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "이미지 카운트";
            // 
            // btnLogClear
            // 
            this.btnLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogClear.Location = new System.Drawing.Point(494, 105);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(84, 20);
            this.btnLogClear.TabIndex = 15;
            this.btnLogClear.Text = "로그 지우기";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.BtnLogClear_Click);
            // 
            // listLog
            // 
            this.listLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.listLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.listLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 21;
            this.listLog.Location = new System.Drawing.Point(3, 131);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(575, 643);
            this.listLog.TabIndex = 4;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.listLog, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.btnLogClear, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(1339, 303);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.47362F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.52638F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(581, 777);
            this.tableLayoutPanel7.TabIndex = 41;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnRun);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1063, 935);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 145);
            this.flowLayoutPanel1.TabIndex = 42;
            // 
            // BtnRun
            // 
            this.BtnRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnRun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BtnRun.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnRun.Location = new System.Drawing.Point(3, 3);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(144, 139);
            this.BtnRun.TabIndex = 43;
            this.BtnRun.Text = "Run";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel7);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.PnlMouse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "VisionPro";
            this.PnlMouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contrastUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureUpDown)).EndInit();
            this.pnlDisplay.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button BtnSaveImage;
        private System.Windows.Forms.Button BtnLoadImage;
        private System.Windows.Forms.Button btnAcquire;
        private System.Windows.Forms.Button btnTriggerChange;
        private System.Windows.Forms.TableLayoutPanel PnlMouse;
        private System.Windows.Forms.Button btnDisplayClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBoardType;
        internal System.Windows.Forms.NumericUpDown contrastUpDown;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown brightnessUpDown;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.NumericUpDown exposureUpDown;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnbStrobe;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox hwNameTxt;
        private System.Windows.Forms.ComboBox hwNameCombo;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCountClear;
        private System.Windows.Forms.Button BtnSetupLoad;
        private System.Windows.Forms.ComboBox VidFormatComboBox;
        private System.Windows.Forms.FlowLayoutPanel pnlDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CameraTypeComboBox;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.Button btnLogClear;
        public System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.Button BtnDisplay;
    }
}

