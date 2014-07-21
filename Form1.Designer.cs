namespace MYinkscape
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.VertexButton = new System.Windows.Forms.ToolStripButton();
            this.EdgeCostTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.EdgeOneWayButton = new System.Windows.Forms.ToolStripButton();
            this.EdgeTwoWayButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.ClearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DiameterButton = new System.Windows.Forms.ToolStripButton();
            this.MinPathButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpButton = new System.Windows.Forms.ToolStripButton();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.toolStripSeparator1,
            this.VertexButton,
            this.EdgeCostTextBox,
            this.EdgeOneWayButton,
            this.EdgeTwoWayButton,
            this.toolStripSeparator2,
            this.SelectButton,
            this.DeleteButton,
            this.ClearButton,
            this.toolStripSeparator3,
            this.DiameterButton,
            this.MinPathButton,
            this.toolStripSeparator4,
            this.HelpButton,
            this.AboutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1183, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = global::MYinkscape.Properties.Resources.open;
            this.OpenButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(28, 28);
            this.OpenButton.Text = "toolStripButton1";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = global::MYinkscape.Properties.Resources.save;
            this.SaveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(28, 28);
            this.SaveButton.Text = "toolStripButton2";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // VertexButton
            // 
            this.VertexButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.VertexButton.Image = global::MYinkscape.Properties.Resources.vertex;
            this.VertexButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VertexButton.Name = "VertexButton";
            this.VertexButton.Size = new System.Drawing.Size(28, 28);
            this.VertexButton.Text = "toolStripButton3";
            this.VertexButton.Click += new System.EventHandler(this.VertexButton_Click);
            // 
            // EdgeCostTextBox
            // 
            this.EdgeCostTextBox.Name = "EdgeCostTextBox";
            this.EdgeCostTextBox.Size = new System.Drawing.Size(100, 31);
            this.EdgeCostTextBox.Text = "5";
            // 
            // EdgeOneWayButton
            // 
            this.EdgeOneWayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EdgeOneWayButton.Image = global::MYinkscape.Properties.Resources.arrow1;
            this.EdgeOneWayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EdgeOneWayButton.Name = "EdgeOneWayButton";
            this.EdgeOneWayButton.Size = new System.Drawing.Size(28, 28);
            this.EdgeOneWayButton.Text = "toolStripButton4";
            this.EdgeOneWayButton.Click += new System.EventHandler(this.EdgeOneWayButton_Click);
            // 
            // EdgeTwoWayButton
            // 
            this.EdgeTwoWayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EdgeTwoWayButton.Image = global::MYinkscape.Properties.Resources.arrow2;
            this.EdgeTwoWayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EdgeTwoWayButton.Name = "EdgeTwoWayButton";
            this.EdgeTwoWayButton.Size = new System.Drawing.Size(28, 28);
            this.EdgeTwoWayButton.Text = "toolStripButton5";
            this.EdgeTwoWayButton.Click += new System.EventHandler(this.EdgeTwoWayButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // SelectButton
            // 
            this.SelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectButton.Image = global::MYinkscape.Properties.Resources.select;
            this.SelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(28, 28);
            this.SelectButton.Text = "toolStripButton3";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Image = global::MYinkscape.Properties.Resources.Delete;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(28, 28);
            this.DeleteButton.Text = "toolStripButton4";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearButton.Image = global::MYinkscape.Properties.Resources.clear;
            this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(28, 28);
            this.ClearButton.Text = "toolStripButton5";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // DiameterButton
            // 
            this.DiameterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DiameterButton.Image = global::MYinkscape.Properties.Resources.diam;
            this.DiameterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DiameterButton.Name = "DiameterButton";
            this.DiameterButton.Size = new System.Drawing.Size(28, 28);
            this.DiameterButton.Text = "toolStripButton3";
            this.DiameterButton.Click += new System.EventHandler(this.DiameterButton_Click);
            // 
            // MinPathButton
            // 
            this.MinPathButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MinPathButton.Image = global::MYinkscape.Properties.Resources.min;
            this.MinPathButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MinPathButton.Name = "MinPathButton";
            this.MinPathButton.Size = new System.Drawing.Size(28, 28);
            this.MinPathButton.Text = "toolStripButton4";
            this.MinPathButton.Click += new System.EventHandler(this.MinPathButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // HelpButton
            // 
            this.HelpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HelpButton.Image = global::MYinkscape.Properties.Resources.guide;
            this.HelpButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HelpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(23, 28);
            this.HelpButton.Text = "toolStripButton4";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Image = global::MYinkscape.Properties.Resources.about;
            this.AboutButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(23, 28);
            this.AboutButton.Text = "toolStripButton3";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(895, 259);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 417);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(1034, 259);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(137, 417);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(857, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(288, 216);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 764);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton VertexButton;
        private System.Windows.Forms.ToolStripTextBox EdgeCostTextBox;
        private System.Windows.Forms.ToolStripButton EdgeOneWayButton;
        private System.Windows.Forms.ToolStripButton EdgeTwoWayButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton DiameterButton;
        private System.Windows.Forms.ToolStripButton MinPathButton;
        private System.Windows.Forms.ToolStripButton SelectButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripButton ClearButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton HelpButton;
        private System.Windows.Forms.ToolStripButton AboutButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

