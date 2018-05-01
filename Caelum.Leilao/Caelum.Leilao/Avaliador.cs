using System;
using System.Collections.Generic;
using System.Linq;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double medioDeTodos = 0;
        private int contador = 0;
        private IList<Lance> maiores;

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count ==  0)
            {
                throw new Exception("Não é possível um leilão sem lances");

            }

            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }

                medioDeTodos = medioDeTodos + lance.Valor;
                contador = contador + 1;
            }
            medioDeTodos = medioDeTodos / contador;
            pegaOsMaioresNo(leilao);
        }
        private void pegaOsMaioresNo(Leilao leilao)
        {
            var filtro = leilao.Lances.OrderByDescending(p => p.Valor).Take(3);
            maiores = new List<Lance>(filtro);
        }

        
        public double MaiorLance { get { return maiorDeTodos; } }
        public double MenorLance { get { return menorDeTodos; } }
        public double MediaLanc { get { return medioDeTodos; } }
        public IList<Lance> TresMaiores { get { return this.maiores; } }
    }
}

