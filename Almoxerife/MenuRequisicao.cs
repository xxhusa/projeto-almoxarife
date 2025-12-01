using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxerife
{
    internal class MenuRequisicao
    {
        public void Exibir()
        {


            string opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU REQUISICAO ===");
                Console.WriteLine("1 -  Fazer requisicao");
                Console.WriteLine("2 - Mostrar requisicao");
                Console.WriteLine("3 - Alteracao de requisicao");
                Console.WriteLine("4 - Deletar requisicao");
                Console.WriteLine("B - Voltar");
                Console.Write("Selecione uma opção: ");

                opcao = Console.ReadLine().ToUpper();

                RequisicaoDAO dao = new RequisicaoDAO();


                switch (opcao)
                {
                    case "1":

                       
                        Requisicao r = new Requisicao();
                        r.Funcionario = new Funcionario();
                        FuncionarioDAO fda = new FuncionarioDAO();
                        fda.Mostrar();
                        Console.WriteLine("Digite o Id do funcionario ");
                        r.Funcionario.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o numero da requisicao");
                        r.NumeroRequisicao = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a data da requisicao");
                        r.DataSaida = DateTime.Parse(Console.ReadLine());   


                        dao.InserirReq(r);
                        Console.WriteLine("\nRequisicao cadastrada com sucesso!");
                        Console.ReadKey();


                        break;


                    case "2":

                        Requisicao r1 = new Requisicao();
                        r1.Funcionario = new Funcionario();
                        FuncionarioDAO fda2 = new FuncionarioDAO();
                        fda2.Mostrar();
                        Console.WriteLine("Digite o Id do funcionario ");
                        r1.Funcionario.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o Id da requisicao ");
                        r1.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o numero da requisicao");
                        r1.NumeroRequisicao = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a data da requisicao");
                        r1.DataSaida = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Lista de Fornecedores Cadastrados");

                        dao.MostrarReq();
                        Console.ReadKey();

                        break;

                    case "3":

                        Requisicao r2 = new Requisicao();
                        r2.Funcionario = new Funcionario();
                        FuncionarioDAO fda3 = new FuncionarioDAO();
                        fda3.Mostrar();
                        Console.WriteLine("Digite o Id da requisicao ");
                        r2.Funcionario.Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o novo numero ");
                        r2.Id = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Alterar Dados Cadatrais de Fornecedores:");

                        dao.AlterarReq();
                        Console.ReadKey();

                        break;

                    case "4":

                        Requisicao r3 = new Requisicao();
                        r3.Funcionario = new Funcionario();
                        FuncionarioDAO fda4 = new FuncionarioDAO();
                        fda4.Mostrar();
                        Console.WriteLine("Digite o Id da requisicao ");
                        r3.Funcionario.Id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Deletar Fornecedores");

                        dao.DeletarReq();
                        Console.ReadKey();

                        break;

                    case "B":

                        Console.WriteLine("saindo do programa");

                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

                if (opcao != "B")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != "B");
        }
    }
}
