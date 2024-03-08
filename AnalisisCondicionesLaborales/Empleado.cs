using System;
using System.Collections.Generic;

namespace AnalisisCondicionesLaborales
{
    public class Empleado
    {
        private decimal salario;
        private char genero;

        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Cedula { get; set; }
        public double Salario { get; set; }

        public Empleado(string nombre, string genero, string cedula, double salario)
        {
            Nombre = nombre;Genero = genero;Cedula = cedula;Salario = salario;
        }

        public Empleado(string nombre, decimal salario, char genero, string cedula)
        {
            Nombre = nombre;
            this.salario = salario;
            this.genero = genero;
            Cedula = cedula;
        }
    }
}
