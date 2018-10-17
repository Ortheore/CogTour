using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogTour
{
    [Serializable]
    class SwissStage:Stage
    {
        public SwissStage(Tournament tour):base(tour)
        {

        }
    }
    [Serializable]
    class SwissPlayer:Player
    {
        private int score=0;
        private int countback=0;
        private List<SwissPlayer> priorOpps = new List<SwissPlayer>();

        public SwissPlayer(string username):base(username)
        {

        }

        public void AddResult(SwissPlayer opponent, int score)
        {
            priorOpps.Add(opponent);
            this.score += score;
        }
    }
}
