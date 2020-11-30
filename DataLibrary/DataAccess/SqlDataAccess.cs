using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Dapper;

namespace AppEvolucional.DataLibrary.DataAccess
{
    /// <summary>
    /// Realiza as consultas ao banco de dados
    /// </summary>
    public static class SqlDataAccess
    {
        
        /// <summary>
        /// Retorna a strind de conexão
        /// </summary>
        /// <param name="connectionName">Nome da conexão configurado no appsettings</param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName = "DefaultConnection")
        {
            return Startup.StaticConfig.GetConnectionString("DefaultConnection");

        }

        /// <summary>
        /// Requisita algum dado do banco de dados
        /// </summary>
        /// <param name="sql">String de requisição</param>
        /// <typeparam name="T">Modelo dos dados a serem requisitados</typeparam>
        /// <returns>Lista com todos os dados requisitados</returns>
        public static List<T> LoadData<T>(string sql)
        {
            using(IDbConnection cnn =  new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            } 

        }

        /// <summary>
        /// Grava lgum dado no banco de dados
        /// </summary>
        /// <param name="sql">String de requisição</param>
        /// <param name="data">Dados a serem gravados</param>
        /// <typeparam name="T">odelo dos dados a serem salvos</typeparam>
        /// <returns>resultado da operação, caso houve uma falha retorna -1</returns>
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