namespace RAMCleaner
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listViewProcesses = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            imageListProcess = new ImageList(components);
            btnRefresh = new Button();
            btnKill = new Button();
            listViewFavourites = new ListView();
            columnHeader4 = new ColumnHeader();
            buttonRemoveFavourite = new Button();
            btnAddFavourite = new Button();
            btnKillFavorites = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // listViewProcesses
            // 
            listViewProcesses.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewProcesses.FullRowSelect = true;
            listViewProcesses.Location = new Point(44, 59);
            listViewProcesses.MultiSelect = false;
            listViewProcesses.Name = "listViewProcesses";
            listViewProcesses.Size = new Size(482, 345);
            listViewProcesses.SmallImageList = imageListProcess;
            listViewProcesses.TabIndex = 0;
            listViewProcesses.UseCompatibleStateImageBehavior = false;
            listViewProcesses.View = View.Details;
            listViewProcesses.ColumnClick += listViewProcesses_ColumnClick;
            listViewProcesses.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listViewProcesses.MouseDoubleClick += listViewProcesses_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Process Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "PID";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Memory (MB)";
            columnHeader3.TextAlign = HorizontalAlignment.Right;
            columnHeader3.Width = 100;
            // 
            // imageListProcess
            // 
            imageListProcess.ColorDepth = ColorDepth.Depth32Bit;
            imageListProcess.ImageStream = (ImageListStreamer)resources.GetObject("imageListProcess.ImageStream");
            imageListProcess.TransparentColor = Color.Transparent;
            imageListProcess.Images.SetKeyName(0, "minus-square-icon.png");
            imageListProcess.Images.SetKeyName(1, "danger-icon.png");
            imageListProcess.Images.SetKeyName(2, "recycle-bin-icon.png");
            imageListProcess.Images.SetKeyName(3, "plus-icon.png");
            imageListProcess.Images.SetKeyName(4, "redo-arrow-icon.png");
            // 
            // btnRefresh
            // 
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefresh.ImageKey = "redo-arrow-icon.png";
            btnRefresh.ImageList = imageListProcess;
            btnRefresh.Location = new Point(44, 410);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnKill
            // 
            btnKill.FlatStyle = FlatStyle.Popup;
            btnKill.ImageAlign = ContentAlignment.MiddleLeft;
            btnKill.ImageIndex = 2;
            btnKill.ImageList = imageListProcess;
            btnKill.Location = new Point(197, 410);
            btnKill.Name = "btnKill";
            btnKill.Size = new Size(120, 29);
            btnKill.TabIndex = 2;
            btnKill.Text = "Kill Selected";
            btnKill.TextAlign = ContentAlignment.MiddleRight;
            btnKill.UseVisualStyleBackColor = true;
            btnKill.Click += btnKill_Click;
            // 
            // listViewFavourites
            // 
            listViewFavourites.Columns.AddRange(new ColumnHeader[] { columnHeader4 });
            listViewFavourites.FullRowSelect = true;
            listViewFavourites.Location = new Point(645, 59);
            listViewFavourites.MultiSelect = false;
            listViewFavourites.Name = "listViewFavourites";
            listViewFavourites.Size = new Size(429, 345);
            listViewFavourites.TabIndex = 3;
            listViewFavourites.UseCompatibleStateImageBehavior = false;
            listViewFavourites.View = View.Details;
            listViewFavourites.MouseDoubleClick += listViewFavourites_MouseDoubleClick;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Process Name";
            columnHeader4.Width = 200;
            // 
            // buttonRemoveFavourite
            // 
            buttonRemoveFavourite.FlatStyle = FlatStyle.Popup;
            buttonRemoveFavourite.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRemoveFavourite.ImageIndex = 0;
            buttonRemoveFavourite.ImageList = imageListProcess;
            buttonRemoveFavourite.Location = new Point(645, 410);
            buttonRemoveFavourite.Name = "buttonRemoveFavourite";
            buttonRemoveFavourite.Size = new Size(195, 29);
            buttonRemoveFavourite.TabIndex = 4;
            buttonRemoveFavourite.Text = "Remove From Favourites";
            buttonRemoveFavourite.TextAlign = ContentAlignment.MiddleRight;
            buttonRemoveFavourite.UseVisualStyleBackColor = true;
            buttonRemoveFavourite.Click += buttonRemoveFavourite_Click;
            // 
            // btnAddFavourite
            // 
            btnAddFavourite.FlatStyle = FlatStyle.Popup;
            btnAddFavourite.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddFavourite.ImageKey = "plus-icon.png";
            btnAddFavourite.ImageList = imageListProcess;
            btnAddFavourite.Location = new Point(375, 410);
            btnAddFavourite.Name = "btnAddFavourite";
            btnAddFavourite.Size = new Size(151, 29);
            btnAddFavourite.TabIndex = 5;
            btnAddFavourite.Text = "Add To Favourites";
            btnAddFavourite.TextAlign = ContentAlignment.MiddleRight;
            btnAddFavourite.UseVisualStyleBackColor = true;
            btnAddFavourite.Click += btnAddFavourite_Click;
            // 
            // btnKillFavorites
            // 
            btnKillFavorites.FlatStyle = FlatStyle.Popup;
            btnKillFavorites.ImageAlign = ContentAlignment.MiddleLeft;
            btnKillFavorites.ImageIndex = 1;
            btnKillFavorites.ImageList = imageListProcess;
            btnKillFavorites.Location = new Point(893, 410);
            btnKillFavorites.Name = "btnKillFavorites";
            btnKillFavorites.Size = new Size(181, 29);
            btnKillFavorites.TabIndex = 6;
            btnKillFavorites.Text = "Kill Favorite Processes";
            btnKillFavorites.TextAlign = ContentAlignment.MiddleRight;
            btnKillFavorites.UseVisualStyleBackColor = true;
            btnKillFavorites.Click += btnKillFavorites_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 21);
            label1.Name = "label1";
            label1.Size = new Size(289, 62);
            label1.TabIndex = 7;
            label1.Text = "🗂 All Running Processes\n\n";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(645, 21);
            label2.Name = "label2";
            label2.Size = new Size(235, 62);
            label2.TabIndex = 8;
            label2.Text = "⭐ Favorite Processes\n\n";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 473);
            Controls.Add(btnKillFavorites);
            Controls.Add(btnAddFavourite);
            Controls.Add(buttonRemoveFavourite);
            Controls.Add(listViewFavourites);
            Controls.Add(btnKill);
            Controls.Add(btnRefresh);
            Controls.Add(listViewProcesses);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RAMCleaner – Custom Process Controller";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewProcesses;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btnRefresh;
        private Button btnKill;
        private ListView listViewFavourites;
        private ColumnHeader columnHeader4;
        private Button buttonRemoveFavourite;
        private Button btnAddFavourite;
        private Button btnKillFavorites;
        private Label label1;
        private Label label2;
        private ImageList imageListProcess;
    }
}
