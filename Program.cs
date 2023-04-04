using System.Collections.Generic;
Dictionary<int, Persona> DicPersonas = new Dictionary<int, Persona>();
const string MSG_MENU = "Ingrese\n1: Para cargar una nueva persona\n2: Para ver las estadísticas del censo\n3: Buscar Persona\n4: Modificar Mail\n5: Salir";
string opcion = IngresarStr(MSG_MENU);
while(opcion != "5")
{
    switch (opcion){
    case "1":
    Persona persona1 = new Persona(IngresarEntero("Ingrese DNI"),IngresarStr("Ingrese Apellido"),IngresarStr("Ingrese Nombre"),IngresarFecha("Ingrese la fecha de nacimiento con formato AAAA/MM/DD"),IngresarMail("Ingresa el mail"));
    DicPersonas.Add(persona1.DNI, persona1);
    break;
    case "2":
    Console.WriteLine("La cantidad de personas es: " + DicPersonas.Count);
    int i = 0, promedio = 0;
    
    foreach(KeyValuePair<int, Persona> value in DicPersonas){
        if(value.Value.PuedeVotar()) i++;
        promedio += value.Value.ObtenerEdad();
    }
    Console.WriteLine("La cantidad de personas que pueden votar es: " + i.ToString());
    Console.WriteLine("El promedio de edad de personas es: " + promedio/DicPersonas.Count);
    break;
    case "3":
    Persona persona2 = GetPersonaDNI(DicPersonas);
    Console.WriteLine("El dni de la persona es: " + persona2.DNI);
    Console.WriteLine("El nombre de la persona es: " + persona2.Nombre);
    Console.WriteLine("El apellido de la persona es: " + persona2.Apellido);
    Console.WriteLine("La fecha de nacimiento de la persona es: " + persona2.FechaNacimiento);
    Console.WriteLine("El mail de la persona es: " + persona2.Email);
    break;
    case "4":
    Persona persona3 = GetPersonaDNI(DicPersonas);
    persona3.Email =  IngresarMail("Ingrese el nuevo mail: ");
    break;
    default:
    Console.WriteLine("Esa opcion no existe, ingrese de nuevo");
    break;
    }
    Console.WriteLine("Pulsa Enter para countinuar");
    Console.ReadLine();
    Console.Clear();
    opcion = IngresarStr(MSG_MENU);
}
static int IngresarEntero(string msj){
    Console.WriteLine(msj);
    int n;
    while(!int.TryParse(Console.ReadLine(), out n)){
        Console.WriteLine("Error, el ingreso debe ser un entero, intente otra vez:");
    }
    return n;
}
static string IngresarStr(string msj){
    Console.WriteLine(msj);
    return Console.ReadLine();
}
string IngresarMail(string msg){
    string email = IngresarStr(msg);
    while(email.IndexOf("@") == -1 || email.LastIndexOf("@") != email.IndexOf("@")||email.IndexOf(".") == -1){
        Console.WriteLine("El mail no es válido, ingrese de nuevo");
        email = IngresarStr("");
    }
    return email;
}
static DateTime IngresarFecha(string msj){
    Console.WriteLine(msj);
    DateTime n;
    while(!DateTime.TryParse(Console.ReadLine(), out n)){
        Console.WriteLine("Error, el ingreso debe ser una fecha, intente otra vez con el formato AAAA/MM/DD:");
    }
    return n.Date;
}
Persona GetPersonaDNI(Dictionary<int,Persona> dic){
    Persona persona = new Persona();
    while(!dic.TryGetValue(IngresarEntero("Ingresa el DNI que busca"), out persona)){
        Console.WriteLine("Ese DNI no esta registrado, ingrese de nuevo");
    }
    return persona;
}