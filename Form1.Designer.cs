namespace KRON
{
    partial class KRON
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KRON));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Closer = new System.Windows.Forms.Button();
            this.Mini = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Market = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TopPanel.BackgroundImage = global::KRON.Properties.Resources.Avatar;
            this.TopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TopPanel.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(250, 30);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(2, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "V II";
            // 
            // Closer
            // 
            this.Closer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Closer.BackgroundImage = global::KRON.Properties.Resources.Close;
            this.Closer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Closer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Closer.FlatAppearance.BorderSize = 0;
            this.Closer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closer.Location = new System.Drawing.Point(220, 0);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(30, 30);
            this.Closer.TabIndex = 1;
            this.Closer.UseVisualStyleBackColor = false;
            this.Closer.Click += new System.EventHandler(this.Closer_Click);
            // 
            // Mini
            // 
            this.Mini.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Mini.BackgroundImage = global::KRON.Properties.Resources.Move;
            this.Mini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Mini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mini.FlatAppearance.BorderSize = 0;
            this.Mini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mini.Location = new System.Drawing.Point(190, 0);
            this.Mini.Name = "Mini";
            this.Mini.Size = new System.Drawing.Size(30, 30);
            this.Mini.TabIndex = 2;
            this.Mini.UseVisualStyleBackColor = false;
            this.Mini.Click += new System.EventHandler(this.button1_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Location = new System.Drawing.Point(0, 120);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(125, 30);
            this.Start.TabIndex = 3;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(0, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 16);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(2, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quantity:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(64, 77);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 16);
            this.textBox2.TabIndex = 6;
            // 
            // Market
            // 
            this.Market.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Market.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Market.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Market.FlatAppearance.BorderSize = 0;
            this.Market.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Market.Location = new System.Drawing.Point(125, 120);
            this.Market.Name = "Market";
            this.Market.Size = new System.Drawing.Size(125, 30);
            this.Market.TabIndex = 7;
            this.Market.Text = "Market";
            this.Market.UseVisualStyleBackColor = false;
            this.Market.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // KRON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.Market);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Mini);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KRON";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button Closer;
        private System.Windows.Forms.Button Mini;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Market;
    }
}
