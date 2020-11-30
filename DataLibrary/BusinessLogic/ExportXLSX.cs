using AppEvolucional.DataLibrary.Models;
using AppEvolucional.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ClosedXML;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AppEvolucional.DataLibrary.BusinessLogic
{
    public static class ExportXLSX
    {
        public static MemoryStream Export()
        {
            List<AlunoModel> alunos = AlunoProcessor.ListAluno();
            List<NotasModel> notas = NotasProcessor.ListNotas();

            NotasModel medias = new NotasModel();

            medias.Matematica = 0;
            medias.Portugues = 0;
            medias.Historia = 0;
            medias.Geografia = 0;
            medias.Ingles = 0;
            medias.Biologia = 0;
            medias.Filosofia = 0;
            medias.Fisica = 0;
            medias.Quimica = 0;

            

            try
            {

                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Notas Alunos");
                    worksheet.Cell(1, 1).Value = "Nome Aluno";
                    worksheet.Cell(1, 2).Value = "Matemática";
                    worksheet.Cell(1, 3).Value = "Português";
                    worksheet.Cell(1, 4).Value = "História";
                    worksheet.Cell(1, 5).Value = "Geografia";
                    worksheet.Cell(1, 6).Value = "Inglês";
                    worksheet.Cell(1, 7).Value = "Biologia";
                    worksheet.Cell(1, 8).Value = "Filosofia";
                    worksheet.Cell(1, 9).Value = "Física";
                    worksheet.Cell(1, 10).Value = "Química";

                    int index = 1;

                    for (; index <= alunos.Count; index++)
                    {
                        worksheet.Cell(index + 1, 1).Value = alunos[index - 1].Nome;
                        worksheet.Cell(index + 1, 2).Value = notas[index - 1].Matematica;
                        worksheet.Cell(index + 1, 3).Value = notas[index - 1].Portugues;
                        worksheet.Cell(index + 1, 4).Value = notas[index - 1].Historia;
                        worksheet.Cell(index + 1, 5).Value = notas[index - 1].Geografia;
                        worksheet.Cell(index + 1, 6).Value = notas[index - 1].Ingles;
                        worksheet.Cell(index + 1, 7).Value = notas[index - 1].Biologia;
                        worksheet.Cell(index + 1, 8).Value = notas[index - 1].Filosofia;
                        worksheet.Cell(index + 1, 9).Value = notas[index - 1].Fisica;
                        worksheet.Cell(index + 1, 10).Value = notas[index - 1].Quimica;

                        medias.Matematica += notas[index - 1].Matematica;
                        medias.Portugues += notas[index - 1].Portugues;
                        medias.Historia  += notas[index - 1].Historia;
                        medias.Geografia  += notas[index - 1].Geografia;
                        medias.Ingles   += notas[index - 1].Ingles;
                        medias.Biologia +=  notas[index - 1].Biologia;
                        medias.Filosofia += notas[index - 1].Filosofia;
                        medias.Fisica   += notas[index - 1].Fisica;
                        medias.Quimica  += notas[index - 1].Quimica;
             
                    }

                    worksheet.Cell(index + 1, 1).Value =  " Medias";
                    worksheet.Cell(index + 1, 2).Value  =   medias.Matematica/alunos.Count();
                    worksheet.Cell(index + 1, 3).Value  =   medias.Portugues/alunos.Count();
                    worksheet.Cell(index + 1, 4).Value  =   medias.Historia/alunos.Count();
                    worksheet.Cell(index + 1, 5).Value  =   medias.Geografia/alunos.Count();
                    worksheet.Cell(index + 1, 6).Value  =   medias.Ingles/alunos.Count();
                    worksheet.Cell(index + 1, 7).Value  =   medias.Biologia/alunos.Count();
                    worksheet.Cell(index + 1, 8).Value  =   medias.Filosofia/alunos.Count();
                    worksheet.Cell(index + 1, 9).Value  =   medias.Fisica/alunos.Count();
                    worksheet.Cell(index + 1, 10).Value  =  medias.Quimica/alunos.Count();
                    

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);

                        return stream;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }


        }

    }
}