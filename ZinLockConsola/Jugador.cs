using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZinLockConsola
{
    public delegate void TeclaPremudaEventHandler(Tecla tecla);
    public enum Tecla
    { 
        Up,Down,Left,Right,Enter,Space,Esc
    }

  public  class Jugador
    {
        Thread filJugador;
        bool jugadorActiu;

        public event TeclaPremudaEventHandler TeclaPremudaJugador;
        public Jugador()
        {
            filJugador = new Thread(() => ComençaEscolta());
            jugadorActiu = true;
        }
        public void Atura() { jugadorActiu = false; }
        public void Comença() { filJugador.Start(); }
        private void ComençaEscolta()
        {
            System.ConsoleKeyInfo c = new ConsoleKeyInfo();
            Tecla teclaPremuda = Tecla.Enter;
            while (jugadorActiu)
            {
                c = Console.ReadKey();
                switch (c.Key)
                {
                    case ConsoleKey.UpArrow: teclaPremuda = Tecla.Up; break;
                    case ConsoleKey.DownArrow: teclaPremuda = Tecla.Down; break;
                    case ConsoleKey.LeftArrow: teclaPremuda = Tecla.Left; break;
                    case ConsoleKey.RightArrow: teclaPremuda = Tecla.Right; break;
                    case ConsoleKey.Enter: teclaPremuda = Tecla.Enter; break;
                    case ConsoleKey.Spacebar:teclaPremuda=Tecla.Space;break;
                    case ConsoleKey.Escape:teclaPremuda=Tecla.Esc;break;
                }
                if (TeclaPremudaJugador != null)
                    TeclaPremudaJugador(teclaPremuda);
            }
        }
    }
}
