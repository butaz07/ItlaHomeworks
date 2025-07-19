public class Contacto
    //Ian Elian Chavez Franco 20242577
{

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int Edad { get; set; }
    public bool EsMejorAmigo { get; set; }

    
    public Contacto(int id, string nombre, string apellido, string direccion, string telefono, string email, int edad, bool esMejorAmigo)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        Telefono = telefono;
        Email = email;
        Edad = edad;
        EsMejorAmigo = esMejorAmigo;
    }

    
    public void MostrarInformacion()
    {
        string esAmigo = EsMejorAmigo ? "Sí" : "No";
        Console.WriteLine($"{Nombre,-15} {Apellido,-20} {Direccion,-20} {Telefono,-15} {Email,-20} {Edad,-10} {esAmigo}");

    }
}








public class GestorContactos
{
    private List<Contacto> contactos = new List<Contacto>();
    private int siguienteId = 1;

   
    public void AgregarContacto(Contacto nuevoContacto)
    {
        nuevoContacto.Id = siguienteId++;
        contactos.Add(nuevoContacto);
    }

    public void MostrarTodos()
    {
        Console.WriteLine($"{"Nombre",-15} {"Apellido",-20} {"Dirección",-20} {"Teléfono",-15} {"Email",-20} {"Edad",-10} {"Mejor Amigo"}");
        Console.WriteLine(new string('-', 120));

        foreach (var contacto in contactos)
        {
            contacto.MostrarInformacion();
        }
    }

    public Contacto BuscarPorId(int id)
    {
        return contactos.FirstOrDefault(c => c.Id == id);
    }

    public List<Contacto> BuscarPorNombre(string termino)
    {
        return contactos.Where(c =>
            c.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
            c.Apellido.Contains(termino, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public bool EliminarContacto(int id)
    {
        var contacto = BuscarPorId(id);
        if (contacto != null)
        {
            contactos.Remove(contacto);
            return true;
        }
        return false;
    }
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a mi lista de Contactos");
        GestorContactos gestor = new GestorContactos();
        bool ejecutando = true;

        while (ejecutando)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarContacto(gestor);
                    break;
                case "2":
                    gestor.MostrarTodos();
                    break;
                case "3":
                    BuscarContacto(gestor);
                    break;
                case "4":
                    ModificarContacto(gestor);
                    break;
                case "5":
                    EliminarContacto(gestor);
                    break;
                case "6":
                    ejecutando = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\nMenú Principal:");
        Console.WriteLine("1. Agregar Contacto");
        Console.WriteLine("2. Ver Contactos");
        Console.WriteLine("3. Buscar Contactos");
        Console.WriteLine("4. Modificar Contacto");
        Console.WriteLine("5. Eliminar Contacto");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AgregarContacto(GestorContactos gestor)
    {
        Console.WriteLine("\nNuevo Contacto:");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("¿Es mejor amigo? (S/N): ");
        bool esMejorAmigo = Console.ReadLine().ToUpper() == "S";

        var nuevoContacto = new Contacto(0, nombre, apellido, direccion, telefono, email, edad, esMejorAmigo);
        gestor.AgregarContacto(nuevoContacto);

        Console.WriteLine("Contacto agregado exitosamente!");
    }

    static void BuscarContacto(GestorContactos gestor)
    {
        Console.Write("\nIngrese nombre o apellido a buscar: ");
        string termino = Console.ReadLine();

        var resultados = gestor.BuscarPorNombre(termino);

        if (resultados.Any())
        {
            Console.WriteLine("\nResultados de la búsqueda:");
            foreach (var contacto in resultados)
            {
                contacto.MostrarInformacion();
            }
        }
        else
        {
            Console.WriteLine("No se encontraron contactos que coincidan.");
        }
    }

    static void ModificarContacto(GestorContactos gestor)
    {
        gestor.MostrarTodos();
        Console.Write("\nIngrese ID del contacto a modificar: ");
        int id = int.Parse(Console.ReadLine());

        var contacto = gestor.BuscarPorId(id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        Console.WriteLine("\nDeje en blanco para mantener el valor actual.");

        Console.Write($"Nombre ({contacto.Nombre}): ");
        string nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre)) contacto.Nombre = nombre;

       

        Console.WriteLine("Contacto modificado exitosamente!");
    }

    static void EliminarContacto(GestorContactos gestor)
    {
        gestor.MostrarTodos();
        Console.Write("\nIngrese ID del contacto a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        if (gestor.EliminarContacto(id))
        {
            Console.WriteLine("Contacto eliminado exitosamente!");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }
}