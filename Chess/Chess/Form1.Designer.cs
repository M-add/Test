namespace Chess
{
    partial class Form1
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TurnPanel = new System.Windows.Forms.Panel();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.TurnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.AutoScroll = true;
            this.LayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(164)))), ((int)(((byte)(133)))));
            this.LayoutPanel.ColumnCount = 8;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(5, 33);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 8;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.LayoutPanel.Size = new System.Drawing.Size(1164, 723);
            this.LayoutPanel.TabIndex = 1;
            // 
            // TurnPanel
            // 
            this.TurnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(127)))), ((int)(((byte)(83)))));
            this.TurnPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TurnPanel.Controls.Add(this.TurnLabel);
            this.TurnPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TurnPanel.Location = new System.Drawing.Point(5, 5);
            this.TurnPanel.Name = "TurnPanel";
            this.TurnPanel.Size = new System.Drawing.Size(1164, 28);
            this.TurnPanel.TabIndex = 2;
            // 
            // TurnLabel
            // 
            this.TurnLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TurnLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TurnLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLabel.Location = new System.Drawing.Point(977, 0);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(183, 24);
            this.TurnLabel.TabIndex = 0;
            this.TurnLabel.Text = "White\'s Turn";
            this.TurnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(119)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(1174, 761);
            this.Controls.Add(this.LayoutPanel);
            this.Controls.Add(this.TurnPanel);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1Load);
            this.TurnPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.Panel TurnPanel;
        private System.Windows.Forms.Label TurnLabel;
    }
}

