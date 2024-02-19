using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;

        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm()) {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text
                );

                GlobalConfig.Connection.CreatePrize(model);

                callingForm.PrizeComplete(model);

                this.Close();

                // placeNameValue.Text = "";
                // placeNumberValue.Text = "";
                // prizeAmountValue.Text = "0";
                // prizePercentageValue.Text = "0";
                // MessageBox.Show("Prize Successfully Added.");
            }
            else
            {
                MessageBox.Show("Some fields appear to have invalid information.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (!placeNumberValidNumber)
            {
                // Alert logic
                output = false;
            }

            if(placeNumber < 1)
            {
                // Alert logic
                output = false;
            }

            if(placeNameValue.Text.Length <= 0)
            {
                // Alert logic
                output = false;
            }

            decimal prizeAmount = 0;
            bool prizeAmountValidNumber = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            double prizePercentage = 0;
            bool prizePercentageValidPercentage = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (!prizeAmountValidNumber ||!prizeAmountValidNumber)
            {
                // Alert logic
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                // Alert logic
                output = false;
            }

            if (!prizeAmountValidNumber)
            {
                // Alert logic
                output = false;
            }         

            if (!prizePercentageValidPercentage || prizePercentage > 100 || prizePercentage < 0)
            {
                // Alert logic
                output = false;
            }

            return output;
        }
    }
}
