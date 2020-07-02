namespace imgSummator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ControlsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SecondaryImages = new System.Windows.Forms.Panel();
            this.ImgsListView = new System.Windows.Forms.ListView();
            this.ImageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.BWchkbx = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.CreateEndBttn = new System.Windows.Forms.Button();
            this.CreateDifferenceBttn = new System.Windows.Forms.Button();
            this.imagepanel = new System.Windows.Forms.Panel();
            this.BigImaxPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.указатьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMainImageBttn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSecondImageBttn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDiffBttn = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsSplitContainer)).BeginInit();
            this.ControlsSplitContainer.Panel1.SuspendLayout();
            this.ControlsSplitContainer.Panel2.SuspendLayout();
            this.ControlsSplitContainer.SuspendLayout();
            this.SecondaryImages.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.imagepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigImaxPictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 28);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ControlsSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.imagepanel);
            this.MainSplitContainer.Size = new System.Drawing.Size(1149, 616);
            this.MainSplitContainer.SplitterDistance = 261;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // ControlsSplitContainer
            // 
            this.ControlsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ControlsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ControlsSplitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ControlsSplitContainer.Name = "ControlsSplitContainer";
            this.ControlsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ControlsSplitContainer.Panel1
            // 
            this.ControlsSplitContainer.Panel1.Controls.Add(this.SecondaryImages);
            // 
            // ControlsSplitContainer.Panel2
            // 
            this.ControlsSplitContainer.Panel2.Controls.Add(this.controlsPanel);
            this.ControlsSplitContainer.Size = new System.Drawing.Size(261, 616);
            this.ControlsSplitContainer.SplitterDistance = 437;
            this.ControlsSplitContainer.TabIndex = 1;
            // 
            // SecondaryImages
            // 
            this.SecondaryImages.Controls.Add(this.ImgsListView);
            this.SecondaryImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondaryImages.Location = new System.Drawing.Point(0, 0);
            this.SecondaryImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SecondaryImages.Name = "SecondaryImages";
            this.SecondaryImages.Size = new System.Drawing.Size(261, 437);
            this.SecondaryImages.TabIndex = 0;
            // 
            // ImgsListView
            // 
            this.ImgsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ImageColumn,
            this.PathColumn,
            this.ImageType});
            this.ImgsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgsListView.GridLines = true;
            this.ImgsListView.HideSelection = false;
            this.ImgsListView.Location = new System.Drawing.Point(0, 0);
            this.ImgsListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImgsListView.Name = "ImgsListView";
            this.ImgsListView.Size = new System.Drawing.Size(261, 437);
            this.ImgsListView.SmallImageList = this.imageList;
            this.ImgsListView.TabIndex = 0;
            this.ImgsListView.UseCompatibleStateImageBehavior = false;
            this.ImgsListView.View = System.Windows.Forms.View.Details;
            this.ImgsListView.ItemActivate += new System.EventHandler(this.ImgsListView_ItemActivate);
            // 
            // ImageColumn
            // 
            this.ImageColumn.Text = "Изображение";
            this.ImageColumn.Width = 126;
            // 
            // PathColumn
            // 
            this.PathColumn.Text = "Путь";
            this.PathColumn.Width = 131;
            // 
            // ImageType
            // 
            this.ImageType.Text = "Тип";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(40, 40);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.BWchkbx);
            this.controlsPanel.Controls.Add(this.progressBar);
            this.controlsPanel.Controls.Add(this.CreateEndBttn);
            this.controlsPanel.Controls.Add(this.CreateDifferenceBttn);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsPanel.Location = new System.Drawing.Point(0, 0);
            this.controlsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.controlsPanel.Size = new System.Drawing.Size(261, 175);
            this.controlsPanel.TabIndex = 0;
            // 
            // BWchkbx
            // 
            this.BWchkbx.AutoSize = true;
            this.BWchkbx.Location = new System.Drawing.Point(9, 80);
            this.BWchkbx.Margin = new System.Windows.Forms.Padding(4);
            this.BWchkbx.Name = "BWchkbx";
            this.BWchkbx.Size = new System.Drawing.Size(113, 21);
            this.BWchkbx.TabIndex = 2;
            this.BWchkbx.Text = "Серая карта";
            this.BWchkbx.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(5, 150);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(251, 20);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // CreateEndBttn
            // 
            this.CreateEndBttn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateEndBttn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateEndBttn.Enabled = false;
            this.CreateEndBttn.Location = new System.Drawing.Point(5, 39);
            this.CreateEndBttn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateEndBttn.Name = "CreateEndBttn";
            this.CreateEndBttn.Padding = new System.Windows.Forms.Padding(4);
            this.CreateEndBttn.Size = new System.Drawing.Size(251, 34);
            this.CreateEndBttn.TabIndex = 0;
            this.CreateEndBttn.Text = "Создать конечное";
            this.CreateEndBttn.UseVisualStyleBackColor = true;
            this.CreateEndBttn.Click += new System.EventHandler(this.CreateEndBttn_Click);
            // 
            // CreateDifferenceBttn
            // 
            this.CreateDifferenceBttn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateDifferenceBttn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateDifferenceBttn.Enabled = false;
            this.CreateDifferenceBttn.Location = new System.Drawing.Point(5, 5);
            this.CreateDifferenceBttn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateDifferenceBttn.Name = "CreateDifferenceBttn";
            this.CreateDifferenceBttn.Padding = new System.Windows.Forms.Padding(4);
            this.CreateDifferenceBttn.Size = new System.Drawing.Size(251, 34);
            this.CreateDifferenceBttn.TabIndex = 0;
            this.CreateDifferenceBttn.Text = "Создать разность";
            this.CreateDifferenceBttn.UseVisualStyleBackColor = true;
            this.CreateDifferenceBttn.Click += new System.EventHandler(this.CreateDifferenceBttn_Click);
            // 
            // imagepanel
            // 
            this.imagepanel.AutoScroll = true;
            this.imagepanel.AutoSize = true;
            this.imagepanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imagepanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imagepanel.Controls.Add(this.BigImaxPictureBox);
            this.imagepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagepanel.Location = new System.Drawing.Point(0, 0);
            this.imagepanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imagepanel.Name = "imagepanel";
            this.imagepanel.Size = new System.Drawing.Size(884, 616);
            this.imagepanel.TabIndex = 0;
            this.imagepanel.Resize += new System.EventHandler(this.imagepanel_Resize);
            // 
            // BigImaxPictureBox
            // 
            this.BigImaxPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BigImaxPictureBox.Location = new System.Drawing.Point(1, 1);
            this.BigImaxPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BigImaxPictureBox.Name = "BigImaxPictureBox";
            this.BigImaxPictureBox.Size = new System.Drawing.Size(870, 619);
            this.BigImaxPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BigImaxPictureBox.TabIndex = 0;
            this.BigImaxPictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.указатьИзображениеToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1149, 28);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // указатьИзображениеToolStripMenuItem
            // 
            this.указатьИзображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMainImageBttn,
            this.AddSecondImageBttn,
            this.AddDiffBttn});
            this.указатьИзображениеToolStripMenuItem.Name = "указатьИзображениеToolStripMenuItem";
            this.указатьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.указатьИзображениеToolStripMenuItem.Text = "Указать изображение";
            // 
            // AddMainImageBttn
            // 
            this.AddMainImageBttn.Name = "AddMainImageBttn";
            this.AddMainImageBttn.Size = new System.Drawing.Size(209, 26);
            this.AddMainImageBttn.Text = "Главное";
            this.AddMainImageBttn.Click += new System.EventHandler(this.AddMainImageBttn_Click);
            // 
            // AddSecondImageBttn
            // 
            this.AddSecondImageBttn.Name = "AddSecondImageBttn";
            this.AddSecondImageBttn.Size = new System.Drawing.Size(209, 26);
            this.AddSecondImageBttn.Text = "Второстепенные";
            this.AddSecondImageBttn.Click += new System.EventHandler(this.AddSecondImageBttn_Click);
            // 
            // AddDiffBttn
            // 
            this.AddDiffBttn.Name = "AddDiffBttn";
            this.AddDiffBttn.Size = new System.Drawing.Size(209, 26);
            this.AddDiffBttn.Text = "Разностное";
            this.AddDiffBttn.Click += new System.EventHandler(this.AddDiffBttn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 644);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Сумматор изображений";
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ControlsSplitContainer.Panel1.ResumeLayout(false);
            this.ControlsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ControlsSplitContainer)).EndInit();
            this.ControlsSplitContainer.ResumeLayout(false);
            this.SecondaryImages.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.imagepanel.ResumeLayout(false);
            this.imagepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigImaxPictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel SecondaryImages;
        private System.Windows.Forms.ListView ImgsListView;
        private System.Windows.Forms.SplitContainer ControlsSplitContainer;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Panel imagepanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox BigImaxPictureBox;
        private System.Windows.Forms.ColumnHeader ImageColumn;
        private System.Windows.Forms.ColumnHeader PathColumn;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader ImageType;
        private System.Windows.Forms.Button CreateDifferenceBttn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button CreateEndBttn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem указатьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddMainImageBttn;
        private System.Windows.Forms.ToolStripMenuItem AddSecondImageBttn;
        private System.Windows.Forms.ToolStripMenuItem AddDiffBttn;
        private System.Windows.Forms.CheckBox BWchkbx;
    }
}

