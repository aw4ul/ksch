namespace Quiz
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.comboBoxTopics = new System.Windows.Forms.ComboBox();
            this.lblSelectTopic = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.answerPanel = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblOverall = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelHeader.Controls.Add(this.lblSelectTopic);
            this.panelHeader.Controls.Add(this.comboBoxTopics);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(540, 60);
            this.panelHeader.TabIndex = 100;
            // 
            // comboBoxTopics
            // 
            this.comboBoxTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTopics.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxTopics.FormattingEnabled = true;
            this.comboBoxTopics.Location = new System.Drawing.Point(160, 14);
            this.comboBoxTopics.Name = "comboBoxTopics";
            this.comboBoxTopics.Size = new System.Drawing.Size(280, 28);
            this.comboBoxTopics.TabIndex = 0;
            this.comboBoxTopics.SelectedIndexChanged += new System.EventHandler(this.comboBoxTopics_SelectedIndexChanged);
            // 
            // lblSelectTopic
            // 
            this.lblSelectTopic.AutoSize = true;
            this.lblSelectTopic.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectTopic.ForeColor = System.Drawing.Color.White;
            this.lblSelectTopic.Location = new System.Drawing.Point(25, 17);
            this.lblSelectTopic.Name = "lblSelectTopic";
            this.lblSelectTopic.Size = new System.Drawing.Size(120, 21);
            this.lblSelectTopic.TabIndex = 1;
            this.lblSelectTopic.Text = "Оберіть тему:";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(540, 420);
            this.panelMain.TabIndex = 101;
            this.panelMain.Controls.Add(this.lblQuestion);
            this.panelMain.Controls.Add(this.answerPanel);
            this.panelMain.Controls.Add(this.btnSubmit);
            this.panelMain.Controls.Add(this.lblResult);
            this.panelMain.Controls.Add(this.lblOverall);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblQuestion.Location = new System.Drawing.Point(24, 18);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(495, 54);
            this.lblQuestion.TabIndex = 2;
            // 
            // answerPanel
            // 
            this.answerPanel.BackColor = System.Drawing.Color.White;
            this.answerPanel.Location = new System.Drawing.Point(24, 75);
            this.answerPanel.Name = "answerPanel";
            this.answerPanel.Size = new System.Drawing.Size(495, 190);
            this.answerPanel.TabIndex = 3;
            this.answerPanel.AutoScroll = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(24, 281);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 38);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Відповісти";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(160, 281);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(359, 60); // ЗБІЛЬШЕНО ВИСОТУ!
            this.lblResult.TabIndex = 5;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverall
            // 
            this.lblOverall.BackColor = System.Drawing.Color.Transparent;
            this.lblOverall.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblOverall.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblOverall.Location = new System.Drawing.Point(24, 345);
            this.lblOverall.Name = "lblOverall";
            this.lblOverall.Size = new System.Drawing.Size(495, 60);
            this.lblOverall.TabIndex = 6;
            this.lblOverall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(540, 480);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTopics;
        private System.Windows.Forms.Label lblSelectTopic;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel answerPanel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblOverall;
    }
}