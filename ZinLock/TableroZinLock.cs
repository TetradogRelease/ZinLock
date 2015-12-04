/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 25/06/2015
 * Hora: 14:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
namespace ZinLock
{
	public delegate void FichasMovidasEventHandler(TableroZinLock tablero);
	/// <summary>
	/// Description of TableroZinLock.
	/// </summary>
	public class TableroZinLock
	{
		#region NivelesCanon
	public static readonly int[,] MAPAVACIO = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1},{1, 1, 1, 1, 1, 1, 1, 1},{1, 1, 1, 1, 1, 1, 1, 1},{1, 1, 1, 1, 1, 1, 1, 1},{1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL1 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 2, 1, 1, 1, 1}, {1, 1, 1, 2, 1, 1, 1, 1}, {1, 1, 1, 2, 1, 1, 1, 1}, {1, 1, 1, 2, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL2 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 2, 2, 2, 2, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL3 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 4, 4, 1, 1, 1, 1}, {1, 1, 4, 4, 1, 1, 1, 1}, {1, 1, 4, 4, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL4 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 5, 1, 1, 1, 1}, {1, 1, 5, 5, 5, 1, 1, 1}, {1, 1, 1, 5, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL5 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 5, 5, 5, 1, 1}, {1, 1, 1, 5, 5, 5, 1, 1}, {1, 1, 1, 5, 5, 5, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL6 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 6, 6, 1, 1, 1, 1, 1}, {1, 6, 6, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 5, 5, 1}, {1, 1, 1, 1, 1, 5, 5, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL7 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 6, 6, 1, 1, 1, 1}, {1, 1, 6, 6, 1, 1, 1, 1}, {1, 1, 6, 6, 1, 1, 1, 1}, {1, 1, 6, 6, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL8 = {{1, 1, 1, 1, 5, 1, 1, 1}, {1, 1, 1, 1, 5, 1, 1, 1}, {1, 1, 1, 1, 5, 1, 1, 1}, {1, 1, 1, 1, 5, 1, 1, 1}, {5, 5, 5, 5, 5, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL9 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {3, 3, 3, 3, 3, 1, 1, 1}, {5, 5, 5, 5, 5, 1, 1, 1}};
		public static readonly int[,] NIVEL10 = {{6, 6, 6, 1, 1, 1, 1, 1}, {6, 6, 6, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 5, 5, 1, 1, 1}, {1, 1, 1, 5, 5, 1, 1, 1}, {1, 1, 1, 5, 5, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL11 = {{3, 3, 1, 1, 1, 1, 1, 1}, {3, 3, 1, 1, 1, 1, 1, 1}, {3, 3, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 4, 4, 1}, {1, 1, 1, 1, 1, 4, 4, 1}, {1, 1, 1, 1, 1, 4, 4, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL12 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 2, 2, 1, 1, 1, 1, 1}, {1, 2, 2, 1, 1, 5, 5, 1}, {1, 2, 2, 1, 1, 5, 5, 1}, {1, 1, 1, 1, 1, 5, 5, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL13 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 3, 3, 3, 1, 1, 1}, {1, 1, 3, 3, 3, 1, 1, 1}, {1, 1, 1, 1, 2, 2, 2, 1}, {1, 1, 1, 1, 2, 2, 2, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL14 = {{1, 5, 5, 5, 1, 1, 1, 1}, {1, 5, 5, 5, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 4, 4, 4, 1, 1, 1, 1}, {1, 4, 4, 4, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL15 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 3, 3, 1, 2, 2, 1}, {1, 1, 3, 3, 1, 2, 2, 1}, {1, 1, 3, 3, 1, 2, 2, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL16 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 4, 1, 1, 1, 1}, {1, 1, 4, 4, 1, 1, 1, 1}, {1, 1, 3, 4, 1, 1, 1, 1}, {1, 1, 3, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL17 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 3, 1, 1}, {1, 3, 3, 3, 1, 1, 3, 1}, {1, 1, 1, 1, 1, 1, 3, 1}, {1, 1, 1, 1, 1, 1, 3, 1}, {1, 3, 3, 3, 1, 1, 3, 1}, {1, 1, 1, 1, 1, 3, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL18 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 6, 6, 6, 1, 5, 1}, {1, 1, 6, 6, 6, 1, 5, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL19 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 2, 2, 2, 1, 1}, {1, 1, 1, 2, 2, 2, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL20 = {{4, 4, 1, 3, 3, 1, 1, 1}, {4, 4, 1, 3, 3, 1, 2, 2}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL21 = {{1, 1, 1, 4, 4, 1, 1, 1}, {1, 1, 1, 4, 4, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {3, 3, 1, 1, 1, 1, 5, 5}, {3, 3, 1, 1, 1, 1, 5, 5}};
		public static readonly int[,] NIVEL22 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 4, 4, 1, 1, 1, 1, 1}, {1, 2, 2, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 6, 6, 1, 1}, {1, 1, 1, 1, 3, 3, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL23 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 3, 3, 1, 1, 1}, {1, 1, 3, 3, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 5, 5, 1, 1, 1}, {1, 1, 5, 5, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 2, 2, 1}, {1, 1, 1, 1, 1, 1, 2, 2}};
		public static readonly int[,] NIVEL24 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 6, 4, 6, 4, 1, 1}, {1, 3, 6, 4, 6, 4, 3, 1}, {1, 1, 6, 4, 6, 4, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		public static readonly int[,] NIVEL25 = {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 3, 4, 2, 5, 1, 1}, {1, 1, 5, 4, 2, 3, 1, 1}, {1, 1, 4, 5, 3, 2, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1}};
		#endregion
		int[,] tablero;
		int[,] tableroSolucionado;
		public event FichasMovidasEventHandler FichasMovidas;
		public event EventHandler FinMovimientoFichas;
		public event EventHandler MapaSolucionado;
		int valorSinFicha=1;
		public TableroZinLock()
		{
			tablero = new int[8, 8];
			tableroSolucionado=new int[8,8];
		}
		public TableroZinLock(int[,] mapaNivel)
			: this()
		{
			PonNivel(mapaNivel);
		}

		public int ValorSinFicha {
			get {
				return valorSinFicha;
			}
			set {
				valorSinFicha = value;
			}
		}
		public int[,] TableroSolucionado {
			get {
				return tableroSolucionado;
			}
		}

		public int[,] TableroJugador {
			get {
				return tablero;
			}
		}
		public int this[int x, int y] {
			get{ return tablero[x, y]; }
			set{ tablero[x, y] = value; }
			
			
		}
		public void PonNivel(int nivelCanon)
		{
			switch (nivelCanon) {
				case 1:
					PonNivel(NIVEL1);
					break;
				case 2:
					PonNivel(NIVEL2);
					break;
				case 3:
					PonNivel(NIVEL3);
					break;
				case 4:
					PonNivel(NIVEL4);
					break;
				case 5:
					PonNivel(NIVEL5);
					break;
				case 6:
					PonNivel(NIVEL6);
					break;
				case 7:
					PonNivel(NIVEL7);
					break;
				case 8:
					PonNivel(NIVEL8);
					break;
				case 9:
					PonNivel(NIVEL9);
					break;
				case 10:
					PonNivel(NIVEL10);
					break;
					
				case 11:
					PonNivel(NIVEL11);
					break;
				case 12:
					PonNivel(NIVEL12);
					break;
				case 13:
					PonNivel(NIVEL13);
					break;
				case 14:
					PonNivel(NIVEL14);
					break;
				case 15:
					PonNivel(NIVEL15);
					break;
				case 16:
					PonNivel(NIVEL16);
					break;
				case 17:
					PonNivel(NIVEL17);
					break;
				case 18:
					PonNivel(NIVEL18);
					break;
				case 19:
					PonNivel(NIVEL19);
					break;
				case 20:
					PonNivel(NIVEL20);
					break;
					
				case 21:
					PonNivel(NIVEL21);
					break;
				case 22:
					PonNivel(NIVEL22);
					break;
				case 23:
					PonNivel(NIVEL23);
					break;
				case 24:
					PonNivel(NIVEL24);
					break;
				case 25:
					PonNivel(NIVEL25);
					break;
				default:
					PonNivel(MAPAVACIO);
					break;
			}
			
		}
		public void PonNivel(int[,] mapaSolucinado)
		{
			try{
				
				if(mapaSolucinado.GetLength(0)!=mapaSolucinado.GetLength(1))
					throw new Exception();
				tableroSolucionado=mapaSolucinado;
			}catch{
				throw new Exception("el mapa tiene que ser cuadrado");
			}
		}
		public void Desordena()
		{
			List<int> fichas=new  List<int>();
			Random llavor=new Random();
			foreach(int ficha in tableroSolucionado)
				fichas.Add(ficha);
			for(int y=0;y<8;y++)
				for(int x=0;x<8;x++){
				tablero[x,y]=fichas[llavor.Next(fichas.Count)];
				fichas.Remove(tablero[x,y]);
			}
		}
		public void EmpiezaNivel(int nivelCanon)
		{
			PonNivel(nivelCanon);Desordena();
		}
		public void EmpiezaNivel(int[,] mapaNivelSolucion)
		{
			PonNivel(mapaNivelSolucion);Desordena();
		}
		public bool Solucionado()
		{
			bool iguales=true;
			for(int y=0;y<tableroSolucionado.GetLength(1)&&iguales;y++)
				for(int x=0;x<tableroSolucionado.GetLength(0)&&iguales;x++)
					iguales=tablero[x,y]==tableroSolucionado[x,y];
			return iguales;
		}
		public void Mueve(int xInicio,int yInicio,int xFin,int yFin)
		{
			Mueve(new Point(xInicio,yInicio),new  Point(xFin,yFin));
		}
		public void Mueve(Point puntoInicio, Point puntoFin)
		{
			int fichaAnt = -1;
			int fichaAux = -1;
			if (MovimientoValido(puntoInicio, puntoFin)) {
				if (puntoInicio.X == puntoFin.X) {
					//mueve vertical

					if (puntoInicio.Y > puntoFin.Y) {
						//sube

						for (int j = 0, f = puntoInicio.Y - puntoFin.Y; j < f; j++) {
							//muevo la primera ficha al final
							fichaAux = tablero[puntoInicio.X, tablero.GetLength(1)-1];//conservo la ficha del final
							tablero[puntoInicio.X, tablero.GetLength(1)-1] = tablero[puntoInicio.X, 0];
							for (int i = tablero.GetLength(0)-2; i >= 0; i--) {
								fichaAnt = tablero[puntoInicio.X, i];
								tablero[puntoInicio.X, i] = fichaAux;//subo la ficha
								fichaAux = fichaAnt;//cojo la ficha de arriba
							}
							if (FichasMovidas != null)
								FichasMovidas(this);
						}

					} else {
						//baja
						for (int j = 0, f = puntoFin.Y - puntoInicio.Y; j < f; j++) {
							//muevo la primera ficha al final
							fichaAux = tablero[puntoInicio.X, 0];//conservo la ficha del final
							tablero[puntoInicio.X, 0] = tablero[puntoInicio.X, tablero.GetLength(1)-1];
							for (int i = 1; i < tablero.GetLength(1); i++) {
								fichaAnt = tablero[puntoInicio.X, i];
								tablero[puntoInicio.X, i] = fichaAux;//subo la ficha
								fichaAux = fichaAnt;//cojo la ficha de arriba
							}
							if (FichasMovidas != null)
								FichasMovidas(this);
						}
					}
					
				} else {
					//mueve horizontal
					if (puntoInicio.X > puntoFin.X) {
						//va a la izquierda
						for (int j = 0, f = puntoInicio.X - puntoFin.X; j < f; j++) {
							fichaAux = tablero[tablero.GetLength(0)-1, puntoInicio.Y];//conservo la ficha del final
							tablero[tablero.GetLength(0)-1, puntoInicio.Y] = tablero[0, puntoInicio.Y];
							for (int i = tablero.GetLength(0)-2; i >= 0; i--) {
								fichaAnt = tablero[i, puntoInicio.Y];
								tablero[i, puntoInicio.Y] = fichaAux;//subo la ficha
								fichaAux = fichaAnt;//cojo la ficha de arriba
							}
							if (FichasMovidas != null)
								FichasMovidas(this);
						}
					} else {
						//va a la derecha
						for (int j = 0, f = puntoFin.X - puntoInicio.X; j < f; j++) {
							fichaAux = tablero[0, puntoInicio.Y];//conservo la ficha del final
							tablero[0, puntoInicio.Y] = tablero[tablero.GetLength(0)-1, puntoInicio.Y];
							for (int i = 1; i < tablero.GetLength(0); i++) {
								fichaAnt = tablero[i, puntoInicio.Y];
								tablero[i, puntoInicio.Y] = fichaAux;//subo la ficha
								fichaAux = fichaAnt;//cojo la ficha de arriba
							}
							if (FichasMovidas != null)
								FichasMovidas(this);
						}
					}
				}
			}
			if (FinMovimientoFichas != null)
				FinMovimientoFichas(this, new EventArgs());
			
		}

		public bool CasillaValidaParaMover(int posX,int posY)
		{
			return tablero[posX,posY]!=valorSinFicha;
		}
		public bool MovimientoValido(Point puntoInicio, Point puntoFin)
		{
			bool correcte = true;
			if (puntoInicio.X != puntoFin.X && puntoInicio.Y != puntoFin.Y||tablero[puntoInicio.X,puntoInicio.Y]==valorSinFicha)
				correcte = false;
			return correcte;
		}
		public override bool Equals(object obj)
		{
			TableroZinLock other = obj as TableroZinLock;
			if (other == null)
				return false;
			return object.Equals(this.tablero, other.tablero);
		}
	}

}
