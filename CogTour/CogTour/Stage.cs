using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogTour
{
    [Serializable]
    class Stage //This class isn't to actually be used in and of itself, but instead to implement things that are common to all stages
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
