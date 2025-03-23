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

        private long _clicksThisSecond = 0;
        private long _permanentCPS = 0;
        private Timer _cpsTimer;

        private List<Bonus> _lstBonuses;

        public long ClicksThisSecond { get => _clicksThisSecond; set => _clicksThisSecond = value; }
        public Timer CpsTimer { get => _cpsTimer; set => _cpsTimer = value; }
        public List<Bonus> LstBonuses { get => _lstBonuses; set => _lstBonuses = value; }
        public long PermanentCPS { get => _permanentCPS; set => _permanentCPS = value; }

        private void GenerateBonusButtons()
        {
            int startY = btnClick.Location.Y; // Position verticale de départ
            int spacing = 40; // Espace entre les boutons

            foreach (Bonus bonus in _lstBonuses)
            {
                Button btn = new Button
                {
                    Text = $"{bonus.NameBonus} (x{bonus.Owned}) - {bonus.Cost} clicks",
                    Tag = bonus, // On stocke l'objet Bonus dans le bouton
                    Size = new Size(200, 30),
                    Location = new Point(btnClick.Width + spacing, startY)
                };

                btn.Click += PurchaseBonus; // Associe l'événement d'achat
                this.Controls.Add(btn); // Ajoute le bouton à la Form

                startY += spacing; // Décale les boutons vers le bas
            }
        }

        public Form1()
        {
            InitializeComponent();

            Counter = 0;
            CpsTimer = new Timer { Interval = 1000 };

            CpsTimer.Tick += (s, e) =>
            {
                Counter += PermanentCPS;
                RefreshInterface();
            };
            CpsTimer.Start();

            // Initialisation des bonus
            LstBonuses = new List<Bonus>
            {
                new Bonus("Auto Clicker", 1, 1, 0),
                new Bonus("Double Click", 2, 200, 0),
                new Bonus("Mega Clicker", 5, 1000, 0)
            };

            GenerateBonusButtons(); // Génère les boutons dynamiquement

            RefreshInterface();
        }




        public void RefreshInterface()
        {
            lblCounter.Text = Counter.ToString();
            lblCPS.Text = PermanentCPS.ToString() + " clics / s";
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
                if (Counter >= bonus.Cost) // Vérifie si le joueur a assez de clicks
                {
                    Counter -= bonus.Cost; // Déduit le coût
                    bonus.UpCost(); // Augmente le coût et Owned
                    _permanentCPS += bonus.AddedCPS; // Ajoute les CPS permanents

                    btn.Text = $"{bonus.NameBonus} (x{bonus.Owned}) - {bonus.Cost} clicks"; // Met à jour le texte du bouton
                    RefreshInterface();
                }
                else
                {
                    MessageBox.Show("Pas assez de clicks !", "Achat impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
