using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto2;
using Trabajo_integrador_Guia.punto3;
using Trabajo_integrador_Guia.punto3.ISP;
using Trabajo_integrador_Guia.punto4;
using Trabajo_integrador_Guia.punto5.Controlador;
using Trabajo_integrador_Guia.punto5.Vistas;



namespace Trabajo_integrador_Guia
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            PrincipalMenu();
        }
        public static void PrincipalMenu()
        {
            bool salida = false;

            do
            {

                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════════╗");
                Console.WriteLine("║              MENÚ DE GESTIÓN DE EJERCICIOS        ║");
                Console.WriteLine("╠═══════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Fundamentos de POO                            ║");
                Console.WriteLine("║  2. Herencia y Polimorfismo                       ║");
                Console.WriteLine("║  3. Principios SOLID                              ║");
                Console.WriteLine("║  4. CRUD + JSON + Repositorio                     ║");
                Console.WriteLine("║  5. Libreria + MVC                                ║");
                Console.WriteLine("║  0. Salir                                         ║");
                Console.WriteLine("║═══════════════════════════════════════════════════║");
                Console.WriteLine("║  -. Selecciona una opción:                        ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════╝");

                try
                {
                    char opc = Console.ReadKey().KeyChar;

                    switch (opc)
                    {
                        case '1':
                            punto1(); Console.WriteLine("Presione una tecla...");
                            Console.ReadKey();
                            break;
                        case '2':
                            punto2(); Console.WriteLine("Presione una tecla...");
                            Console.ReadKey();
                            break;
                        case '3':
                            punto3(); Console.WriteLine("Presione una tecla...");
                            Console.ReadKey();
                            break;
                        case '4':
                            punto4(); Console.ReadKey();
                            break;
                        case '5':
                            punto5(); Console.ReadKey();
                            break;
                        case '0':
                            Console.WriteLine("Saliendo del programa...");
                            salida = true;
                            break;
                        default:
                            Console.WriteLine("[ERROR] opcion invalida. Intente de nuevo.");
                            Console.WriteLine("Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }




                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");

                }

            } while (!salida);
        }

        public static void punto1()
        {
            Ciudadano c1 = new Ciudadano("Lucía González", "30123456", 20);

            Console.WriteLine(c1.Saludar()); // Hola, soy Lucía González y tengo 20 años.
            Console.WriteLine("¿Es mayor de edad? " + c1.EsMayorDeEdad()); // true
        }
        public static void punto2()
        {
            Animal miPerro = new Perro("Toby");
            Animal miGato = new Gato("Michi");

            Console.WriteLine(miPerro.Presentarse()); // Soy un perro llamado Toby y hago Guau!
            Console.WriteLine(miGato.Presentarse());  // Soy un gato llamado Michi y hago Miau!

        }

        public static void punto3()
        {
            // 1. Creamos una factura
            Factura factura = new Factura { Id = 1, Monto = 2500 };

            // 2. Calculamos el total
            FacturaCalculator calculadora = new FacturaCalculator();
            decimal total = calculadora.CalcularTotal(factura);
            Console.WriteLine($"Total de la factura #{factura.Id}: ${total}");

            // 3. Guardamos en archivo (simulado)
            Facturasaver saver = new Facturasaver();
            saver.GuardarEnArchivo(factura);

            // 4. Imprimimos digitalmente
            IimprimirDigital impresoraDigital = new FacturaPrinterDigital();
            impresoraDigital.ImprimirDigital();

            // 5. Imprimimos en papel
            IimprimirPapel impresoraPapel = new FacturaPrinterPapel();
            impresoraPapel.ImprimirEnPapel();
        }

        public static void punto4()
        {
            var repo = new ProductoRepository();
            var controller = new ProductoController(repo);
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║         FERRETERÍA - MENÚ            ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Alta producto                     ║");
                Console.WriteLine("║ 2. Baja producto                     ║");
                Console.WriteLine("║ 3. Modificar producto                ║");
                Console.WriteLine("║ 4. Ver productos                     ║");
                Console.WriteLine("║ 5. Salir                             ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.WriteLine("║══════════════════════════════════════║");
                Console.WriteLine("║  - Selecciona una opción:            ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": controller.Alta(); break;
                    case "2": controller.Baja(); break;
                    case "3": controller.Modificar(); break;
                    case "4": controller.VerTodos(); break;
                    case "5":
                        controller.GuardarCambios();
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        public static void punto5()
        {

            var libroController = new LibroController();
            var usuarioController = new UsuarioController();
            var prestamoController = new PrestamoController(libroController, usuarioController);

            var libroView = new LibroView(libroController);
            var usuarioView = new UsuarioView(usuarioController);
            var prestamoView = new PrestamoView(prestamoController);

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║         Biblioteca Barrial         ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Registrar nuevo libro           ║");
                Console.WriteLine("║ 2. Registrar nuevo usuario         ║");
                Console.WriteLine("║ 3. Listar libros disponibles       ║");
                Console.WriteLine("║ 4. Prestar libro                   ║");
                Console.WriteLine("║ 5. Devolver libro                  ║");
                Console.WriteLine("║ 6. Salir                           ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
                Console.Write("Seleccione una opción (1-6): ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        libroView.RegistrarLibro();
                        break;
                    case "2":
                        usuarioView.RegistrarUsuario();
                        break;
                    case "3":
                        libroView.MostrarLibrosDisponibles();
                        break;
                    case "4":
                        prestamoView.PrestarLibro();
                        break;
                    case "5":
                        prestamoView.DevolverLibro();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }

            }
        }
    }
}

            
            
        

        
    

           