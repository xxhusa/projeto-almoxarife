using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxerife
{
    internal class Pessoa
    {
        public string Nome;
        public string CPF;
        public string CEP;
        public string Endereco;


        public void CadastroPessoa()
        {
            Console.WriteLine("Declare o nome");
            Nome = Console.ReadLine();
            Console.WriteLine("CPF");
            CPF = Console.ReadLine();
            Console.WriteLine("CEP");
            CEP = Console.ReadLine();
            Console.WriteLine("Endereço");
            Endereco = Console.ReadLine();

            Console.WriteLine($"{Nome}, {CPF}, {CEP}, {Endereco}");
        }
    }
}