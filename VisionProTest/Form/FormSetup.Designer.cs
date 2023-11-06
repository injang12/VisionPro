namespace VisionProTest
{
    partial class FormSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetup));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.ToolPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplaySetup = new Cognex.VisionPro.CogRecordDisplay();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FolderList = new System.Windows.Forms.ListView();
            this.col_ModelIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_ModelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_ModelTool = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.txtSelectName = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAcquire = new System.Windows.Forms.Button();
            this.BtnImageLoad = new System.Windows.Forms.Button();
            this.BtnPMAlignToolLoad = new System.Windows.Forms.Button();
            this.BtnCaliperToolLoad = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnToolDelete = new System.Windows.Forms.Button();
            this.ModelToolList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtToolName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.ToolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplaySetup)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BtnExit, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1920, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnExit
            // 
            this.BtnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnExit.Location = new System.Drawing.Point(1857, 3);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(60, 52);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.Text = "X";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // ToolPanel
            // 
            this.ToolPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ToolPanel.ColumnCount = 1;
            this.ToolPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ToolPanel.Controls.Add(this.cogDisplaySetup, 0, 0);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToolPanel.Location = new System.Drawing.Point(1085, 58);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.RowCount = 2;
            this.ToolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ToolPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.ToolPanel.Size = new System.Drawing.Size(835, 1022);
            this.ToolPanel.TabIndex = 1;
            // 
            // cogDisplaySetup
            // 
            this.cogDisplaySetup.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplaySetup.ColorMapLowerRoiLimit = 0D;
            this.cogDisplaySetup.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplaySetup.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplaySetup.ColorMapUpperRoiLimit = 1D;
            this.cogDisplaySetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplaySetup.DoubleTapZoomCycleLength = 2;
            this.cogDisplaySetup.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplaySetup.Location = new System.Drawing.Point(3, 3);
            this.cogDisplaySetup.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplaySetup.MouseWheelSensitivity = 1D;
            this.cogDisplaySetup.Name = "cogDisplaySetup";
            this.cogDisplaySetup.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplaySetup.OcxState")));
            this.cogDisplaySetup.Size = new System.Drawing.Size(829, 646);
            this.cogDisplaySetup.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 964);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1085, 116);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // FolderList
            // 
            this.FolderList.BackColor = System.Drawing.Color.Gainsboro;
            this.FolderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_ModelIndex,
            this.col_ModelName,
            this.col_ModelTool});
            this.FolderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderList.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderList.FullRowSelect = true;
            this.FolderList.GridLines = true;
            this.FolderList.HideSelection = false;
            this.FolderList.Location = new System.Drawing.Point(3, 3);
            this.FolderList.MultiSelect = false;
            this.FolderList.Name = "FolderList";
            this.FolderList.Scrollable = false;
            this.FolderList.Size = new System.Drawing.Size(341, 900);
            this.FolderList.TabIndex = 40;
            this.FolderList.UseCompatibleStateImageBehavior = false;
            this.FolderList.View = System.Windows.Forms.View.Details;
            // 
            // col_ModelIndex
            // 
            this.col_ModelIndex.Tag = "Numeric";
            this.col_ModelIndex.Text = "Index ▲";
            this.col_ModelIndex.Width = 84;
            // 
            // col_ModelName
            // 
            this.col_ModelName.Tag = "";
            this.col_ModelName.Text = "Name";
            this.col_ModelName.Width = 158;
            // 
            // col_ModelTool
            // 
            this.col_ModelTool.Text = "Tool";
            this.col_ModelTool.Width = 150;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FolderList, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(347, 906);
            this.tableLayoutPanel2.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(353, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 30);
            this.label1.TabIndex = 45;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(453, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 31);
            this.txtName.TabIndex = 44;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.Black;
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAdd.Location = new System.Drawing.Point(352, 113);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(153, 59);
            this.BtnAdd.TabIndex = 46;
            this.BtnAdd.Text = "추가";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelect.ForeColor = System.Drawing.Color.Black;
            this.BtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("BtnSelect.Image")));
            this.BtnSelect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSelect.Location = new System.Drawing.Point(352, 233);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(153, 59);
            this.BtnSelect.TabIndex = 48;
            this.BtnSelect.Text = "선택";
            this.BtnSelect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // txtSelectName
            // 
            this.txtSelectName.AutoSize = true;
            this.txtSelectName.BackColor = System.Drawing.Color.Transparent;
            this.txtSelectName.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectName.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtSelectName.Location = new System.Drawing.Point(712, 69);
            this.txtSelectName.Name = "txtSelectName";
            this.txtSelectName.Size = new System.Drawing.Size(101, 38);
            this.txtSelectName.TabIndex = 169;
            this.txtSelectName.Text = "Empty";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.Black;
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnDelete.Location = new System.Drawing.Point(352, 173);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(153, 59);
            this.BtnDelete.TabIndex = 172;
            this.BtnDelete.Text = "삭제";
            this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAcquire
            // 
            this.BtnAcquire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAcquire.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcquire.ForeColor = System.Drawing.Color.Black;
            this.BtnAcquire.Image = ((System.Drawing.Image)(resources.GetObject("BtnAcquire.Image")));
            this.BtnAcquire.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAcquire.Location = new System.Drawing.Point(3, 3);
            this.BtnAcquire.Name = "BtnAcquire";
            this.BtnAcquire.Size = new System.Drawing.Size(150, 59);
            this.BtnAcquire.TabIndex = 174;
            this.BtnAcquire.Text = "촬영";
            this.BtnAcquire.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAcquire.UseVisualStyleBackColor = true;
            this.BtnAcquire.Click += new System.EventHandler(this.BtnAcquire_Click);
            // 
            // BtnImageLoad
            // 
            this.BtnImageLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnImageLoad.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImageLoad.ForeColor = System.Drawing.Color.Black;
            this.BtnImageLoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnImageLoad.Image")));
            this.BtnImageLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnImageLoad.Location = new System.Drawing.Point(3, 68);
            this.BtnImageLoad.Name = "BtnImageLoad";
            this.BtnImageLoad.Size = new System.Drawing.Size(150, 59);
            this.BtnImageLoad.TabIndex = 174;
            this.BtnImageLoad.Text = "이미지 불러오기";
            this.BtnImageLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnImageLoad.UseVisualStyleBackColor = true;
            this.BtnImageLoad.Click += new System.EventHandler(this.BtnImageLoad_Click);
            // 
            // BtnPMAlignToolLoad
            // 
            this.BtnPMAlignToolLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPMAlignToolLoad.Font = new System.Drawing.Font("Verdana", 10F);
            this.BtnPMAlignToolLoad.ForeColor = System.Drawing.Color.Black;
            this.BtnPMAlignToolLoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnPMAlignToolLoad.Image")));
            this.BtnPMAlignToolLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPMAlignToolLoad.Location = new System.Drawing.Point(3, 133);
            this.BtnPMAlignToolLoad.Name = "BtnPMAlignToolLoad";
            this.BtnPMAlignToolLoad.Size = new System.Drawing.Size(150, 59);
            this.BtnPMAlignToolLoad.TabIndex = 174;
            this.BtnPMAlignToolLoad.Text = "PMAlign";
            this.BtnPMAlignToolLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPMAlignToolLoad.UseVisualStyleBackColor = true;
            this.BtnPMAlignToolLoad.Click += new System.EventHandler(this.BtnPMAlignToolLoad_Click);
            // 
            // BtnCaliperToolLoad
            // 
            this.BtnCaliperToolLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCaliperToolLoad.Font = new System.Drawing.Font("Verdana", 10F);
            this.BtnCaliperToolLoad.ForeColor = System.Drawing.Color.Black;
            this.BtnCaliperToolLoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnCaliperToolLoad.Image")));
            this.BtnCaliperToolLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCaliperToolLoad.Location = new System.Drawing.Point(3, 198);
            this.BtnCaliperToolLoad.Name = "BtnCaliperToolLoad";
            this.BtnCaliperToolLoad.Size = new System.Drawing.Size(150, 59);
            this.BtnCaliperToolLoad.TabIndex = 175;
            this.BtnCaliperToolLoad.Text = "Caliper";
            this.BtnCaliperToolLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCaliperToolLoad.UseVisualStyleBackColor = true;
            this.BtnCaliperToolLoad.Click += new System.EventHandler(this.BtnCaliperToolLoad_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.BtnToolDelete, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.BtnCaliperToolLoad, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.BtnPMAlignToolLoad, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.BtnImageLoad, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.BtnAcquire, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ModelToolList, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(929, 58);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(156, 906);
            this.tableLayoutPanel4.TabIndex = 173;
            // 
            // BtnToolDelete
            // 
            this.BtnToolDelete.Font = new System.Drawing.Font("Verdana", 10F);
            this.BtnToolDelete.ForeColor = System.Drawing.Color.Black;
            this.BtnToolDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnToolDelete.Image")));
            this.BtnToolDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnToolDelete.Location = new System.Drawing.Point(3, 263);
            this.BtnToolDelete.Name = "BtnToolDelete";
            this.BtnToolDelete.Size = new System.Drawing.Size(150, 59);
            this.BtnToolDelete.TabIndex = 177;
            this.BtnToolDelete.Text = "삭제";
            this.BtnToolDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnToolDelete.UseVisualStyleBackColor = true;
            this.BtnToolDelete.Click += new System.EventHandler(this.BtnToolDelete_Click);
            // 
            // ModelToolList
            // 
            this.ModelToolList.BackColor = System.Drawing.Color.Gainsboro;
            this.ModelToolList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ModelToolList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModelToolList.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.ModelToolList.FullRowSelect = true;
            this.ModelToolList.GridLines = true;
            this.ModelToolList.HideSelection = false;
            this.ModelToolList.Location = new System.Drawing.Point(3, 328);
            this.ModelToolList.MultiSelect = false;
            this.ModelToolList.Name = "ModelToolList";
            this.ModelToolList.Scrollable = false;
            this.ModelToolList.Size = new System.Drawing.Size(150, 640);
            this.ModelToolList.TabIndex = 174;
            this.ModelToolList.UseCompatibleStateImageBehavior = false;
            this.ModelToolList.View = System.Windows.Forms.View.Details;
            this.ModelToolList.SelectedIndexChanged += new System.EventHandler(this.ModelToolList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 145;
            // 
            // txtToolName
            // 
            this.txtToolName.AutoSize = true;
            this.txtToolName.BackColor = System.Drawing.Color.Transparent;
            this.txtToolName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtToolName.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtToolName.Location = new System.Drawing.Point(726, 113);
            this.txtToolName.Name = "txtToolName";
            this.txtToolName.Size = new System.Drawing.Size(59, 21);
            this.txtToolName.TabIndex = 174;
            this.txtToolName.Text = "Empty";
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.txtToolName);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.txtSelectName);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.ToolPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToolManager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ToolPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplaySetup)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TableLayoutPanel ToolPanel;
        private Cognex.VisionPro.CogRecordDisplay cogDisplaySetup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView FolderList;
        private System.Windows.Forms.ColumnHeader col_ModelIndex;
        private System.Windows.Forms.ColumnHeader col_ModelName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnSelect;
        public System.Windows.Forms.Label txtSelectName;
        private System.Windows.Forms.ColumnHeader col_ModelTool;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAcquire;
        private System.Windows.Forms.Button BtnImageLoad;
        private System.Windows.Forms.Button BtnPMAlignToolLoad;
        private System.Windows.Forms.Button BtnCaliperToolLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListView ModelToolList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.Label txtToolName;
        private System.Windows.Forms.Button BtnToolDelete;
    }
}