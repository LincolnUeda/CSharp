using APITeste.DTO;
using APITeste.Model;
using APITeste.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IGenericRepository<ClienteModel> _clienteRepository;

        public ClienteController(IGenericRepository<ClienteModel> clienterep)
        {
            _clienteRepository = clienterep;
        }


        [HttpGet("Listar")]
        public List<ClienteModel> Listar()
        {
            var clientes = _clienteRepository.ListarTodos();
            return clientes;
        }

        [HttpGet("ListarId")]
        public ClienteModel ListarId(int id)
        {
            var cliente = _clienteRepository.ListarId(id);
            if (cliente == null)
            {
                cliente = new ClienteModel { Id = 0, Nome = "cliente não encontrado", Cpf = "0" };
            }

            return cliente;
        }


        [HttpPost("Adicionar")]
        public ClienteModel Adicionar(ClienteDTO novocliente)
        {
            ClienteModel clienteModel = new ClienteModel
            {
                Cpf = novocliente.Cpf,
                Nome = novocliente.Nome,
            };
            _clienteRepository.Adicionar(clienteModel);


            return clienteModel;
        }


        [HttpPut("Editar")]
        public ClienteModel Editar(ClienteModel cliente)
        {

            _clienteRepository.Editar(cliente);
            return cliente;
        }

        [HttpDelete("Apagar")]
        public ClienteModel Apagar(ClienteModel cliente)
        {

            _clienteRepository.Apagar(cliente);
            return cliente;
        }


        [HttpGet("RelatorioCadastral")]
        public IActionResult RelCadastral()
        {
            string titulo = "Clientes";
            var clientes = _clienteRepository.ListarTodos();
            string[,]? clientescolunas = new string[clientes.Count(),3];
            int i = 0;
            foreach (ClienteModel cliente in clientes)
            {
                clientescolunas[i, 0] = cliente.Id.ToString();
                clientescolunas[i, 1] = cliente.Nome;
                clientescolunas[i, 2] = cliente.Cpf;
                i++;

            }

            PDFItens itens = new PDFItens
            {

                columnwitdh = [80, 300, 100],
                titulos = ["Código", "Nome", "CPF"],
                itens = clientescolunas
            };
            byte[] pdfBytes = PDFRepository.RelCadastral(titulo, itens);


            return File(pdfBytes, "application/pdf", "teste.pdf");


        }
    }
}
