using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        private int codigo;
        private int nombre;
        private Cliente cliente;
        private float pesoUnidad;
        private float precio;

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }


        public float PesoUnidad
        {
            get { return pesoUnidad; }
            set { float pesoUnidad = value; }
        }


        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        public int Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}
