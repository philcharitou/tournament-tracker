using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// A unique identifier for the prize.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The numeric identifier for the place (1 for first, 2 for second, etc.).
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// The friendly name for the place (second place, first runner up, etc.).
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// The fixed amount this place earns or 0 if not used.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// The number which represents the percentage of overall take, or 0 if not used.
        /// Percentage is a fraction of 1 (i.e. 0.5 for 50%).
        /// </summary>
        public double PrizePercentage { get; set; }

        public string PrizeName {
            get {
                if (PrizeAmount != null)
                {
                    return PlaceName + ": $" + PrizeAmount;
                }
                else
                {
                    return PlaceName + ": " + PrizePercentage + "%";
                }
            }
        }

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
