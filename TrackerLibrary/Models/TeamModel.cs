using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team participating in the tournament.
    /// </summary>
    public class TeamModel
    {
        /// <summary>
        /// A unique identifier for the team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List of members of the team.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        /// <summary>
        /// The name of the team.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// A description of the team.
        /// </summary>
        public string TeamDescription { get; set; }

        public TeamModel() { }

        public TeamModel(List<PersonModel> teamMembers, string teamName, string teamDescription)
        {
            TeamMembers = teamMembers;
            TeamName = teamName;
            TeamDescription = teamDescription;
        }
    }
}
