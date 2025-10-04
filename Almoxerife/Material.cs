using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Almoxerife
{
    internal class Material 
    {
        public int codigo;
        public string descricao;
        public string categoria;
        public string tipoProduto;
        public string marca;
        public string modelo;
        public DateTime validade;
        public string fornecedor;
        public int numeroNF;


        public void CadastraMaterial()
        {
            Console.WriteLine("Digite a Descrição do material:");
            descricao = Console.ReadLine();
            Console.WriteLine("Crie um Codigo para seu Material:");
            codigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a categoria do seu materia:");
            categoria = Console.ReadLine();
            Console.WriteLine("Qual a Marca:");
            marca = Console.ReadLine();
            Console.WriteLine("Qual modelo:");
            modelo = Console.ReadLine();
            Console.WriteLine("Data de validade");
            validade = DateTime.Parse (Console.ReadLine());
            Console.WriteLine("Qual o Fornecedor:");
            fornecedor = Console.ReadLine();
            Console.WriteLine("Qual a NF de Entrada:");
            numeroNF = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o tipo do produto: Consumivel ou Devolvivel");
            tipoProduto = Console.ReadLine();

            if (tipoProduto == "Consumivel")
            {
                Console.WriteLine("não tera que devolver");
            } else if (tipoProduto == "Devolvivel") { 
            
                Console.WriteLine("Material tera que ser Devolvido");
            }

            Console.WriteLine($"Dados cadastrados com Sucesso! Codigo : {codigo} , Descrição : {descricao}");

            
  
        }
        }

    }

