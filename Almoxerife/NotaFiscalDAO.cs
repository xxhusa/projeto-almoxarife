using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Almoxerife
{
    internal class NotaFiscalDAO
    {
        private Conexao conexao = new Conexao();

        public void Inserir(NotaFiscal nf)
        {
            var conn = conexao.Abrir();

            MaterialDAO mdao = new MaterialDAO();

            try
            {

                string sqlNF = "INSERT INTO nota_fiscal (NumeroNF, DataEntrada, FornecedorId) VALUES (@NumeroNF, @DataEntrada, @FornecedorId)";


                MySqlCommand cmdNF = new MySqlCommand(sqlNF, conn);

                cmdNF.Parameters.AddWithValue("@NumeroNF", nf.NumeroNF);
                cmdNF.Parameters.AddWithValue("@DataEntrada", nf.DataEntrada);
                cmdNF.Parameters.AddWithValue("@FornecedorId", nf.fornecedor.Id);
                cmdNF.ExecuteNonQuery();

                int notaId = (int)cmdNF.LastInsertedId;

                foreach (var item in nf.Itens)
                {
                    mdao.AtualizarEstoque(item.Material.Codigo, item.Quantidade);

                    string sqlItem = "INSERT INTO item_nf (NotaFiscalId, MaterialId, Quantidade) VALUES (@NotaFiscalId, @MaterialId, @Quantidade)";

                    MySqlCommand cmdItem = new MySqlCommand(sqlItem, conn);

                    cmdItem.Parameters.AddWithValue("@NotaFiscalId", notaId);
                    cmdItem.Parameters.AddWithValue("@MaterialId", item.Material.Codigo);
                    cmdItem.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    cmdItem.ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro ao inserir nota fiscal: {erro.Message}");
            }

        }
    }
}
