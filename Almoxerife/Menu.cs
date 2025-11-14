using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxerife
{
    internal class Menu
    {
        public void ExibirMenuPrincipal()
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Cadastros de Funcionario");
                Console.WriteLine("2 - Cadastros de Fornecedor");
                Console.WriteLine("3 - Entradas (Notas Fiscais)");
                Console.WriteLine("4 - Requisições");
                Console.WriteLine("5 - Devoluções");
                Console.WriteLine("6 - Estoque");
                Console.WriteLine("0 - Sair");
                Console.Write("Selecione uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuCadastro menuCadastro = new MenuCadastro();
                        menuCadastro.Exibir();
                        break;
                    case 2:
                        MenuFornecedor menufornecedor = new MenuFornecedor();
                        menufornecedor.Exibir();
                        break;
                    case 3:
                        NotaFiscal nf = new NotaFiscal();
                        nf.RegistrarNota();
                        break;
                    case 4:
                        Console.WriteLine("Menu de Requisições...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Menu de Devoluções...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Menu de Estoque...");
                        Console.ReadKey();
                        break;
                    case 0:

                        Console.WriteLine("saindo do programa");

                        break;
                }

            } while (opcao != 0);
        }
    }
}
    

