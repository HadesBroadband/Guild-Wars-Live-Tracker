namespace Player_Tracker_Lite
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
            this.xPos = new System.Windows.Forms.Label();
            this.yPos = new System.Windows.Forms.Label();
            this.zPos = new System.Windows.Forms.Label();
            this.mapID = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.mLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xPos
            // 
            this.xPos.AutoSize = true;
            this.xPos.Location = new System.Drawing.Point(12, 9);
            this.xPos.Name = "xPos";
            this.xPos.Size = new System.Drawing.Size(42, 13);
            this.xPos.TabIndex = 0;
            this.xPos.Text = "X POS:";
            // 
            // yPos
            // 
            this.yPos.AutoSize = true;
            this.yPos.Location = new System.Drawing.Point(12, 34);
            this.yPos.Name = "yPos";
            this.yPos.Size = new System.Drawing.Size(42, 13);
            this.yPos.TabIndex = 1;
            this.yPos.Text = "Y POS:";
            // 
            // zPos
            // 
            this.zPos.AutoSize = true;
            this.zPos.Location = new System.Drawing.Point(12, 60);
            this.zPos.Name = "zPos";
            this.zPos.Size = new System.Drawing.Size(42, 13);
            this.zPos.TabIndex = 2;
            this.zPos.Text = "Z POS:";
            // 
            // mapID
            // 
            this.mapID.AutoSize = true;
            this.mapID.Location = new System.Drawing.Point(12, 86);
            this.mapID.Name = "mapID";
            this.mapID.Size = new System.Drawing.Size(42, 13);
            this.mapID.TabIndex = 3;
            this.mapID.Text = "MAP   :";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(60, 9);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(13, 13);
            this.xLabel.TabIndex = 4;
            this.xLabel.Text = "0";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(60, 34);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(13, 13);
            this.yLabel.TabIndex = 5;
            this.yLabel.Text = "0";
            // 
            // zLabel
            // 
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(60, 60);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(13, 13);
            this.zLabel.TabIndex = 6;
            this.zLabel.Text = "0";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(60, 87);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(13, 13);
            this.mLabel.TabIndex = 7;
            this.mLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 109);
            this.Controls.Add(this.mLabel);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.mapID);
            this.Controls.Add(this.zPos);
            this.Controls.Add(this.yPos);
            this.Controls.Add(this.xPos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xPos;
        private System.Windows.Forms.Label yPos;
        private System.Windows.Forms.Label zPos;
        private System.Windows.Forms.Label mapID;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Label mLabel;
    }
}

