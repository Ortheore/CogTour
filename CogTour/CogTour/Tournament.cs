using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogTour
{
    [Serializable]
    class Tournament
    {
        public List<Player> entrants = new List<Player>();
        private List<Object> stages = new List<Object>();
        public string name { get; set; }
        public string game { get; set; }
        public DateTime date { get; set; }

        public void ModTournament(string name, string game)
        {
            this.name = name;
            this.game = game;
            this.date = DateTime.Now;
        }
        //should I add a separate mod function? It would be pretty much identical to the constructor, but I probably shouldn't be calling the constructor for that purpose

        public void AddPlayer(Player newPlayer)
        {
            entrants.Add(newPlayer);
        }

        public void AddStage(string type)
        {
            switch (type)
            {
                case "Swiss":
                    SwissStage swiss = new SwissStage(this);
                    stages.Add(swiss);
                    break;
                case "Single Elim":
                    SingleElimStage single = new SingleElimStage(this);
                    stages.Add(single);
                    break;
                default://Probably want to display error or something here
                    break;
            }
        }
        public void SetDefaultStages()
        {
            //Current default is to have a swiss then a single elim
            //This will need to be updated as I modify each stage's constructor
            stages.Clear();
            stages.Add(new SwissStage(this));
            stages.Add(new SingleElimStage(this));
        }
    }
}
