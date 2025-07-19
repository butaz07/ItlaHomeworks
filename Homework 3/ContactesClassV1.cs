Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
//IAN ELIAN CHAVEZ FRANCO 20242577
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();




while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   6. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {
              

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2:
            {
              case 2:
                    ViewContacs(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;


                case 3: 
             SearchContact(ids, names, lastnames);

                    break;
                case 4: 
           ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;
                case 5: 
              DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;
                case 6:
                    runing = false;
                    break;
                default:
                    Console.WriteLine("kkkkk");
                    break;
                }
            
            }


            static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
            {
                Console.WriteLine("Digite el nombre de la persona");
                string name = Console.ReadLine();
                Console.WriteLine("Digite el apellido de la persona");
                string lastname = Console.ReadLine();
                Console.WriteLine("Digite la dirección");
                string address = Console.ReadLine();
                Console.WriteLine("Digite el telefono de la persona");
                string phone = Console.ReadLine();
                Console.WriteLine("Digite el email de la persona");
                string email = Console.ReadLine();
                Console.WriteLine("Digite la edad de la persona en números");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

                bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                var id = ids.Count + 1;
                ids.Add(id);
                names.Add(id, name);
                lastnames.Add(id, lastname);
                addresses.Add(id, address);
                telephones.Add(id, phone);
                emails.Add(id, email);
                ages.Add(id, age);
                bestFriends.Add(id, isBestFriend);
            }   
    }



 
    static void ViewContacs(List<int> ids,Dictionary<int, string> names,Dictionary<int, string> lastnames,Dictionary<int, string> addresses,Dictionary<int, string> telephones,Dictionary<int, string> emails,Dictionary<int, int> ages,Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
        Console.WriteLine($"____________________________________________________________________________________________________________________________");
        foreach (var id in ids)
        {
            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
        }
    }
}


static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames);
{
    Console.WriteLine("Ingrese el nombre o apellido a buscar:");
    string searchTerm = Console.ReadLine().ToLower();

    bool found = false;

    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");

    foreach (var id in ids)
    {
        if (names[id].ToLower().Contains(searchTerm) || lastnames[id].ToLower().Contains(searchTerm))
        {
            found = true;
            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
        }
    }

    if (!found)
    {
        Console.WriteLine("No se encontraron contactos que coincidan con la búsqueda.");
    }
}


static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                         Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                         Dictionary<int, string> emails, Dictionary<int, int> ages,
                         Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Lista de contactos disponibles:");
    foreach (var id in ids)
    {
        Console.WriteLine($"{id}. {names[id]} {lastnames[id]}");
    }

    Console.WriteLine("Ingrese el ID del contacto a modificar:");
    int contactId = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(contactId))
    {
        Console.WriteLine("ID de contacto no válido.");
        return;
    }

    Console.WriteLine("Deje en blanco los campos que no desea modificar.");

    Console.WriteLine($"Nombre actual: {names[contactId]}");
    Console.WriteLine("Nuevo nombre:");
    string newName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newName))
    {
        names[contactId] = newName;
    }

    Console.WriteLine($"Apellido actual: {lastnames[contactId]}");
    Console.WriteLine("Nuevo apellido:");
    string newLastname = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newLastname))
    {
        lastnames[contactId] = newLastname;
    }

    Console.WriteLine($"Dirección actual: {addresses[contactId]}");
    Console.WriteLine("Nueva dirección:");
    string newAddress = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newAddress))
    {
        addresses[contactId] = newAddress;
    }

    Console.WriteLine($"Teléfono actual: {telephones[contactId]}");
    Console.WriteLine("Nuevo teléfono:");
    string newPhone = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newPhone))
    {
        telephones[contactId] = newPhone;
    }

    Console.WriteLine($"Email actual: {emails[contactId]}");
    Console.WriteLine("Nuevo email:");
    string newEmail = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newEmail))
    {
        emails[contactId] = newEmail;
    }

    Console.WriteLine($"Edad actual: {ages[contactId]}");
    Console.WriteLine("Nueva edad (solo números):");
    string ageInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(ageInput))
    {
        ages[contactId] = Convert.ToInt32(ageInput);
    }

    Console.WriteLine($"¿Es mejor amigo actualmente? {(bestFriends[contactId] ? "Si" : "No")}");
    Console.WriteLine("¿Es mejor amigo? (1. Si, 2. No):");
    string bestFriendInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(bestFriendInput))
    {
        bestFriends[contactId] = Convert.ToInt32(bestFriendInput) == 1;
    }

    Console.WriteLine("Contacto modificado exitosamente.");
}


static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                         Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                         Dictionary<int, string> emails, Dictionary<int, int> ages,
                         Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Lista de contactos disponibles:");
    foreach (var id in ids)
    {
        Console.WriteLine($"{id}. {names[id]} {lastnames[id]}");
    }

    Console.WriteLine("Ingrese el ID del contacto a eliminar:");
    int contactId = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(contactId))
    {
        Console.WriteLine("ID de contacto no válido.");
        return;
    }

    Console.WriteLine($"¿Está seguro que desea eliminar a {names[contactId]} {lastnames[contactId]}? (1. Si, 2. No)");
    int confirmation = Convert.ToInt32(Console.ReadLine());

    if (confirmation == 1)
    {
        ids.Remove(contactId);
        names.Remove(contactId);
        lastnames.Remove(contactId);
        addresses.Remove(contactId);
        telephones.Remove(contactId);
        emails.Remove(contactId);
        ages.Remove(contactId);
        bestFriends.Remove(contactId);
        Console.WriteLine("Contacto eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }
}