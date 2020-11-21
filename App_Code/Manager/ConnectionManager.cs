using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for ConnectionManager
/// </summary>
public class ConnectionManager
{
    public ConnectionManager()
    {
        
    }

    public static MySqlConnection Connect()
    {
        MySqlConnection connection;
        connection = new MySqlConnection();

        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["jcMouseConnectionString"].ConnectionString;

        return connection;
    }

    public static MySqlCommand BuildQuery(string stored, string query, MySqlConnection connection)
    {
        MySqlCommand command = new MySqlCommand("call " + stored +"('" + query + "')", connection);

        return command;
    }
}