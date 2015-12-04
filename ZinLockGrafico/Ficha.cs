/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 30/06/2015
 * Hora: 15:10
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZinLockGrafico
{
	public delegate void FichaSeleccionada(int ficha);
	/// <summary>
	/// Description of Ficha.
	/// </summary>
	public partial class Ficha : UserControl
	{
		int numero = 1;
		public Ficha()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public Ficha(int numero)
		{
			this.numero = numero;
			Refresh();
		}

		public int Numero {
			get {
				return numero;
			}
			set {
				numero = value;
				Refresh();
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Width = Height;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			float medidaCelda =Width;
			float medidaSeparacionFichaSuelo = medidaCelda / 5f;
			RectangleF fondoGris = new RectangleF(medidaCelda / 40, medidaCelda / 40, medidaCelda * 39 / 40, medidaCelda * 39 / 40);
			RectangleF fondoBlanco = fondoGris;
			fondoBlanco.Inflate(medidaCelda / -15f, medidaCelda / -15f);

			RectangleF bordeFicha = fondoBlanco;
			bordeFicha.Inflate(medidaCelda / -19f, medidaCelda / -19f);
			RectangleF centroFicha = fondoGris;
			centroFicha.Inflate(fondoGris.Width / -2.6f, fondoGris.Height / -2.6f);
			
			RectangleF fondoFicha = bordeFicha;
			fondoFicha.Inflate(medidaCelda / -20f, medidaCelda / -20f);

			SolidBrush colorAPintar = new SolidBrush(Color.White);
			//ficha->recuadro de su color,color del centro y una linea curba en la esquina izquierda de arriba
			if(numero!=1){
				switch (numero) {//pinto borde
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
				e.Graphics.FillRectangle(colorAPintar, bordeFicha.Location.X, bordeFicha.Location.Y, bordeFicha.Size.Width, bordeFicha.Size.Height);
				switch (numero) {//pinto color interior
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
				e.Graphics.FillRectangle(colorAPintar, fondoFicha.Location.X , fondoFicha.Location.Y , fondoFicha.Size.Width, fondoFicha.Size.Height);

				//pinto la curba blanca
				e.Graphics.DrawCurve(new Pen(new SolidBrush(Color.White), medidaCelda / 20), new PointF[] {
				                     	new PointF(fondoFicha.Location.X,fondoFicha.Location.Y + fondoFicha.Height / 2f),
				                     	new PointF(fondoFicha.Location.X + fondoFicha.Width / 8,fondoFicha.Location.Y + fondoFicha.Height / 8f),
				                     	new PointF(fondoFicha.Location.X + fondoFicha.Width / 3f,fondoFicha.Location.Y)
				                     });
			}
		else
		{	colorAPintar = new SolidBrush(Color.FromArgb(255, 203, 203, 203));
			e.Graphics.FillRectangle(colorAPintar, centroFicha.Location.X,  centroFicha.Location.Y , centroFicha.Size.Width, centroFicha.Size.Height);
		}}
	}
}
