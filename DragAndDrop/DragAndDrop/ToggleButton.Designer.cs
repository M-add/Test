﻿namespace DragAndDrop
{
    partial class ToggleButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToggleButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ToggleButton";
            this.Size = new System.Drawing.Size(190, 90);
            this.Load += new System.EventHandler(this.ToggleButton_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ToggleButton_MouseClick);
            this.Resize += new System.EventHandler(this.ToggleButtonResize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
