using System.Windows.Forms;

namespace KerbalConfigEditor
{
    partial class ProgramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramForm));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeView = new System.Windows.Forms.TreeView();
            this.buttonTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNewNode = new System.Windows.Forms.Button();
            this.buttonNewValue = new System.Windows.Forms.Button();
            this.nodePanel = new System.Windows.Forms.Panel();
            this.saveValuesButton = new System.Windows.Forms.Button();
            this.valuesTable = new System.Windows.Forms.TableLayoutPanel();
            this.valuesLabel = new System.Windows.Forms.Label();
            this.nodeEditorDivider = new System.Windows.Forms.Label();
            this.nodeRemoveButton = new System.Windows.Forms.Button();
            this.nodeNameTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.nodeNameField = new System.Windows.Forms.TextBox();
            this.nodeNameLabel = new System.Windows.Forms.Label();
            this.nodeNameButton = new System.Windows.Forms.Button();
            this.noValsLabel = new System.Windows.Forms.Label();
            this.openConfigDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveConfigDialog = new System.Windows.Forms.SaveFileDialog();
            this.cheatTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSavedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayoutPanel.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.buttonTablePanel.SuspendLayout();
            this.nodePanel.SuspendLayout();
            this.nodeNameTablePanel.SuspendLayout();
            this.cheatTablePanel.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.mainLayoutPanel.Controls.Add(this.mainMenuStrip, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.nodeView, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.buttonTablePanel, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.nodePanel, 1, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(778, 334);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(194, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // nodeView
            // 
            this.nodeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeView.Location = new System.Drawing.Point(3, 33);
            this.nodeView.Name = "nodeView";
            this.nodeView.PathSeparator = ".";
            this.nodeView.Size = new System.Drawing.Size(188, 298);
            this.nodeView.TabIndex = 1;
            this.nodeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.nodeView_BeforeSelect);
            this.nodeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeView_AfterSelect);
            // 
            // buttonTablePanel
            // 
            this.buttonTablePanel.ColumnCount = 2;
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTablePanel.Controls.Add(this.buttonNewNode, 0, 0);
            this.buttonTablePanel.Controls.Add(this.buttonNewValue, 1, 0);
            this.buttonTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTablePanel.Location = new System.Drawing.Point(197, 3);
            this.buttonTablePanel.Name = "buttonTablePanel";
            this.buttonTablePanel.RowCount = 1;
            this.buttonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.buttonTablePanel.Size = new System.Drawing.Size(578, 24);
            this.buttonTablePanel.TabIndex = 3;
            // 
            // buttonNewNode
            // 
            this.buttonNewNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewNode.Location = new System.Drawing.Point(0, 0);
            this.buttonNewNode.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNewNode.Name = "buttonNewNode";
            this.buttonNewNode.Size = new System.Drawing.Size(289, 24);
            this.buttonNewNode.TabIndex = 0;
            this.buttonNewNode.Text = "New Node";
            this.buttonNewNode.UseVisualStyleBackColor = true;
            this.buttonNewNode.Click += new System.EventHandler(this.buttonNewNode_Click);
            // 
            // buttonNewValue
            // 
            this.buttonNewValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewValue.Location = new System.Drawing.Point(289, 0);
            this.buttonNewValue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNewValue.Name = "buttonNewValue";
            this.buttonNewValue.Size = new System.Drawing.Size(289, 24);
            this.buttonNewValue.TabIndex = 1;
            this.buttonNewValue.Text = "New Value";
            this.buttonNewValue.UseVisualStyleBackColor = true;
            this.buttonNewValue.Click += new System.EventHandler(this.buttonNewValue_Click);
            // 
            // nodePanel
            // 
            this.nodePanel.AutoScroll = true;
            this.nodePanel.Controls.Add(this.saveValuesButton);
            this.nodePanel.Controls.Add(this.valuesTable);
            this.nodePanel.Controls.Add(this.valuesLabel);
            this.nodePanel.Controls.Add(this.nodeEditorDivider);
            this.nodePanel.Controls.Add(this.nodeRemoveButton);
            this.nodePanel.Controls.Add(this.nodeNameTablePanel);
            this.nodePanel.Controls.Add(this.noValsLabel);
            this.nodePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodePanel.Location = new System.Drawing.Point(197, 33);
            this.nodePanel.Name = "nodePanel";
            this.nodePanel.Size = new System.Drawing.Size(578, 298);
            this.nodePanel.TabIndex = 2;
            // 
            // saveValuesButton
            // 
            this.saveValuesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveValuesButton.Enabled = false;
            this.saveValuesButton.Location = new System.Drawing.Point(0, 80);
            this.saveValuesButton.Name = "saveValuesButton";
            this.saveValuesButton.Size = new System.Drawing.Size(578, 23);
            this.saveValuesButton.TabIndex = 5;
            this.saveValuesButton.Text = "Save Values";
            this.saveValuesButton.UseVisualStyleBackColor = true;
            this.saveValuesButton.Click += new System.EventHandler(this.saveValuesButton_Click);
            // 
            // valuesTable
            // 
            this.valuesTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valuesTable.AutoSize = true;
            this.valuesTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.valuesTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.valuesTable.ColumnCount = 5;
            this.valuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.valuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.valuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.valuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.valuesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.valuesTable.Location = new System.Drawing.Point(3, 109);
            this.valuesTable.Name = "valuesTable";
            this.valuesTable.RowCount = 1;
            this.valuesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.valuesTable.Size = new System.Drawing.Size(572, 4);
            this.valuesTable.TabIndex = 1;
            this.valuesTable.Visible = false;
            // 
            // valuesLabel
            // 
            this.valuesLabel.AutoSize = true;
            this.valuesLabel.Location = new System.Drawing.Point(3, 63);
            this.valuesLabel.Name = "valuesLabel";
            this.valuesLabel.Size = new System.Drawing.Size(39, 13);
            this.valuesLabel.TabIndex = 0;
            this.valuesLabel.Text = "Values";
            // 
            // nodeEditorDivider
            // 
            this.nodeEditorDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeEditorDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeEditorDivider.Location = new System.Drawing.Point(1, 61);
            this.nodeEditorDivider.Name = "nodeEditorDivider";
            this.nodeEditorDivider.Size = new System.Drawing.Size(577, 2);
            this.nodeEditorDivider.TabIndex = 3;
            // 
            // nodeRemoveButton
            // 
            this.nodeRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeRemoveButton.Location = new System.Drawing.Point(0, 35);
            this.nodeRemoveButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.nodeRemoveButton.Name = "nodeRemoveButton";
            this.nodeRemoveButton.Size = new System.Drawing.Size(578, 23);
            this.nodeRemoveButton.TabIndex = 1;
            this.nodeRemoveButton.Text = "Remove Node";
            this.nodeRemoveButton.UseVisualStyleBackColor = true;
            this.nodeRemoveButton.Click += new System.EventHandler(this.nodeRemoveButton_Click);
            // 
            // nodeNameTablePanel
            // 
            this.nodeNameTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeNameTablePanel.ColumnCount = 3;
            this.nodeNameTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.nodeNameTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.nodeNameTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.nodeNameTablePanel.Controls.Add(this.nodeNameField, 1, 0);
            this.nodeNameTablePanel.Controls.Add(this.nodeNameLabel, 0, 0);
            this.nodeNameTablePanel.Controls.Add(this.nodeNameButton, 2, 0);
            this.nodeNameTablePanel.Location = new System.Drawing.Point(0, 4);
            this.nodeNameTablePanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.nodeNameTablePanel.Name = "nodeNameTablePanel";
            this.nodeNameTablePanel.RowCount = 1;
            this.nodeNameTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.nodeNameTablePanel.Size = new System.Drawing.Size(578, 28);
            this.nodeNameTablePanel.TabIndex = 0;
            // 
            // nodeNameField
            // 
            this.nodeNameField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeNameField.Location = new System.Drawing.Point(38, 4);
            this.nodeNameField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nodeNameField.Name = "nodeNameField";
            this.nodeNameField.Size = new System.Drawing.Size(477, 20);
            this.nodeNameField.TabIndex = 1;
            // 
            // nodeNameLabel
            // 
            this.nodeNameLabel.AutoSize = true;
            this.nodeNameLabel.Location = new System.Drawing.Point(0, 8);
            this.nodeNameLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 3);
            this.nodeNameLabel.Name = "nodeNameLabel";
            this.nodeNameLabel.Size = new System.Drawing.Size(35, 13);
            this.nodeNameLabel.TabIndex = 0;
            this.nodeNameLabel.Text = "Name";
            // 
            // nodeNameButton
            // 
            this.nodeNameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeNameButton.Location = new System.Drawing.Point(521, 3);
            this.nodeNameButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.nodeNameButton.Name = "nodeNameButton";
            this.nodeNameButton.Size = new System.Drawing.Size(57, 22);
            this.nodeNameButton.TabIndex = 2;
            this.nodeNameButton.Text = "Save";
            this.nodeNameButton.UseVisualStyleBackColor = true;
            this.nodeNameButton.Click += new System.EventHandler(this.nodeNameButton_Click);
            // 
            // noValsLabel
            // 
            this.noValsLabel.AutoSize = true;
            this.noValsLabel.Location = new System.Drawing.Point(3, 107);
            this.noValsLabel.Name = "noValsLabel";
            this.noValsLabel.Size = new System.Drawing.Size(115, 13);
            this.noValsLabel.TabIndex = 4;
            this.noValsLabel.Text = "No values in this node.";
            // 
            // openConfigDialog
            // 
            this.openConfigDialog.DefaultExt = "cfg";
            this.openConfigDialog.FileName = "config.cfg";
            this.openConfigDialog.Filter = "KSP Files|*.cfg;*.sfs|KSP Config Files|*.cfg|KSP Save Files|*.sfs";
            this.openConfigDialog.InitialDirectory = "C:\\Users";
            // 
            // saveConfigDialog
            // 
            this.saveConfigDialog.DefaultExt = "cfg";
            this.saveConfigDialog.FileName = "config.cfg";
            this.saveConfigDialog.Filter = "KSP Files|*.cfg;*.sfs|KSP Config Files|*.cfg|KSP Save Files|*.sfs";
            this.saveConfigDialog.InitialDirectory = "C:\\Users";
            // 
            // cheatTablePanel
            // 
            this.cheatTablePanel.ColumnCount = 1;
            this.cheatTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cheatTablePanel.Controls.Add(this.mainStatusStrip, 0, 1);
            this.cheatTablePanel.Controls.Add(this.mainLayoutPanel, 0, 0);
            this.cheatTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cheatTablePanel.Location = new System.Drawing.Point(0, 0);
            this.cheatTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.cheatTablePanel.Name = "cheatTablePanel";
            this.cheatTablePanel.RowCount = 2;
            this.cheatTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cheatTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cheatTablePanel.Size = new System.Drawing.Size(784, 362);
            this.cheatTablePanel.TabIndex = 1;
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressLabel,
            this.toolStripProgressBar,
            this.toolStripSavedLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 340);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressLabel
            // 
            this.toolStripProgressLabel.Name = "toolStripProgressLabel";
            this.toolStripProgressLabel.Size = new System.Drawing.Size(106, 17);
            this.toolStripProgressLabel.Text = "Working! Progress:";
            this.toolStripProgressLabel.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripSavedLabel
            // 
            this.toolStripSavedLabel.Name = "toolStripSavedLabel";
            this.toolStripSavedLabel.Size = new System.Drawing.Size(78, 17);
            this.toolStripSavedLabel.Text = "Values Saved!";
            this.toolStripSavedLabel.Visible = false;
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // ProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.cheatTablePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "ProgramForm";
            this.Text = "Kerbal Config Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramForm_FormClosing);
            this.Load += new System.EventHandler(this.ProgramForm_Load);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.buttonTablePanel.ResumeLayout(false);
            this.nodePanel.ResumeLayout(false);
            this.nodePanel.PerformLayout();
            this.nodeNameTablePanel.ResumeLayout(false);
            this.nodeNameTablePanel.PerformLayout();
            this.cheatTablePanel.ResumeLayout(false);
            this.cheatTablePanel.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainLayoutPanel;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TreeView nodeView;
        private OpenFileDialog openConfigDialog;
        private SaveFileDialog saveConfigDialog;
        private Panel nodePanel;
        private TableLayoutPanel buttonTablePanel;
        private Button buttonNewNode;
        private Button buttonNewValue;
        private TableLayoutPanel nodeNameTablePanel;
        private Label nodeNameLabel;
        private TextBox nodeNameField;
        private Button nodeNameButton;
        private Button nodeRemoveButton;
        private Label valuesLabel;
        private Label nodeEditorDivider;
        private TableLayoutPanel valuesTable;
        private TableLayoutPanel cheatTablePanel;
        private StatusStrip mainStatusStrip;
        private ToolStripStatusLabel toolStripProgressLabel;
        private ToolStripProgressBar toolStripProgressBar;
        private Label noValsLabel;
        private Button saveValuesButton;
        private ToolStripStatusLabel toolStripSavedLabel;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}

