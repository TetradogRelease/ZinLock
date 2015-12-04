/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 26/06/2015
 * Hora: 22:15
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Text;
using System.Threading;

namespace ZinLockConsola
{
	class Program
	{
		#region constantes
		const char POSICIONSINPIEZA = ' ';
		const char POSICIONJUGADORSINPIEZADEBAJO = 'j';
		const char POSICIONJUGADORCONPIEZADEBAJO = 'J';
		//piezas actuales
		const char POSICONCONPIEZA2 = 'd';
		const char POSICONCONPIEZA3 = 't';
		const char POSICONCONPIEZA4 = 'q';
		const char POSICONCONPIEZA5 = 'c';
		const char POSICONCONPIEZA6 = 's';
		//piezas solucion
		const char POSICONCONPIEZA2SOLUCION = 'D';
		const char POSICONCONPIEZA3SOLUCION = 'T';
		const char POSICONCONPIEZA4SOLUCION = 'Q';
		const char POSICONCONPIEZA5SOLUCION = 'C';
		const char POSICONCONPIEZA6SOLUCION = 'S';
		//pieza mal colocada
		const char PIEZAMALCOLOCADA = 'M';
		const char PIEZABIENCOLOCADA = 'B';
		const char PIEZASELECCIONADA = 'x';
		const char PIEZADESTINO = 'X';
		const char CARACTERSEPARACION='|';
		#endregion
		static bool puedeMoverse;
		static int posX = 0;
		static int posY = 0;
		static int minutos = 0;
		static int segundos = 0;
		static int posicionSeleccionadaX = -1;
		static int posicionSeleccionadaY = -1;
		static Jugador jugador;
		static ZinLock.PartidaZinLock partida;
		const int TIEMPOMOVIMIENTOFICHA = 1 * 1000;
		static bool partidaOn;
		static Thread hiloMusica;
		public static void Main(string[] args)
		{
			partidaOn = true;
			jugador = new Jugador();
			partida = new ZinLock.PartidaZinLock();
			jugador.TeclaPremudaJugador += MouJugadorEvent;
			partida.FichasMovidas += FinFichasMovidas;
			partida.NuevoNivel += NuevoNivelEvent;
			partida.Tablero.FichasMovidas += FichasMoviendoseEvent;
			partida.TiempoActual += TiempoEvent;
			partida.FinPartida += FinPartidaEvent;
			partida.VidaPerdida += SonidoVidaPerdidoEvent;
			partida.Play();
			jugador.Comença();
			while (partidaOn)
				Thread.Sleep(1000);
			ZinLock.SonidosZinLock.EliminaArchivosTemporales();
		}

		static void MouJugadorEvent(Tecla tecla)
		{
			//si se muevenLasFichas no se puede mover el jugador
			if (puedeMoverse)
				switch (tecla) {
					case Tecla.Down:
						if (posY == 7)
							posY = 0;
						else
							posY++;
						break;
					case Tecla.Up:
						if (posY == 0)
							posY = 7;
						else
							posY--;
						break;
					case Tecla.Left:
						if (posX == 0)
							posX = 7;
						else
							posX--;
						break;
					case Tecla.Right:
						if (posX == 7)
							posX = 0;
						else
							posX++;
						break;
					case Tecla.Esc:
						ZinLock.SonidosZinLock.StopSoundTrack();
						jugador.Atura();
						partidaOn=false;break;
					case Tecla.Enter:
						ZinLock.SonidosZinLock.PonOQuitaSoundTrack();
						break;
					default:
						SeleccionaOMueveFicha();
						break;
				}
			ImprimerPartida();
		}

		static void SeleccionaOMueveFicha()
		{
			if (posicionSeleccionadaX != -1) {
				if (posicionSeleccionadaX == posX && posicionSeleccionadaY == posY) {
					posicionSeleccionadaX = -1;
					posicionSeleccionadaY = -1;
					//sonido seleccionado
					ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.FichaSeleccionada);
				} else {
					//mueve
					partida.Tablero.Mueve(posicionSeleccionadaX, posicionSeleccionadaY, posX, posY);
					posicionSeleccionadaX = -1;
					posicionSeleccionadaY = -1;
				}
			} else {
				if(partida.Tablero.CasillaValidaParaMover(posX,posY)){
				posicionSeleccionadaX = posX;
				posicionSeleccionadaY = posY;
				//sonido seleccionado
				ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.FichaSeleccionada);}
			}
			ImprimerPartida();
		}

		static void SonidoVidaPerdidoEvent(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.TimeOut);
			
		}

		static void TiempoEvent(int minuto, int segundo)
		{
			minutos = minuto;
			segundos = segundo;
			ImprimerPartida();
		}

		static void FinFichasMovidas(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			puedeMoverse = true;
			ImprimerPartida();
		}

		static void FinPartidaEvent(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			Console.Clear();
			if (!e.Ganada) {
				Console.WriteLine("Has perdido :C Nivel{0}", partida.NivelCanon);
				Console.ReadKey();
				partidaOn=false;
				jugador.Atura();
			} else if (partida.NivelCanon < 25) {
				Console.WriteLine("Nivel superado :D");
			} else {
				Console.WriteLine("Has cabado :D");
				partidaOn = false;
				jugador.Atura();
			}

			
		}
		static void FichasMoviendoseEvent(ZinLock.TableroZinLock tablero)
		{
			puedeMoverse = false;
			ImprimerPartida();
			//sonido moviendose
			ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.FichaMoviendose);
			Thread.Sleep(TIEMPOMOVIMIENTOFICHA);
		}
		static void NuevoNivelEvent(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			ImprimerPartida();
			//sonido victoria
			ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.WinLevel);
		}
		static void ImprimerPartida()
		{
			//stats
			//tablero
			//usar stringBuilder
			char caracter = ' ';
			StringBuilder pantalla = new StringBuilder();
			pantalla.Append("Partida Zinlock adaptada a C# por Gabriel Cortes\n");
			pantalla.Append("\nNivel: " + partida.NivelCanon);
			pantalla.Append("\nVidas: " + partida.Vidas);
			pantalla.Append("\nMovimientos: " + partida.Movimientos);
			pantalla.Append("\nTiempo: " + minutos + ":" + segundos);
			pantalla.Append("\n\nUsuario   \t\tSolucion ");
			for (int y = 0, finY = partida.Tablero.TableroJugador.GetLength(1); y < finY; y++) {
				pantalla.Append("\n"+CARACTERSEPARACION);
				for (int x = 0, finX = partida.Tablero.TableroJugador.GetLength(0); x < finX; x++) {
					switch (partida.Tablero.TableroJugador[x, y]) {
						case 1:
							caracter = POSICIONSINPIEZA;
							break;
						case 2:
							if (partida.Tablero.TableroSolucionado[x, y] != 2)
								caracter = POSICONCONPIEZA2;
							else
								caracter = POSICONCONPIEZA2SOLUCION;
							break;
						case 3:
							if (partida.Tablero.TableroSolucionado[x, y] != 3)
								caracter = POSICONCONPIEZA3;
							else
								caracter = POSICONCONPIEZA3SOLUCION;
							break;
						case 4:
							if (partida.Tablero.TableroSolucionado[x, y] != 4)
								caracter = POSICONCONPIEZA4;
							else
								caracter = POSICONCONPIEZA4SOLUCION;
							break;
						case 5:
							if (partida.Tablero.TableroSolucionado[x, y] != 5)
								caracter = POSICONCONPIEZA5;
							else
								caracter = POSICONCONPIEZA5SOLUCION;
							break;
						case 6:
							if (partida.Tablero.TableroSolucionado[x, y] != 6)
								caracter = POSICONCONPIEZA6;
							else
								caracter = POSICONCONPIEZA6SOLUCION;
							break;
					}
					if (posX == x && posY == y) {
						if (caracter == POSICIONSINPIEZA)
							caracter = POSICIONJUGADORSINPIEZADEBAJO;
						else
							caracter = POSICIONJUGADORCONPIEZADEBAJO;
					}
					pantalla.Append(caracter +""+CARACTERSEPARACION);
				}
				pantalla.Append("\t"+CARACTERSEPARACION);
				for (int x = 0, finX = partida.Tablero.TableroSolucionado.GetLength(0); x < finX; x++)
				{
					switch (partida.Tablero.TableroSolucionado[x,y]) {
						case 1:
							caracter = POSICIONSINPIEZA;
							break;
						case 2:
							if (partida.Tablero.TableroSolucionado[x, y] != 2)
								caracter = POSICONCONPIEZA2;
							else
								caracter = POSICONCONPIEZA2SOLUCION;
							break;
						case 3:
							if (partida.Tablero.TableroSolucionado[x, y] != 3)
								caracter = POSICONCONPIEZA3;
							else
								caracter = POSICONCONPIEZA3SOLUCION;
							break;
						case 4:
							if (partida.Tablero.TableroSolucionado[x, y] != 4)
								caracter = POSICONCONPIEZA4;
							else
								caracter = POSICONCONPIEZA4SOLUCION;
							break;
						case 5:
							if (partida.Tablero.TableroSolucionado[x, y] != 5)
								caracter = POSICONCONPIEZA5;
							else
								caracter = POSICONCONPIEZA5SOLUCION;
							break;
						case 6:
							if (partida.Tablero.TableroSolucionado[x, y] != 6)
								caracter = POSICONCONPIEZA6;
							else
								caracter = POSICONCONPIEZA6SOLUCION;
							break;
					}
					pantalla.Append(caracter+""+CARACTERSEPARACION);
				}
			}
			pantalla.Append("\n\nPara seleccionar y mover pulsa espacio\nPara poner musica de fondo dale a enter\nPara salir pulsa ESC\n");
			Console.Clear();
			Console.WriteLine(pantalla.ToString());
		}
	}
}