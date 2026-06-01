namespace RpgShop.Models
{
    using System;

    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ItemId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }

        public string NomeCliente { get; set; }
        public string NomeItem { get; set; }

        public Venda() { }

        // O construtor continua sem a DataVenda, pois o banco cuida disso
        public Venda(int clienteId, int itemId, int quantidade, decimal valorTotal)
        {
            if (clienteId < 1) throw new ArgumentException("Erro: ClienteId deve ser um valor positivo.");
            if (itemId < 1) throw new ArgumentException("Erro: ItemId deve ser um valor positivo.");
            if (quantidade < 1) throw new ArgumentException("Erro: A quantidade de itens deve ser maior que zero.");
            if (valorTotal < 0) throw new ArgumentException("Erro: O valor total não pode ser negativo.");

            ClienteId = clienteId;
            ItemId = itemId;
            Quantidade = quantidade;
            ValorTotal = valorTotal;
        }
    }
}