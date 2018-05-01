using System;

namespace Caelum.Leilao
{

    public class Lance
    {

        public Usuario Usuario { get; private set; }
        public double Valor { get; private set; }

        public Lance(Usuario usuario, double valor)
        {
            if (valor <= 0) throw new ArgumentException();
            this.Usuario = usuario;
            this.Valor = valor;
        }



    }
}