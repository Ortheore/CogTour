using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CogTour
{
    [Serializable]
    class Player:INotifyPropertyChanged
    {
        //Set all variables as properties for use in binding and the PropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;
        private string username, firstName, surname, phoneNum, email, team;
        public string Username
        {
            get { return this.username; }
            set
            {
                if (this.username != value)
                {
                    this.username = value;
                    NotifyPropertyChange("Username");
                }
            }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    NotifyPropertyChange("FirstName");
                }
            }
        }
        public string Surname
        {
            get { return this.surname; }
            set
            {
                if (value != this.surname)
                {
                    this.surname = value;
                    NotifyPropertyChange("Surname");
                }
            }
        }
        public string PhoneNum
        {
            get { return this.phoneNum; }
            set
            {
                if (this.phoneNum != value)
                {
                    this.phoneNum = value;
                    NotifyPropertyChange("PhoneNum");
                }
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    NotifyPropertyChange("Email");
                }
            }
        }
        public string Team
        {
            get { return this.team; }
            set
            {
                if (this.team != value)
                {
                    this.team = value;
                    NotifyPropertyChange("Team");
                }
            }
        }
        //Other variables
        private bool sameUser = false;//This is only to be true if players have the same username. This is extremely unlikely, but there's no reason it couldn't happen
        private List<Object> stages;//Each stage is to consist of a player type for that stage

        public Player(string username, string firstName, string surname, string phoneNum, string email, string team)
        {
            this.username = username;
            this.firstName = firstName;
            this.surname = surname;
            this.phoneNum = phoneNum;
            this.email = email;
            this.team = team;
        }

        public void ResetPlayer()
        {
            username = "";
            firstName = "";
            surname = "";
            phoneNum = "";
            email = "";
            team = "";

        }

        //This is basically only for testing
        public Player(string username)
        {
            this.username = username;
        }

        private void NotifyPropertyChange(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
