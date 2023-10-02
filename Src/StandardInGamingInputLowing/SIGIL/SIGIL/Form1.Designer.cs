namespace SIGIL
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runProcessAtLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startProgramAtBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSystrayAtCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSystrayAtBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associateFileExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileAssociationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbdsvendorid = new System.Windows.Forms.ToolStripTextBox();
            this.productIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbdsproductid = new System.Windows.Forms.ToolStripTextBox();
            this.labelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbdslabel = new System.Windows.Forms.ToolStripTextBox();
            this.dS4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorIDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbds4vendorid = new System.Windows.Forms.ToolStripTextBox();
            this.productIDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbds4productid = new System.Windows.Forms.ToolStripTextBox();
            this.labelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbds4label = new System.Windows.Forms.ToolStripTextBox();
            this.intToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbintkeyboardid = new System.Windows.Forms.ToolStripTextBox();
            this.mouseIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbintmouseid = new System.Windows.Forms.ToolStripTextBox();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.autocompleteMenu1.SetAutocompleteMenu(this.fastColoredTextBox1, this.autocompleteMenu1);
            this.fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox1.CharHeight = 18;
            this.fastColoredTextBox1.CharWidth = 10;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fastColoredTextBox1.LeftBracket = '(';
            this.fastColoredTextBox1.LeftBracket2 = '{';
            this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 28);
            this.fastColoredTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.RightBracket = ')';
            this.fastColoredTextBox1.RightBracket2 = '}';
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(982, 525);
            this.fastColoredTextBox1.TabIndex = 3;
            this.fastColoredTextBox1.Zoom = 100;
            this.fastColoredTextBox1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBox1_TextChanged);
            this.fastColoredTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fastColoredTextBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.pSToolStripMenuItem,
            this.intToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.processToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runProcessAtLaunchToolStripMenuItem,
            this.startProgramAtBootToolStripMenuItem,
            this.minimizeToSystrayAtCloseToolStripMenuItem,
            this.minimizeToSystrayAtBootToolStripMenuItem,
            this.associateFileExtensionToolStripMenuItem,
            this.removeFileAssociationToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // runProcessAtLaunchToolStripMenuItem
            // 
            this.runProcessAtLaunchToolStripMenuItem.Checked = true;
            this.runProcessAtLaunchToolStripMenuItem.CheckOnClick = true;
            this.runProcessAtLaunchToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runProcessAtLaunchToolStripMenuItem.Name = "runProcessAtLaunchToolStripMenuItem";
            this.runProcessAtLaunchToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.runProcessAtLaunchToolStripMenuItem.Text = "Run process at launch";
            // 
            // startProgramAtBootToolStripMenuItem
            // 
            this.startProgramAtBootToolStripMenuItem.Checked = true;
            this.startProgramAtBootToolStripMenuItem.CheckOnClick = true;
            this.startProgramAtBootToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startProgramAtBootToolStripMenuItem.Name = "startProgramAtBootToolStripMenuItem";
            this.startProgramAtBootToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.startProgramAtBootToolStripMenuItem.Text = "Start program at boot";
            this.startProgramAtBootToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.startProgramAtBootToolStripMenuItem_CheckStateChanged);
            // 
            // minimizeToSystrayAtCloseToolStripMenuItem
            // 
            this.minimizeToSystrayAtCloseToolStripMenuItem.Checked = true;
            this.minimizeToSystrayAtCloseToolStripMenuItem.CheckOnClick = true;
            this.minimizeToSystrayAtCloseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeToSystrayAtCloseToolStripMenuItem.Name = "minimizeToSystrayAtCloseToolStripMenuItem";
            this.minimizeToSystrayAtCloseToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.minimizeToSystrayAtCloseToolStripMenuItem.Text = "Minimize to systray at close";
            // 
            // minimizeToSystrayAtBootToolStripMenuItem
            // 
            this.minimizeToSystrayAtBootToolStripMenuItem.Checked = true;
            this.minimizeToSystrayAtBootToolStripMenuItem.CheckOnClick = true;
            this.minimizeToSystrayAtBootToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeToSystrayAtBootToolStripMenuItem.Name = "minimizeToSystrayAtBootToolStripMenuItem";
            this.minimizeToSystrayAtBootToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.minimizeToSystrayAtBootToolStripMenuItem.Text = "Minimize to systray at boot";
            // 
            // associateFileExtensionToolStripMenuItem
            // 
            this.associateFileExtensionToolStripMenuItem.Name = "associateFileExtensionToolStripMenuItem";
            this.associateFileExtensionToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.associateFileExtensionToolStripMenuItem.Text = "Associate file extension";
            this.associateFileExtensionToolStripMenuItem.Click += new System.EventHandler(this.associateFileExtensionToolStripMenuItem_Click);
            // 
            // removeFileAssociationToolStripMenuItem
            // 
            this.removeFileAssociationToolStripMenuItem.Name = "removeFileAssociationToolStripMenuItem";
            this.removeFileAssociationToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.removeFileAssociationToolStripMenuItem.Text = "Remove file association";
            this.removeFileAssociationToolStripMenuItem.Click += new System.EventHandler(this.removeFileAssociationToolStripMenuItem_Click);
            // 
            // pSToolStripMenuItem
            // 
            this.pSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dSToolStripMenuItem,
            this.dS4ToolStripMenuItem});
            this.pSToolStripMenuItem.Name = "pSToolStripMenuItem";
            this.pSToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.pSToolStripMenuItem.Text = "PS";
            // 
            // dSToolStripMenuItem
            // 
            this.dSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendorIDToolStripMenuItem,
            this.productIDToolStripMenuItem,
            this.labelToolStripMenuItem});
            this.dSToolStripMenuItem.Name = "dSToolStripMenuItem";
            this.dSToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.dSToolStripMenuItem.Text = "DS";
            // 
            // vendorIDToolStripMenuItem
            // 
            this.vendorIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbdsvendorid});
            this.vendorIDToolStripMenuItem.Name = "vendorIDToolStripMenuItem";
            this.vendorIDToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.vendorIDToolStripMenuItem.Text = "Vendor ID";
            // 
            // tbdsvendorid
            // 
            this.tbdsvendorid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbdsvendorid.Name = "tbdsvendorid";
            this.tbdsvendorid.Size = new System.Drawing.Size(100, 27);
            this.tbdsvendorid.Text = "54C";
            // 
            // productIDToolStripMenuItem
            // 
            this.productIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbdsproductid});
            this.productIDToolStripMenuItem.Name = "productIDToolStripMenuItem";
            this.productIDToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.productIDToolStripMenuItem.Text = "Product ID";
            // 
            // tbdsproductid
            // 
            this.tbdsproductid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbdsproductid.Name = "tbdsproductid";
            this.tbdsproductid.Size = new System.Drawing.Size(100, 27);
            this.tbdsproductid.Text = "CE6";
            // 
            // labelToolStripMenuItem
            // 
            this.labelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbdslabel});
            this.labelToolStripMenuItem.Name = "labelToolStripMenuItem";
            this.labelToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.labelToolStripMenuItem.Text = "Label";
            // 
            // tbdslabel
            // 
            this.tbdslabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbdslabel.Name = "tbdslabel";
            this.tbdslabel.Size = new System.Drawing.Size(100, 27);
            this.tbdslabel.Text = "DualSense";
            // 
            // dS4ToolStripMenuItem
            // 
            this.dS4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendorIDToolStripMenuItem1,
            this.productIDToolStripMenuItem1,
            this.labelToolStripMenuItem1});
            this.dS4ToolStripMenuItem.Name = "dS4ToolStripMenuItem";
            this.dS4ToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.dS4ToolStripMenuItem.Text = "DS4";
            // 
            // vendorIDToolStripMenuItem1
            // 
            this.vendorIDToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbds4vendorid});
            this.vendorIDToolStripMenuItem1.Name = "vendorIDToolStripMenuItem1";
            this.vendorIDToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.vendorIDToolStripMenuItem1.Text = "Vendor ID";
            // 
            // tbds4vendorid
            // 
            this.tbds4vendorid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbds4vendorid.Name = "tbds4vendorid";
            this.tbds4vendorid.Size = new System.Drawing.Size(100, 27);
            this.tbds4vendorid.Text = "54C";
            // 
            // productIDToolStripMenuItem1
            // 
            this.productIDToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbds4productid});
            this.productIDToolStripMenuItem1.Name = "productIDToolStripMenuItem1";
            this.productIDToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.productIDToolStripMenuItem1.Text = "Product ID";
            // 
            // tbds4productid
            // 
            this.tbds4productid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbds4productid.Name = "tbds4productid";
            this.tbds4productid.Size = new System.Drawing.Size(100, 27);
            this.tbds4productid.Text = "9CC";
            // 
            // labelToolStripMenuItem1
            // 
            this.labelToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbds4label});
            this.labelToolStripMenuItem1.Name = "labelToolStripMenuItem1";
            this.labelToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.labelToolStripMenuItem1.Text = "Label";
            // 
            // tbds4label
            // 
            this.tbds4label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbds4label.Name = "tbds4label";
            this.tbds4label.Size = new System.Drawing.Size(100, 27);
            this.tbds4label.Text = "Wireless Controller";
            // 
            // intToolStripMenuItem
            // 
            this.intToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardIDToolStripMenuItem,
            this.mouseIDToolStripMenuItem});
            this.intToolStripMenuItem.Name = "intToolStripMenuItem";
            this.intToolStripMenuItem.Size = new System.Drawing.Size(40, 24);
            this.intToolStripMenuItem.Text = "Int";
            // 
            // keyboardIDToolStripMenuItem
            // 
            this.keyboardIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbintkeyboardid});
            this.keyboardIDToolStripMenuItem.Name = "keyboardIDToolStripMenuItem";
            this.keyboardIDToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.keyboardIDToolStripMenuItem.Text = "Keyboard ID";
            // 
            // tbintkeyboardid
            // 
            this.tbintkeyboardid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbintkeyboardid.Name = "tbintkeyboardid";
            this.tbintkeyboardid.Size = new System.Drawing.Size(100, 27);
            this.tbintkeyboardid.Text = "2";
            // 
            // mouseIDToolStripMenuItem
            // 
            this.mouseIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbintmouseid});
            this.mouseIDToolStripMenuItem.Name = "mouseIDToolStripMenuItem";
            this.mouseIDToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.mouseIDToolStripMenuItem.Text = "Mouse ID";
            // 
            // tbintmouseid
            // 
            this.tbintmouseid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbintmouseid.Name = "tbintmouseid";
            this.tbintmouseid.Size = new System.Drawing.Size(100, 27);
            this.tbintmouseid.Text = "12";
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.typeToolStripMenuItem.Text = "Type";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "WiiJoyL-XC",
            "WiiJoyR-XC",
            "Wii-XC",
            "Joys-XC",
            "JoyL-XC",
            "JoyR-XC",
            "SPC-XC",
            "JCG-XC",
            "DIC-XC",
            "DICM-XC",
            "DS-XC",
            "DS4-XC",
            "KM-XC",
            "XC-XC",
            "XCM-XC",
            "MJoyL-XC",
            "MJoyR-XC",
            "WiiJoyL-KM",
            "WiiJoyR-KM",
            "Wii-KM",
            "Joys-KM",
            "JoyL-KM",
            "JoyR-KM",
            "SPC-KM",
            "JCG-KM",
            "DIC-KM",
            "DICM-KM",
            "DS-KM",
            "DS4-KM",
            "KM-KM",
            "XC-KM",
            "XCM-KM",
            "MJoyL-KM",
            "MJoyR-KM",
            "WiiJoyL-Int",
            "WiiJoyR-Int",
            "Wii-Int",
            "Joys-Int",
            "JoyL-Int",
            "JoyR-Int",
            "SPC-Int",
            "JCG-Int",
            "DIC-Int",
            "DICM-Int",
            "DS-Int",
            "DS4-Int",
            "KM-Int",
            "XC-Int",
            "XCM-Int",
            "MJoyL-Int",
            "MJoyR-Int",
            "WiiJoyL-DS4",
            "WiiJoyR-DS4",
            "Wii-DS4",
            "Joys-DS4",
            "JoyL-DS4",
            "JoyR-DS4",
            "SPC-DS4",
            "JCG-DS4",
            "DIC-DS4",
            "DICM-DS4",
            "DS-DS4",
            "DS4-DS4",
            "KM-DS4",
            "XC-DS4",
            "XCM-DS4",
            "MJoyL-DS4",
            "MJoyR-DS4",
            "WiiJoyL-VJoy",
            "WiiJoyR-VJoy",
            "Wii-VJoy",
            "Joys-VJoy",
            "JoyL-VJoy",
            "JoyR-VJoy",
            "SPC-VJoy",
            "JCG-VJoy",
            "DIC-VJoy",
            "DICM-VJoy",
            "DS-VJoy",
            "DS4-VJoy",
            "KM-VJoy",
            "XC-VJoy",
            "XCM-VJoy",
            "MJoyL-VJoy",
            "MJoyR-VJoy"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.testToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.runToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.testToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 24);
            this.toolStripMenuItem1.Text = "?";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.AllowsTabKey = true;
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu1.ImageList = null;
            this.autocompleteMenu1.Items = new string[0];
            this.autocompleteMenu1.MaximumSize = new System.Drawing.Size(250, 300);
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SIGIL";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StandardInGamingInputLowing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem pSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbdsvendorid;
        private System.Windows.Forms.ToolStripMenuItem productIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbdsproductid;
        private System.Windows.Forms.ToolStripMenuItem labelToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbdslabel;
        private System.Windows.Forms.ToolStripMenuItem dS4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorIDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox tbds4vendorid;
        private System.Windows.Forms.ToolStripMenuItem productIDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox tbds4productid;
        private System.Windows.Forms.ToolStripMenuItem labelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox tbds4label;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runProcessAtLaunchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startProgramAtBootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystrayAtCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToSystrayAtBootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyboardIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbintkeyboardid;
        private System.Windows.Forms.ToolStripMenuItem mouseIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbintmouseid;
        private System.Windows.Forms.ToolStripMenuItem associateFileExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileAssociationToolStripMenuItem;
    }
}

