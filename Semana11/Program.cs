using System;

class Libro
{
    private static int correlativo = 0;
    private int codigo;
    private string nombre;
    private int cantidadPaginas;
    private int paginasLeidas;
    private bool leido;

    public Libro(string nombre, int cantidadPaginas)
    {
        this.codigo = ++correlativo;
        this.nombre = nombre;
        this.cantidadPaginas = cantidadPaginas;
        this.paginasLeidas = 0;
        this.leido = false;
    }

    public void Leer(int paginas)
    {
        if (paginasLeidas + paginas > cantidadPaginas)
        {
            Console.WriteLine("Error: No se pueden leer más páginas de las que tiene el libro.");
            return;
        }
        paginasLeidas += paginas;
        if (paginasLeidas == cantidadPaginas)
        {
            leido = true;
        }
    }

    public float ObtenerPorcentajeLectura()
    {
        return (float)paginasLeidas / cantidadPaginas * 100;
    }

    public int ObtenerPaginaActual()
    {
        return paginasLeidas + 1;
    }

    public void MostrarLibro()
    {
        Console.WriteLine("Código: {0}", codigo);
        Console.WriteLine("Nombre: {0}", nombre);
        Console.WriteLine("Cantidad de páginas: {0}", cantidadPaginas);
        Console.WriteLine("Porcentaje de lectura: {0}%", ObtenerPorcentajeLectura());
        Console.WriteLine("Páginas leídas: {0}", paginasLeidas);
        Console.WriteLine("Estado: {0}", leido ? "Leído" : "En proceso");
    }

    public string ObtenerEstadoLibro()
    {
        if (leido)
        {
            return "Leído";
        }
        else if (paginasLeidas > 0)
        {
            return "En proceso";
        }
        else
        {
            return "No leído";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Libro libro = new Libro("Cien años de soledad", 471);

        libro.MostrarLibro();

        libro.Leer(100);
        Console.WriteLine("Página actual: {0}", libro.ObtenerPaginaActual());
        Console.WriteLine("Estado: {0}", libro.ObtenerEstadoLibro());
        libro.MostrarLibro();

        libro.Leer(400);
        Console.WriteLine("Página actual: {0}", libro.ObtenerPaginaActual());
        Console.WriteLine("Estado: {0}", libro.ObtenerEstadoLibro());
        libro.MostrarLibro();

        libro.Leer(100);
        Console.WriteLine("Página actual: {0}", libro.ObtenerPaginaActual());
        Console.WriteLine("Estado: {0}", libro.ObtenerEstadoLibro());
        libro.MostrarLibro();
    }
}