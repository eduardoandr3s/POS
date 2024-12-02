﻿namespace POS
{


    abstract class Producto
    {

        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; }
        public decimal Impuesto { get; set; }


        public Producto(string nombre, decimal precio, string categoria, string codigo, decimal impuesto)
        {

            this.Nombre = nombre;
            this.Valor = precio;
            this.Categoria = categoria;
            this.Codigo = codigo;
            this.Impuesto = impuesto;
        }
        public abstract decimal CalcularPrecioFinal();

        public virtual void MostrarDetalles()
        {

            Console.WriteLine($"Producto: {Nombre}, Valor: {Valor:C}, Categoría: {Categoria}, Código: {Codigo}, Impuesto: {Impuesto:C}");
        }

    }

    class Libro : Producto
    {

        public string Autor { get; set; }
        public int NumeroPaginas { get; set; }



        public Libro(string nombre, decimal precio, string categoria, string codigo, decimal impuesto, string autor, int numeroPaginas) : base(nombre, precio, categoria, codigo, impuesto)
        {
            this.Autor = autor;
            this.NumeroPaginas = numeroPaginas;
        }

        public override decimal CalcularPrecioFinal()
        {
            decimal descuento = 0.1m;
            decimal precioConDescuento = this.Valor - (this.Valor * descuento);

            return precioConDescuento + (precioConDescuento * this.Impuesto);
        }

        public override void MostrarDetalles()
        {

            base.MostrarDetalles();
            Console.WriteLine($"Autor: {Autor}, Páginas: {NumeroPaginas}, Precio final: {CalcularPrecioFinal:C}");


        }


    }


    class Computadora : Producto
    {

        public string Marca { get; set; }
        public string Procesador { get; set; }
        public int RAM { get; set; }



        public Computadora(string nombre, decimal precio, string categoria, string codigo, decimal impuesto, string marca, string procesador, int ram) : base(nombre, precio, categoria, codigo, impuesto)
        {
            this.Marca = marca;
            this.Procesador = procesador;
            this.RAM = ram;
        }

        public override decimal CalcularPrecioFinal()
        {

            return this.Valor + (this.Valor * this.Impuesto);

        }
        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Marca {Marca}, Procesador: {Procesador}, RAM: {RAM}");
        }



    }


    class Factura : Producto
    {


        private List<Producto> productos = new List<Producto>();


        public void AgregarProducto(Producto producto)
        {

            productos.Add(producto);
        }

        public void MostrarProductos() { 
        
        decimal total = 0;
            Console.WriteLine("Lista productos");
            foreach (Producto producto in productos) {
                Console.WriteLine(producto.MostrarDetalles());
                total += producto.CalcularPrecioFinal();

            }

            
        
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
