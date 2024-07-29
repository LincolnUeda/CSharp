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
                cliente = new ClienteModel { Id = 0, Nome = "cliente não encontrado", Cpf = "0"};
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










    }
}
