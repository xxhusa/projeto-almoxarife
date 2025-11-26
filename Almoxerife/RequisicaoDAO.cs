using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Almoxerife
{
    public class RequisicaoDAO
    {
        private Conexao conexao = new Conexao();

        public void InserirReq(Requisicao r)
        {
            try
            {
                var conn = conexao.Abrir();
                if (conn == null)
                {
                    Console.WriteLine("!ERRO: NÃO FOI POSSIVEL SE CONECTAR!");
                    return;
                }

                string sql = @"INSERT INTO requisicao 
                               (NumeroRequisicao, DataSaida, FuncionarioId)
                               VALUES (@NumeroRequisicao, @DataSaida, @FuncionarioId)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NumeroRequisicao", r.NumeroRequisicao);
                    cmd.Parameters.AddWithValue("@DataSaida", r.DataSaida);
                    cmd.Parameters.AddWithValue("@FuncionarioId", r.Funcionario.Id);

                    int linhas = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{linhas} requisição(ões) cadastrada(s).");

                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("!ERRO: REQUISIÇÃO INVÁLIDA!");
                Console.WriteLine($"{erro.Message}");
            }
        }

        public void MostrarReq()
        {
            try
            {
                var conn = conexao.Abrir();
                if (conn == null)
                {
                    Console.WriteLine("!ERRO: CONEXÃO FALHOU!");
                    return;
                }

                string sql = "SELECT * FROM requisicao";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        int numero = Convert.ToInt32(reader["NumeroRequisicao"]);
                        int funcionario = Convert.ToInt32(reader["FuncionarioId"]);
                        DateTime data = Convert.ToDateTime(reader["DataSaida"]);

                        Console.WriteLine($"ID: {id} Req Nº: {numero} Funcionário ID: {funcionario} Data: {data.ToShortDateString()}");
                    }
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("!ERRO: REQUISIÇÃO NÃO LISTADA!");
                Console.WriteLine($"Detalhes: {erro.Message}");
            }
        }

        public void AlterarReq()
        {
            try
            {
                Console.Write("ID:");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Novo ID");
                int novoNum = int.Parse(Console.ReadLine());

                var conn = conexao.Abrir();
                if (conn == null)
                {
                    Console.WriteLine("!ERRO: NÃO FOI POSSIVEL SE CONECTAR!");
                    return;
                }

                string sql = "UPDATE requisicao SET NumeroRequisicao=@num WHERE Id=@id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@num", novoNum);
                    cmd.Parameters.AddWithValue("@id", id);

                    int alterados = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{alterados} registro atualizado.");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("!ERRO: REQUISIÇÃO NÃO ATUALIZADA!");
                Console.WriteLine($"{erro.Message}");
            }
        }

        public void DeletarReq()
        {
            try
            {
                Console.Write("ID");
                int id = int.Parse(Console.ReadLine());

                var conn = conexao.Abrir();
                if (conn == null)
                {
                    Console.WriteLine("!ERRO: NÃO FOI POSSIVEL SE CONECTAR!");
                    return;
                }

                string sql = "DELETE FROM requisicao WHERE Id=@id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int removidos = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{removidos} registro(s) excluído(s).");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("!ERRO: REQUISIÇÃO NÃO DELETADA!");
                Console.WriteLine($"{erro.Message}");
            }
        }

        public Requisicao BuscarPorNumero(int numeroReq)
        {
            try
            {
                var conn = conexao.Abrir();
                if (conn == null)
                {
                    Console.WriteLine("!ERRO: NÃO FOI POSSIVEL SE CONECTAR!");
                    
                }

                string sql = "SELECT * FROM requisicao WHERE NumeroRequisicao = @num";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@num", numeroReq);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Requisicao r = new Requisicao();
                            r.Id = Convert.ToInt32(reader["Id"]);
                            r.NumeroRequisicao = Convert.ToInt32(reader["NumeroRequisicao"]);
                            r.Funcionario.Id = Convert.ToInt32(reader["FuncionarioId"]);
                            r.DataSaida = Convert.ToDateTime(reader["DataSaida"]);

                            return r;
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("!ERRO: REQUISIÇÃO NÃO ENCONTRADA!");
                Console.WriteLine($"{erro.Message}");
            }

            return null;
        }
    }
}
