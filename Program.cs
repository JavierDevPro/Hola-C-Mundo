using System;
using ServiciosCajero.service.src;

class Program
{
    public static void Main(string[] args)
    {
        double saldo = 1000000;
        string ingreso = null;
        int eleccion;

        //Pantalla del cajero:
        Console.WriteLine("\n--- Menu Cajero ---\n");
        Console.WriteLine("1. Consultar saldo \n2. Depositar dinero \n3. Retirar dinero \n4. Salir \n");

        Console.Write("Que deseas hacer? \n");
        ingreso = Console.ReadLine();

        while (!int.TryParse(ingreso, out eleccion))
        {
            //Pantalla del cajero:
            Console.WriteLine("\n--- Menu Cajero ---\n");
            Console.WriteLine("1. Consultar saldo \n2. Depositar dinero \n3. Retirar dinero \n4. Salir \n");
            Console.WriteLine($"ERROR: '{ingreso}' no es un valor numerico valido.");
            Console.Write("Que deseas hacer? \n");
            ingreso = Console.ReadLine();
        }
        /***
        con la condicion en la linea 16 me ahorro lo siguiente:
        try
        {
            eleccion = int.Parse(ingreso);
        }
        catch
        {
            Console.WriteLine($"ERROR: error al intentar parsear la eleccion ingresada ({ingreso}).");
        }
        ***/

        switch (eleccion)
        {
            case 1:
                consultarSaldo(saldo);
                break;
            case 2:
                saldo = depositarSaldo(saldo);
                break;

        }
    }
    static void consultarSaldo(double value)
    {
        Console.Write($"Su saldo actual es de: \n{value}$$\n");
    }
    static double depositarSaldo(double actualValue)
    {
        //Pantalla del cajero:
        Console.WriteLine("\n--- C ---\n");
        Console.WriteLine("1. Consultar saldo \n2. Depositar dinero \n3. Retirar dinero \n4. Salir \n");
        double newValue = 1;
        return newValue;
    }
}