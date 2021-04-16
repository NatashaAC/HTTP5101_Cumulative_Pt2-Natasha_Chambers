using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers.Models
{
    public class SchoolDbContext
    {
        // Ready Only properties for the School Database
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        // Set of creditals called ConnectionString that connect to the School database
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        // Objective:
        // Method that accesses the database
        /// <summary>
        ///     Returns a connection to the School Database
        /// </summary>
        /// <returns> A MySqlConnection Object </returns>
        /// <example>
        ///     private SchoolDbContext School = new SchoolDbContext();
        ///     MySqlConnection Conn = School.AccessDatabase();
        /// </example>
        public MySqlConnection AccessDatabase()
        {
            // Instantiating MySqlConnection Class to create an Object that is a specific connection to school database
            return new MySqlConnection(ConnectionString);
        }
    }
}