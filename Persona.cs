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
        int edad = DateTime.Today.Year - FechaNacimiento.Year;
        if(DateTime.Today.Month < FechaNacimiento.Month||DateTime.Today.Day < FechaNacimiento.Day){edad--;}
        return edad;
    }
    public bool PuedeVotar(){
        return ObtenerEdad() > 15;
    }
}
