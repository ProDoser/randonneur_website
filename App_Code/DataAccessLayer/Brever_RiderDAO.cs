using System;
using System.Collections.Generic;
using System.Data;
using Karis.DatabaseLibrary;

/// <summary>
/// Summary description for BrevetDAO
/// </summary>
public class Brevet_RaiderDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public Brevet_RaiderDAO()
    {
        myConnectionString = ConnectionString.Text;
        myDatabase = new Database();
    }

    public List<Brevet_Raider> GetAllBrevet_Raider()
    {
        List<Brevet_Raider> brevet_RiderList = new List<Brevet_Raider>();
        IDataReader resultSet;
        try
        {
            myDatabase = new Database();
            myDatabase.Open(myConnectionString);

            string sqlText =
                "SELECT * FROM Brevet_Rider"+
                "ORDER BY brevetid";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet_Raider brevet = new Brevet_Raider();
                brevet.RiderId = (int)resultSet["riderid"];
                brevet.BrevetId = (int)resultSet["brevetid"];
                brevet.IsCompleated = (String)resultSet["isCompleated"];
                brevet.FinishingTime = (String)resultSet["finishingtime"];


                brevet_RiderList.Add(brevet);
            }

            resultSet.Close();
            return brevet_RiderList;
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

 /*   public Brevet_Raider GetBrevetByID(int brevetid_Raider)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"SELECT brevetid, distance, brevetdate, location, climbing
                FROM brevet
                WHERE brevet = {0}", brevetid_Raider);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Brevet_Raider brevet = new Brevet_Raider();
                brevet.BrevetId = (int)resultSet["brevetid"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.BrevetDate = (DateTime)resultSet["brevetdate"];
                brevet.Location = (String)resultSet["location"];
                brevet.Climbing = (int)resultSet["climbing"];

                return brevet;
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

    }*/

    private bool brevetExist(int brevetid)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
            @"SELECT brevetid
            FROM brevet
            WHERE brevetid = {0}", brevetid);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound; // true = row exists, otherwise false

    }

    public int InsertBrevet(Brevet brevet)
    {
        try
        {
            myDatabase.Open(myConnectionString);
            if (brevetExist(brevet.BrevetId) == true)
            {
                return 1; // row exists
            }

            String sqlText = String.Format(
                @"INSERT INTO Brevet (brevetid, distance, brevetdate, location, climbing)
                VALUES ({0}, '{1}', '{2}', '{3}', '{4}')",
                brevet.BrevetId, brevet.Distance, brevet.BrevetDate, brevet.Location, brevet.Climbing);

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