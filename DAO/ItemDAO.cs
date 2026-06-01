using Npgsql;
using RpgShop.Models;

namespace RpgShop.DAO
{
    public class ItemDAO
    {
        public void AdicionarItem(ItemRPG item)
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "INSERT INTO itens_rpg " +
                    "(nome, tipo, preco, quantidade, descricao) " +
                    "VALUES (@nome, @tipo, @preco, @quantidade, @descricao)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", item.Nome);
                    cmd.Parameters.AddWithValue("@tipo", item.Tipo);
                    cmd.Parameters.AddWithValue("@preco", item.Preco);
                    cmd.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    cmd.Parameters.AddWithValue("@descricao", item.Descricao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ItemRPG> BuscarItensCadastrados()
        {
            var listaDeItens = new List<ItemRPG>();
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM itens_rpg ORDER BY id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemRPG item = new ItemRPG()
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Tipo = reader.GetString(2),
                                Preco = reader.GetDecimal(3),
                                Quantidade = reader.GetInt32(4),
                                Descricao = reader.GetString(5)
                            };
                            listaDeItens.Add(item);
                        }
                    }
                }
            }
            return listaDeItens;
        }
        public void ReporEstoque(int idItem, int novaQuantidade) // <- Adicionado o ID aqui
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "UPDATE itens_rpg " +
                    "SET quantidade = quantidade + @quantidade " +
                    "WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idItem);
                    cmd.Parameters.AddWithValue("@quantidade", novaQuantidade);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ExcluirItem(int idItem)
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "DELETE FROM itens_rpg " +
                    "WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idItem);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AtualizarPreco(int idItem, decimal valorNovo) // <- Adicionado o ID aqui
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "UPDATE itens_rpg " +
                    "SET preco = @preco " +
                    "WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idItem);
                    cmd.Parameters.AddWithValue("@preco", valorNovo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<ItemRPG> BuscarItensPorNome(string nomeItem)
        {
            var listaDeItensFiltrados = new List<ItemRPG>();
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                // Busca por aproximação case-insensitive usando ILIKE
                string sql = "SELECT * FROM itens_rpg WHERE nome ILIKE @nome ORDER BY id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", "%" + nomeItem + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemRPG item = new ItemRPG()
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Tipo = reader.GetString(2),
                                Preco = reader.GetDecimal(3),
                                Quantidade = reader.GetInt32(4),
                                Descricao = reader.GetString(5)
                            };
                            listaDeItensFiltrados.Add(item);
                        }
                    }
                }
            }
            return listaDeItensFiltrados;
        }

        public List<ItemRPG> BuscarItensPorTipo(string tipoItem)
        {
            var listaDeItensFiltrados = new List<ItemRPG>();
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM itens_rpg WHERE tipo = @tipo ORDER BY id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tipo", tipoItem);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ItemRPG item = new ItemRPG()
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Tipo = reader.GetString(2),
                                Preco = reader.GetDecimal(3),
                                Quantidade = reader.GetInt32(4),
                                Descricao = reader.GetString(5)
                            };
                            listaDeItensFiltrados.Add(item);
                        }
                    }
                }
            }
            return listaDeItensFiltrados;
        }
        public void DiminuirEstoque(int idItem, int quantidadeVendida)
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // O banco de dados vai pegar a quantidade atual e subtrair o que foi vendido
                string sql = "UPDATE itens_rpg SET quantidade = quantidade - @quantidade WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idItem);
                    cmd.Parameters.AddWithValue("@quantidade", quantidadeVendida);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
