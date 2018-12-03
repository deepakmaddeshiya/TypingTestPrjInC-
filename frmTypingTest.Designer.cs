namespace TypingTest
{
    partial class FrmTypingTest
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
            this.lstStatistics = new System.Windows.Forms.ListBox();
            this.textPharase = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerTyping = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTestDone = new System.Windows.Forms.Button();
            this.textWrite = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lstStatistics
            // 
            this.lstStatistics.FormattingEnabled = true;
            this.lstStatistics.Location = new System.Drawing.Point(672, 27);
            this.lstStatistics.Name = "lstStatistics";
            this.lstStatistics.Size = new System.Drawing.Size(215, 303);
            this.lstStatistics.TabIndex = 6;
            // 
            // textPharase
            // 
            this.textPharase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPharase.Location = new System.Drawing.Point(21, 27);
            this.textPharase.Multiline = true;
            this.textPharase.Name = "textPharase";
            this.textPharase.ReadOnly = true;
            this.textPharase.Size = new System.Drawing.Size(580, 131);
            this.textPharase.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(812, 357);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // timerTyping
            // 
            this.timerTyping.Tick += new System.EventHandler(this.TimerTyping_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(710, 357);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnTestDone
            // 
            this.btnTestDone.Location = new System.Drawing.Point(609, 357);
            this.btnTestDone.Name = "btnTestDone";
            this.btnTestDone.Size = new System.Drawing.Size(75, 23);
            this.btnTestDone.TabIndex = 3;
            this.btnTestDone.Text = "Test Done";
            this.btnTestDone.UseVisualStyleBackColor = true;
            this.btnTestDone.Click += new System.EventHandler(this.BtnTestDone_Click);
            // 
            // textWrite
            // 
            this.textWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWrite.Location = new System.Drawing.Point(21, 216);
            this.textWrite.Name = "textWrite";
            this.textWrite.Size = new System.Drawing.Size(580, 131);
            this.textWrite.TabIndex = 2;
            this.textWrite.Text = "";
            this.textWrite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textWrite_OnKeyPressed);
            // 
            // FrmTypingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 411);
            this.Controls.Add(this.textWrite);
            this.Controls.Add(this.btnTestDone);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.textPharase);
            this.Controls.Add(this.lstStatistics);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(931, 450);
            this.MinimumSize = new System.Drawing.Size(931, 450);
            this.Name = "FrmTypingTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typing Test";
            this.Load += new System.EventHandler(this.FrmTypingTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstStatistics;
        private System.Windows.Forms.TextBox textPharase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerTyping;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTestDone;
        private System.Windows.Forms.RichTextBox textWrite;
    }
}

