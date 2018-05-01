using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests1
{
    [TestFixture]
    public class LanceTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRecusarLancesComValorDeZero()
        {
            new Lance(new Usuario("John Doe"), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DeveRecusarLancesComValorNegativo()
        {
            new Lance(new Usuario("John Doe"), -10);
        }
    }
}
