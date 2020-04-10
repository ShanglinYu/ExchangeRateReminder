namespace ExchangeRateReminder
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
            this.components = new System.ComponentModel.Container();
            this.cbbLeft = new System.Windows.Forms.ComboBox();
            this.cbbRight = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDirection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAlertPrice1 = new System.Windows.Forms.TextBox();
            this.btnSetAlert1 = new System.Windows.Forms.Button();
            this.cbAlertCondition1 = new System.Windows.Forms.ComboBox();
            this.gbAlert = new System.Windows.Forms.GroupBox();
            this.btnCancelAlert2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetAlert2 = new System.Windows.Forms.Button();
            this.cbAlertCondition2 = new System.Windows.Forms.ComboBox();
            this.tbAlertPrice2 = new System.Windows.Forms.TextBox();
            this.btnCancelAlert1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.gbAlert.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbLeft
            // 
            this.cbbLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLeft.FormattingEnabled = true;
            this.cbbLeft.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbbLeft.Items.AddRange(new object[] {
            "USD",
            "SGD",
            "CNY",
            "HKD",
            "MOP",
            "EUR",
            "GBP",
            "AUD",
            "CHF",
            "CAD",
            "NZD",
            "RUB",
            "KRW",
            "THB"});
            this.cbbLeft.Location = new System.Drawing.Point(12, 12);
            this.cbbLeft.Name = "cbbLeft";
            this.cbbLeft.Size = new System.Drawing.Size(63, 20);
            this.cbbLeft.TabIndex = 1;
            // 
            // cbbRight
            // 
            this.cbbRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRight.FormattingEnabled = true;
            this.cbbRight.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbbRight.Items.AddRange(new object[] {
            "USD",
            "SGD",
            "CNY",
            "HKD",
            "MOP",
            "EUR",
            "GBP",
            "AUD",
            "CHF",
            "CAD",
            "NZD",
            "RUB",
            "KRW",
            "THB"});
            this.cbbRight.Location = new System.Drawing.Point(127, 12);
            this.cbbRight.Name = "cbbRight";
            this.cbbRight.Size = new System.Drawing.Size(65, 20);
            this.cbbRight.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 241);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(333, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 38);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.Size = new System.Drawing.Size(309, 120);
            this.tbOutput.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(202, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(54, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(267, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(54, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDirection
            // 
            this.btnDirection.Location = new System.Drawing.Point(81, 10);
            this.btnDirection.Name = "btnDirection";
            this.btnDirection.Size = new System.Drawing.Size(40, 23);
            this.btnDirection.TabIndex = 8;
            this.btnDirection.Text = "-->";
            this.btnDirection.UseVisualStyleBackColor = true;
            this.btnDirection.Click += new System.EventHandler(this.btnDirection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Price:";
            // 
            // tbAlertPrice1
            // 
            this.tbAlertPrice1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbAlertPrice1.Location = new System.Drawing.Point(96, 15);
            this.tbAlertPrice1.Name = "tbAlertPrice1";
            this.tbAlertPrice1.Size = new System.Drawing.Size(87, 21);
            this.tbAlertPrice1.TabIndex = 10;
            // 
            // btnSetAlert1
            // 
            this.btnSetAlert1.Location = new System.Drawing.Point(189, 14);
            this.btnSetAlert1.Name = "btnSetAlert1";
            this.btnSetAlert1.Size = new System.Drawing.Size(55, 23);
            this.btnSetAlert1.TabIndex = 11;
            this.btnSetAlert1.Text = "Set";
            this.btnSetAlert1.UseVisualStyleBackColor = true;
            this.btnSetAlert1.Click += new System.EventHandler(this.btnSetAlert1_Click);
            // 
            // cbAlertCondition1
            // 
            this.cbAlertCondition1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlertCondition1.FormattingEnabled = true;
            this.cbAlertCondition1.Items.AddRange(new object[] {
            "=",
            ">",
            ">=",
            "<",
            "<="});
            this.cbAlertCondition1.Location = new System.Drawing.Point(50, 16);
            this.cbAlertCondition1.Name = "cbAlertCondition1";
            this.cbAlertCondition1.Size = new System.Drawing.Size(40, 20);
            this.cbAlertCondition1.TabIndex = 12;
            // 
            // gbAlert
            // 
            this.gbAlert.Controls.Add(this.btnCancelAlert2);
            this.gbAlert.Controls.Add(this.label2);
            this.gbAlert.Controls.Add(this.btnSetAlert2);
            this.gbAlert.Controls.Add(this.cbAlertCondition2);
            this.gbAlert.Controls.Add(this.tbAlertPrice2);
            this.gbAlert.Controls.Add(this.btnCancelAlert1);
            this.gbAlert.Controls.Add(this.label1);
            this.gbAlert.Controls.Add(this.btnSetAlert1);
            this.gbAlert.Controls.Add(this.cbAlertCondition1);
            this.gbAlert.Controls.Add(this.tbAlertPrice1);
            this.gbAlert.Enabled = false;
            this.gbAlert.Location = new System.Drawing.Point(12, 164);
            this.gbAlert.Name = "gbAlert";
            this.gbAlert.Size = new System.Drawing.Size(309, 74);
            this.gbAlert.TabIndex = 13;
            this.gbAlert.TabStop = false;
            this.gbAlert.Text = "Alert";
            // 
            // btnCancelAlert2
            // 
            this.btnCancelAlert2.Location = new System.Drawing.Point(250, 43);
            this.btnCancelAlert2.Name = "btnCancelAlert2";
            this.btnCancelAlert2.Size = new System.Drawing.Size(55, 23);
            this.btnCancelAlert2.TabIndex = 18;
            this.btnCancelAlert2.Text = "Cancel";
            this.btnCancelAlert2.UseVisualStyleBackColor = true;
            this.btnCancelAlert2.Click += new System.EventHandler(this.btnCancelAlert2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Price:";
            // 
            // btnSetAlert2
            // 
            this.btnSetAlert2.Location = new System.Drawing.Point(189, 43);
            this.btnSetAlert2.Name = "btnSetAlert2";
            this.btnSetAlert2.Size = new System.Drawing.Size(55, 23);
            this.btnSetAlert2.TabIndex = 16;
            this.btnSetAlert2.Text = "Set";
            this.btnSetAlert2.UseVisualStyleBackColor = true;
            this.btnSetAlert2.Click += new System.EventHandler(this.btnSetAlert2_Click);
            // 
            // cbAlertCondition2
            // 
            this.cbAlertCondition2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlertCondition2.FormattingEnabled = true;
            this.cbAlertCondition2.Items.AddRange(new object[] {
            "=",
            ">",
            ">=",
            "<",
            "<="});
            this.cbAlertCondition2.Location = new System.Drawing.Point(50, 45);
            this.cbAlertCondition2.Name = "cbAlertCondition2";
            this.cbAlertCondition2.Size = new System.Drawing.Size(40, 20);
            this.cbAlertCondition2.TabIndex = 17;
            // 
            // tbAlertPrice2
            // 
            this.tbAlertPrice2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tbAlertPrice2.Location = new System.Drawing.Point(96, 44);
            this.tbAlertPrice2.Name = "tbAlertPrice2";
            this.tbAlertPrice2.Size = new System.Drawing.Size(87, 21);
            this.tbAlertPrice2.TabIndex = 15;
            // 
            // btnCancelAlert1
            // 
            this.btnCancelAlert1.Location = new System.Drawing.Point(250, 14);
            this.btnCancelAlert1.Name = "btnCancelAlert1";
            this.btnCancelAlert1.Size = new System.Drawing.Size(55, 23);
            this.btnCancelAlert1.TabIndex = 13;
            this.btnCancelAlert1.Text = "Cancel";
            this.btnCancelAlert1.UseVisualStyleBackColor = true;
            this.btnCancelAlert1.Click += new System.EventHandler(this.btnCancelAlert1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 48);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.showWindowToolStripMenuItem.Text = "Show Window";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 263);
            this.Controls.Add(this.gbAlert);
            this.Controls.Add(this.btnDirection);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbbRight);
            this.Controls.Add(this.cbbLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ERR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.Form1_TextChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbAlert.ResumeLayout(false);
            this.gbAlert.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbLeft;
        private System.Windows.Forms.ComboBox cbbRight;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAlertPrice1;
        private System.Windows.Forms.Button btnSetAlert1;
        private System.Windows.Forms.ComboBox cbAlertCondition1;
        private System.Windows.Forms.GroupBox gbAlert;
        private System.Windows.Forms.Button btnCancelAlert1;
        private System.Windows.Forms.Button btnCancelAlert2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetAlert2;
        private System.Windows.Forms.ComboBox cbAlertCondition2;
        private System.Windows.Forms.TextBox tbAlertPrice2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

