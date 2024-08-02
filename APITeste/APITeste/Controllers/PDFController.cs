using APITeste.Model;
using APITeste.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : Controller
    {


        private readonly IGenericRepository<ClienteModel> _clienteRepository;

        public PDFController(IGenericRepository<ClienteModel> clienterep)
        {
            _clienteRepository = clienterep;
        }


        [HttpGet("GerarPDF")]
        public IActionResult RelCadastral(string? titulo)
        {
            if (titulo == null)
            {
                titulo = "Titulo";
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
                            int[] columnswidth = [80,300,100];
                            
                            foreach (int i in columnswidth)
                            {
                                columns.ConstantColumn(i);
                            }
                            
                        });

                        table.Cell().PaddingRight(20).PaddingVertical(10).AlignRight().Text("Código").FontSize(14).Bold();
                        table.Cell().PaddingRight(20).PaddingVertical(10).Text("Nome").FontSize(14).Bold();
                        table.Cell().PaddingRight(20).PaddingVertical(10).Text("CPF").FontSize(14).Bold();

                       
                        List<ClienteModel> clientes = _clienteRepository.ListarTodos();
                        foreach (var cliente in clientes)
                        {

                            table.Cell().PaddingRight(20).AlignRight().Text(cliente.Id.ToString()).FontSize(12);
                            table.Cell().PaddingRight(5).Text(cliente.Nome).FontSize(12);
                            table.Cell().PaddingRight(5).Text(cliente.Cpf).FontSize(12);

                        }

                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });
            byte[] pdfBytes = document.GeneratePdf();
           
            return File(pdfBytes, "application/pdf","teste.pdf");

        }
    }
}
