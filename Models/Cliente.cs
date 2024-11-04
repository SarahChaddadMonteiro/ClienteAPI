namespace ClienteAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

    
        public Cliente(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
        }
    }
}