using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxerife
{
    internal class Funcionario : Pessoa
    {
        public int Matricula;
        public string Departamento;
        public string Cargo;

        public void CadastroFunc()
        {
            Console.WriteLine("Declare o nome");
            Nome = Console.ReadLine();
            Console.WriteLine("CPF");
            CPF = Console.ReadLine();
            Console.WriteLine("CEP");
            CEP = Console.ReadLine();
            Console.WriteLine("Endereço");
            Endereco = Console.ReadLine();
            Console.WriteLine("Insira matrícula");
            Matricula = int.Parse(Console.ReadLine());
            Console.WriteLine("Departamento");
            Departamento = Console.ReadLine();
            Console.WriteLine("Cargo");
            Cargo = Console.ReadLine();

            Console.WriteLine($"{Nome}, {CPF}, {CEP}, {Endereco}, {Matricula}, {Departamento}, {Cargo}");
        }
    }
}