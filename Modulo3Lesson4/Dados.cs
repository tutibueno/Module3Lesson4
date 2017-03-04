using System;
namespace Modulo3Lesson4
{
	public class Dados
	{
		
		public Dados(string titulo, double latitude, double longitude)
		{
			Titulo = titulo;
			Latitude = latitude;
			Longitude = longitude;
		}

		public string Titulo { get; set;}
		public double Latitude { get; set; }
		public double Longitude { get; set; }

	}
}
