using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            string[] nomes = { "abracadabra", "allottee", "assessee" };
            var prog = new Program(); 

            Console.WriteLine(prog.verificaImpares(numeros));
            prog.exibeLiteraisSemDuplicacoes(nomes);

            Console.WriteLine("Pressione a tecla Enter para sair");

           

            //var resultado = (from a in nomes select a).Distinct();
            

            Console.ReadLine();
        }

        
        /*
         * Exercício 1
         * Metodo para verificar se Array só contem numeros ímpares
         */
        public string verificaImpares(int[] numeros)
        {
            var resultado = (from n in numeros select n).Where(n => n % 2 == 0);
            return resultado.Count() > 0 ? $"O Array possui {resultado.Count()} números pares" : "O Array só possui números ímpares";
        }


        /*
         * Exercicio 2
         * Remove carateres duplicados de um array
         */
        public void exibeLiteraisSemDuplicacoes(string[] literais) {

            foreach (String nome in literais)
            {
                Console.WriteLine(Regex.Replace(nome, @"(.)(\1)+", "$1"));

            }
        }
    }
}
