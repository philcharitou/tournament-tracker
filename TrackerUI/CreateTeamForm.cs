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
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        ITeamRequester callingForm;

        private List<PersonModel> availableTeamMembers = new List<PersonModel>();  //GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();

            CreateSampleData();
            WireUpLists();
            callingForm = caller;
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel("John", "Wick", "johnwick@sympatico.com", "1234567890"));
            availableTeamMembers.Add(new PersonModel("Wohn", "Jick", "wohnjick@sympatico.com", "1234567890"));
            selectedTeamMembers.Add(new PersonModel("Wohn", "Wick", "wohnwick@sympatico.com", "1234567890"));
            selectedTeamMembers.Add(new PersonModel("John", "Jick", "johnjick@sympatico.com", "1234567890"));
        }

        private void WireUpLists()
        {
            selectTeamMemberDropdown.DataSource = null;

            selectTeamMemberDropdown.DataSource = availableTeamMembers;
            selectTeamMemberDropdown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel model = new PersonModel(
                    firstNameValue.Text,
                    lastNameValue.Text,
                    emailValue.Text,
                    callPhoneValue.Text
                );

                GlobalConfig.Connection.CreatePerson(model);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                callPhoneValue.Text = "";

                MessageBox.Show("Person Successfully Added.");
            }
            else
            {
                MessageBox.Show("Some fields appear to have invalid information.");
            }
        }

        private bool ValidateForm()
        {
            // TODO - Add validation to the member button form
            return true;
        }

        private bool ValidateTeamForm()
        {
            // TODO - Add validation to the team button form
            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropdown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateTeamForm())
            {
                TeamModel model = new TeamModel(
                    selectedTeamMembers,
                    teamNameValue.Text,
                    "Team Description"
                );

                GlobalConfig.Connection.CreateTeam(model);

                selectedTeamMembers = null;
                teamNameValue.Text = "";
                
                WireUpLists();

                MessageBox.Show("Team Successfully Added.");

                // TODO - If closing this form after creation, don't reset form
            }
            else
            {
                MessageBox.Show("Some fields appear to have invalid information.");
            }
        }
    }
}
