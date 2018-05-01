using Caelum.Leilao;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,3001),
            new Lance(joao,3000),
            new Lance(joao,4000),
            new Lance(joao, 5200)});

            Console.WriteLine(resultado[0].Valor);
            Console.ReadKey();
        }
    }
}
