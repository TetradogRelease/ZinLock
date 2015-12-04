/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 30/06/2015
 * Hora: 14:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZinLockGrafico
{
	public delegate void MapaEventHandler(int[,] mapa,string nombre,int segundos);
	/// <summary>
	/// Description of NivelExtra.
	/// </summary>
	public partial class NivelExtra : UserControl
	{
		public event MapaEventHandler Mapa;
		int segundos;
		public NivelExtra()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public NivelExtra(string nombre,string mapa,int segundos):this()
		{
			mapaExtra.MapaString(mapa);
			mapaExtra.ResetPosiciones();
			lblNombre.Text=nombre;
			lblTiempo.Text="tiempo "+segundos/60+":"+segundos%60;
			this.segundos=segundos;
		}
		void Mapa1MouseClick(object sender, MouseEventArgs e)
		{
			if(Mapa!=null)
				Mapa(mapaExtra.MapaAPintar,lblNombre.Text,segundos);
		}
	}
}
