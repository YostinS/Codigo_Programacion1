var ids = new List<int>();
var nombres = new Dictionary<int, string>();
var apellidos = new Dictionary<int, string>();
var telefonos = new Dictionary<int, string>();
var direcciones = new Dictionary<int, string>();
var edades = new Dictionary<int, int>();
var contactosDeEmergencia = new Dictionary<int, bool>();
var opcionSeleccionada = 1;
var ejecutandose = true;
Console.WriteLine("AGENDA");

while (ejecutandose)
{
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("1. Agregar Contacto | 2. Ver listado de contactos | 3. Actualizar un contacto | 4. Eliminar un Contacto | \n"+
        "5. Salir | 6. Manual de uso, ");
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

    opcionSeleccionada = int.Parse(Console.ReadLine());

    if (opcionSeleccionada < 0 || opcionSeleccionada >= 7)
    {
        Console.WriteLine("ERROR: La opcion seleccionada no existente");
    }
    else
    {
        switch (opcionSeleccionada)
        {
            case 1:
                {
                    AgregarContacto(ids, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Digite el Id, del contacto que desea Visualizar");
                    var idSeleccionado = int.Parse(Console.ReadLine());

                    MostrarContacto(idSeleccionado, ids, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia);

                    break;
                }
            case 3:
                {
                    Console.WriteLine("Ingrese el ID del contacto a modificar: ");
                    var idSeleccionado = int.Parse(Console.ReadLine());
                    Console.WriteLine("----------------------------------------");

                    MostrarContacto(idSeleccionado, ids, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia);
                    
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Escriba los nuevos parametros: ");
                    var id = idSeleccionado;
                    ActualizarContacto(id, nombres, apellidos, telefonos, direcciones, edades);
                    break;
                }
            case 4:
                {
                    
                    break;
                }
            case 5:
                {
                    ejecutandose = false;
                    break;
                }
            case 6:
                {
                    Console.WriteLine("Manual de uso");
                    Console.WriteLine("1- Los numeros que se soliciten deben ser estrictamente numeros enteros. \n" +
                        "2- Cuando se solicite el numero de telefono debe ingresarlos sin espacios para un mejor guardado del mismo. \n" +
                        "3- Solo dar los datos solicitados, nada de enteros si se pide un nombre. \n" +
                        "4- Nada de valores nulos, es decir, no puedes dejar un valor vacio en el menu principal. \n");
                    break;
                }
        }
    }
}

Console.WriteLine("Cerrando el Programa...");
Console.ReadKey();

static int GeneradorDeId(List<int> ids)
{
    var id = ids.Count();
    id++;
    return id;
}

static bool DeterminarSiEsContactoDeEmergencia()
{
    Console.Write("Es un contacto de emergencia? 1. Si, 2. No: ");

    int contactoDeEmergenciaDigitado = int.Parse(Console.ReadLine());

    return contactoDeEmergenciaDigitado == 1 ? true : false;
}

static void MostrarContacto(int idIndicado, List<int> ids, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia)
{
    string nombre, apellido, telefono, direccion, esContactoDeEmergencia;
    int edad;

    BuscarContacto(idIndicado, nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia, out nombre, out apellido, out telefono, out edad, out direccion, out esContactoDeEmergencia);

    MostrarValoresEnPantallaDeContactoSeleccionado(nombre, apellido, telefono, direccion, edad, esContactoDeEmergencia, idIndicado);

}

static void BuscarContacto(int idIndicado, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia, out string nombre, out string apellido, out string telefono, out int edad, out string direccion, out string esContactoDeEmergencia)
{
    nombre = nombres[idIndicado];
    apellido = apellidos[idIndicado];
    telefono = telefonos[idIndicado];
    edad = edades[idIndicado];
    direccion = direcciones[idIndicado];
    esContactoDeEmergencia = contactosDeEmergencia[idIndicado] ? "Si" : "No";

}
static void MostrarValoresEnPantallaDeContactoSeleccionado(string? nombre, string? apellido, string? tel, string? dir, int edad, string contactoDeEmergencia, int id)
{
    Console.WriteLine($"El contacto seleccionado con el ID: {id} es, ");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Apellido: {apellido}");
    Console.WriteLine($"Tel: {tel}");
    Console.WriteLine($"Dirección: {dir}");
    Console.WriteLine($"Edad: {edad}");
    Console.WriteLine($"Es Contacto de Emergencia?: {contactoDeEmergencia}");
}

static void AgregarContacto(List<int> ids, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia)
{
    Console.Write("Digite un nombre: ");
    var nombre = Console.ReadLine();
    Console.Write("Digite un apellido: ");
    var apellido = Console.ReadLine();
    Console.Write("Digite un Telefono: ");
    var tel = Console.ReadLine();
    Console.Write("Digite una Direccion: ");
    var dir = Console.ReadLine();
    Console.Write("Digite una Edad: ");
    var edad = int.Parse(Console.ReadLine());

    bool contactoDeEmergencia = DeterminarSiEsContactoDeEmergencia();

    var id = GeneradorDeId(ids);
    ids.Add(id);
    AgregandoValoresALosDiccionarios(nombres, apellidos, telefonos, direcciones, edades, contactosDeEmergencia, nombre, apellido, tel, dir, edad, contactoDeEmergencia, id);
}

static void AgregandoValoresALosDiccionarios(Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia, string? nombre, string? apellido, string? tel, string? dir, int edad, bool contactoDeEmergencia, int id)
{
    nombres.Add(id, nombre);
    apellidos.Add(id, apellido);
    telefonos.Add(id, tel);
    direcciones.Add(id, dir);
    edades.Add(id, edad);
    contactosDeEmergencia.Add(id, contactoDeEmergencia);
}
static void ActualizarContacto(int id, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades)
{
    if (!nombres.ContainsKey(id))
    {
        Console.WriteLine("ERROR: El ID ingresado no existe.");
        return;
    }
    Console.WriteLine("¿Qué desea actualizar?");
    Console.WriteLine("1. Nombre");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Teléfono");
    Console.WriteLine("4. Dirección");
    Console.WriteLine("5. Edad");
    Console.Write("Digite la opción: ");

    int opcionActualizar;

    if (!int.TryParse(Console.ReadLine(), out opcionActualizar))
    {
        Console.WriteLine("ERROR: Debe ingresar un número válido.");
        return;
    }

    switch (opcionActualizar)
    {
        case 1:
            Console.Write("Digite el nuevo Nombre: ");
            nombres[id] = Console.ReadLine();
            Console.WriteLine("Nombre actualizado con éxito.");
            break;
        case 2:
            Console.Write("Digite el nuevo Apellido: ");
            apellidos[id] = Console.ReadLine();
            Console.WriteLine("Apellido actualizado con éxito.");
            break;
        case 3:
            Console.Write("Digite el nuevo Teléfono: ");
            telefonos[id] = Console.ReadLine();
            Console.WriteLine("Teléfono actualizado con éxito.");
            break;
        case 4:
            Console.Write("Digite la nueva Dirección: ");
            direcciones[id] = Console.ReadLine();
            Console.WriteLine("Dirección actualizada con éxito.");
            break;
        case 5:
            Console.Write("Digite la nueva Edad: ");
            if (int.TryParse(Console.ReadLine(), out int nuevaEdad))
            {
                edades[id] = nuevaEdad;
                Console.WriteLine("Edad actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("ERROR: Debe ingresar un número válido.");
            }
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}
/*
static void ActualizarContacto(int idIndicado, int id, Dictionary<int, string> nombres, Dictionary<int, string> apellidos, Dictionary<int, string> telefonos, Dictionary<int, string> direcciones, Dictionary<int, int> edades, Dictionary<int, bool> contactosDeEmergencia)
{
    
    Console.WriteLine("Que desea actualiazar");
    Console.WriteLine("1. Nombre");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Telefono");
    Console.WriteLine("4. Direccion");
    Console.WriteLine("5. Edad");
    //Console.WriteLine("6. Es contacto de emergencia?");
    Console.Write("Digite las opcion");
    int OpcionesActualizar = 0;
    OpcionesActualizar = int.Parse(Console.ReadLine());

    switch (OpcionesActualizar)
    {
        case 1:
            {
                Console.Write("Digite el nuevo Nombre: ");
                nombres[id] = Console.ReadLine();
                Console.WriteLine("Nombre actualizado con éxito");
                break;

            }
        case 2:
            {
                Console.Write("Digite el nuevo Apellido: ");
                apellidos[id] = Console.ReadLine();
                Console.WriteLine("Apellido actualizado con éxito");
                break;
            }
        case 3:
            {
                Console.Write("Digite el nuevo Telefono: ");
                telefonos[id] = Console.ReadLine();
                Console.WriteLine("Telefono actualizado con éxito");
                break;
            }
        case 4:
            {
                Console.Write("Digite el nueva Direcion: ");
                direcciones[id] = Console.ReadLine();
                Console.WriteLine("Direccion actualizada con éxito");
                break;
            }
        case 5:
            {
                Console.Write("Digite la nueva Edad: ");
                edades[id] = int.Parse(Console.ReadLine());
                Console.WriteLine("Edad actualizada con éxito");
                break;
            }
        case 6:
            {
                DeterminarSiEsContactoDeEmergencia();
                Console.WriteLine("Contacto de emergencia actualizado con éxito");
                break;
            }
    }
}
/*
static void ActualizarContacto( string apellido, string? tel, string? dir, int edad, string contactoDeEmergencia, int id)
{
    Console.WriteLine("Que desea actualiazar");
    Console.WriteLine("1. Nombre");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Telefono");
    Console.WriteLine("4. Direccion");
    Console.WriteLine("5. Edad");
    Console.WriteLine("6. Es contacto de emergencia?");
    Console.Write("Digite las opcion");
    int OpcionesActualizar = 0;
    OpcionesActualizar = int.Parse(Console.ReadLine());

    switch (OpcionesActualizar) 
    {
        case 1: CambiarNombre(); 
            break;
        case 2: CambiarApellido();
            break;
        case 3: CambiarTelefono();
            break;
        case 4: CambiarDireccion();
            break;
        case 5: CambiarEdad();
            break;
        case 6: CambiarContactoDeEmergencia();
            break;
        default:
            Console.WriteLine("Eres bruto o que");
            break;
    }
   
}
*/
/*
static void CambiarNombre()
 {
    
    Console.Write("Digite el nuevo nombre");
    string Actualizacion = Console.ReadLine();
    Actualizacion.Replace(nombres, string.Empty);
    Console.WriteLine("Nombre actualizado con exito");

 }
 static void CambiarApellido(string apellido) 
 {
     
 }
static void CambiarTelefono()
{

}
static void CambiarDireccion()
{

}
static void CambiarEdad()
{

}
static void CambiarContactoDeEmergencia()
{

}
*/