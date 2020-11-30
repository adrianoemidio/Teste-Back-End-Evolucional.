using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Dapper;

namespace AppEvolucional.DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        
        public static string GetConnectionString(string connectionName = "Db")
        {
            return Startup.StaticConfig.GetConnectionString("DefaultConnection");

        }

        public static List<T> LoadData<T>(string sql)
        {
            using(IDbConnection cnn =  new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            } 

        }

        public static int SaveData<T>(string sql, T data)
        {
            using(IDbConnection cnn =  new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //return cnn.Execute(sql,data);
                    return cnn.Query<int>(sql,data).Single();
                    
                }
                catch
                {
                    return -1;
                }

            } 
        }

    }
}