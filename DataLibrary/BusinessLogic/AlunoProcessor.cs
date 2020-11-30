using AppEvolucional.DataLibrary.Models;
using AppEvolucional.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace AppEvolucional.DataLibrary.BusinessLogic
{
    public static class AlunoProcessor
    {
        public static int CreateAluno(string nome)
        {
            AlunoModel data = new AlunoModel
            {

               Nome = nome

            };

            string sql = @"insert dbo.Aluno(Nome)
                         values(@Nome); select SCOPE_IDENTITY()";

            return SqlDataAccess.SaveData(sql,data);

        }

        public static List<UserModel> ListAluno(int alunoID,string nome)
        {
            
            List<UserModel> userList = new List<UserModel>();

            AlunoModel data = new AlunoModel
            {

                AlunoID = alunoID,
                Nome = nome

            };

            string sql = @"SELECT * FROM Users WHERE @Nome = Nome;";

            userList = SqlDataAccess.LoadData<UserModel>(sql);

        
            return userList;         
        }

    }

}