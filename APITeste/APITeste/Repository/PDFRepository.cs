using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace APITeste.Repository
{
    public class PDFRepository
    {

        public static byte[] RelCadastral(string? titulo,PDFItens? itens)
        {
            if (titulo == null)
            {
                titulo = "Titulo";
            }
            if (itens == null)
            {
                itens = new PDFItens();
            }
            Document document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));
                    page.Header().Border(1).PaddingVertical(5).PaddingHorizontal(3).Text(titulo).SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);



                    page.Content().Table(table => {

                        table.ColumnsDefinition(columns =>
                        {
                            foreach (int i in itens.columnwitdh)
                            {
                                columns.ConstantColumn(i);
                            }
                        });

                        foreach (string titulo in itens.titulos)
                        {
                            table.Cell().PaddingRight(20).PaddingVertical(10).Text(titulo).FontSize(14).Bold();

                        }
                        
                        for (int i = 0; i < itens.itens.GetLength(0);i++)
                        {
                            for (int j = 0; j < itens.itens.GetLength(1); j++)
                            {
                                table.Cell().PaddingRight(5).Text(itens.itens[i, j]).FontSize(12);
                            }

                        }

                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                        });
                });
            });
            byte[] pdfBytes = document.GeneratePdf();

            return pdfBytes;

        }


    }
}
