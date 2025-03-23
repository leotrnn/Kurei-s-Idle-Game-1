using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdleGameV1
{
    public partial class Form1 : Form
    {
        private long _counter;
        public long Counter
        {
            get => _counter;
            set => _counter = Math.Max(0, value);
        }
        private Label lblBonusDescription;

        private long _clicksThisSecond = 0;
        private long _permanentCPS = 0;
        private Timer _cpsTimer;
        private Panel panelBonuses;
        private List<Bonus> _lstBonuses;

        public long ClicksThisSecond { get => _clicksThisSecond; set => _clicksThisSecond = value; }
        public Timer CpsTimer { get => _cpsTimer; set => _cpsTimer = value; }
        public List<Bonus> LstBonuses { get => _lstBonuses; set => _lstBonuses = value; }
        public long PermanentCPS { get => _permanentCPS; set => _permanentCPS = value; }
        public Panel PanelBonuses { get => panelBonuses; set => panelBonuses = value; }
        public Label LblBonusDescription { get => lblBonusDescription; set => lblBonusDescription = value; }

        private void GenerateBonusButtons()
        {
            int startY = 10;
            int spacing = 20;

            foreach (Bonus bonus in _lstBonuses)
            {
                int availableWidth = panelBonuses.ClientSize.Width - spacing - spacing;
                Button btn = new Button
                {
                    Text = $"{bonus.NameBonus} (x{bonus.Owned}) - {bonus.Cost} clicks",
                    Tag = bonus,
                    Size = new Size(availableWidth, 30),
                    Location = new Point(12, startY)
                };

                btn.Click += PurchaseBonus;
                btn.MouseHover += (s, e) => { ShowBonusDescription(bonus); };
                btn.MouseLeave += (s, e) => { lblBonusDescription.Text = ""; };

                panelBonuses.Controls.Add(btn);

                startY += btn.Height + spacing;
            }
        }

        private void ShowBonusDescription(Bonus bonus)
        {
            lblBonusDescription.Text = bonus.Description;
        }

        public Form1()
        {
            InitializeComponent();

            lblBonusDescription = new Label
            {
                Location = new Point(10, this.ClientSize.Height - 30),
                Size = new Size(this.ClientSize.Width - 20, 30),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Italic)
            };
            this.Controls.Add(lblBonusDescription);

            Counter = 0;
            CpsTimer = new Timer { Interval = 1000 };

            CpsTimer.Start();
            CpsTimer.Tick += (s, e) =>
            {
                Counter += PermanentCPS;

                lblCounter.Text = Counter.ToString();
                lblCPS.Text = $"{PermanentCPS} clics / s";

                RefreshInterface();
            };

            LstBonuses = new List<Bonus>
            {
                new Bonus("Auto Clicker", 3, 1, 0, "+1 click / s."),
                new Bonus("Double Click", 5, 200, 0, "Double le nombre de clics effectués."),
                new Bonus("Mega Clicker", 10, 1000, 0, "Clique puissamment pour des clics massifs."),
            };

            panelBonuses = new FlowLayoutPanel
            {
                Size = new Size(this.ClientSize.Width - btnClick.Width - 24, this.ClientSize.Height - 100),
                Location = new Point(btnClick.Width + 20, btnClick.Location.Y),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0)
            };

            this.Controls.Add(panelBonuses);

            GenerateBonusButtons();

            RefreshInterface();
        }

        public void RefreshInterface()
        {
            lblCounter.Text = Counter.ToString();
            lblCPS.Text = PermanentCPS.ToString() + " clics / s";

            foreach (Control control in panelBonuses.Controls)
            {
                if (control is Button btn && btn.Tag is Bonus bonus)
                {
                    if (Counter >= bonus.Cost)
                    {
                        btn.BackColor = Color.LightGreen;
                        btn.Cursor = Cursors.Hand;
                        btn.Text = $"{bonus.NameBonus} (x{bonus.Owned}) - {bonus.Cost} clicks";
                        btn.Click -= PreventClick;
                        btn.Click += (s, e) => PurchaseBonus(s, e);
                    }
                    else
                    {
                        btn.BackColor = Color.Gray;
                        btn.Cursor = Cursors.No;
                        btn.Text = $"{bonus.NameBonus} (x{bonus.Owned}) - {bonus.Cost} clicks - Pas assez de clics";

                        btn.Click -= (s, e) => PurchaseBonus(s, e);
                        btn.Click += PreventClick;
                    }
                }
            }
        }

        private void PreventClick(object sender, EventArgs e)
        {
        }

        private void UserClick(object sender, EventArgs e)
        {
            Counter++;
            ClicksThisSecond++;
            RefreshInterface();
        }

        private void PurchaseBonus(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Bonus bonus)
            {
                if (Counter >= bonus.Cost)
                {
                    Counter -= bonus.Cost;
                    bonus.UpCost();
                    PermanentCPS += bonus.AddedCPS;
                    btn.Text = $"{bonus.NameBonus} (x{bonus.Owned}) - {bonus.Cost} clicks";
                    RefreshInterface();
                }
            }
        }
    }
}
