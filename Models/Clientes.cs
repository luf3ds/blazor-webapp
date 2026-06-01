namespace RpgShop.Models
{
    using System;

    public class Cliente
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public decimal Saldo { get; set; }

        public Cliente() { }

        public Cliente(int idUsuario, string nomeUsuario, string tipoUsuario, decimal saldo)
        {
            if (idUsuario < 1)
                throw new ArgumentException("Erro: Número de ID deve ser um valor positivo.");

            if (string.IsNullOrWhiteSpace(nomeUsuario))
                throw new ArgumentException("Erro: Nome do usuário não pode ser vazio.");

            if (saldo < 0)
                throw new ArgumentException("Erro: O saldo não pode ser menor que 0.");

            // Aqui estava o erro de cópia/cola na sua versão original ("Tipo de item")
            if (string.IsNullOrWhiteSpace(tipoUsuario))
                throw new ArgumentException("Erro: Tipo de usuário não pode ser vazio.");

            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            TipoUsuario = tipoUsuario;
            Saldo = saldo;
        }
    }
}