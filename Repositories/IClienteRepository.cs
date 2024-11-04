using ClienteAPI.Models;
using System.Collections.Generic;

namespace ClienteAPI.Repositories
{
    public interface IClienteRepository
    {
        Cliente? GetClienteById(int id);
        IEnumerable<Cliente> GetAllClientes();
        Cliente? GetByCPF(string cpf);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(string cpf);
    }
}