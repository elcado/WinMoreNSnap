namespace WinMoreNSnap
{
    partial class TrayApp
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrayApp));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbResizeMouseRight = new System.Windows.Forms.RadioButton();
            this.rbResizeMouseLeft = new System.Windows.Forms.RadioButton();
            this.cbResizeKeyShift = new System.Windows.Forms.CheckBox();
            this.cbResizeKeyAlt = new System.Windows.Forms.CheckBox();
            this.cbResizeKeyCtrl = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMoveMouseRight = new System.Windows.Forms.RadioButton();
            this.rbMoveMouseLeft = new System.Windows.Forms.RadioButton();
            this.cbMoveKeyShift = new System.Windows.Forms.CheckBox();
            this.cbMoveKeyAlt = new System.Windows.Forms.CheckBox();
            this.cbMoveKeyCtrl = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSnapDistLeft = new System.Windows.Forms.TextBox();
            this.tbSnapDistBottom = new System.Windows.Forms.TextBox();
            this.tbSnapDistRight = new System.Windows.Forms.TextBox();
            this.tbSnapDistTop = new System.Windows.Forms.TextBox();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.trayMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "WinMoreNSnap";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(142, 76);
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Checked = true;
            this.activeToolStripMenuItem.CheckOnClick = true;
            this.activeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.OnActiveStateChange);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 127);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbStartWithWindows);
            this.tabPage1.Controls.Add(this.checkBoxActive);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 101);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Enabled = false;
            this.cbStartWithWindows.Location = new System.Drawing.Point(9, 31);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.cbStartWithWindows.TabIndex = 1;
            this.cbStartWithWindows.Text = "Start with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(9, 7);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 0;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            this.checkBoxActive.CheckedChanged += new System.EventHandler(this.OnActiveStateChange);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(472, 101);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Move & resize";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbResizeMouseRight);
            this.groupBox2.Controls.Add(this.rbResizeMouseLeft);
            this.groupBox2.Controls.Add(this.cbResizeKeyShift);
            this.groupBox2.Controls.Add(this.cbResizeKeyAlt);
            this.groupBox2.Controls.Add(this.cbResizeKeyCtrl);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(238, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resize";
            // 
            // rbResizeMouseRight
            // 
            this.rbResizeMouseRight.AutoSize = true;
            this.rbResizeMouseRight.Checked = true;
            this.rbResizeMouseRight.Location = new System.Drawing.Point(136, 54);
            this.rbResizeMouseRight.Name = "rbResizeMouseRight";
            this.rbResizeMouseRight.Size = new System.Drawing.Size(50, 17);
            this.rbResizeMouseRight.TabIndex = 8;
            this.rbResizeMouseRight.TabStop = true;
            this.rbResizeMouseRight.Text = "Right";
            this.rbResizeMouseRight.UseVisualStyleBackColor = true;
            this.rbResizeMouseRight.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // rbResizeMouseLeft
            // 
            this.rbResizeMouseLeft.AutoSize = true;
            this.rbResizeMouseLeft.Location = new System.Drawing.Point(87, 54);
            this.rbResizeMouseLeft.Name = "rbResizeMouseLeft";
            this.rbResizeMouseLeft.Size = new System.Drawing.Size(43, 17);
            this.rbResizeMouseLeft.TabIndex = 7;
            this.rbResizeMouseLeft.Text = "Left";
            this.rbResizeMouseLeft.UseVisualStyleBackColor = true;
            this.rbResizeMouseLeft.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // cbResizeKeyShift
            // 
            this.cbResizeKeyShift.AutoSize = true;
            this.cbResizeKeyShift.Location = new System.Drawing.Point(170, 21);
            this.cbResizeKeyShift.Name = "cbResizeKeyShift";
            this.cbResizeKeyShift.Size = new System.Drawing.Size(47, 17);
            this.cbResizeKeyShift.TabIndex = 6;
            this.cbResizeKeyShift.Text = "Shift";
            this.cbResizeKeyShift.UseVisualStyleBackColor = true;
            this.cbResizeKeyShift.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // cbResizeKeyAlt
            // 
            this.cbResizeKeyAlt.AutoSize = true;
            this.cbResizeKeyAlt.Checked = true;
            this.cbResizeKeyAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbResizeKeyAlt.Location = new System.Drawing.Point(126, 21);
            this.cbResizeKeyAlt.Name = "cbResizeKeyAlt";
            this.cbResizeKeyAlt.Size = new System.Drawing.Size(38, 17);
            this.cbResizeKeyAlt.TabIndex = 5;
            this.cbResizeKeyAlt.Text = "Alt";
            this.cbResizeKeyAlt.UseVisualStyleBackColor = true;
            this.cbResizeKeyAlt.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // cbResizeKeyCtrl
            // 
            this.cbResizeKeyCtrl.AutoSize = true;
            this.cbResizeKeyCtrl.Location = new System.Drawing.Point(79, 21);
            this.cbResizeKeyCtrl.Name = "cbResizeKeyCtrl";
            this.cbResizeKeyCtrl.Size = new System.Drawing.Size(41, 17);
            this.cbResizeKeyCtrl.TabIndex = 4;
            this.cbResizeKeyCtrl.Text = "Ctrl";
            this.cbResizeKeyCtrl.UseVisualStyleBackColor = true;
            this.cbResizeKeyCtrl.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mouse button:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Key modifier:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMoveMouseRight);
            this.groupBox1.Controls.Add(this.rbMoveMouseLeft);
            this.groupBox1.Controls.Add(this.cbMoveKeyShift);
            this.groupBox1.Controls.Add(this.cbMoveKeyAlt);
            this.groupBox1.Controls.Add(this.cbMoveKeyCtrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move";
            // 
            // rbMoveMouseRight
            // 
            this.rbMoveMouseRight.AutoSize = true;
            this.rbMoveMouseRight.Location = new System.Drawing.Point(136, 54);
            this.rbMoveMouseRight.Name = "rbMoveMouseRight";
            this.rbMoveMouseRight.Size = new System.Drawing.Size(50, 17);
            this.rbMoveMouseRight.TabIndex = 8;
            this.rbMoveMouseRight.Text = "Right";
            this.rbMoveMouseRight.UseVisualStyleBackColor = true;
            this.rbMoveMouseRight.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // rbMoveMouseLeft
            // 
            this.rbMoveMouseLeft.AutoSize = true;
            this.rbMoveMouseLeft.Checked = true;
            this.rbMoveMouseLeft.Location = new System.Drawing.Point(87, 54);
            this.rbMoveMouseLeft.Name = "rbMoveMouseLeft";
            this.rbMoveMouseLeft.Size = new System.Drawing.Size(43, 17);
            this.rbMoveMouseLeft.TabIndex = 7;
            this.rbMoveMouseLeft.TabStop = true;
            this.rbMoveMouseLeft.Text = "Left";
            this.rbMoveMouseLeft.UseVisualStyleBackColor = true;
            this.rbMoveMouseLeft.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // cbMoveKeyShift
            // 
            this.cbMoveKeyShift.AutoSize = true;
            this.cbMoveKeyShift.Location = new System.Drawing.Point(170, 21);
            this.cbMoveKeyShift.Name = "cbMoveKeyShift";
            this.cbMoveKeyShift.Size = new System.Drawing.Size(47, 17);
            this.cbMoveKeyShift.TabIndex = 6;
            this.cbMoveKeyShift.Text = "Shift";
            this.cbMoveKeyShift.UseVisualStyleBackColor = true;
            this.cbMoveKeyShift.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // cbMoveKeyAlt
            // 
            this.cbMoveKeyAlt.AutoSize = true;
            this.cbMoveKeyAlt.Checked = true;
            this.cbMoveKeyAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMoveKeyAlt.Location = new System.Drawing.Point(126, 21);
            this.cbMoveKeyAlt.Name = "cbMoveKeyAlt";
            this.cbMoveKeyAlt.Size = new System.Drawing.Size(38, 17);
            this.cbMoveKeyAlt.TabIndex = 5;
            this.cbMoveKeyAlt.Text = "Alt";
            this.cbMoveKeyAlt.UseVisualStyleBackColor = true;
            this.cbMoveKeyAlt.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // cbMoveKeyCtrl
            // 
            this.cbMoveKeyCtrl.AutoSize = true;
            this.cbMoveKeyCtrl.Location = new System.Drawing.Point(79, 21);
            this.cbMoveKeyCtrl.Name = "cbMoveKeyCtrl";
            this.cbMoveKeyCtrl.Size = new System.Drawing.Size(41, 17);
            this.cbMoveKeyCtrl.TabIndex = 4;
            this.cbMoveKeyCtrl.Text = "Ctrl";
            this.cbMoveKeyCtrl.UseVisualStyleBackColor = true;
            this.cbMoveKeyCtrl.CheckedChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mouse button:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key modifier:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(472, 101);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Snap";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbSnapDistLeft);
            this.groupBox3.Controls.Add(this.tbSnapDistBottom);
            this.groupBox3.Controls.Add(this.tbSnapDistRight);
            this.groupBox3.Controls.Add(this.tbSnapDistTop);
            this.groupBox3.Location = new System.Drawing.Point(136, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 89);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Snaping distances";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Left:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bottom:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Right:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Top:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSnapDistLeft
            // 
            this.tbSnapDistLeft.Location = new System.Drawing.Point(41, 39);
            this.tbSnapDistLeft.Name = "tbSnapDistLeft";
            this.tbSnapDistLeft.Size = new System.Drawing.Size(32, 20);
            this.tbSnapDistLeft.TabIndex = 1;
            this.tbSnapDistLeft.Text = "10";
            this.tbSnapDistLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSnapDistLeft.TextChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // tbSnapDistBottom
            // 
            this.tbSnapDistBottom.Location = new System.Drawing.Point(101, 63);
            this.tbSnapDistBottom.Name = "tbSnapDistBottom";
            this.tbSnapDistBottom.Size = new System.Drawing.Size(32, 20);
            this.tbSnapDistBottom.TabIndex = 1;
            this.tbSnapDistBottom.Text = "10";
            this.tbSnapDistBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSnapDistBottom.TextChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // tbSnapDistRight
            // 
            this.tbSnapDistRight.Location = new System.Drawing.Point(161, 39);
            this.tbSnapDistRight.Name = "tbSnapDistRight";
            this.tbSnapDistRight.Size = new System.Drawing.Size(32, 20);
            this.tbSnapDistRight.TabIndex = 1;
            this.tbSnapDistRight.Text = "10";
            this.tbSnapDistRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSnapDistRight.TextChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // tbSnapDistTop
            // 
            this.tbSnapDistTop.Location = new System.Drawing.Point(101, 19);
            this.tbSnapDistTop.Name = "tbSnapDistTop";
            this.tbSnapDistTop.Size = new System.Drawing.Size(32, 20);
            this.tbSnapDistTop.TabIndex = 1;
            this.tbSnapDistTop.Text = "10";
            this.tbSnapDistTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSnapDistTop.TextChanged += new System.EventHandler(this.cbCheckedChanged);
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonHide.Location = new System.Drawing.Point(393, 135);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(75, 23);
            this.buttonHide.TabIndex = 1;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(312, 135);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // TrayApp
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonHide;
            this.ClientSize = new System.Drawing.Size(480, 170);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrayApp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinMoreNSnap settings";
            this.Load += new System.EventHandler(this.TrayApp_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrayApp_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrayApp_FormClosing);
            this.trayMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbMoveKeyShift;
        private System.Windows.Forms.CheckBox cbMoveKeyAlt;
        private System.Windows.Forms.CheckBox cbMoveKeyCtrl;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RadioButton rbMoveMouseRight;
        private System.Windows.Forms.RadioButton rbMoveMouseLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbResizeMouseRight;
        private System.Windows.Forms.RadioButton rbResizeMouseLeft;
        private System.Windows.Forms.CheckBox cbResizeKeyShift;
        private System.Windows.Forms.CheckBox cbResizeKeyAlt;
        private System.Windows.Forms.CheckBox cbResizeKeyCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSnapDistLeft;
        private System.Windows.Forms.TextBox tbSnapDistBottom;
        private System.Windows.Forms.TextBox tbSnapDistRight;
        private System.Windows.Forms.TextBox tbSnapDistTop;
    }
}

