namespace HeroSurvivor
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
            this.ofdReader = new System.Windows.Forms.OpenFileDialog();
            this.ofdWriter = new System.Windows.Forms.OpenFileDialog();
            this.btnReader = new System.Windows.Forms.Button();
            this.btnWriter = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.readFilePath = new System.Windows.Forms.Label();
            this.writeFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ofdReader
            // 
            this.ofdReader.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdReader_FileOk);
            // 
            // ofdWriter
            // 
            this.ofdWriter.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdWriter_FileOk);
            // 
            // btnReader
            // 
            this.btnReader.Location = new System.Drawing.Point(12, 12);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(136, 23);
            this.btnReader.TabIndex = 0;
            this.btnReader.Text = "Select Input File";
            this.btnReader.UseVisualStyleBackColor = true;
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
            // 
            // btnWriter
            // 
            this.btnWriter.Location = new System.Drawing.Point(12, 42);
            this.btnWriter.Name = "btnWriter";
            this.btnWriter.Size = new System.Drawing.Size(136, 23);
            this.btnWriter.TabIndex = 1;
            this.btnWriter.Text = "Select Output File";
            this.btnWriter.UseVisualStyleBackColor = true;
            this.btnWriter.Click += new System.EventHandler(this.btnWriter_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Game!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // readFilePath
            // 
            this.readFilePath.AutoSize = true;
            this.readFilePath.Location = new System.Drawing.Point(154, 17);
            this.readFilePath.Name = "readFilePath";
            this.readFilePath.Size = new System.Drawing.Size(69, 13);
            this.readFilePath.TabIndex = 3;
            this.readFilePath.Text = "Not Selected";
            // 
            // writeFilePath
            // 
            this.writeFilePath.AutoSize = true;
            this.writeFilePath.Location = new System.Drawing.Point(154, 47);
            this.writeFilePath.Name = "writeFilePath";
            this.writeFilePath.Size = new System.Drawing.Size(69, 13);
            this.writeFilePath.TabIndex = 4;
            this.writeFilePath.Text = "Not Selected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 108);
            this.Controls.Add(this.writeFilePath);
            this.Controls.Add(this.readFilePath);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnWriter);
            this.Controls.Add(this.btnReader);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdReader;
        private System.Windows.Forms.OpenFileDialog ofdWriter;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.Button btnWriter;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label readFilePath;
        private System.Windows.Forms.Label writeFilePath;
    }
}

