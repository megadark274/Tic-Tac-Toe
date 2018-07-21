using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        //Tic Tac Toe
        public static void Render(string[] tablero)
        {
            //renderiza el tablero
            Console.Clear();
            Console.WriteLine(tablero[0] + "|" + tablero[1] + "|" + tablero[2]);
            Console.WriteLine("-----");
            Console.WriteLine(tablero[3] + "|" + tablero[4] + "|" + tablero[5]);
            Console.WriteLine("-----");
            Console.WriteLine(tablero[6] + "|" + tablero[7] + "|" + tablero[8]);
        }

        public static string[] EjecutarJugada(string valorJugada, string[] tablero)
        {
            bool jugadaValida = false;

            Console.WriteLine("Es el turno del jugador: " + valorJugada);

            while (!jugadaValida)
            {
                int pos;
                string posChar;
                //recibe X o O y ejecuta la jugada

                posChar = Console.ReadLine();
                //int pos = Convert.ToInt32(Console.ReadLine()) - 1;
                //verifica que el valor introducido es un numero del 1 al 9
                if (!(System.Text.RegularExpressions.Regex.IsMatch(posChar, @"^[1-9]+$")))
                {
                    Console.WriteLine("El valor introducido no es un numero, intente de nuevo.");
                    //TODO: provar esa vaina vacana
                    //EjecutarJugada(valorJugada, tablero);
                    tablero = EjecutarJugada(valorJugada, tablero);
                }
                else
                {
                    pos = Convert.ToInt32(posChar) - 1;
                    if (tablero[pos] == "x" || tablero[pos] == "o")
                    {
                        Console.WriteLine("Ese espacio ya esta ocupado, intente de nuevo");
                    }
                    else
                    {
                        tablero[pos] = valorJugada;
                        jugadaValida = true;
                        Render(tablero);
                    }
                }

            }

            return tablero;
        }

        private static bool EvaluaJuego(string[] tablero)
        {
            //compara el tablero
            if (tablero[0] == tablero[1] && tablero[1] == tablero[2] ||
                tablero[3] == tablero[4] && tablero[4] == tablero[5] ||
                tablero[6] == tablero[7] && tablero[7] == tablero[8] ||
                tablero[0] == tablero[3] && tablero[3] == tablero[6] ||
                tablero[1] == tablero[4] && tablero[4] == tablero[7] ||
                tablero[2] == tablero[5] && tablero[5] == tablero[8] ||
                tablero[0] == tablero[4] && tablero[4] == tablero[8] ||
                tablero[6] == tablero[4] && tablero[4] == tablero[2])
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        static void Main(string[] args)
        {
            //inicializa las variables
            string[] tablero = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool JugadorXactual = true;
            bool gameover = false;
            string valorJugada;
            //logica del juego
            while (!gameover)
            {
                Render(tablero);
                if (JugadorXactual)
                {
                    valorJugada = "x";
                    tablero = EjecutarJugada(valorJugada, tablero);
                    JugadorXactual = false;
                }
                else
                {
                    valorJugada = "o";
                    tablero = EjecutarJugada(valorJugada, tablero);
                    JugadorXactual = true;
                }
                gameover = EvaluaJuego(tablero);
            }
            Console.WriteLine("fin del juego!");
            Console.ReadKey();


        }


    }
}
