using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Karis.DatabaseLibrary;



public class RiderDAO
{
    private Database myDatabase;
    private String myConnectionString;
    private ClubDAO clubDAO = new ClubDAO();

    public RiderDAO()
    {
        myConnectionString = ConnectionString.Text;
        myDatabase = new Database();
    }

    public List<Rider> GetAllRiders()
    {
        List<Rider> riderList = new List<Rider>();
        IDataReader resultSet;
        try
        {
            myDatabase = new Database();
            myDatabase.Open(myConnectionString);

            string sqlText =
                "SELECT riderid, familyname, givenname, gender, clubid " +
                "FROM rider " +
                "ORDER BY clubid, familyname, givenname;";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();
                rider.RiderId = (int)resultSet["riderid"];
                rider.FamilyName = (String)resultSet["familyname"];
                rider.GivenName = (String)resultSet["givenname"];
                rider.Gender = (String)resultSet["gender"];
                rider.ClubId = (int)resultSet["clubid"];

                riderList.Add(rider);
            }

            resultSet.Close();
            return riderList;
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

    public List<String> GetAllRidersByBrevetId(int brevetid)
    {
        List<String> riderList = new List<String>();
        IDataReader resultSet;
        try
        {
            myDatabase = new Database();
            myDatabase.Open(myConnectionString);

            string sqlText =
                "SELECT r.familyname AS familyname, r.givenname, Club.clubname AS club, br.finishingTime " + 
                "FROM Brevet_Rider AS br "+ 
                "JOIN Rider AS r "+ 
                "ON br.riderid = r.riderid "+
                "JOIN Club ON r.clubid = Club.clubid " + 
                "WHERE br.brevetid = " + brevetid +
                " ORDER BY br.finishingTime;";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                                   
                String familyName = (String)resultSet["familyname"];
                String givenName = (String)resultSet["givenname"];
                String clubName = (String)resultSet["club"];
                String time = (String)resultSet["finishingtime"];

                String riderResult = familyName + " " + givenName + ", Club: " +
                    clubName + "- Time: " + time;


                riderList.Add(riderResult);
            }

            resultSet.Close();
            return riderList;
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

    public Rider GetRiderByID(int riderid)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"SELECT riderid, familyname, givenname, gender, phone, 
                email, clubid, username, password, role 
                FROM rider 
                WHERE riderid = {0} 
                ORDER BY clubid, familyname, givenname 
                ", riderid);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Rider rider = new Rider();
                rider.RiderId = (int)resultSet["riderid"];
                rider.FamilyName = (String)resultSet["familyname"];
                rider.GivenName = (String)resultSet["givenname"];
                rider.Gender = (String)resultSet["gender"];
                rider.Phone = (String)resultSet["phone"];
                rider.Email = (String)resultSet["email"];
                rider.ClubId = (int)resultSet["clubid"];
                rider.Username = (String)resultSet["username"];
                rider.Password = (String)resultSet["password"];
                rider.Role = (String)resultSet["role"];

                return rider;
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

   

    public int InsertRider(Rider rider)
    {
        try
        {
            myDatabase.Open(myConnectionString);
            if (riderExistsForClub(rider.RiderId) == true)
            {
                return 1; // row exists
            }

            String sqlText = String.Format(
                @"INSERT INTO Rider (riderid, familyName, givenName, gender, phone, 
                email, clubid, username, password, role)
                VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}' )",
                rider.RiderId, rider.FamilyName, rider.GivenName, rider.Gender, rider.Phone, 
                rider.Email, rider.ClubId, rider.Username, rider.Password, rider.Role);

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


    public int UpdateRider(Rider rider)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                 @"UPDATE Rider 
                SET familyName ='{1}', givenName ='{2}', gender ='{3}', phone ='{4}', 
                email ='{5}', clubid ='{6}', username ='{7}', password ='{8}', role ='{9}'
                WHERE riderid ={0}",
                rider.RiderId, rider.FamilyName, rider.GivenName, rider.Gender, rider.Phone, 
                rider.Email, rider.ClubId, rider.Username, rider.Password, rider.Role);

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

    public int DeleteRider(int riderid)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (riderExistsForClub(riderid) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM rider
                 WHERE riderid = {0}", riderid);

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
    private bool riderExistsForClub(int riderid)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderid
              FROM Brevet_Rider 
             WHERE riderid = {0}", riderid);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }



}






