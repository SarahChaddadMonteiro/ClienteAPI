using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ClienteAPI.Models;
using ClienteAPI.Repositories;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            // Alterado para chamar o método correto
            return _clienteRepository.GetAllClientes();
        }

        [HttpGet("{cpf}")]
        public ActionResult<Cliente> GetCliente(string cpf)
        {
            var cliente = _clienteRepository.GetByCPF(cpf);
            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public ActionResult AddCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _clienteRepository.Add(cliente);
            return CreatedAtAction(nameof(GetCliente), new { cpf = cliente.CPF }, cliente);
        }

        [HttpPut("{cpf}")]
        public ActionResult UpdateCliente(string cpf, Cliente cliente)
        {
            if (cpf != cliente.CPF)
            {
                return BadRequest();
            }

            var clienteExistente = _clienteRepository.GetByCPF(cpf);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            _clienteRepository.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public ActionResult DeleteCliente(string cpf)
        {
            var cliente = _clienteRepository.GetByCPF(cpf);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteRepository.Delete(cpf);
            return NoContent();
        }
    }
}