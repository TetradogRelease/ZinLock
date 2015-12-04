/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 27/06/2015
 * Hora: 21:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace ZinLockGrafico
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		ZinLock.PartidaZinLock partida;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			partida = new ZinLock.PartidaZinLock();
			partida.FichasMovidas += FichasMovidasEvento;
			partida.FinPartida += FinPartidaEvento;
			partida.NuevoNivel += NuevoNivelEvento;
			partida.TiempoActual += TiempoActualEvento;
			partida.VidaPerdida += VidaPerdidaEvento;
			partida.Tablero.FichasMovidas += FichasMoviendoseEvento;
			partida.Play();
			mapaJugador.EsMapaDeSolucion = false;
			mapaJugador.PuntoClic += SeleccionaOMueveEvent;
			KeyPreview = true;
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			switch (e.KeyData) {
					case	Keys.F5:
						partida.ResetNivel();
					break;
				case Keys.T:
					partida.ParaORenudaTiempo();
					mapaJugador.Bloqueado = !mapaJugador.Bloqueado;
					mapaJugador.MostrarFichas = !mapaJugador.Bloqueado;
					break;
				case Keys.F3:
					partida.ResetTiempo();
					break;
				case Keys.F11:
					partida.EmpiezaNivel(partida.NivelCanon + 1);
					break;
			}
		}

		void FichasMovidasEvento(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			//desbloquea seleccionar
			mapaJugador.Bloqueado = false;
			mapaJugador.ResetPosiciones();
			lblMovimientos.Text = "movimientos " + partida.Movimientos;
		}

		void SeleccionaOMueveEvent(int x, int y)
		{
			if (!mapaJugador.PosicionFichaAMover.Equals(Mapa.PUNTONOVALIDO)) {
				if (!partida.Tablero.CasillaValidaParaMover(x, y)) {
					mapaJugador.PosicionFinMovimiento = new Point(x, y);
					mapaJugador.Bloqueado = true;
					partida.Tablero.Mueve(mapaJugador.PosicionFichaAMover, mapaJugador.PosicionFinMovimiento);
				} else {
					mapaJugador.PosicionFichaAMover = new Point(x, y);
					ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.FichaSeleccionada);
				}
			} else if (partida.Tablero.CasillaValidaParaMover(x, y)) {
				mapaJugador.PosicionFichaAMover = new Point(x, y);
				ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.FichaSeleccionada);
			} else
				mapaJugador.ResetPosiciones();
			
			
		}
		void FinPartidaEvento(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			if (!e.Ganada) {
				MessageBox.Show("Has Perdido!!");
				mapaJugador.Bloqueado = true;
				this.Close();
			} else if (partida.NivelCanon < 25) {
				ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.WinLevel);
			} else {
				MessageBox.Show("Que crac te lo has pasado :)");
				mapaJugador.Bloqueado = true;
			}
			
		}

		void NuevoNivelEvento(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			//actualiza todo
			mapaJugador.MapaAPintar = partida.Tablero.TableroJugador;
			mapaSolucion.MapaAPintar = partida.Tablero.TableroSolucionado;
			mapaJugador.Bloqueado = false;
			mapaJugador.ResetPosiciones();
			lblMovimientos.Text = "movimientos " + partida.Movimientos;
			if (partida.NivelCanon != -1)
				lblNivel.Text = "nivel " + partida.NivelCanon;
			else
				lblNivel.Text = "nivel "+partida.NivelExtra;
		}

		void TiempoActualEvento(int minutos, int segundos)
		{
			//actualiza lblTiempo
			lblTiempo.Text = "tiempo " + minutos + ":" + segundos;
		}

		void VidaPerdidaEvento(object sender, ZinLock.PartidaZinLockEventArgs e)
		{
			//actualiza lblVidas
			lblVidas.Text = "vidas " + partida.Vidas;
			ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.TimeOut);
		}

		void FichasMoviendoseEvento(ZinLock.TableroZinLock tablero)
		{
			//actualiza mapa
			//bloquea seleecionar
			mapaJugador.Bloqueado = true;
			mapaJugador.AvanzaPosicion();
			mapaJugador.MapaAPintar = partida.Tablero.TableroJugador;
			ZinLock.SonidosZinLock.Play(ZinLock.SonidosZinLock.Sonidos.FichaMoviendose);
		}
		void MainFormMouseClick(object sender, MouseEventArgs e)
		{
			ZinLock.SonidosZinLock.PonOQuitaSoundTrack(false);
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			ZinLock.SonidosZinLock.StopSoundTrack();
		}
		void MapaSolucionMouseDoubleClick(object sender, MouseEventArgs e)
		{
			//Huevo de pascua :D
			frmNivelesExtra huevo = new frmNivelesExtra();
			huevo.MapaSeleccionado += PonNivelExtra;
			huevo.Show();
		}

		void PonNivelExtra(int[,] mapa,string nombre,int segundos)
		{
			partida.EmpiezaNivel(mapa,nombre,segundos);
		}
	}
}
