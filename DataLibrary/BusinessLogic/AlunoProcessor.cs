using AppEvolucional.DataLibrary.Models;
using AppEvolucional.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace AppEvolucional.DataLibrary.BusinessLogic
{
    /// <summary>
    /// Classe para se realizar operações com a tabela Alunos no db
    /// </summary>
    public static class AlunoProcessor
    {
        /// <summary>
        /// Cria um novo aluno no banco de dados
        /// </summary>
        /// <param name="nome">Nome do aluno</param>
        /// <returns>Id do aluno, caso haja um erro, retorna -1</returns>
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

        /// <summary>
        /// Retrona todos os alunos cadastrados no banco de dados
        /// </summary>
        /// <returns>Lista contendo todos os alunos</returns>
        public static List<AlunoModel> ListAluno()
        {
            
            List<AlunoModel> userList = new List<AlunoModel>();

            string sql = @"select * from Aluno;";

            userList = SqlDataAccess.LoadData<AlunoModel>(sql);

        
            return userList;         
        }

    }

}