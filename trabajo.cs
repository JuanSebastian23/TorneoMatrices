using System;

class TorneoFutbol
{
    // Declaramos los equipos y la tabla de posiciones
    static string[] equipos = { "Equipo A", "Equipo B", "Equipo C", "Equipo D" };
    static int[,] tablaPosiciones = new int[4, 7]; // [Puntos, PG, PE, PP, GF, GC, DF]
    static Random rand = new Random();

    static void Main()
    {
        int opcion;
        do
        {
            // Menu principal
            Console.WriteLine("Opciones del menu:");
            Console.WriteLine("1. Jugar fecha (mostrar marcadores)");
            Console.WriteLine("2. Imprimir tabla de posiciones");
            Console.WriteLine("3. Jugar otra eliminatoria");
            Console.WriteLine("4. Buscar datos de Seleccion");
            Console.WriteLine("5. Imprimir dato Estadistico");
            Console.WriteLine("6. Imprimir recorrido seleccionado");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    JugarFecha();
                    break;
                case 2:
                    ImprimirTabla();
                    break;
                case 3:
                    ReiniciarTorneo();
                    break;
                case 4:
                    BuscarDatos();
                    break;
                case 5:
                    ImprimirEstadistico();
                    break;
                case 6:
                    ImprimirRecorrido();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
        } while (opcion != 0);
    }

    // Funcion para simular una fecha de juegos
    static void JugarFecha()
    {
        Console.WriteLine("Resultados de la fecha:");
        for (int i = 0; i < equipos.Length; i += 2)
        {
            int golesEquipo1 = rand.Next(0, 11);
            int golesEquipo2 = rand.Next(0, 11);
            Console.WriteLine($"{equipos[i]} {golesEquipo1} - {golesEquipo2} {equipos[i + 1]}");
            ActualizarTabla(i, i + 1, golesEquipo1, golesEquipo2);
        }
    }

    // Funcion para actualizar la tabla de posiciones
    static void ActualizarTabla(int equipo1, int equipo2, int goles1, int goles2)
    {
        if (goles1 == goles2) // Empate
        {
            tablaPosiciones[equipo1, 0] += 1;
            tablaPosiciones[equipo2, 0] += 1;
            tablaPosiciones[equipo1, 2] += 1;
            tablaPosiciones[equipo2, 2] += 1;
        }
        else if (goles1 > goles2) // Gana equipo1
        {
            tablaPosiciones[equipo1, 0] += 3;
            tablaPosiciones[equipo1, 1] += 1;
            tablaPosiciones[equipo2, 3] += 1;
        }
        else // Gana equipo2
        {
            tablaPosiciones[equipo2, 0] += 3;
            tablaPosiciones[equipo2, 1] += 1;
            tablaPosiciones[equipo1, 3] += 1;
        }

        tablaPosiciones[equipo1, 4] += goles1;
        tablaPosiciones[equipo2, 4] += goles2;
        tablaPosiciones[equipo1, 5] += goles2;
        tablaPosiciones[equipo2, 5] += goles1;
        tablaPosiciones[equipo1, 6] = tablaPosiciones[equipo1, 4] - tablaPosiciones[equipo1, 5];
        tablaPosiciones[equipo2, 6] = tablaPosiciones[equipo2, 4] - tablaPosiciones[equipo2, 5];
    }

    // Funcion para imprimir la tabla de posiciones
    static void ImprimirTabla()
    {
        Console.WriteLine("\nTabla de Posiciones:");
        Console.WriteLine("Equipo      | PTS | PG | PE | PP | GF | GC | DF ");
        Console.WriteLine("-------------------------------------------------");
        for (int i = 0; i < equipos.Length; i++)
        {
            Console.WriteLine($"{equipos[i],-10} | {tablaPosiciones[i, 0],3} | {tablaPosiciones[i, 1],2} | {tablaPosiciones[i, 2],2} | {tablaPosiciones[i, 3],2} | {tablaPosiciones[i, 4],2} | {tablaPosiciones[i, 5],2} | {tablaPosiciones[i, 6],3}");
        }
        Console.WriteLine("-------------------------------------------------");
    }

    // Funcion para reiniciar el torneo
    static void ReiniciarTorneo()
    {
        Array.Clear(tablaPosiciones, 0, tablaPosiciones.Length);
        Console.WriteLine("Torneo reiniciado.\n");
    }

    // Funcion para buscar datos de una seleccion
    static void BuscarDatos()
    {
        Console.Write("Ingrese el nombre del equipo a buscar: ");
        string equipo = Console.ReadLine();
        int index = Array.IndexOf(equipos, equipo);
        if (index != -1)
        {
            Console.WriteLine($"{equipos[index]} - PTS: {tablaPosiciones[index, 0]}, PG: {tablaPosiciones[index, 1]}, PE: {tablaPosiciones[index, 2]}, PP: {tablaPosiciones[index, 3]}, GF: {tablaPosiciones[index, 4]}, GC: {tablaPosiciones[index, 5]}, DF: {tablaPosiciones[index, 6]}");
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }

    // Funcion para imprimir un dato estadistico (ejemplo)
    static void ImprimirEstadistico()
    {
        int maxPuntos = -1;
        string equipoMax = "";
        for (int i = 0; i < equipos.Length; i++)
        {
            if (tablaPosiciones[i, 0] > maxPuntos)
            {
                maxPuntos = tablaPosiciones[i, 0];
                equipoMax = equipos[i];
            }
        }
        Console.WriteLine($"Equipo con mas puntos: {equipoMax} ({maxPuntos} puntos)");
    }

    // Funcion para imprimir el recorrido seleccionado
    static void ImprimirRecorrido()
    {
        Console.WriteLine("Recorrido de los equipos:");
        for (int i = 0; i < equipos.Length; i++)
        {
            Console.WriteLine($"{equipos[i]} - PTS: {tablaPosiciones[i, 0]}, GF: {tablaPosiciones[i, 4]}, GC: {tablaPosiciones[i, 5]}");
        }
    }
}
