using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGameV1
{
    public class Bonus
    {
        private string _nameBonus;
        private long _addedCPS;
        private long _owned;
        private long _cost;

        public string NameBonus { get => _nameBonus; set => _nameBonus = value; }
        public long AddedCPS { get => _addedCPS; set => _addedCPS = value; }
        public long Cost { get => _cost; set => _cost = value; }
        public long Owned { get => _owned; set => _owned = value; }

        public Bonus(string nameBonus, long addedCPS, long cost, long owned)
        {
            NameBonus = nameBonus;
            AddedCPS = addedCPS;
            Cost = cost;
            Owned = owned;
        }

        public void UpCost()
        {
            Owned++;
            double logFactor = 1 + Math.Log(Owned + 1, 2);
            Cost = (long)(Cost * logFactor);
        }
    }
}
