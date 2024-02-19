using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        private List<TeamModel> availableTeams = new List<TeamModel>();  //GlobalConfig.Connection.GetPerson_All();
        private List<TeamModel> selectedTeams = new List<TeamModel>();
        private List<PrizeModel> prizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            CreateSampleData();
            WireUpLists();
        }

        private void CreateSampleData()
        {
            selectedTeams.Add(new TeamModel(null, "Team 1", "Team 1"));
            selectedTeams.Add(new TeamModel(null, "Team 2", "Team 2"));
            availableTeams.Add(new TeamModel(null, "Team 3", "Team 3"));
            prizes.Add(new PrizeModel("1", "First", "100", "50"));
            prizes.Add(new PrizeModel("2", "Second", "50", "10"));
            prizes.Add(new PrizeModel("3", "Third", "", "5"));
        }

        private void WireUpLists()
        {
            selectTeamDropdown.DataSource = null;

            selectTeamDropdown.DataSource = availableTeams;
            selectTeamDropdown.DisplayMember = "TeamName";

            tournamentPlayersListBox.DataSource = null;

            tournamentPlayersListBox.DataSource = selectedTeams;
            tournamentPlayersListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;

            prizesListBox.DataSource = prizes;
            prizesListBox.DisplayMember = "PrizeName";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropdown.SelectedItem;

            if (t != null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);

                WireUpLists();
            }
        }

        private void deleteSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentPlayersListBox.SelectedItem;

            if (t != null)
            {
                availableTeams.Add(t);
                selectedTeams.Remove(t);

                WireUpLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call create prize form
            CreatePrizeForm form = new CreatePrizeForm(this);
            form.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            prizes.Add(model);

            WireUpLists();
        }

        private void createTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Call create team form
            CreateTeamForm form = new CreateTeamForm(this);
            form.Show();
        }

        public void TeamComplete(TeamModel model)
        {
            availableTeams.Add(model);

            WireUpLists();
        }

        private void deleteSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

            if (p != null)
            {
                prizes.Remove(p);
                WireUpLists();
            }

        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            decimal fee = 0;

            bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("Please enter a valid entry fee.",
                    "Invalid Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Create Tournament Model
            TournamentModel tm = new TournamentModel();

            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;

            foreach (PrizeModel prize in prizes)
            {
                tm.Prizes.Add(prize);
            }
        }
    }
}
