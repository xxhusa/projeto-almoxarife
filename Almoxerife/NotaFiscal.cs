using Almoxerife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxerife
{
     class NotaFiscal
    {
        public int NumeroNF;
        public DateTime DataEntrada;
        public Fornecedor fornecedor;
        public List<ItemNF> Itens = new List<ItemNF>();
    
        public void RegistrarNota()
        {
            Console.WriteLine("Número da Nota Fiscal:");
            NumeroNF = int.Parse(Console.ReadLine());

            Console.WriteLine("Data de Entrada (Ex: 10/11/2025):");
            DataEntrada = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("ID do Fornecedor:");
            int idFornecedor = int.Parse(Console.ReadLine());

            FornecedorDAO fdao = new FornecedorDAO();
            fornecedor = fdao.BuscarPorId(idFornecedor);

            bool adicionarMais = true;
            MaterialDAO mdao = new MaterialDAO();

            while (adicionarMais)
    {
                Console.WriteLine("\n--- Cadastro de Item da Nota ---");

                Console.WriteLine("Código do Material (numérico):");
                int codigoMaterial = int.Parse(Console.ReadLine());

                // Verifica se o material já existe
                Material material = mdao.BuscarPorCodigo(codigoMaterial);

                if (material == null)
                {
                    Console.WriteLine("Material não encontrado. Cadastrando novo material.");

                    material = new Material();
                    material.Codigo = codigoMaterial;

                    Console.WriteLine("Descrição:");
                    material.Descricao = Console.ReadLine();

                    Console.WriteLine("Categoria:");
                    material.Categoria = Console.ReadLine();

                    Console.WriteLine("Marca:");
                    material.Marca = Console.ReadLine();

                    Console.WriteLine("Modelo:");
                    material.Modelo = Console.ReadLine();

                    Console.WriteLine("Validade (Enter se não tiver):");
                    string dataVal = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(dataVal))
                    {
                        material.Validade = DateTime.MinValue; // indica "sem validade"
                    }
                    else
                    {
                        material.Validade = DateTime.Parse(dataVal);
                    }

                    Console.WriteLine("Tipo do Produto (Consumível / Devolvível):");
                    material.TipoProduto = Console.ReadLine();

                    
                    mdao.Inserir(material);
                }
                ItemNF item = new ItemNF();
                item.Material = material;
                Console.WriteLine("Quantidade Recebida:");
                item.Quantidade = int.Parse(Console.ReadLine());

                Itens.Add(item);

                Console.WriteLine("Adicionar mais itens? (s/n)");
                adicionarMais = Console.ReadLine().ToLower() == "s";
            }

            NotaFiscalDAO nfdao = new NotaFiscalDAO();
            nfdao.Inserir(this);

            Console.WriteLine("\n Nota cadastrada com sucesso!");
}
    }
}