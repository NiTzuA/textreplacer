namespace textreplacernitzua
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.normalText = new System.Windows.Forms.Label();
            this.normalTextBox = new System.Windows.Forms.TextBox();
            this.replaceText = new System.Windows.Forms.Label();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.normalText);
            this.flowLayoutPanel1.Controls.Add(this.normalTextBox);
            this.flowLayoutPanel1.Controls.Add(this.replaceText);
            this.flowLayoutPanel1.Controls.Add(this.replaceTextBox);
            this.flowLayoutPanel1.Controls.Add(this.startButton);
            this.flowLayoutPanel1.Controls.Add(this.stopButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 154);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // normalText
            // 
            this.normalText.AutoSize = true;
            this.normalText.Location = new System.Drawing.Point(3, 0);
            this.normalText.Name = "normalText";
            this.normalText.Size = new System.Drawing.Size(63, 15);
            this.normalText.TabIndex = 0;
            this.normalText.Text = "Target Text";
            // 
            // normalTextBox
            // 
            this.normalTextBox.Location = new System.Drawing.Point(3, 18);
            this.normalTextBox.Name = "normalTextBox";
            this.normalTextBox.Size = new System.Drawing.Size(237, 23);
            this.normalTextBox.TabIndex = 1;
            this.normalTextBox.TextChanged += new System.EventHandler(this.normalTextBox_TextChanged);
            // 
            // replaceText
            // 
            this.replaceText.AutoSize = true;
            this.replaceText.Location = new System.Drawing.Point(3, 44);
            this.replaceText.Name = "replaceText";
            this.replaceText.Size = new System.Drawing.Size(76, 15);
            this.replaceText.TabIndex = 2;
            this.replaceText.Text = "Raplace With";
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Location = new System.Drawing.Point(3, 62);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(237, 23);
            this.replaceTextBox.TabIndex = 3;
            this.replaceTextBox.TextChanged += new System.EventHandler(this.replaceTextBox_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(3, 91);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(237, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start Replacing";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(3, 120);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(237, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop Replacing";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 174);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "NiTzuA\'s Text Replacer";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label normalText;
        private TextBox normalTextBox;
        private Label replaceText;
        private TextBox replaceTextBox;
        private Button startButton;
        private Button stopButton;
    }
}