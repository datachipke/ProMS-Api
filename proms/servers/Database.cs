using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.servers
{
    public class Database
    {
        public static string hostName = "localhost";
        public static string connPort = "3309";
        public static string userName = "root";
        public static string password = "password";
        public static string database = "proms";
        public static string connString = "SERVER=" + hostName + ";" + "PORT=" + connPort + ";" + "DATABASE=" + database + ";" + "UID=" + userName + ";" + "PASSWORD=" + password + ";";
    }
}