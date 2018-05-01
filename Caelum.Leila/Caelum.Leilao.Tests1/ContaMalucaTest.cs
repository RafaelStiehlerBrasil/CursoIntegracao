using Caelum.Leilao;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    [TestFixture]
    public class ContaMalucaTest
    {
        public ContaMalucaTest()
        {
        }

        [Test]
        public void NumeroMaiorQueTrinta()
        {
            //cenário 1 onde o número é maior que trinta

            MatematicaMaluca conta1 = new MatematicaMaluca();
            int retornoConta = conta1.ContaMaluca(35);

            Assert.AreEqual(140, retornoConta, 0.0001);
        }

        [Test]
        public void NumeroMaiorQueDez()
        {
            //cenário 1 onde o número é maior que trinta

            MatematicaMaluca conta1 = new MatematicaMaluca();
            int retornoConta = conta1.ContaMaluca(15);

            Assert.AreEqual(45, retornoConta, 0.0001);
        }

        [Test]
        public void NumeroMenorDez()
        {
            //cenário 1 onde o número é maior que trinta

            MatematicaMaluca conta1 = new MatematicaMaluca();
            int retornoConta = conta1.ContaMaluca(5);

            Assert.AreEqual(10, retornoConta, 0.0001);
        }

    }
}
