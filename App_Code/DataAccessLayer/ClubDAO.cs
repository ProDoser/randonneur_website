using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Karis.DatabaseLibrary;



public class ClubDAO
{
    private Database myDatabase;
    private String myConnectionString; 

    public ClubDAO()
    {
        myConnectionString = ConnectionString.Text;
        myDatabase = new Database();
    }

    public List<Club> GetAllClubs()
    {
        List<Club> clubList = new List<Club>();
        IDataReader resultSet;
        try
        {
            myDatabase = new Database();
            myDatabase.Open(myConnectionString);

            string sqlText =
                "SELECT clubName, city, clubid, email " +
                "FROM Club " +
                "ORDER BY clubName;";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Club club = new Club();
                club.ClubId = (int)resultSet["clubid"];
                club.ClubName = (String)resultSet["clubName"];
                club.ClubCity = (String)resultSet["city"];
                club.ClubEmail = (String)resultSet["email"];

                clubList.Add(club);
            }

            resultSet.Close();
            return clubList;
        }

        catch (Exception)
        {
            return null;
        }
        finally
        {
            myDatabase.Close();
        }
    }

    public Club GetClubByID(int clubid)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"SELECT clubName, city, clubid, email
                FROM Club
                WHERE clubid = {0}", clubid);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Club club = new Club();

                club.ClubId = (int)resultSet["clubid"];
                club.ClubName = (String)resultSet["clubName"];
                club.ClubCity = (String)resultSet["city"];
                club.ClubEmail = (String)resultSet["email"];

                return club;
            }

            else
            {
                return null;
            }
        }
            catch (Exception)
            {
                return null;
            }

            finally
        {
            myDatabase.Close();
        }
    
    }

    private bool clubExist(int clubid)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
            @"SELECT clubid
            FROM club
            WHERE clubid = {0}", clubid);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound; // true = row exists, otherwise false

    }

    public int InsertClub(Club club)
    {
        try
        {
            myDatabase.Open(myConnectionString);
            if (clubExist(club.ClubId) == true)
            {
                return 1; // row exists
            }

            String sqlText = String.Format(
                @"INSERT INTO Club (clubid, clubName, city, email)
                VALUES ({0}, '{1}', '{2}', '{3}')",
                club.ClubId, club.ClubName, club.ClubCity, club.ClubEmail);

            myDatabase.ExecuteQuery(sqlText);
            return 0; //OK
        }
        catch (Exception)
        {
            return -1; // ERROR
        }
        finally
        {
            myDatabase.Close();
        }
    }


    public int UpdateClub(Club club)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"UPDATE Club
                SET clubname ='{0}',
                    city ='{1}',
                    email ='{2}'
                WHERE clubid = {3}",
                
                club.ClubName,
                club.ClubCity,
                club.ClubEmail,
                club.ClubId);

            myDatabase.ExecuteQuery(sqlText);
            return 0; //OK
        }
        catch (Exception)
        {
            return -1; //ERROR
        }
        finally
        {
            myDatabase.Close();
        }
    }

    public int DeleteClub(int clubid)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (riderExistsForClub(clubid) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM club
                 WHERE clubid = {0}", clubid);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;   // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }
        private bool riderExistsForClub(int clubid)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderid
              FROM rider
             WHERE clubid = {0}", clubid);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

        

}

      




