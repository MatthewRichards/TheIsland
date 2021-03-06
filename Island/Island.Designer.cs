﻿namespace Island
{
  partial class Island
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
      this.components = new System.ComponentModel.Container();
      this.WorldImage = new System.Windows.Forms.PictureBox();
      this.Clock = new System.Windows.Forms.Timer(this.components);
      this.TimeLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.WorldImage)).BeginInit();
      this.SuspendLayout();
      // 
      // WorldImage
      // 
      this.WorldImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WorldImage.Location = new System.Drawing.Point(0, 0);
      this.WorldImage.Name = "WorldImage";
      this.WorldImage.Size = new System.Drawing.Size(785, 488);
      this.WorldImage.TabIndex = 0;
      this.WorldImage.TabStop = false;
      this.WorldImage.Paint += new System.Windows.Forms.PaintEventHandler(this.WorldImage_Paint);
      // 
      // Clock
      // 
      this.Clock.Enabled = true;
      this.Clock.Interval = 50;
      this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
      // 
      // TimeLabel
      // 
      this.TimeLabel.AutoSize = true;
      this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.TimeLabel.Location = new System.Drawing.Point(0, 475);
      this.TimeLabel.Name = "TimeLabel";
      this.TimeLabel.Size = new System.Drawing.Size(105, 13);
      this.TimeLabel.TabIndex = 1;
      this.TimeLabel.Text = "Time: The Beginning";
      // 
      // Island
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(785, 488);
      this.Controls.Add(this.TimeLabel);
      this.Controls.Add(this.WorldImage);
      this.Name = "Island";
      this.Text = "Island";
      ((System.ComponentModel.ISupportInitialize)(this.WorldImage)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox WorldImage;
    private System.Windows.Forms.Timer Clock;
    private System.Windows.Forms.Label TimeLabel;
  }
}

