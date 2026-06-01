using Npgsql;
using System.Collections.Generic;
using RpgShop.Models;

namespace RpgShop.DAO
{
    public class ClienteDAO
    {
        public List<Cliente> BuscarClientesCadastrados()
        {
            var listaDeClientes = new List<Cliente>();
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM clientes ORDER BY id_usuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cli = new Cliente()
                            {
                                IdUsuario = reader.GetInt32(0),
                                NomeUsuario = reader.GetString(1),
                                TipoUsuario = reader.GetString(2),
                                Saldo = reader.GetDecimal(3)
                            };
                            listaDeClientes.Add(cli);
                        }
                    }
                }
            }
            return listaDeClientes;
        }

        public bool DescontarSaldo(int idUsuario, decimal valorCompra)
        {
            using (NpgsqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                // Desconto do saldo (-=) e validação diretamente na query
                string sql = "UPDATE clientes SET saldo = saldo - @valor WHERE id_usuario = @id AND saldo >= @valor";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.Parameters.AddWithValue("@valor", valorCompra);

                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
        }
    }
}
