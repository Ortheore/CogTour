using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace CogTour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tournament tour=null;
        private string tourData= System.IO.Path.Combine(Environment.CurrentDirectory, "Tour Data");
        private int playerIndex=-1;//Used in determining where to insert a player in the player list. -1 indicates new player.
        private Player curPlayer = new Player("", "", "", "", "", "");

        public MainWindow()
        {
            InitializeComponent();
            grdPlayerInfo.DataContext = curPlayer;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (tour != null)
            {
                MessageBoxResult result=System.Windows.MessageBox.Show("Clicking yes will overwrite the existing tournament, removing all stage and player data. Clicking no will merely change the name and game without affecting other data.", "Overwrite", MessageBoxButton.YesNoCancel);
                if (result==MessageBoxResult.Cancel)
                {
                    return;
                }else if (result == MessageBoxResult.Yes)
                {
                    tour = new Tournament();
                }
            }
            else
            {
                tour = new Tournament();
            }
            tour.ModTournament(tbxTourName.Text, tbxGame.Text);
            tour.SetDefaultStages();
            tabControl.IsEnabled = true;
        }

        private void btnSaveTour_Click(object sender, RoutedEventArgs e)
        {
            if (tour == null) return;//Will want to make this an error statement later on
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save Tournament Data";
            saveDialog.Filter = "Tournament files (.tour)|*.tour|All Files(*.*)|*.*";
            if (!Directory.Exists(tourData)) Directory.CreateDirectory(tourData);
            saveDialog.InitialDirectory = tourData;
            saveDialog.RestoreDirectory = true;
            saveDialog.FileName = tour.name;
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                Stream fs = saveDialog.OpenFile();
                SerializeTool.BinarySerialize(tour, fs);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Load Existing Tournament";
            openDialog.Filter= "Tournament files (.tour)|*.tour|All Files(*.*)|*.*";
            if (!Directory.Exists(tourData)) Directory.CreateDirectory(tourData);
            openDialog.InitialDirectory = tourData;
            openDialog.RestoreDirectory = true;

            DialogResult res = openDialog.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {
                Stream stream = openDialog.OpenFile();
                Object obj = SerializeTool.BinaryDeserializer(stream);
                try
                {
                    tour = (Tournament)obj;
                    tbxTourName.Text = tour.name;
                    tbxGame.Text = tour.game;
                    tabControl.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error reading tournament file.\nException: " + ex.Message);
                }
            }
        }

        private void btnSetNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            tbkSignups.Text = "Signups (new)";
            curPlayer.ResetPlayer();
            playerIndex = -1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool inputValid = true;
            //Add input validation here.
            //I'll worry about this later, as I'm initially going to be the only one using the software
            if (inputValid)
            {
                if (playerIndex == -1)
                {
                    tour.AddPlayer(curPlayer);
                }
                else
                {
                    if (playerIndex >= 0)
                    {

                    }
                    else
                    {
                        //Error handling goes here
                    }
                }
            }
        }
    }
}
