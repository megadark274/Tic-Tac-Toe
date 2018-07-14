using System;

namespace Tic_Tac_Toe
{
    class Program
    {

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
            //recibe X o O y ejecuta la jugada
            Console.WriteLine("Es el turno del jugador: " + valorJugada);
            int pos = Convert.ToInt32(Console.ReadLine()) - 1;
            tablero[pos] = valorJugada;
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
