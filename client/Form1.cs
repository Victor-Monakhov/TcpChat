using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public interface ISubscriber
    {
        void LoadNews();
    }
    public partial class Form1 : Form , ISubscriber
    {
        private Render render;
        private Button[] allButtons;
        private int _labelCnt;
        private List<Label> _labels;
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
            render = new Render();
            allButtons = new Button[] { minimizeBtn, maximizeBtn, exitBtn, sendBtn};
            foreach (Button b in allButtons)
                b.Tag = false;
            _labelCnt = 0;
            _labels = new List<Label>();
            UpdateBtn();
            Client.Subscribe(this);
            ThreadStart start;
            thread = new Thread(start = delegate { while (Client.Work) Client.Run(); });
            thread.Start();
        }
         public void LoadNews()
        {
            PaintEventHandler paintHendler = new PaintEventHandler(fLP_Paint);
            paintHendler?.Invoke(fLP, new PaintEventArgs(fLP.CreateGraphics(), fLP.ClientRectangle));
            fLP.Invalidate();
        }
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            render.MouseCheckButtons(exitBtn, Btn_Paint, e.Location);
            render.MouseCheckButtons(minimizeBtn, Btn_Paint, e.Location);
            render.MouseCheckButtons(maximizeBtn, Btn_Paint, e.Location);
        }
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
            UpdateBtn();
            fLP.Invalidate();
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Client.Work = false;
                Thread.Sleep(500);
                thread.Abort();
                this.Close();
            }
            catch { }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == (object)panelTop && this.WindowState == FormWindowState.Normal)
                panelTop.Capture = false;
            else
                base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        }
        private void Btn_Paint(object sender, PaintEventArgs e)
        {
            exitBtn.Location = new Point(panelTop.Location.X + panelTop.Width - 30, panelTop.Location.Y + 5);
            maximizeBtn.Location = new Point(panelTop.Location.X + panelTop.Width - 50, panelTop.Location.Y + 5);
            minimizeBtn.Location = new Point(panelTop.Location.X + panelTop.Width - 70, panelTop.Location.Y + 5);
            foreach (Button b in allButtons)
                if (sender == (object)b)
                {
                    if (b.BackColor == Color.LightGreen)
                        render.ButtonRender(e, (Button)sender, Brushes.LightGreen);
                    else if (b.BackColor == Color.Aqua)
                        render.ButtonRender(e, (Button)sender, Brushes.Aqua);
                    else if (b.BackColor == Color.Yellow)
                        render.ButtonRender(e, (Button)sender, Brushes.Yellow);
                    else
                        render.ButtonRender(e, (Button)sender, Brushes.Red);
                }
        }
        private void UpdateBtn()
        {
            foreach (Button b in allButtons)
            {
                var btnPaint = new PaintEventHandler(Btn_Paint);
                btnPaint?.Invoke(b, new PaintEventArgs(b.CreateGraphics(), b.ClientRectangle));
            }
        }
        private void PanelBottom_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 3; i < allButtons.Length; ++i)
                render.MouseCheckButtons(allButtons[i], Btn_Paint, e.Location);
        }
        private void fLP_Paint(object sender, PaintEventArgs e)
        {
            int labelsCount = Client.Messages.Count();
            CheckUsers();
            if (labelsCount > 0)
            {
                for (int j = _labelCnt; j < labelsCount; ++j, ++_labelCnt)
                {
                    fLP.Controls.Add(new RichTextBox()
                    {
                        Dock = DockStyle.Top,
                        BackColor = Color.Black,
                        Font = new Font("Times New Roman", 14, FontStyle.Bold),
                        Tag = false,
                        Padding = new Padding(3),
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = Client.Messages[j],
                        ReadOnly = true,
                        Size = new Size(fLP.Width - 150, 70),
                        ScrollBars = RichTextBoxScrollBars.Vertical,
                        ForeColor = ((Client.Messages[j].Contains(Client.UserName)) ? Color.Aqua : Color.DarkOrange)
                    });
                    fLP.VerticalScroll.Value = fLP.VerticalScroll.Maximum;
                }
            }
            else
            {
                _labelCnt = 0;
            }
        }
        private void CheckUsers()
        {
            for (int i = 0; i < Client.Users.Count(); ++i)
            {
                if (cLB.Items.Contains(Client.Users[i]))
                    continue;
                else
                {
                    cLB.SetItemChecked(cLB.Items.Add(Client.Users[i]), true);
                }
            }
            for(int i = cLB.Items.Count - 1; i>=0; --i)
            {
                if (Client.Users.Contains(cLB.Items[i]))
                {
                    continue;
                }
                else
                    cLB.Items.Remove(cLB.Items[i]);
            }
            Client.WhiteList.Clear();
            foreach (string item in cLB.CheckedItems)
                Client.WhiteList.Add(item);
        }
        private void nickTB_TextChanged(object sender, EventArgs e)
        {
            Client.UserName = nickTB.Text;
        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            Client.SetOutgoingMessage(rTB.Text);
            Client.SetSend(true);
            rTB.Text = string.Empty;
        }
        private void cLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client.WhiteList.Clear();
            foreach (var item in cLB.CheckedItems)
                Client.WhiteList.Add(item.ToString());
        }
        private void panelBottom_SizeChanged(object sender, EventArgs e)
        {
            rTB.Height = panelBottom.Height - 40;
            sendBtn.Invalidate();
        }
    }
}
