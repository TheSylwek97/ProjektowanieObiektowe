namespace Snake
{
    /// <summary>
    /// 
    /// </summary>
    partial class FrmSnake
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
            this.PbCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSocre = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // PbCanvas
            // 
            this.PbCanvas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PbCanvas.Location = new System.Drawing.Point(13, 13);
            this.PbCanvas.Name = "PbCanvas";
            this.PbCanvas.Size = new System.Drawing.Size(611, 308);
            this.PbCanvas.TabIndex = 0;
            this.PbCanvas.TabStop = false;
            this.PbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PbCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(630, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Punkty:";
            // 
            // lblSocre
            // 
            this.lblSocre.AutoSize = true;
            this.lblSocre.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSocre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSocre.Location = new System.Drawing.Point(630, 79);
            this.lblSocre.Name = "lblSocre";
            this.lblSocre.Size = new System.Drawing.Size(0, 37);
            this.lblSocre.TabIndex = 2;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGameOver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGameOver.Location = new System.Drawing.Point(27, 79);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Padding = new System.Windows.Forms.Padding(10);
            this.lblGameOver.Size = new System.Drawing.Size(398, 75);
            this.lblGameOver.TabIndex = 3;
            this.lblGameOver.Text = "Game Over Text";
            this.lblGameOver.Visible = false;
            // 
            // FrmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(843, 361);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblSocre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbCanvas);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmSnake";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSnake_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSnake_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSocre;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblGameOver;
    }
}

