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

        public static List<AlunoModel> ListAluno()
        {
            
            List<AlunoModel> userList = new List<AlunoModel>();

            /*
            AlunoModel data = new AlunoModel
            {

                AlunoID = alunoID,
                Nome = nome

            };
            */

            string sql = @"select * from Aluno;";

            userList = SqlDataAccess.LoadData<AlunoModel>(sql);

        
            return userList;         
        }

    }

}