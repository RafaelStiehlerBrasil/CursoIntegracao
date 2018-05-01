using Caelum.Leilao;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        public AvaliadorTest()
        {
        }

        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [SetUp]
        public void CriaAvaliador()
        {
            leiloeiro = new Avaliador();
            joao = new Usuario("João");
            jose = new Usuario("José");
            maria = new Usuario("Maria");
            Console.WriteLine("inicializando teste!");
        }

        [TestFixtureSetUp]
        public void TestandoBeforeClass()
        {
            Console.WriteLine("test fixture setup");
        }

        [TearDown]
        public void Finaliza()
        {
            Console.WriteLine("fim");
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // cenario: 3 lances em ordem crescente
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(maria, 250.0)
            .Lance(joao, 300.0)
            .Lance(jose, 400.0)
            .Constroi();

            // executando a acao
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;
            double mediaEsperado = 317;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(mediaEsperado, Math.Round(leiloeiro.MediaLanc), 0.0001);
            
        }


        [Test]
        public void DeveEntenderUmUnicoLance()
        {
            // cenario: 1 único lance
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 300.0)
            .Constroi();

            // executando a acao
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 300;
            double menorEsperado = 300;
            double mediaEsperado = 300;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(mediaEsperado, Math.Round(leiloeiro.MediaLanc), 0.0001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            // cenario: 3 lances em ordem aleatória
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(maria, 500.0)
            .Lance(joao, 200.0)
            .Lance(jose, 600.0)
            .Constroi();

            // executando a acao
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 600;
            double menorEsperado = 200;
            double mediaEsperado = 433;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(mediaEsperado, Math.Round(leiloeiro.MediaLanc), 0.0001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            // cenario: 3 lances em ordem decrescente
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(maria, 400.0)
            .Lance(joao, 300.0)
            .Lance(jose, 250.0)
            .Constroi();

            // executando a acao
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;
            double mediaEsperado = 317;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(mediaEsperado, Math.Round(leiloeiro.MediaLanc), 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            //Usando somente 2 usuarios
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 100.0)
            .Lance(maria, 200.0)
            .Lance(joao, 300.0)
            .Lance(maria, 400.0)
            .Constroi();

            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.00001);
            Assert.AreEqual(300, maiores[1].Valor, 0.00001);
            Assert.AreEqual(200, maiores[2].Valor, 0.00001);
        }

        [Test]
        public void DeveEncontrarDoisLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 100.0)
            .Lance(maria, 200.0)
            .Constroi();

            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.00001);
            Assert.AreEqual(100, maiores[1].Valor, 0.00001);
        }


        [Test]
        [ExpectedException(typeof (Exception) )]
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {

            Leilao leilao = new CriadorDeLeilao().Para("PlayStation").Constroi();
            leiloeiro.Avalia(leilao);

        }
    }
}
