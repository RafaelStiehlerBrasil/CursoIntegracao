using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {

        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniak"), 3000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveJobs, 3000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario billGates = new Usuario("Bill Gates");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(billGates, 3000));
            leilao.Propoe(new Lance(steveJobs, 4000));
            leilao.Propoe(new Lance(billGates, 5000));
            leilao.Propoe(new Lance(steveJobs, 6000));
            leilao.Propoe(new Lance(billGates, 7000));
            leilao.Propoe(new Lance(steveJobs, 8000));
            leilao.Propoe(new Lance(billGates, 9000));
            leilao.Propoe(new Lance(steveJobs, 10000));
            leilao.Propoe(new Lance(billGates, 11000));

            // deve ser ignorado
            leilao.Propoe(new Lance(steveJobs, 12000));

            Assert.AreEqual(10, leilao.Lances.Count);
            int ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(11000.0, ultimoLance.Valor, 0.00001);
        }

        [Test]
        public void DeveDobrarOUltimoLanceDado()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario billGates = new Usuario("Bill Gates");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(billGates, 3000));
            leilao.DobraLance(steveJobs);

            Assert.AreEqual(4000, leilao.Lances[2].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveDobrarCasoNaoHajaLanceAnterior()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");

            leilao.DobraLance(steveJobs);

            Assert.AreEqual(0, leilao.Lances.Count);
        }


    }
}
