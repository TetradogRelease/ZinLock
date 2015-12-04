/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 27/06/2015
 * Hora: 21:52
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZinLockGrafico
{
	public delegate void PuntoSeleccionadoEventHandler(int x, int y);
	/// <summary>
	/// Description of Mapa.
	/// </summary>
	public partial class Mapa : UserControl
	{
		public const int VALORSUELODEFAULT = 1;
		public static readonly Point PUNTONOVALIDO = new Point(-1, -1);
		int valorSuelo = VALORSUELODEFAULT;
		int[,] mapaAPintar;
		bool pintarSuelo;
		Point posicionFichaAMover;
		Point posicionFinMovimiento;
		bool bloqueado;
		
		public event PuntoSeleccionadoEventHandler PuntoClic;
		GrupoPaint paintTablero;
		public Mapa()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			paintTablero = new GrupoPaint(new PintaEventHandler[] {
				PintarTableroPart1, 
				PintarTableroPart2, 
				PintarTableroPart3, 
				PintarTableroPart4,
				PintarFichas
			}){ Dock = DockStyle.Fill };
			for (int i = 0; i < 4; i++) {
				paintTablero.Controls[i].Dock = DockStyle.None;
				paintTablero.Controls[i].Size = new Size(Width / 2, Height / 2);
			}
			paintTablero.Controls[0].Location = new Point(0, 0);
			paintTablero.Controls[1].Location = new Point(Width / 2, 0);
			paintTablero.Controls[2].Location = new Point(0, Height / 2);
			paintTablero.Controls[3].Location = new Point(Width / 2, Height / 2);
			mapaAPintar = ZinLock.TableroZinLock.MAPAVACIO;
			ResetPosiciones();
			Controls.Add(paintTablero);
			paintTablero.RefreshAll();
			paintTablero.MouseClick += ClickEvent;
			paintTablero.BringToFront();
		}

		public int ValorSuelo {
			get {
				return valorSuelo;
			}
			set {
				valorSuelo = value;
			}
		}
		public Point PosicionFichaAMover {
			get {
				return posicionFichaAMover;
			}
			set {
				posicionFichaAMover = value;
				Refresh();
			}
		}

		public Point PosicionFinMovimiento {
			get {
				return posicionFinMovimiento;
			}
			set {
				posicionFinMovimiento = value;
				Refresh();
			}
		}

		public bool Bloqueado {
			get {
				return bloqueado;
			}
			set {
				bloqueado = value;
			}
		}
		public bool EsMapaDeSolucion {
			get {
				return !pintarSuelo;
			}
			set {
				pintarSuelo = !value;
				if (!EsMapaDeSolucion) {
					BackColor = Color.FromArgb(154, 154, 154);
				} else
					BackColor = Color.White;
				Refresh();
			}
		}
		public int[,] MapaAPintar {
			get {
				return mapaAPintar;
			}
			set {
				mapaAPintar = value;
				if (mapaAPintar == null)
					mapaAPintar = ZinLock.TableroZinLock.MAPAVACIO;
				paintTablero.Refresh(4);
			}
		}

		public void AvanzaPosicion()
		{
			int x = 0, y = 0;
			//tiene que dar un paso hacia la posicion final
			if (posicionFichaAMover.X == posicionFinMovimiento.X) {
				if (posicionFichaAMover.Y < posicionFinMovimiento.Y)
					y = posicionFichaAMover.Y + 1;
				else
					y = posicionFichaAMover.Y - 1;
				x = posicionFichaAMover.X;
			} else {
				y = posicionFichaAMover.Y;
				if (posicionFichaAMover.X < posicionFinMovimiento.X)
					x = posicionFichaAMover.X + 1;
				else
					x = posicionFichaAMover.X - 1;
			}
			posicionFichaAMover = new Point(x, y);
		}
		public void ResetPosiciones()
		{
			posicionFichaAMover = PUNTONOVALIDO;
			posicionFinMovimiento = PUNTONOVALIDO;
			Refresh();
		}

		void ClickEvent(object sender, MouseEventArgs e)
		{
			OnMouseClick(e);
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			//Aqui miro donde hacen clic y lo comunico
			if (PuntoClic != null && !Bloqueado)//no deja que haga clic encima de una ficha porque la selecciona
				PuntoClic(e.X / (Width / 8), e.Y / (Height / 8));//por mirar si va bien1
		}
		private void PintarTableroPart1(PaintEventArgs e)
		{
			//pinto una parte
			PintarTablero(e, 0, mapaAPintar.GetLength(0) / 2, 0, mapaAPintar.GetLength(1) / 2);
		}
		private void PintarTableroPart2(PaintEventArgs e)
		{
			//pinto una parte
			PintarTablero(e, mapaAPintar.GetLength(0) / 2, mapaAPintar.GetLength(0), 0, mapaAPintar.GetLength(1) / 2);
		}
		private void PintarTableroPart3(PaintEventArgs e)
		{
			//pinto una parte
			PintarTablero(e, 0, mapaAPintar.GetLength(0) / 2, mapaAPintar.GetLength(1) / 2, mapaAPintar.GetLength(1));
		}
		private void PintarTableroPart4(PaintEventArgs e)
		{
			//pinto una parte
			PintarTablero(e, mapaAPintar.GetLength(0) / 2, mapaAPintar.GetLength(0), mapaAPintar.GetLength(1) / 2, mapaAPintar.GetLength(1));
		}
		private void PintarTablero(PaintEventArgs e, int xInicio, int xFin, int yInicio, int yFin)
		{
			
			//base.OnPaint(e);
			float medidaCelda = Height / 8.05f;
			float medidaSeparacionFichaSuelo = medidaCelda / 5f;
			RectangleF fondoGris = new RectangleF(medidaCelda / 20, medidaCelda / 20, medidaCelda * 19 / 20, medidaCelda * 19 / 20);
			RectangleF fondoBlanco = fondoGris;
			fondoBlanco.Inflate(medidaCelda / -15f, medidaCelda / -15f);

			RectangleF bordeFicha = fondoBlanco;
			bordeFicha.Inflate(medidaCelda / -19f, medidaCelda / -19f);
			RectangleF centroFicha = fondoGris;
			centroFicha.Inflate(fondoGris.Width / -2.6f, fondoGris.Height / -2.6f);
			
			RectangleF fondoFicha = bordeFicha;
			fondoFicha.Inflate(medidaCelda / -20f, medidaCelda / -20f);

			Brush colorAPintar = null;
			Pen colorGrisInterior = new Pen(Color.FromArgb(255, 203, 203, 203));

			//Pinto el mapa
			//recorro el mapa y pinto sus fichas (saltando los 1 o el valor que sea suelo)
			for (int y = yInicio, finY = yFin; y < finY; y++)
				for (int x = xInicio, finX = xFin; x < finX; x++) {
					//pinto el suelo
					if (!EsMapaDeSolucion) {//si es mapa de solucion no se pinta esa parte
						//cuadrados grises,fondo gris,rectangulos blanquizos
						e.Graphics.FillRectangle(colorGrisInterior.Brush, fondoGris.Location.X + (x * medidaCelda), fondoGris.Location.Y + (y * medidaCelda), fondoGris.Size.Width, fondoGris.Size.Height);
						e.Graphics.FillRectangle(new SolidBrush(Color.White), fondoBlanco.Location.X + (x * medidaCelda), fondoBlanco.Location.Y + (y * medidaCelda), fondoBlanco.Size.Width, fondoBlanco.Size.Height);
						e.Graphics.DrawLine(colorGrisInterior, centroFicha.Location.X + (x * medidaCelda) + colorGrisInterior.Width / 2, centroFicha.Location.Y + (y * medidaCelda), centroFicha.Location.X + (x * medidaCelda) + colorGrisInterior.Width / 2, fondoBlanco.Location.Y + (y * medidaCelda));
						e.Graphics.DrawLine(colorGrisInterior, centroFicha.Location.X + (x * medidaCelda) + colorGrisInterior.Width / 2, centroFicha.Location.Y + centroFicha.Height + (y * medidaCelda), fondoBlanco.Location.X + (x * medidaCelda) + colorGrisInterior.Width / 2, centroFicha.Height + centroFicha.Location.Y + (y * medidaCelda));
						e.Graphics.DrawLine(colorGrisInterior, centroFicha.Location.X + centroFicha.Width + (x * medidaCelda), centroFicha.Location.Y + (y * medidaCelda) + colorGrisInterior.Width / 2, fondoBlanco.Location.X + (x * medidaCelda) + fondoBlanco.Width, centroFicha.Location.Y + (y * medidaCelda) + colorGrisInterior.Width / 2);
						e.Graphics.DrawLine(colorGrisInterior, centroFicha.Location.X + centroFicha.Width + (x * medidaCelda) - colorGrisInterior.Width / 2, centroFicha.Location.Y + centroFicha.Height + (y * medidaCelda), centroFicha.Location.X + centroFicha.Width + (x * medidaCelda) - colorGrisInterior.Width / 2, fondoBlanco.Location.Y + fondoBlanco.Height + (y * medidaCelda));
					}
				
					colorAPintar = new SolidBrush(Color.FromArgb(255, 203, 203, 203));
					e.Graphics.FillRectangle(colorAPintar, centroFicha.Location.X + x * medidaCelda, centroFicha.Location.Y + y * medidaCelda, centroFicha.Size.Width, centroFicha.Size.Height);
				
				}
			
			if (!posicionFichaAMover.Equals(PUNTONOVALIDO)) {
				if (!posicionFinMovimiento.Equals(PUNTONOVALIDO)) {
					//si no hay ficha
					if (mapaAPintar[posicionFinMovimiento.X, posicionFinMovimiento.Y] == valorSuelo) {
						switch (mapaAPintar[posicionFichaAMover.X, posicionFichaAMover.Y]) {//pinto centro
							case 2:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 0, 160, 0));
								break;
							case 3:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 10, 99, 141));
								break;
							case 4:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 239, 5, 8));
								break;
							case 5:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 248, 208, 0));
								break;
							case 6:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 190, 62, 181));
								break;
						}
						e.Graphics.FillRectangle(colorAPintar, centroFicha.Location.X + posicionFinMovimiento.X * medidaCelda, centroFicha.Location.Y + posicionFinMovimiento.Y * medidaCelda, centroFicha.Size.Width, centroFicha.Size.Height);
					}
				}
			}
		}
		private void PintarFichas(PaintEventArgs e)
		{
			//base.OnPaint(e);
			float medidaCelda = Height / 8.05f;
			float medidaSeparacionFichaSuelo = medidaCelda / 5f;
			RectangleF fondoGris = new RectangleF(medidaCelda / 20, medidaCelda / 20, medidaCelda * 19 / 20, medidaCelda * 19 / 20);
			RectangleF fondoBlanco = fondoGris;
			fondoBlanco.Inflate(medidaCelda / -15f, medidaCelda / -15f);

			RectangleF bordeFicha = fondoBlanco;
			bordeFicha.Inflate(medidaCelda / -19f, medidaCelda / -19f);
			RectangleF centroFicha = fondoGris;
			centroFicha.Inflate(fondoGris.Width / -2.6f, fondoGris.Height / -2.6f);
			
			RectangleF fondoFicha = bordeFicha;
			fondoFicha.Inflate(medidaCelda / -20f, medidaCelda / -20f);

			Brush colorAPintar = null;
			Pen colorGrisInterior = new Pen(Color.FromArgb(255, 203, 203, 203));

			//Pinto el mapa
			//recorro el mapa y pinto sus fichas (saltando los 1 o el valor que sea suelo)
			for (int y = 0, finY = mapaAPintar.GetLength(1); y < finY; y++)
				for (int x = 0, finX = mapaAPintar.GetLength(0); x < finX; x++) {
					//pinto el suelo
					if (mapaAPintar[x, y] != ValorSuelo) {
						//ficha->recuadro de su color,color del centro y una linea curba en la esquina izquierda de arriba
						switch (mapaAPintar[x, y]) {//pinto borde
							case 2:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 61, 99, 14));
								break;
							case 3:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 0, 52, 126));
								break;
							case 4:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 155, 0, 0));
								break;
							case 5:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 165, 135, 1));
								break;
							case 6:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 180, 0, 180));
								break;
						}
						e.Graphics.FillRectangle(colorAPintar, bordeFicha.Location.X + (x * medidaCelda), bordeFicha.Location.Y + (y * medidaCelda), bordeFicha.Size.Width, bordeFicha.Size.Height);
						switch (mapaAPintar[x, y]) {//pinto color interior
							case 2:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 111, 156, 1));
								break;
							
							case 3:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 0, 102, 151));
								break;
							case 4:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 232, 75, 8));
								break;
							case 5:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 212, 170, 0));
								break;
							case 6:
								colorAPintar = new SolidBrush(Color.FromArgb(255, 200, 104, 201));
								break;
						}
						e.Graphics.FillRectangle(colorAPintar, fondoFicha.Location.X + (x * medidaCelda), fondoFicha.Location.Y + (y * medidaCelda), fondoFicha.Size.Width, fondoFicha.Size.Height);

						//pinto la curba blanca
						e.Graphics.DrawCurve(new Pen(new SolidBrush(Color.White), medidaCelda / 20), new PointF[] {
							new PointF(x * medidaCelda + fondoFicha.Location.X, y * medidaCelda + fondoFicha.Location.Y + fondoFicha.Height / 2f),
							new PointF(x * medidaCelda + fondoFicha.Location.X + fondoFicha.Width / 8, y * medidaCelda + fondoFicha.Location.Y + fondoFicha.Height / 8f),
							new PointF(x * medidaCelda + fondoFicha.Location.X + fondoFicha.Width / 3f, y * medidaCelda + fondoFicha.Location.Y)
						});
					}
				}
			
			if (!posicionFichaAMover.Equals(PUNTONOVALIDO)) {
				//pinto en la ficha el recuadro blanco
				colorAPintar = new SolidBrush(Color.White);
				e.Graphics.FillRectangle(colorAPintar, centroFicha.Location.X + posicionFichaAMover.X * medidaCelda, centroFicha.Location.Y + posicionFichaAMover.Y * medidaCelda, centroFicha.Size.Width, centroFicha.Size.Height);
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Width = Height;
			for (int i = 0; i < 4; i++) {
				paintTablero.Controls[i].Size = new Size(Width / 2, Height / 2);
			}
			paintTablero.Controls[0].Location = new Point(0, 0);
			paintTablero.Controls[1].Location = new Point(Width / 2, 0);
			paintTablero.Controls[2].Location = new Point(0, Height / 2);
			paintTablero.Controls[3].Location = new Point(Width / 2, Height / 2);
		}
	}

}
