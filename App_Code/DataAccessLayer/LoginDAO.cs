/* *************************************************************************
 * LoginDAO.cs   Original version: Kari Silpiц 20.3.2014 v1.0
 *               Modified by     : -
 * ------------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Data Access Layer
 *  Class:       DAO class for database services for login functionality
 * -------------------------------------------------------------------------
 * NOTICE: This is an over-simplified example for an introductory course. 
 * - Error processing is not robust (some error are not handled)
 * - No multi-user considerations, no transaction programming 
 * - No protection for attacks of type 'SQL injection'
 * - No password security etc.
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using Karis.DatabaseLibrary;

/// <summary>
/// LoginDAO - Data Access Layer interface class. Accesses the data storage.
/// <remarks>Original version: Kari Silpiц 2014
///          Modified by: -</remarks>
/// </summary>>
public class LoginDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public LoginDAO()
    {
        myConnectionString = ConnectionString.Text;
        myDatabase = new Database();
    }

    public LoginRole GetLoginRole(string username, string password)
    {

        LoginRole loginRole = new LoginRole();
        loginRole.Role = null;
        IDataReader resultSet;

        try
        {
            myDatabase = new Database();
            myDatabase.Open(myConnectionString);
            String role = "";
            String sqlText =
            "SELECT role " +
            "FROM Rider " +
            "WHERE username = '" + username + "' AND password = '" + password + "'";

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                role = (String)resultSet["role"];
            }


            if (role == "user")
            {
                loginRole.Role = "user";
            }
            else if (role == "admin")
            {
                loginRole.Role = "administrator";
            }
            resultSet.Close();
            return loginRole;
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
}
// End
