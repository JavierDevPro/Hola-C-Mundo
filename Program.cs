using System;
using System.Runtime.CompilerServices;
using ServiciosCajero.service.src;

class Program
{
    public static void Main(string[] args)
    {
        bool salir = false;
        double saldo = 1000000;
        string ingreso = null;
        int eleccion;

        while (!salir)
        {
            //Pantalla del cajero:
            Console.Clear();
            showMenu("Principal");
            Console.Write("Que deseas hacer? \n");
            ingreso = Console.ReadLine();

            while (!int.TryParse(ingreso, out eleccion))
            {
                //Pantalla del cajero:
                Console.Clear();
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
                    salir = exit(false);
                    break;
                case 2:
                    saldo = depositarSaldo(saldo);
                    Console.WriteLine($"tu nuevo saldo es de:{saldo}");
                    break;
                case 3:
                    saldo = retirarDinero(saldo);
                    Console.WriteLine($"tu nuevo saldo es de:{saldo}");
                    break;
                case 4:
                    showMenu("Salir");
                    salir = exit(false);
                    break;
            }
        }
    }
    static void consultarSaldo(double value)
    {
        Console.Clear();
        Console.Write($"\n***********************\nSu saldo actual es de: \n***********************\n{value}$\n***********************\n");
        Console.WriteLine($"Desea terminar el proceso? \nSI / NO (volver al menu)");
    }
    static double depositarSaldo(double actualValue)
    {
        //mostrar el menu de depositar
        Console.Clear();
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
        actualValue += value;
        return actualValue;
    }

    static double retirarDinero(double actualValue)
    {
        if (actualValue <= 0)
        {
            Console.Clear();
            Console.WriteLine("NO SE PUEDEN HACER RETIROS SI NO SE CUENTA CON DINERO DISPONIBLE!");
            Console.WriteLine($"Desea Ingresar dinero? \nSI/NO");
            bool res = exit(false);
            if (res)
            {
                return depositarSaldo(actualValue);
            }
            else
            {
                return actualValue;
            }
        }
        //mostrar el menu de retirar
        Console.Clear();
        showMenu("Retirar");
        double value = 0;
        value = retiroSelectivo(actualValue);
        while (value < 10000)
        {
            Console.Clear();
            Console.WriteLine($"ERROR: no se ingreso un retiro aceptable ({value}).");
            showMenu("Retirar");
            value = retiroSelectivo(actualValue);
        }
        actualValue -= value;
        return actualValue;
    }

    static double retiroSelectivo(double actualValue)
    {
        double value = 0;
        string selectiva;
        selectiva = Console.ReadLine();
        switch (selectiva)
        {
            case "1":
                value = 10000;
                break;
            case "2":
                value = 20000;
                break;
            case "3":
                value = 30000;
                break;
            case "4":
                value = 50000;
                break;
            case "5":
                value = 75000;
                break;
            case "6":
                value = 100000;
                break;
            case "7":
                Console.Clear();
                Console.WriteLine($"Ingrese cualquier valor no superior a : {actualValue}$\n");
                string retiro = Console.ReadLine();
                double.TryParse(retiro, out value);
                break;
            default:
                Console.WriteLine($"ERROR: SELECCION INGRESADA INVALIDA!");
                break;
        }
        return value;
    }

    static bool exit(bool clearReq)
    {
        string[] resValues = { "SI", "NO", "S", "N" };
        string res;
        int i = 0;
        //mostrar el menu de salir
        if (clearReq)
        {
            Console.Clear();    
        }
        res = Console.ReadLine();
        while (res == null || res == resValues[i])
        {
            i += 1;
            res = Console.ReadLine();
        }

        if (res.ToUpper() == resValues[0] || res.ToUpper() == resValues[2])
        {
            return true;
        }
        else if (res.ToUpper() == resValues[1] || res.ToUpper() == resValues[3])
        {
            return false;
        }
        Console.WriteLine($"ERROR: LA RESPUESTA INGRESADA NO ES VALIDA. \t{res}");
        return false;
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
                Console.WriteLine("1. 10.000$ \n2. 20.000$ \n3. 30.000$ \n4. 50.000$ \n5. 75.000$ \n6.100.000$ \n7.otro \n");
                break;
            case "Salir":
                //Pantalla del cajero-Salida
                Console.WriteLine("\n--- Seguro que quiere salir? ---\n");
                Console.WriteLine("  SI/NO");
                break;
            default:
                break;
        }
    }
}