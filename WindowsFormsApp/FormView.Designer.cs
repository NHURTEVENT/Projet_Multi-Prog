namespace RoomView
{
    partial class FormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Clear = new System.Windows.Forms.Button();
            this.TimeX10 = new System.Windows.Forms.Button();
            this.TimeX1 = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.Logs = new System.Windows.Forms.RichTextBox();
            this.ticks = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::RoomView.Properties.Resources.map;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Clear);
            this.splitContainer2.Panel1.Controls.Add(this.TimeX10);
            this.splitContainer2.Panel1.Controls.Add(this.TimeX1);
            this.splitContainer2.Panel1.Controls.Add(this.Pause);
            this.splitContainer2.Panel1.Controls.Add(this.Play);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.title);
            this.splitContainer2.Panel2.Controls.Add(this.Logs);
            // 
            // Clear
            // 
            resources.ApplyResources(this.Clear, "Clear");
            this.Clear.Name = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // TimeX10
            // 
            this.TimeX10.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.TimeX10, "TimeX10");
            this.TimeX10.Name = "TimeX10";
            this.TimeX10.UseVisualStyleBackColor = false;
            this.TimeX10.Click += new System.EventHandler(this.TimeX10_Click);
            // 
            // TimeX1
            // 
            this.TimeX1.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.TimeX1, "TimeX1");
            this.TimeX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TimeX1.Name = "TimeX1";
            this.TimeX1.UseVisualStyleBackColor = false;
            this.TimeX1.Click += new System.EventHandler(this.TimeX1_Click);
            // 
            // Pause
            // 
            this.Pause.Image = global::RoomView.Properties.Resources.pauseSmall;
            resources.ApplyResources(this.Pause, "Pause");
            this.Pause.Name = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Play
            // 
            this.Play.Image = global::RoomView.Properties.Resources.play;
            resources.ApplyResources(this.Play, "Play");
            this.Play.Name = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // title
            // 
            resources.ApplyResources(this.title, "title");
            this.title.Name = "title";
            // 
            // Logs
            // 
            this.Logs.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.Logs, "Logs");
            this.Logs.Name = "Logs";
            this.Logs.ReadOnly = true;
            this.Logs.TextChanged += new System.EventHandler(this.Logs_TextChanged);
            // 
            // ticks
            // 
            this.ticks.Interval = 1000;
            this.ticks.Tick += new System.EventHandler(this.ticks_Tick);
            // 
            // FormView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.FormView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormView_Paint);
            this.Resize += new System.EventHandler(this.FormView_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button TimeX10;
        private System.Windows.Forms.Button TimeX1;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Timer ticks;
        private System.Windows.Forms.RichTextBox Logs;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label title;
    }
}

