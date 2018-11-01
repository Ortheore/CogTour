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
        public int Score
        {
            get { return this.score; }
            set
            {
                if (this.score != value)
                {
                    this.score = value;
                    NotifyPropertyChange("Score");
                }
            }
        }
        private int countback=0;
        public int Countback
        {
            get { return this.countback; }
            set
            {
                if (this.countback != value)
                {
                    this.countback = value;
                    NotifyPropertyChange("Countback");
                }
            }
        }
    
        private List<SwissPlayer> priorOpps = new List<SwissPlayer>();//Contains info for all prior opps
        private List<int> roundScores = new List<int>();//Contains score result for all prior rounds
        private int indexKey;

        public SwissPlayer(string username):base(username)
        {

        }

        public void AddResult(SwissPlayer opponent, int score)
        {
            priorOpps.Add(opponent);
            roundScores.Add(score);
            score = CalculateScore();
        }

        private int CalculateScore()
        {
            return roundScores.Sum();
        }

        private void UpdateSwissIndexKey(int index)
        {
            this.indexKey = index;
        }
    }
}
