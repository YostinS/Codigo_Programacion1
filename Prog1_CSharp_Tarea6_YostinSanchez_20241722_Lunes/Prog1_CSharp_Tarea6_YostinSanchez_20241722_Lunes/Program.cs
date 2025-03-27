
class Contacto
{
    private int id;
    private string nombre;
    private string apellido;
    private string telefono;
    private string direccion;
    private int edad;
    private bool contactoDeEmergencia;

    public Contacto(int id, string nombre, string apellido, string telefono, string direccion, int edad, bool contactoDeEmergencia)
    {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.direccion = direccion;
        this.edad = edad;
        this.contactoDeEmergencia = contactoDeEmergencia;
    }

    public int Id => id;
    public string Nombre 
    { get => nombre; set => nombre = value; }
    public string Apellido 
    { get => apellido; set => apellido = value; }
    public string Telefono 
    { get => telefono; set => telefono = value; }
    public string Direccion
    { get => direccion; set => direccion = value; }
    public int Edad 
    { get => edad; set => edad = value; }
    public bool ContactoDeEmergencia
    { get => contactoDeEmergencia; set => contactoDeEmergencia = value; }

    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {id} | Nombre: {nombre} {apellido} | Teléfono: {telefono} | Dirección: {direccion} | Edad: {edad} | Emergencia: {(contactoDeEmergencia ? "Sí" : "No")}");
    }
}

class Agenda
{
    private List<Contacto> contactos;
    private int ultimoId;

    public Agenda()
    {
        contactos = new List<Contacto>();
        ultimoId = 0;
    }

    public void AgregarContacto()
    {
        Console.Write("Digite un nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Digite un apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Digite un teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Digite una dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Digite la edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Es un contacto de emergencia? (1. Sí / 2. No): ");
        bool contactoEmergencia = Console.ReadLine() == "1";

        Contacto nuevoContacto = new Contacto(++ultimoId, nombre, apellido, telefono, direccion, edad, contactoEmergencia);
        contactos.Add(nuevoContacto);

        Console.WriteLine("Contacto agregado con exito.");
    }

    public void VerContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos en la agenda.");
            return;
        }

        Console.WriteLine("Lista de contactos:");
        foreach (var contacto in contactos)
        {
            contacto.MostrarInformacion();
        }
    }

    public void ActualizarContacto()
    {
        Console.Write("Ingrese el ID del contacto a modificar: ");
        int id = int.Parse(Console.ReadLine());

        //COMPLETAR
        Contacto contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("ERROR: El ID ingresado no existe.");
            return;
        }

        Console.WriteLine("1. Nombre | 2. Apellido | 3. Teléfono | 4. Direccion | 5. Edad");
        Console.Write("Seleccione el campo a actualizar: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.Write("Nuevo nombre: ");
                contacto.Nombre = Console.ReadLine();
                break;
            case 2:
                Console.Write("Nuevo apellido: ");
                contacto.Apellido = Console.ReadLine();
                break;
            case 3:
                Console.Write("Nuevo teléfono: ");
                contacto.Telefono = Console.ReadLine();
                break;
            case 4:
                Console.Write("Nueva dirección: ");
                contacto.Direccion = Console.ReadLine();
                break;
            case 5:
                Console.Write("Nueva edad: ");
                contacto.Edad = int.Parse(Console.ReadLine());
                break;
            default:
                Console.WriteLine("Opción inválida.");
                return;
        }

        Console.WriteLine("Contacto actualizado.");
    }

    public void EliminarContacto()
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        Contacto contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("ERROR: El ID ingresado no existe.");
            return;
        }

        Console.Write("¿Está seguro de eliminar este contacto? (1. Sí / 2. No): ");
        if (Console.ReadLine() == "1")
        {
            contactos.Remove(contacto);
            Console.WriteLine("Contacto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Eliminación cancelada.");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        bool ejecutando = true;

        while (ejecutando)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine("1. Agregar Contacto | 2. Ver Contactos | 3. Actualizar Contacto | 4. Eliminar Contacto | 5. Salir");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 5)
            {
                Console.WriteLine("ERROR: Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    agenda.AgregarContacto();
                    break;
                case 2:
                    agenda.VerContactos();
                    break;
                case 3:
                    agenda.ActualizarContacto();
                    break;
                case 4:
                    agenda.EliminarContacto();
                    break;
                case 5:
                    ejecutando = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }
        }
    }
}
