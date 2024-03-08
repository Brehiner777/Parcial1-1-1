using AnalisisCondicionesLaborales;
using System;
using System.Collections.Generic;

namespace Empresa
{
    private List<Empleado> empleados;

    public Empresa()
    {
        empleados = new List<Empleado>();
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        empleados.Add(empleado);
    }

    public decimal CalcularNomina()
    {
        decimal totalSalarios = 0;
        foreach (var empleado in empleados)
        {
            totalSalarios += empleado.Salario;
        }
        return totalSalarios;
    }

    public decimal CalcularSalarioPromedio()
    {
        if (empleados.Count == 0)
            return 0;

        decimal totalSalarios = CalcularNomina();
        return totalSalarios / empleados.Count;
    }

    public Empleado ObtenerMenorSalario()
    {
        Empleado menorSalario = null;
        foreach (var empleado in empleados)
        {
            if (menorSalario == null || empleado.Salario < menorSalario.Salario)
                menorSalario = empleado;
        }
        return menorSalario;
    }

    public (decimal, char, string) ObtenerMayorSalario()
    {
        decimal mayorSalario = 0;
        char generoMayorSalario = ' ';
        string cedulaMayorSalario = "";

        foreach (var empleado in empleados)
        {
            if (empleado.Salario > mayorSalario)
            {
                mayorSalario = empleado.Salario;
                generoMayorSalario = empleado.Genero;
                cedulaMayorSalario = empleado.Cedula;
            }
        }

        return (mayorSalario, generoMayorSalario, cedulaMayorSalario);
    }

    public int ContarSalariosSuperioresAlPromedio()
    {
        decimal salarioPromedio = CalcularSalarioPromedio();
        int contador = 0;

        foreach (var empleado in empleados)
        {
            if (empleado.Salario > salarioPromedio)
                contador++;
        }

        return contador;
    }

    public (int, int, int) ContarEmpleadosPorRangoSalarial(decimal salarioMinimo)
    {
        int menosSalarioMinimo = 0;
        int entre1Y2SalariosMinimos = 0;
        int masDe2SalariosMinimos = 0;

        foreach (var empleado in empleados)
        {
            if (empleado.Salario < salarioMinimo)
                menosSalarioMinimo++;
            else if (empleado.Salario >= salarioMinimo && empleado.Salario <= 2 * salarioMinimo)
                entre1Y2SalariosMinimos++;
            else
                masDe2SalariosMinimos++;
        }

        return (menosSalarioMinimo, entre1Y2SalariosMinimos, masDe2SalariosMinimos);
    }
}
