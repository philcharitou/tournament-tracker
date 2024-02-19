using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        List<PersonModel> GetPerson_All();
        List<TeamModel> GetTeam_All();
        PrizeModel CreatePrize(PrizeModel model);
        TeamModel CreateTeam(TeamModel team);
        PersonModel CreatePerson(PersonModel person);
        TournamentModel CreateTournament(TournamentModel tournament);
        MatchupModel CreateMatchup(MatchupModel matchup);
        MatchupEntryModel CreateMatchupEntry(MatchupEntryModel matchupEntry);
    }
}
