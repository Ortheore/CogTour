using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogTour
{
    [Serializable]
    class Match
    {
        private Player player1, player2;
        private int p1Score=0, p2Score=0;

        public Player GetWinner()
        {
            if (p1Score > p2Score)
            {
                return player1;
            }
            else if (p1Score < p2Score)
            {
                return player2;
            }
            else
            {
                return null;
            }
        }

        public Match(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
        }

        public void UpdateScore(int p1, int p2)
        {
            p1Score = p1;
            p2Score = p2;
        }
    }
}
