using MySql.Data.MySqlClient;
using proms.handlers.models;
using proms.models;
using proms.servers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proms.controllers
{
    public class DatabaseHandler
    {
        private static Response openConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Database.connString);
                connection.Open();
                return new Response(true, 1, "Connection open.", null, connection);
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        return new Response(false, 0, "Cannot connect to server.  Contact administrator.", new string[] { ex.ToString() }, null);
                    case 1045:
                        return new Response(false, 0, "Invalid username/password, please try again.", new string[] { ex.ToString() }, null);
                    default:
                        return new Response(false, 0, "Un specified error.", new string[] { ex.ToString() }, null);
                }
            }
        }

        protected static KeyValue[] formatPairs(KeyValue[] keyModelPairs)
        {
            KeyValue[] formattedPairs = new KeyValue[keyModelPairs.Length];
            if (keyModelPairs.Length > 0)
            {
                int x = 0;
                foreach (KeyValue keyModelPair in keyModelPairs)
                {
                    x++;
                    if (x != keyModelPairs.Length && keyModelPairs.Length != 1) { formattedPairs[x - 1] = new KeyValue(keyModelPair.key, "='" + keyModelPair.value + "' AND "); }
                    else { formattedPairs[x - 1] = new KeyValue(keyModelPair.key, "='" + keyModelPair.value + "'"); }
                }
                return formattedPairs;
            }
            return null;
        }

        protected static Response insertRow(string table, KeyValue[] keyModelPairs)
        {
            string sql = "";
            if (keyModelPairs.Length > 0)
            {
                sql = "INSERT INTO " + table + " (";
                int x = 0;
                foreach (KeyValue keyModelPair in keyModelPairs)
                {
                    x++;
                    if (x != keyModelPairs.Length && keyModelPairs.Length != 1) { sql += "`" + keyModelPair.key + "`, "; }
                    else { sql += "`" + keyModelPair.key + "`"; }
                    
                }
                x = 0;
                sql += ") VALUES(";
                foreach (KeyValue keyModelPair in keyModelPairs)
                {
                    x++;
                    if (x != keyModelPairs.Length && keyModelPairs.Length != 1) { sql += "'" + keyModelPair.value + "', "; }
                    else { sql += "'" + keyModelPair.value + "'"; }

                }
                sql += ");";
            }
            try
            {
                Response response = openConnection();
                if (response.status)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)response.data);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    return new Response(true, 1, "Row inserted.", null, null);
                }
                return response;
            }
            catch (MySqlException ex)
            {
                return new Response(true, 0, "Row not inserted.", new string[] { ex.Message }, null);
            }
        }

        protected static Response updateRow(string table, KeyValue[] keyModelPairs, KeyValue[] updateModelPairs)
        {
            string sql = "";
            if (keyModelPairs.Length > 0 && updateModelPairs.Length > 0)
            {
                sql = "UPDATE " + table + " SET ";
                int x = 0;
                foreach (KeyValue updateModelPair in updateModelPairs)
                {
                    x++;
                    if (x != updateModelPairs.Length && updateModelPairs.Length != 1) { sql += "`" + updateModelPair.key + "`='"+ updateModelPair.value + "', "; }
                    else { sql += "`" + updateModelPair.key + "`='"+ updateModelPair.value + "'"; }

                }
                x = 0;
                sql += " WHERE ";
                foreach (KeyValue keyModelPair in keyModelPairs)
                {
                    x++;
                    if (x != keyModelPairs.Length || keyModelPairs.Length != 1) { sql += "`" + keyModelPair.key + "`='" + keyModelPair.value + "', "; }
                    else {
                        if (keyModelPairs.Length == 1) { sql += "`" + keyModelPair.key + "`='" + keyModelPair.value + "'";  }
                        else { sql += "AND `" + keyModelPair.key + "`='" + keyModelPair.value + "'";  }
                    }

                }
                sql += ";";
                try
                {
                    Response response = openConnection();
                    if (response.status)
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)response.data);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        return new Response(true, 1, "Row updated.", null, null);
                    }
                    return response;
                }
                catch (MySqlException ex)
                {
                    return new Response(true, 0, "Row not updated.", new string[] { ex.Message }, null);
                }
            }
            return new Response(true, 0, "Row updated.", new string[] { "Data error" }, null);
        }

        protected static Response fetchRow(string table, KeyValue[] keyModelPairs)
        {
            string sql = "SELECT * FROM " + table;
            if (keyModelPairs.Length > 0)
            {
                sql += " WHERE ";
                foreach (KeyValue keyModelPair in keyModelPairs)
                {
                    sql += keyModelPair.key + "" + keyModelPair.value;
                }
            }
            try
            {
                Response response = openConnection();
                if (response.status)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)response.data);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0) { return new Response(true, 1, "Data found.", null, ds.Tables[0]); }
                    return new Response(true, 0, "Data NOT found.", new string[] { "No items."}, null);
                }
                return response;
            }
            catch (MySqlException ex)
            {
                return new Response(true, 0, "Data NOT found.", new string[] { ex.Message }, null);
            }
        }

        protected static Response fetchRows(string table, KeyValue[] keyModelPairs)
        {
            string sql = "SELECT * FROM " + table;
            if (keyModelPairs.Length > 0)
            {
                sql += " WHERE ";
                foreach (KeyValue keyModelPair in keyModelPairs)
                {
                    sql += keyModelPair.key + "" + keyModelPair.value;
                }
            }
            try
            {
                Response response = openConnection();
                if (response.status)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)response.data);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0) { return new Response(true, 1, "Data found.", null, ds.Tables[0]); }
                    return new Response(true, 0, "Data NOT found.", new string[] { "No items." }, null);
                }
                return response;
            }
            catch (MySqlException ex)
            {
                return new Response(true, 0, "Data NOT found.", new string[] { ex.Message }, null);
            }
        }

        public static Response searchDB(SearchModel searchModel)
        {
            try
            {
                Response response = openConnection();
                if (response.status)
                {
                    response = prepareSQL(searchModel);
                    if (response.status)
                    {
                        MySqlCommand cmd = new MySqlCommand((string)response.data, (MySqlConnection)response.data);
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0) { return new Response(true, 1, "Data found.", null, ds.Tables[0]); }
                        return new Response(true, 0, "Data NOT found.", new string[] { "No items." }, null);
                    }
                    return response;
                }
                return response;
            }
            catch (MySqlException ex)
            {
                return new Response(true, 0, "Data NOT found.", new string[] { ex.Message }, null);
            }
        }

        private static Response prepareSQL(SearchModel searchModel)
        {
            try
            {
                string sql = "SELECT ";
                //if (searchModel.columns != null && searchModel.tableName != null)
                //{
                //    foreach (KeyValuePair<string, string> column in searchModel.columns)
                //    {
                //        sql += searchModel.tableName + "." + column.Key + " AS " + column.Value + ", ";
                //    }
                //    sql += " FROM " + searchModel.tableName;
                //}
                return new Response(true, 0, "Operation failed.", new string[] { "Missing reference fields." }, null);
            }
            catch (MySqlException ex)
            {
                return new Response(true, 0, "Operation failed.", new string[] { ex.Message }, null);
            }
        }
    }
}