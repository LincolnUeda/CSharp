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


        [HttpPost("Adicionar")]
        public ClienteModel Adicionar(ClienteModel novocliente)
        {
           
             _clienteRepository.Adicionar(novocliente);
           

            return novocliente;
        }













    }
}
