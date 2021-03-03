
namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.chatLbl = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.maximizeBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.cLB = new System.Windows.Forms.CheckedListBox();
            this.usersLbl = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.fLP = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nickTB = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rTB = new System.Windows.Forms.RichTextBox();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.chatLbl);
            this.panelTop.Controls.Add(this.minimizeBtn);
            this.panelTop.Controls.Add(this.maximizeBtn);
            this.panelTop.Controls.Add(this.exitBtn);
            this.panelTop.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 40);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // chatLbl
            // 
            this.chatLbl.AutoSize = true;
            this.chatLbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.chatLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.chatLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chatLbl.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatLbl.ForeColor = System.Drawing.Color.Aqua;
            this.chatLbl.Location = new System.Drawing.Point(0, 0);
            this.chatLbl.Margin = new System.Windows.Forms.Padding(5);
            this.chatLbl.Name = "chatLbl";
            this.chatLbl.Padding = new System.Windows.Forms.Padding(8);
            this.chatLbl.Size = new System.Drawing.Size(124, 44);
            this.chatLbl.TabIndex = 3;
            this.chatLbl.Text = "VM_Chat";
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Yellow;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.Location = new System.Drawing.Point(716, 12);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(20, 20);
            this.minimizeBtn.TabIndex = 2;
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_Paint);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.BackColor = System.Drawing.Color.LightGreen;
            this.maximizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maximizeBtn.Location = new System.Drawing.Point(742, 12);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(20, 20);
            this.maximizeBtn.TabIndex = 1;
            this.maximizeBtn.UseVisualStyleBackColor = false;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            this.maximizeBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_Paint);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitBtn.Location = new System.Drawing.Point(768, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(20, 20);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_Paint);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Black;
            this.panelLeft.Controls.Add(this.cLB);
            this.panelLeft.Controls.Add(this.usersLbl);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 40);
            this.panelLeft.MaximumSize = new System.Drawing.Size(500, 0);
            this.panelLeft.MinimumSize = new System.Drawing.Size(100, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(228, 410);
            this.panelLeft.TabIndex = 1;
            // 
            // cLB
            // 
            this.cLB.BackColor = System.Drawing.Color.Black;
            this.cLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cLB.CheckOnClick = true;
            this.cLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cLB.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cLB.FormattingEnabled = true;
            this.cLB.Location = new System.Drawing.Point(0, 54);
            this.cLB.Name = "cLB";
            this.cLB.Size = new System.Drawing.Size(228, 356);
            this.cLB.Sorted = true;
            this.cLB.TabIndex = 1;
            this.cLB.UseCompatibleTextRendering = true;
            this.cLB.SelectedIndexChanged += new System.EventHandler(this.cLB_SelectedIndexChanged);
            // 
            // usersLbl
            // 
            this.usersLbl.AutoSize = true;
            this.usersLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.usersLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.usersLbl.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usersLbl.ForeColor = System.Drawing.Color.LightGreen;
            this.usersLbl.Location = new System.Drawing.Point(0, 0);
            this.usersLbl.Name = "usersLbl";
            this.usersLbl.Padding = new System.Windows.Forms.Padding(15);
            this.usersLbl.Size = new System.Drawing.Size(95, 54);
            this.usersLbl.TabIndex = 0;
            this.usersLbl.Text = "Users:";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightGreen;
            this.splitter1.Location = new System.Drawing.Point(228, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 410);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.LightGreen;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(233, 312);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(567, 5);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // fLP
            // 
            this.fLP.AutoScroll = true;
            this.fLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fLP.BackColor = System.Drawing.Color.Black;
            this.fLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLP.Location = new System.Drawing.Point(233, 40);
            this.fLP.Name = "fLP";
            this.fLP.Size = new System.Drawing.Size(567, 272);
            this.fLP.TabIndex = 5;
            this.fLP.Paint += new System.Windows.Forms.PaintEventHandler(this.fLP_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.LightGreen;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(116, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nickname:";
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.Color.Aqua;
            this.sendBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.sendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sendBtn.Location = new System.Drawing.Point(467, 0);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(100, 36);
            this.sendBtn.TabIndex = 7;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            this.sendBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.Btn_Paint);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(447, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(20, 0);
            this.panel2.MinimumSize = new System.Drawing.Size(20, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 36);
            this.panel2.TabIndex = 8;
            // 
            // nickTB
            // 
            this.nickTB.BackColor = System.Drawing.Color.Black;
            this.nickTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nickTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nickTB.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nickTB.ForeColor = System.Drawing.Color.Aqua;
            this.nickTB.Location = new System.Drawing.Point(116, 0);
            this.nickTB.Margin = new System.Windows.Forms.Padding(5);
            this.nickTB.Name = "nickTB";
            this.nickTB.Size = new System.Drawing.Size(331, 32);
            this.nickTB.TabIndex = 9;
            this.nickTB.Text = "enter nickname";
            this.nickTB.TextChanged += new System.EventHandler(this.nickTB_TextChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Black;
            this.panelBottom.Controls.Add(this.nickTB);
            this.panelBottom.Controls.Add(this.panel2);
            this.panelBottom.Controls.Add(this.sendBtn);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Controls.Add(this.panel1);
            this.panelBottom.Controls.Add(this.rTB);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(233, 317);
            this.panelBottom.MinimumSize = new System.Drawing.Size(0, 100);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(567, 133);
            this.panelBottom.TabIndex = 3;
            this.panelBottom.SizeChanged += new System.EventHandler(this.panelBottom_SizeChanged);
            this.panelBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelBottom_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 1);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 1);
            this.panel1.TabIndex = 2;
            // 
            // rTB
            // 
            this.rTB.BackColor = System.Drawing.Color.Black;
            this.rTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rTB.Location = new System.Drawing.Point(0, 37);
            this.rTB.Name = "rTB";
            this.rTB.Size = new System.Drawing.Size(567, 96);
            this.rTB.TabIndex = 1;
            this.rTB.Text = "message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fLP);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button maximizeBtn;
        private System.Windows.Forms.Label chatLbl;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label usersLbl;
        private System.Windows.Forms.CheckedListBox cLB;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.FlowLayoutPanel fLP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox nickTB;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.RichTextBox rTB;
        private System.Windows.Forms.Panel panel1;
    }
}

