using ClienteAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClienteAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes = new();

        public Cliente? GetClienteById(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> GetAllClientes()  // Certifique-se de que este método existe
        {
            return _clientes;
        }

        public Cliente? GetByCPF(string cpf)
        {
            return _clientes.FirstOrDefault(c => c.CPF == cpf);
        }

        public void Add(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            var existingCliente = GetClienteById(cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.CPF = cliente.CPF;
                existingCliente.Nome = cliente.Nome;
                existingCliente.Email = cliente.Email;
            }
        }

        public void Delete(string cpf)
        {
            var cliente = GetByCPF(cpf);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }
    }
}