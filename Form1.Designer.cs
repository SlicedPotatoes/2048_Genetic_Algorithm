namespace _2048_Génétic_Algorithm
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btnNextGen = new Button();
            label1 = new Label();
            labelGeneration = new Label();
            btnInit = new Button();
            checkBox1 = new CheckBox();
            selectedIndividu = new GroupBox();
            btnCopy = new Button();
            panelGrid = new TableLayoutPanel();
            selectSeed = new ComboBox();
            label2 = new Label();
            labelTrainingTime = new Label();
            timerStart = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            labelGenTime = new Label();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            exporterToolStripMenuItem = new ToolStripMenuItem();
            importerToolStripMenuItem = new ToolStripMenuItem();
            selectedIndividu.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView1.Location = new Point(12, 27);
            listView1.Name = "listView1";
            listView1.Size = new Size(764, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Rank";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Poid1";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Poid2";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Poid3";
            columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Poid4";
            columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Poid5";
            columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Score";
            columnHeader7.Width = 120;
            // 
            // btnNextGen
            // 
            btnNextGen.Location = new Point(959, 45);
            btnNextGen.Name = "btnNextGen";
            btnNextGen.Size = new Size(171, 23);
            btnNextGen.TabIndex = 1;
            btnNextGen.Text = "NextGen";
            btnNextGen.UseVisualStyleBackColor = true;
            btnNextGen.Click += btnNextGen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(782, 27);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 2;
            label1.Text = "Génération: ";
            // 
            // labelGeneration
            // 
            labelGeneration.AutoSize = true;
            labelGeneration.Location = new Point(859, 27);
            labelGeneration.Name = "labelGeneration";
            labelGeneration.Size = new Size(13, 15);
            labelGeneration.TabIndex = 3;
            labelGeneration.Text = "0";
            // 
            // btnInit
            // 
            btnInit.Location = new Point(782, 45);
            btnInit.Name = "btnInit";
            btnInit.Size = new Size(171, 23);
            btnInit.TabIndex = 4;
            btnInit.Text = "Initialise";
            btnInit.UseVisualStyleBackColor = true;
            btnInit.Click += btnInit_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1049, 23);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(73, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "AutoGen";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // selectedIndividu
            // 
            selectedIndividu.Controls.Add(btnCopy);
            selectedIndividu.Controls.Add(panelGrid);
            selectedIndividu.Controls.Add(selectSeed);
            selectedIndividu.Location = new Point(782, 99);
            selectedIndividu.Name = "selectedIndividu";
            selectedIndividu.Size = new Size(348, 360);
            selectedIndividu.TabIndex = 6;
            selectedIndividu.TabStop = false;
            selectedIndividu.Text = "Individu Selectionné";
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(133, 21);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(187, 23);
            btnCopy.TabIndex = 4;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // panelGrid
            // 
            panelGrid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panelGrid.ColumnCount = 4;
            panelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panelGrid.Location = new Point(20, 54);
            panelGrid.Name = "panelGrid";
            panelGrid.RowCount = 4;
            panelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelGrid.Size = new Size(300, 300);
            panelGrid.TabIndex = 3;
            // 
            // selectSeed
            // 
            selectSeed.FormattingEnabled = true;
            selectSeed.Location = new Point(6, 22);
            selectSeed.Name = "selectSeed";
            selectSeed.Size = new Size(121, 23);
            selectSeed.TabIndex = 1;
            selectSeed.SelectedIndexChanged += selectSeed_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(782, 71);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 7;
            label2.Text = "Training Time:";
            // 
            // labelTrainingTime
            // 
            labelTrainingTime.AutoSize = true;
            labelTrainingTime.Location = new Point(898, 71);
            labelTrainingTime.Name = "labelTrainingTime";
            labelTrainingTime.Size = new Size(55, 15);
            labelTrainingTime.TabIndex = 8;
            labelTrainingTime.Text = "000:00:00";
            // 
            // timerStart
            // 
            timerStart.Interval = 1000;
            timerStart.Tick += timerStart_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(959, 71);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 9;
            label4.Text = "This Gen Time: ";
            // 
            // labelGenTime
            // 
            labelGenTime.AutoSize = true;
            labelGenTime.Location = new Point(1067, 71);
            labelGenTime.Name = "labelGenTime";
            labelGenTime.Size = new Size(55, 15);
            labelGenTime.TabIndex = 10;
            labelGenTime.Text = "000:00:00";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1134, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { exporterToolStripMenuItem, importerToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(54, 20);
            toolStripMenuItem1.Text = "Fichier";
            // 
            // exporterToolStripMenuItem
            // 
            exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            exporterToolStripMenuItem.Size = new Size(180, 22);
            exporterToolStripMenuItem.Text = "Exporter";
            exporterToolStripMenuItem.Click += exporterToolStripMenuItem_Click;
            // 
            // importerToolStripMenuItem
            // 
            importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            importerToolStripMenuItem.Size = new Size(180, 22);
            importerToolStripMenuItem.Text = "Importer";
            importerToolStripMenuItem.Click += importerToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 471);
            Controls.Add(labelGenTime);
            Controls.Add(label4);
            Controls.Add(labelTrainingTime);
            Controls.Add(label2);
            Controls.Add(selectedIndividu);
            Controls.Add(checkBox1);
            Controls.Add(btnInit);
            Controls.Add(labelGeneration);
            Controls.Add(label1);
            Controls.Add(btnNextGen);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            selectedIndividu.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader7;
        private Button btnNextGen;
        private Label label1;
        private Label labelGeneration;
        private Button btnInit;
        private CheckBox checkBox1;
        private GroupBox selectedIndividu;
        private ComboBox selectSeed;
        private TableLayoutPanel panelGrid;
        private Button btnCopy;
        private Label label2;
        private Label labelTrainingTime;
        private System.Windows.Forms.Timer timerStart;
        private Label label4;
        private Label labelGenTime;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem exporterToolStripMenuItem;
        private ToolStripMenuItem importerToolStripMenuItem;
    }
}