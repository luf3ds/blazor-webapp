namespace RpgShop.Models
{
    public class ItemRPG
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        public ItemRPG() { }

        public ItemRPG(int id, string nome, string tipo, decimal preco, int estoque, string descricao)
        {
            if (id < 1) throw new ArgumentException("Erro: Número de ID deve ser um valor positivo.");
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Erro: Nome do item não pode ser vazio.");
            if (preco < 0) throw new ArgumentException("Erro: Preço não deve receber um valor negativo.");
            if (estoque < 0) throw new ArgumentException("Erro: Quantidade em estoque não deve receber um valor negativo.");
            if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("Erro: Tipo de item não pode ser vazio.");

            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = estoque;
            Tipo = tipo;
            Descricao = descricao;
        }
    }
}