using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogTour
{
    [Serializable]
    class Stage
    {
        private Tournament tour;

        public Stage(Tournament tour)
        {
            this.tour = tour;
        }

        public void ImportPlayers()
        {

        }
        public void ImportPlayers(Func<Boolean> filter)
        {

        }
    }
}
