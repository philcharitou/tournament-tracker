using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string dbName = "Tournaments";

        public MatchupModel CreateMatchup(MatchupModel matchup)
        {
            matchup.Id = 1;

            return matchup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchupEntry"></param>
        /// <returns></returns>
        public MatchupEntryModel CreateMatchupEntry(MatchupEntryModel matchupEntry)
        {
            matchupEntry.Id = 1;

            return matchupEntry;
        }

        /// <summary>
        /// Saves a new person to the database.
        /// </summary>
        /// <param name="person">The person information</param>
        /// <returns>The person information, including the unique identifier (ID).</returns>
        public PersonModel CreatePerson(PersonModel person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", person.FirstName);
                p.Add("@LastName", person.LastName);
                p.Add("@EmailAddress", person.EmailAddress);
                p.Add("@CellphoneNumber", person.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                // Search "p" for @id, casting to type "int" because the model class Id parameter is also int
                person.Id = p.Get<int>("@id");

                return person;
            }
        }

        /// <summary>
        /// Saves a new prize to the database.
        /// </summary>
        /// <param name="model">The prize information.</param>
        /// <returns>The prize information, including the unique identifier (ID).</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var dp = new DynamicParameters();
                dp.Add("@PlaceNumber", model.PlaceNumber);
                dp.Add("@PlaceName", model.PlaceName);
                dp.Add("@PrizeAmount", model.PrizeAmount);
                dp.Add("@PrizePercentage", model.PrizePercentage);
                dp.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                // connection.Execute("dbo.spPrizes_Insert", dp, commandType: CommandType.StoredProcedure);

                // Search "p" for @id, casting to type "int" because the model class Id parameter is also int
                model.Id = dp.Get<int>("@id");

                return model;
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return output;
        }

        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel team in output)
                {
                    var t = new DynamicParameters();
                    t.Add("@TeamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", t, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }

        public TeamModel CreateTeam(TeamModel team)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var t = new DynamicParameters();
                t.Add("@TeamName", team.TeamName);
                t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", t, commandType: CommandType.StoredProcedure);

                // Search "p" for @id, casting to type "int" because the model class Id parameter is also int
                team.Id = t.Get<int>("@id");

                foreach  (PersonModel p in team.TeamMembers)
                {
                    var dp = new DynamicParameters();
                    dp.Add("@TeamId", team.Id);
                    dp.Add("@PersonId", p.Id);
                    dp.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spTeamMembers_Insert", dp, commandType: CommandType.StoredProcedure);
                }

                return team;
            }
        }

        public TournamentModel CreateTournament(TournamentModel tournament)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var t = new DynamicParameters();
                t.Add("@TournamentName", tournament.TournamentName);
                t.Add("@EntryFee", tournament.EntryFee);
                t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournaments_Insert", t, commandType: CommandType.StoredProcedure);

                // Search "p" for @id, casting to type "int" because the model class Id parameter is also int
                tournament.Id = t.Get<int>("@id");

                foreach (PrizeModel p in tournament.Prizes)
                {
                    var dp = new DynamicParameters();
                    dp.Add("@TournamentId", tournament.Id);
                    dp.Add("@PrizeId", p.Id);
                    dp.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spTournamentEntries_InsertPrize", dp, commandType: CommandType.StoredProcedure);
                }

                foreach (TeamModel tm in tournament.EnteredTeams)
                {
                    var dp = new DynamicParameters();
                    dp.Add("@TournamentId", tournament.Id);
                    dp.Add("@TeamId", tm.Id);
                    dp.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spTournamentEntries_InsertTeam", dp, commandType: CommandType.StoredProcedure);
                }

                return tournament;
            }
        }
    }
}
