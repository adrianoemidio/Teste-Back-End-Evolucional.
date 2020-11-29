using AppEvolucional.DataLibrary.Models;
using AppEvolucional.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace AppEvolucional.DataLibrary.BusinessLogic
{
    public static class NotasProcessor
    {
        public static int CreateNota(long notasID,
            long alunoID,double matematica,
            double portugues,double historia,
            double geografia,double ingles,
            double biologia,double filosofia,
            double fisica,double quimica)
        {
            NotasModel data = new NotasModel
            {
                NotasID = notasID,
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

            string sql = @"insert int dbo.Users (NotasID,AlunoID,
                        Matematica,Portugues,Historia,Geografia,Ingles,Biologia,
                        Filosofia,Fisica,Quimica) values(@NotasID,@AlunoID,
                        @Matematica,@Portugues,@Historia,@Geografia,@Ingles,@Biologia,
                        @Filosofia,@Fisica,@Quimica);";
                                        

            return SqlDataAccess.SaveData(sql,data);


        }


    }

}