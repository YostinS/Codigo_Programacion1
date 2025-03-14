using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Agenda_POO
{
    public class Persona
    {
        int edad;
        string Nombre;

        public void ModificarEdad(int edad)
        {
            this.edad = edad;
        }
        public int MostrarEdad()
        {
            return edad;
        }
    }
}
