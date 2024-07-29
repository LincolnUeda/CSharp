using APITeste.Model;
using APITeste.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetPDF()
        {
            Document document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));
                    page.Header()
                        .Text("Lista de Clientes")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            List<ClienteModel> clientes = _clienteRepository.ListarTodos();
                            foreach (var cliente in clientes)
                            {

                                string texto = "Código:" + cliente.Id + "\nCPF: " + cliente.Cpf + "\nNome: " + cliente.Nome;
                                x.Item().Text(texto).FontSize(12);
                                
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
