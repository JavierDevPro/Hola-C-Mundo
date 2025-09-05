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
        showMenu("Principal");
        Console.Write("Que deseas hacer? \n");
        ingreso = Console.ReadLine();

        while (!int.TryParse(ingreso, out eleccion))
        {
            //Pantalla del cajero:
            showMenu("Principal");
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
                Console.WriteLine($"tu nuevo saldo es de:{saldo}");
                break;
            case 3:
                saldo = retirarDinero(saldo);
                Console.WriteLine($"tu nuevo saldo es de:{saldo}");
                break;
        }
    }
    static void consultarSaldo(double value)
    {
        Console.Write($"Su saldo actual es de: \n{value}$$\n");
    }
    static double depositarSaldo(double actualValue)
    {
        //mostrar el menu de depositar
        showMenu("Depositar");
        double value = 0;
        string deposito = Console.ReadLine();
        double.TryParse(deposito, out value);
        while (value < 10000)
        {
            Console.WriteLine($"ERROR: no se ingreso un deposito aceptable valor ingresado: ({value}).");
            showMenu("Depositar");
            deposito = Console.ReadLine();
            double.TryParse(deposito, out value);
        }
        double.TryParse(deposito, out value);
        double newValue = actualValue + value;
        return newValue;
    }

    static double retirarDinero(double actualValue)
    {
        //mostrar el menu de retirar
        showMenu("Retirar");
        double value = 0;
        string retiro = Console.ReadLine();
        double.TryParse(retiro, out value);
        while (value < 10000)
        {
            Console.WriteLine($"ERROR: no se ingreso un retiro aceptable ({value}).");
            showMenu("Retirar");
            retiro = Console.ReadLine();
            double.TryParse(retiro, out value);
        }
        double.TryParse(retiro, out value);
        double newValue = actualValue - value;
        return newValue;
    }

    static void showMenu(string menu)
    {
        switch (menu)
        {
            case "Principal":
                //Pantalla del cajero-Principal:
                Console.WriteLine("\n--- Menu Cajero ---\n");
                Console.WriteLine("1. Consultar saldo \n2. Depositar dinero \n3. Retirar dinero \n4. Salir \n");
                break;
            case "Depositar":
                //Pantalla del cajero-Depositar:
                Console.WriteLine("\n--- Cuanto desea depositar? ---\n");
                Console.WriteLine("  (Minimo aceptable 10000$)   ");
                break;
            case "Retirar":
                //Pantalla del cajero-Retirar:
                Console.WriteLine("\n--- Cuanto desea retirar? ---\n");
                Console.WriteLine("1. 10.000$ \n2. 20.000$ \n3. 30.000$ \n4. 50.000$ \n5. 75.000$ \n6.100.000$ \n");
                break;
            case "Salir":
                //Pantalla del cajero-salida
                Console.WriteLine("\n--- Seguro que quiere salir? ---\n");
                Console.WriteLine("  Si/No");
                break;
            default:
                break;
        }
    }
}