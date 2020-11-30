using AppEvolucional.DataLibrary.Models;
using AppEvolucional.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace AppEvolucional.DataLibrary.BusinessLogic
{
    /// <summary>
    /// Classe para manipular a tabela de notas no bd
    /// </summary>
    public static class NotasProcessor
    {

        /// <summary>
        /// Adiciona uma nova nota no banco de dados
        /// </summary>
        /// <param name="alunoID">Id do aluno que possuira essas notas</param>
        /// <param name="matematica">Nota de matematica</param>
        /// <param name="portugues">Nota de portugues</param>
        /// <param name="historia">Nota de historia</param>
        /// <param name="geografia">Nota de geografia</param>
        /// <param name="ingles">Nota de ingles</param>
        /// <param name="biologia">Nota de biologia</param>
        /// <param name="filosofia">Nota de filosofia</param>
        /// <param name="fisica">Nota de fisica</param>
        /// <param name="quimica">Nota de quimica</param>
        /// <returns>Id da nota, caso haja um erro retorna -1</returns>
        public static int CreateNota(
        long alunoID,double matematica,
        double portugues,double historia,
        double geografia,double ingles,
        double biologia,double filosofia,
        double fisica,double quimica)
        {
            NotasModel data = new NotasModel
            {
                AlunoID = alunoID,
                Matematica = matematica,
                Portugues = portugues,
                Historia = historia,
                Geografia = geografia,
                Ingles = ingles,
                Biologia = biologia,
                Filosofia = filosofia,
                Fisica = fisica,
                Quimica  = quimica
            };

            string sql = @"insert dbo.Notas (AlunoID, Matematica,
                        Portugues,Historia,Geografia,Ingles,Biologia,
                        Filosofia,Fisica,Quimica) values(@AlunoID,
                        @Matematica,@Portugues,@Historia,@Geografia,@Ingles,
                        @Biologia,@Filosofia,@Fisica,@Quimica);";
                                        

            return SqlDataAccess.SaveData(sql,data);


        }

        /// <summary>
        /// Retorna todas as notas presentes no db
        /// </summary>
        /// <returns>Lista contendo todas notas</returns>
        public static List<NotasModel> ListNotas()
        {
            List<NotasModel> listaNotas = new List<NotasModel>();

            string sql = @"select * from Notas;";

            listaNotas = SqlDataAccess.LoadData<NotasModel>(sql);

            return listaNotas;
        }


    }

}