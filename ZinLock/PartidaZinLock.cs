/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 26/06/2015
 * Hora: 21:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Timers;
namespace ZinLock
{
	public delegate void TimerPartidaEvenHandler(int minutos, int segundos);
	/// <summary>
	/// Description of PartidaZinLock.
	/// </summary>
	public class PartidaZinLock
	{
		Timer temporizador;
		const int SEGUNDOSPARTIDA = 60 + 40;
		int segundosPartida;
		int tiempoPartida;
		int movimientos;
		int vidas;
		int nivelCanon;
		string nivelExtra;
		TableroZinLock tablero;
		public event EventHandler<PartidaZinLockEventArgs> FinPartida;
		public event EventHandler<PartidaZinLockEventArgs> VidaPerdida;
		public event EventHandler<PartidaZinLockEventArgs> FichasMovidas;
		public event EventHandler<PartidaZinLockEventArgs> NuevoNivel;
		public event TimerPartidaEvenHandler TiempoActual;
		public PartidaZinLock()
		{
			nivelCanon = -1;
			temporizador = new Timer();
			temporizador.Interval = 1000;
			temporizador.Elapsed += DescontarTiempo;
			tablero = new TableroZinLock();
			tablero.EmpiezaNivel(TableroZinLock.MAPAVACIO);
			tablero.FinMovimientoFichas += FichasMovidasEvent;
		}

		public int TiempoPartida {
			get {
				return tiempoPartida;
			}
		}

		public string NivelExtra {
			get {
				return nivelExtra;
			}
			set {
				nivelExtra = value;
			}
		}
		public int NivelCanon {
			get {
				return nivelCanon;
			}
		}

		public int Movimientos {
			get {
				return movimientos;
			}
		}

		public int Vidas {
			get {
				return vidas;
			}
		}

		public TableroZinLock Tablero {
			get {
				return tablero;
			}
		}

		void FichasMovidasEvent(object sender, EventArgs e)
		{
			TableroZinLock tablero = sender as TableroZinLock;
			movimientos++;
			if (FichasMovidas != null)
				FichasMovidas(this, new PartidaZinLockEventArgs(this));
			if (tablero.Solucionado()) {
				if (FinPartida != null)
					FinPartida(this, new PartidaZinLockEventArgs(this));
				temporizador.Enabled = false;
				if (nivelCanon != -1) {
					nivelCanon++;
					EmpiezaNivel(nivelCanon);
				}
			}
		}


		void DescontarTiempo(object sender, ElapsedEventArgs e)
		{
			tiempoPartida--;
			if (TiempoActual != null)
				TiempoActual(tiempoPartida / 60, tiempoPartida % 60);
			if (tiempoPartida < 1) {
				vidas--;
				if (VidaPerdida != null)
					VidaPerdida(this, new PartidaZinLockEventArgs(this));
				tiempoPartida = segundosPartida;//vuelve a poner los segundos
				if (TiempoActual != null)
					TiempoActual(tiempoPartida / 60, tiempoPartida % 60);
			}
			if (vidas < 1) {
				if (FinPartida != null)
					FinPartida(this, new PartidaZinLockEventArgs(this));
				temporizador.Enabled = false;
				
			}
			
		}
		public void EmpiezaNivel(int nivel)
		{
			tablero.EmpiezaNivel(nivel);
			movimientos = 0;
			segundosPartida=SEGUNDOSPARTIDA;
			ResetTiempo();
			if (NuevoNivel != null)
				NuevoNivel(this, new PartidaZinLockEventArgs(this));
			nivelCanon = nivel % 25;
			nivelExtra=null;
			
		}
		public void EmpiezaNivel(int[,] mapaNivel,string nombreNivel,int segundos)
		{
			tablero.EmpiezaNivel(mapaNivel);
			movimientos = 0;
			segundosPartida=segundos;
			ResetTiempo();
			nivelCanon=-1;
			nivelExtra=nombreNivel;
			if (NuevoNivel != null)
				NuevoNivel(this, new PartidaZinLockEventArgs(this));
		}
		public void ResetTiempo()
		{
			tiempoPartida = segundosPartida;
			temporizador.Start();
		}
		public void ResetNivel()
		{
			ResetTiempo();
			tablero.Desordena();
			movimientos = 0;
						if (NuevoNivel != null)
				NuevoNivel(this, new PartidaZinLockEventArgs(this));
		}
		public void Empieza()
		{
            vidas = 3;
			ResetNivel();
			
			
		}
		public void Play()
		{
			nivelCanon = 1;
			segundosPartida=SEGUNDOSPARTIDA;
			tablero.EmpiezaNivel(nivelCanon);
			Empieza();

			
		}

		public void ParaORenudaTiempo()
		{
			temporizador.Enabled = !temporizador.Enabled;
		}
	}
	public class PartidaZinLockEventArgs:EventArgs
	{
		bool ganada;
		int movimientos;
		int vidas;
		int[,] tableroActual;
		public PartidaZinLockEventArgs(PartidaZinLock partida)
		{
			movimientos = partida.Movimientos;
			vidas = partida.Vidas;
			ganada = partida.Tablero.Solucionado();
			tableroActual = partida.Tablero.TableroJugador;
		}
		public bool Ganada {
			get {
				return ganada;
			}
		}

		public int Movimientos {
			get {
				return movimientos;
			}
		}

		public int[,] TableroActual {
			get {
				return tableroActual;
			}
		}
		public int Vidas {
			get {
				return vidas;
			}
		}
	}
}
