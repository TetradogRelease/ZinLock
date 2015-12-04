/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 29/06/2015
 * Hora: 14:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZinLockGrafico
{
	public delegate void PintaEventHandler(PaintEventArgs e);
	/// <summary>
	/// Description of ControlPaint.
	/// </summary>
	public partial class ControlPaint : UserControl
	{
		PintaEventHandler onPaintMetodo;
		public ControlPaint()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public ControlPaint(PintaEventHandler metodoPintar):this()
		{
			OnPaintMetodo=metodoPintar;
		}

		public PintaEventHandler OnPaintMetodo {
			get {
				return onPaintMetodo;
			}
			set {
				onPaintMetodo = value;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);
			if(OnPaintMetodo!=null)
				OnPaintMetodo(e);
		}
	}
}
