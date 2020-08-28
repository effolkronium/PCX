namespace PCX
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInvert = new System.Windows.Forms.Button();
            this.labelInvert = new System.Windows.Forms.Label();
            this.labelRotate = new System.Windows.Forms.Label();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.labelScale = new System.Windows.Forms.Label();
            this.labelMirror = new System.Windows.Forms.Label();
            this.btnMirrorX = new System.Windows.Forms.Button();
            this.btnMirrorY = new System.Windows.Forms.Button();
            this.labelBlackWhite = new System.Windows.Forms.Label();
            this.btnBlackWhite = new System.Windows.Forms.Button();
            this.labelBlackWhiteRate = new System.Windows.Forms.Label();
            this.nmBlackWhiteRate = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.labelRecord = new System.Windows.Forms.Label();
            this.btnRecordStart = new System.Windows.Forms.Button();
            this.btnRecordStop = new System.Windows.Forms.Button();
            this.btnRecordSave = new System.Windows.Forms.Button();
            this.labelRecordIndicator = new System.Windows.Forms.Label();
            this.btnRecordRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonVoidFilling = new System.Windows.Forms.Button();
            this.flowLayoutPanelControls = new PCX.FlowPanelLeftScrollbar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBlackWhiteRate)).BeginInit();
            this.flowLayoutPanelControls.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Black;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOpen.FlatAppearance.BorderSize = 3;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(241, 70);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.BorderSize = 3;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(241, 70);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.BackColor = System.Drawing.Color.Black;
            this.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnZoomIn.FlatAppearance.BorderSize = 3;
            this.btnZoomIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZoomIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZoomIn.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnZoomIn.ForeColor = System.Drawing.Color.White;
            this.btnZoomIn.Location = new System.Drawing.Point(104, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(60, 80);
            this.btnZoomIn.TabIndex = 1;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseCompatibleTextRendering = true;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.BackColor = System.Drawing.Color.Black;
            this.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnZoomOut.FlatAppearance.BorderSize = 3;
            this.btnZoomOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZoomOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZoomOut.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnZoomOut.ForeColor = System.Drawing.Color.White;
            this.btnZoomOut.Location = new System.Drawing.Point(35, 0);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(60, 80);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseCompatibleTextRendering = true;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel.BackgroundImage")));
            this.flowLayoutPanel.Location = new System.Drawing.Point(259, 12);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1292, 816);
            this.flowLayoutPanel.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.btnInvert);
            this.panel5.Controls.Add(this.labelInvert);
            this.panel5.Location = new System.Drawing.Point(3, 663);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 151);
            this.panel5.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 5);
            this.label5.TabIndex = 2;
            this.label5.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "______________________________________";
            // 
            // btnInvert
            // 
            this.btnInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvert.BackColor = System.Drawing.Color.Black;
            this.btnInvert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnInvert.FlatAppearance.BorderSize = 3;
            this.btnInvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInvert.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInvert.ForeColor = System.Drawing.Color.White;
            this.btnInvert.Location = new System.Drawing.Point(64, 0);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(80, 80);
            this.btnInvert.TabIndex = 1;
            this.btnInvert.Text = "*";
            this.btnInvert.UseCompatibleTextRendering = true;
            this.btnInvert.UseVisualStyleBackColor = false;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // labelInvert
            // 
            this.labelInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInvert.AutoSize = true;
            this.labelInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelInvert.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInvert.ForeColor = System.Drawing.Color.White;
            this.labelInvert.Location = new System.Drawing.Point(24, 80);
            this.labelInvert.Name = "labelInvert";
            this.labelInvert.Size = new System.Drawing.Size(164, 54);
            this.labelInvert.TabIndex = 2;
            this.labelInvert.Text = "INVERT";
            // 
            // labelRotate
            // 
            this.labelRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRotate.AutoSize = true;
            this.labelRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRotate.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRotate.ForeColor = System.Drawing.Color.White;
            this.labelRotate.Location = new System.Drawing.Point(21, 83);
            this.labelRotate.Name = "labelRotate";
            this.labelRotate.Size = new System.Drawing.Size(166, 54);
            this.labelRotate.TabIndex = 2;
            this.labelRotate.Text = "ROTATE";
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotateLeft.BackColor = System.Drawing.Color.Black;
            this.btnRotateLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRotateLeft.FlatAppearance.BorderSize = 3;
            this.btnRotateLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRotateLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRotateLeft.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRotateLeft.ForeColor = System.Drawing.Color.White;
            this.btnRotateLeft.Location = new System.Drawing.Point(35, 0);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(60, 80);
            this.btnRotateLeft.TabIndex = 1;
            this.btnRotateLeft.Text = "<";
            this.btnRotateLeft.UseCompatibleTextRendering = true;
            this.btnRotateLeft.UseVisualStyleBackColor = false;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotateRight.BackColor = System.Drawing.Color.Black;
            this.btnRotateRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRotateRight.FlatAppearance.BorderSize = 3;
            this.btnRotateRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRotateRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRotateRight.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRotateRight.ForeColor = System.Drawing.Color.White;
            this.btnRotateRight.Location = new System.Drawing.Point(104, 0);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(60, 80);
            this.btnRotateRight.TabIndex = 1;
            this.btnRotateRight.Text = ">";
            this.btnRotateRight.UseCompatibleTextRendering = true;
            this.btnRotateRight.UseVisualStyleBackColor = false;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // labelScale
            // 
            this.labelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScale.AutoSize = true;
            this.labelScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelScale.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScale.ForeColor = System.Drawing.Color.White;
            this.labelScale.Location = new System.Drawing.Point(31, 85);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(139, 54);
            this.labelScale.TabIndex = 2;
            this.labelScale.Text = "SCALE";
            // 
            // labelMirror
            // 
            this.labelMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMirror.AutoSize = true;
            this.labelMirror.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelMirror.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMirror.ForeColor = System.Drawing.Color.White;
            this.labelMirror.Location = new System.Drawing.Point(11, 83);
            this.labelMirror.Name = "labelMirror";
            this.labelMirror.Size = new System.Drawing.Size(182, 54);
            this.labelMirror.TabIndex = 2;
            this.labelMirror.Text = "MIRROR";
            // 
            // btnMirrorX
            // 
            this.btnMirrorX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMirrorX.BackColor = System.Drawing.Color.Black;
            this.btnMirrorX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMirrorX.FlatAppearance.BorderSize = 3;
            this.btnMirrorX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMirrorX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMirrorX.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMirrorX.ForeColor = System.Drawing.Color.White;
            this.btnMirrorX.Location = new System.Drawing.Point(35, 0);
            this.btnMirrorX.Name = "btnMirrorX";
            this.btnMirrorX.Size = new System.Drawing.Size(60, 80);
            this.btnMirrorX.TabIndex = 1;
            this.btnMirrorX.Text = "X";
            this.btnMirrorX.UseCompatibleTextRendering = true;
            this.btnMirrorX.UseVisualStyleBackColor = false;
            this.btnMirrorX.Click += new System.EventHandler(this.btnMirrorX_Click);
            // 
            // btnMirrorY
            // 
            this.btnMirrorY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMirrorY.BackColor = System.Drawing.Color.Black;
            this.btnMirrorY.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMirrorY.FlatAppearance.BorderSize = 3;
            this.btnMirrorY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMirrorY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMirrorY.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMirrorY.ForeColor = System.Drawing.Color.White;
            this.btnMirrorY.Location = new System.Drawing.Point(104, 0);
            this.btnMirrorY.Name = "btnMirrorY";
            this.btnMirrorY.Size = new System.Drawing.Size(60, 80);
            this.btnMirrorY.TabIndex = 1;
            this.btnMirrorY.Text = "Y";
            this.btnMirrorY.UseCompatibleTextRendering = true;
            this.btnMirrorY.UseVisualStyleBackColor = false;
            this.btnMirrorY.Click += new System.EventHandler(this.btnMirrorY_Click);
            // 
            // labelBlackWhite
            // 
            this.labelBlackWhite.AutoSize = true;
            this.labelBlackWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelBlackWhite.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelBlackWhite.ForeColor = System.Drawing.Color.White;
            this.labelBlackWhite.Location = new System.Drawing.Point(-6, 90);
            this.labelBlackWhite.Name = "labelBlackWhite";
            this.labelBlackWhite.Size = new System.Drawing.Size(213, 40);
            this.labelBlackWhite.TabIndex = 2;
            this.labelBlackWhite.Text = "BLACK-WHITE";
            // 
            // btnBlackWhite
            // 
            this.btnBlackWhite.BackColor = System.Drawing.Color.Black;
            this.btnBlackWhite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBlackWhite.FlatAppearance.BorderSize = 3;
            this.btnBlackWhite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBlackWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBlackWhite.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBlackWhite.ForeColor = System.Drawing.Color.White;
            this.btnBlackWhite.Location = new System.Drawing.Point(24, 0);
            this.btnBlackWhite.Name = "btnBlackWhite";
            this.btnBlackWhite.Size = new System.Drawing.Size(80, 80);
            this.btnBlackWhite.TabIndex = 1;
            this.btnBlackWhite.Text = "*";
            this.btnBlackWhite.UseCompatibleTextRendering = true;
            this.btnBlackWhite.UseVisualStyleBackColor = false;
            this.btnBlackWhite.Click += new System.EventHandler(this.btnBlackWhite_Click);
            // 
            // labelBlackWhiteRate
            // 
            this.labelBlackWhiteRate.AutoSize = true;
            this.labelBlackWhiteRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelBlackWhiteRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelBlackWhiteRate.ForeColor = System.Drawing.Color.White;
            this.labelBlackWhiteRate.Location = new System.Drawing.Point(127, 39);
            this.labelBlackWhiteRate.Name = "labelBlackWhiteRate";
            this.labelBlackWhiteRate.Size = new System.Drawing.Size(78, 28);
            this.labelBlackWhiteRate.TabIndex = 2;
            this.labelBlackWhiteRate.Text = "RATE%";
            this.labelBlackWhiteRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nmBlackWhiteRate
            // 
            this.nmBlackWhiteRate.Location = new System.Drawing.Point(131, 5);
            this.nmBlackWhiteRate.Name = "nmBlackWhiteRate";
            this.nmBlackWhiteRate.Size = new System.Drawing.Size(54, 27);
            this.nmBlackWhiteRate.TabIndex = 4;
            this.nmBlackWhiteRate.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.BackColor = System.Drawing.Color.Black;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnReset.FlatAppearance.BorderSize = 3;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(29, 775);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 36);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "RESET";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseCompatibleTextRendering = true;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRecord.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRecord.ForeColor = System.Drawing.Color.White;
            this.labelRecord.Location = new System.Drawing.Point(21, 90);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new System.Drawing.Size(124, 37);
            this.labelRecord.TabIndex = 2;
            this.labelRecord.Text = "RECORD";
            // 
            // btnRecordStart
            // 
            this.btnRecordStart.BackColor = System.Drawing.Color.Black;
            this.btnRecordStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRecordStart.FlatAppearance.BorderSize = 3;
            this.btnRecordStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRecordStart.ForeColor = System.Drawing.Color.White;
            this.btnRecordStart.Location = new System.Drawing.Point(21, 8);
            this.btnRecordStart.Name = "btnRecordStart";
            this.btnRecordStart.Size = new System.Drawing.Size(70, 30);
            this.btnRecordStart.TabIndex = 1;
            this.btnRecordStart.Text = "START";
            this.btnRecordStart.UseCompatibleTextRendering = true;
            this.btnRecordStart.UseVisualStyleBackColor = false;
            this.btnRecordStart.Click += new System.EventHandler(this.btnRecordStart_Click);
            // 
            // btnRecordStop
            // 
            this.btnRecordStop.BackColor = System.Drawing.Color.Black;
            this.btnRecordStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRecordStop.FlatAppearance.BorderSize = 3;
            this.btnRecordStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRecordStop.ForeColor = System.Drawing.Color.White;
            this.btnRecordStop.Location = new System.Drawing.Point(21, 44);
            this.btnRecordStop.Name = "btnRecordStop";
            this.btnRecordStop.Size = new System.Drawing.Size(70, 30);
            this.btnRecordStop.TabIndex = 1;
            this.btnRecordStop.Text = "STOP";
            this.btnRecordStop.UseCompatibleTextRendering = true;
            this.btnRecordStop.UseVisualStyleBackColor = false;
            this.btnRecordStop.Click += new System.EventHandler(this.btnRecordStop_Click);
            // 
            // btnRecordSave
            // 
            this.btnRecordSave.BackColor = System.Drawing.Color.Black;
            this.btnRecordSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRecordSave.FlatAppearance.BorderSize = 3;
            this.btnRecordSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRecordSave.ForeColor = System.Drawing.Color.White;
            this.btnRecordSave.Location = new System.Drawing.Point(120, 8);
            this.btnRecordSave.Name = "btnRecordSave";
            this.btnRecordSave.Size = new System.Drawing.Size(70, 30);
            this.btnRecordSave.TabIndex = 1;
            this.btnRecordSave.Text = "SAVE";
            this.btnRecordSave.UseCompatibleTextRendering = true;
            this.btnRecordSave.UseVisualStyleBackColor = false;
            this.btnRecordSave.Click += new System.EventHandler(this.btnRecordSave_Click);
            // 
            // labelRecordIndicator
            // 
            this.labelRecordIndicator.AutoSize = true;
            this.labelRecordIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRecordIndicator.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRecordIndicator.ForeColor = System.Drawing.Color.Red;
            this.labelRecordIndicator.Location = new System.Drawing.Point(144, 76);
            this.labelRecordIndicator.Name = "labelRecordIndicator";
            this.labelRecordIndicator.Size = new System.Drawing.Size(62, 81);
            this.labelRecordIndicator.TabIndex = 2;
            this.labelRecordIndicator.Text = "*";
            this.labelRecordIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRecordRun
            // 
            this.btnRecordRun.BackColor = System.Drawing.Color.Black;
            this.btnRecordRun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRecordRun.FlatAppearance.BorderSize = 3;
            this.btnRecordRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRecordRun.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRecordRun.ForeColor = System.Drawing.Color.White;
            this.btnRecordRun.Location = new System.Drawing.Point(120, 44);
            this.btnRecordRun.Name = "btnRecordRun";
            this.btnRecordRun.Size = new System.Drawing.Size(70, 30);
            this.btnRecordRun.TabIndex = 1;
            this.btnRecordRun.Text = "RUN";
            this.btnRecordRun.UseCompatibleTextRendering = true;
            this.btnRecordRun.UseVisualStyleBackColor = false;
            this.btnRecordRun.Click += new System.EventHandler(this.btnRecordRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 5);
            this.label2.TabIndex = 2;
            this.label2.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "______________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "VOID FILLING";
            // 
            // buttonVoidFilling
            // 
            this.buttonVoidFilling.BackColor = System.Drawing.Color.Black;
            this.buttonVoidFilling.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonVoidFilling.FlatAppearance.BorderSize = 3;
            this.buttonVoidFilling.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonVoidFilling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonVoidFilling.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonVoidFilling.ForeColor = System.Drawing.Color.White;
            this.buttonVoidFilling.Location = new System.Drawing.Point(64, 0);
            this.buttonVoidFilling.Name = "buttonVoidFilling";
            this.buttonVoidFilling.Size = new System.Drawing.Size(80, 80);
            this.buttonVoidFilling.TabIndex = 1;
            this.buttonVoidFilling.Text = "*";
            this.buttonVoidFilling.UseCompatibleTextRendering = true;
            this.buttonVoidFilling.UseVisualStyleBackColor = false;
            this.buttonVoidFilling.Click += new System.EventHandler(this.btnBlackWhite_Click);
            // 
            // flowLayoutPanelControls
            // 
            this.flowLayoutPanelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelControls.AutoScroll = true;
            this.flowLayoutPanelControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelControls.Controls.Add(this.panel3);
            this.flowLayoutPanelControls.Controls.Add(this.panel1);
            this.flowLayoutPanelControls.Controls.Add(this.panel2);
            this.flowLayoutPanelControls.Controls.Add(this.panel4);
            this.flowLayoutPanelControls.Controls.Add(this.panel5);
            this.flowLayoutPanelControls.Controls.Add(this.panel6);
            this.flowLayoutPanelControls.Controls.Add(this.panel7);
            this.flowLayoutPanelControls.Location = new System.Drawing.Point(12, 164);
            this.flowLayoutPanelControls.Name = "flowLayoutPanelControls";
            this.flowLayoutPanelControls.Size = new System.Drawing.Size(241, 605);
            this.flowLayoutPanelControls.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.labelRecord);
            this.panel3.Controls.Add(this.btnRecordStart);
            this.panel3.Controls.Add(this.btnRecordStop);
            this.panel3.Controls.Add(this.btnRecordSave);
            this.panel3.Controls.Add(this.labelRecordIndicator);
            this.panel3.Controls.Add(this.btnRecordRun);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(206, 158);
            this.panel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelRotate);
            this.panel1.Controls.Add(this.btnRotateLeft);
            this.panel1.Controls.Add(this.btnRotateRight);
            this.panel1.Location = new System.Drawing.Point(3, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 166);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 5);
            this.label1.TabIndex = 2;
            this.label1.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "______________________________________";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnZoomOut);
            this.panel2.Controls.Add(this.labelScale);
            this.panel2.Controls.Add(this.btnZoomIn);
            this.panel2.Location = new System.Drawing.Point(3, 339);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 156);
            this.panel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 5);
            this.label6.TabIndex = 2;
            this.label6.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "______________________________________";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnMirrorY);
            this.panel4.Controls.Add(this.labelMirror);
            this.panel4.Controls.Add(this.btnMirrorX);
            this.panel4.Location = new System.Drawing.Point(3, 501);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(209, 156);
            this.panel4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 5);
            this.label4.TabIndex = 2;
            this.label4.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "______________________________________";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.btnBlackWhite);
            this.panel6.Controls.Add(this.labelBlackWhite);
            this.panel6.Controls.Add(this.labelBlackWhiteRate);
            this.panel6.Controls.Add(this.nmBlackWhiteRate);
            this.panel6.Location = new System.Drawing.Point(3, 820);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(209, 143);
            this.panel6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 5);
            this.label7.TabIndex = 2;
            this.label7.Text = "_________________________________________________________________________________" +
    "________________________________________________________________________________" +
    "______________________________________";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.buttonVoidFilling);
            this.panel7.Location = new System.Drawing.Point(3, 969);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(209, 132);
            this.panel7.TabIndex = 6;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1553, 823);
            this.Controls.Add(this.flowLayoutPanelControls);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.MinimumSize = new System.Drawing.Size(1247, 746);
            this.Name = "MainWindow";
            this.Text = "Form_PCX";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBlackWhiteRate)).EndInit();
            this.flowLayoutPanelControls.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label labelRotate;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Label labelMirror;
        private System.Windows.Forms.Button btnMirrorX;
        private System.Windows.Forms.Button btnMirrorY;
        private System.Windows.Forms.Label labelInvert;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Label labelBlackWhite;
        private System.Windows.Forms.Button btnBlackWhite;
        private System.Windows.Forms.Label labelBlackWhiteRate;
        private System.Windows.Forms.NumericUpDown nmBlackWhiteRate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.Button btnRecordStart;
        private System.Windows.Forms.Button btnRecordStop;
        private System.Windows.Forms.Button btnRecordSave;
        private System.Windows.Forms.Label labelRecordIndicator;
        private System.Windows.Forms.Button btnRecordRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonVoidFilling;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private FlowPanelLeftScrollbar flowLayoutPanelControls;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
    }
}

