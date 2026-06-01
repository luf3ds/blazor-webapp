using Npgsql;
using System.Collections.Generic;
using RpgShop.Models;

namespace RpgShop.DAO
{
    public class VendaDAO
    {
        public List<Venda> BuscarListaDeVendas()
        {
            var listaDeVendas = new List<Venda>();
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // INNER JOIN traz os nomes reais para a interface do Blazor
                string sql = @"
                    SELECT v.id, v.cliente_id, v.item_id, v.quantidade, v.valor_total, v.data_venda, 
                           c.nome_usuario, i.nome 
                    FROM vendas v
                    JOIN clientes c ON v.cliente_id = c.id_usuario
                    JOIN itens_rpg i ON v.item_id = i.id
                    ORDER BY v.data_venda ASC";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venda venda = new Venda()
                            {
                                Id = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                ItemId = reader.GetInt32(2),
                                Quantidade = reader.GetInt32(3),
                                ValorTotal = reader.GetDecimal(4),
                                // .ToLocalTime() ajusta o fuso horário vindo do servidor cloud para a sua máquina
                                DataVenda = reader.GetDateTime(5).ToLocalTime(),
                                NomeCliente = reader.GetString(6),
                                NomeItem = reader.GetString(7)
                            };
                            listaDeVendas.Add(venda);
                        }
                    }
                }
            }
            return listaDeVendas;
        }

        public void AdicionarVenda(Venda venda)
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Sem enviar 'data_venda'. O Supabase configurado com 'timestamptz' gera o horário sozinho!
                string sql =
                    "INSERT INTO vendas " +
                    "(cliente_id, item_id, quantidade, valor_total) " +
                    "VALUES (@idCliente, @idItem, @quantidade, @valorTotal)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", venda.ClienteId);
                    cmd.Parameters.AddWithValue("@idItem", venda.ItemId);
                    cmd.Parameters.AddWithValue("@quantidade", venda.Quantidade);
                    cmd.Parameters.AddWithValue("@valorTotal", venda.ValorTotal);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}