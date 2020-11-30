using AppEvolucional.DataLibrary.Models;
using AppEvolucional.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AppEvolucional.DataLibrary.BusinessLogic
{
    /// <summary>
    /// Classe para preencher a tabela dados as espeficações
    /// </summary>
    public static class Tablefill
    {

        private static string[] nomeArray = {
            "Maria", "José", "Pedro", "Jacobino",
            "Souza", "Peres","Fonseca","Armando",
            "Suelen","Selena","Mariana","Silva",
            "Dom","Capelo","Freitas","Lorena",
            "Aparecida", "Jaime","Alfredo",
            "Carlos","Tupã","Alice","Takashi",
            "Ana","Betriz","Cabrones","Pezzota",
            "Lisboa","Carvalho","Altino","Prudente"
        };

        /// <summary>
        /// Preenche o banco dados com 1000 alunos aletórios diferentes
        /// cada um com o seu conjunto de notas gerado aletorimente
        /// </summary>
        public static void startOperation()
        {
            Random rand = new Random();

            int tryOut = 50;
            int count  = 1000;

            while(count > 0)
            {

                List<int> posNomes = new List<int>();
                List<Double> notas = new List<double>();
                int pos;

                if(tryOut == 0)
                    break;

                //Pega 3 No diferentes aleatorios
                for(int i = 0; i < 3; i++)
                {
                    do
                    {
                        pos = rand.Next(0, 31);

                    }while(posNomes.Contains(pos));

                    posNomes.Add(pos);
                } 

                for(int i = 0; i < 9; i++)
                {
                    double nota = (Convert.ToDouble(rand.Next(0,10)) + rand.NextDouble());

                    if(nota > 10) nota = 10;

                    notas.Add(Math.Round(nota,2));

                }

                string nomeAluno = String.Format("{0} {1} {2}",nomeArray[posNomes[0]],
                    nomeArray[posNomes[1]],nomeArray[posNomes[2]]);

                long alunoId = AlunoProcessor.CreateAluno(nomeAluno);

                if(alunoId == -1)
                {
                    tryOut--;

                }
                else
                {
                    NotasProcessor.CreateNota(alunoId,notas[0],
                            notas[1],notas[2],notas[3],notas[4],
                            notas[5],notas[6],notas[7],notas[8]);

                    tryOut = 50;
                    count--;
                }

            }
        }

    }
}