using AnalisisCondicionesLaborales;


// Solicitar datos de empleados y agregarlos a la lista
Console.WriteLine("Ingrese los datos de los empleados:");
Console.WriteLine("Formato: Nombre, Salario, Género (M/F), Cédula");
Console.WriteLine("Ejemplo: Juan, 2500, M, 12345678");

var miEmpresa = new Empresa();
while (true)
{
    Console.Write("Empleado (o 'fin' para terminar): ");
    string entrada = Console.ReadLine();

    if (entrada.ToLower() == "fin")
        break;

    string[] datos = entrada.Split(',');
    if (datos.Length != 4)
    {
        Console.WriteLine("Formato incorrecto. Vuelva a intentarlo.");
        continue;
    }

    string nombre = datos[0].Trim();
    decimal salario;
    if (!decimal.TryParse(datos[1].Trim(), out salario))
    {
        Console.WriteLine("Salario inválido. Vuelva a intentarlo.");
        continue;
    }

    char genero = char.Parse(datos[2].Trim().ToUpper());
    string cedula = datos[3].Trim();

    miEmpresa.AgregarEmpleado(new Empleado(nombre, salario, genero, cedula));
}

// Realizar los cálculos requeridos y mostrar los resultados
Console.WriteLine($"Nómina total: {miEmpresa.CalcularNomina():C}");
Console.WriteLine($"Salario promedio: {miEmpresa.CalcularSalarioPromedio():C}");

Empleado menorSalario = miEmpresa.ObtenerMenorSalario();
Console.WriteLine($"Menor salario: {menorSalario.Nombre} ({menorSalario.Salario:C})");

(decimal mayorSalario, char generoMayorSalario, string cedulaMayorSalario) = miEmpresa.ObtenerMayorSalario();
Console.WriteLine($"Mayor salario: {mayorSalario:C}, Género: {generoMayorSalario}, Cédula: {cedulaMayorSalario}");

int empleadosSuperioresAlPromedio = miEmpresa.ContarSalariosSuperioresAlPromedio();
Console.WriteLine($"Empleados que ganan más que el salario promedio: {empleadosSuperioresAlPromedio}");

decimal salarioMinimo = 1000; // Cambia esto al salario mínimo real
(int menosSalarioMinimo, int entre1Y2SalariosMinimos, int masDe2SalariosMinimos) = miEmpresa.ContarEmpleadosPorRangoSalarial(salarioMinimo);
Console.WriteLine($"Empleados que ganan menos del salario mínimo: {menosSalarioMinimo}");
Console.WriteLine($"Empleados que ganan entre 1 y 2 salarios mínimos: {entre1Y2SalariosMinimos}");
Console.WriteLine($"Empleados que ganan más de 2 salarios mínimos: {masDe2SalariosMinimos}");
