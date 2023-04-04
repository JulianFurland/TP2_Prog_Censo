class Persona{
    public int DNI{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public string Email{get;set;}

    public Persona(int dni, string apellido, string nombre, DateTime fn, string email){
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaNacimiento = fn;
        Email = email;
    }
     public Persona(){
    
    }
     public int ObtenerEdad()
    {
        return ((DateTime.Today.Year*365+DateTime.Today.Month*30+DateTime.Today.Day) - (FechaNacimiento.Year*365+FechaNacimiento.Month*30+FechaNacimiento.Day))/365;
    }
    public bool PuedeVotar(){
        return ObtenerEdad() > 15;
    }
}
