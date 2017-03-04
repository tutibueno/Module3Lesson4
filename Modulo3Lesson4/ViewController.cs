using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreLocation;
using MapKit;


namespace Modulo3Lesson4
{
	public partial class ViewController : UIViewController
	{

		private List<Dados> lista;


		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			lista = DadosLista();
		}

		public List<Dados> DadosLista()
		{
			var informacaoLista = new List<Dados>()
			{
				new Dados("León, México", 21.152676, -101.711698),
				new Dados("Cancún, México", 21.052743, -86.847242),
				new Dados("Tijuana, México", 32.526384, -117.028983)
			};

			return informacaoLista;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Visor.Image = UIImage.FromFile("pict.png");
			Visor.ContentMode = UIViewContentMode.ScaleAspectFit;
			string htmlString = "<HTML>\n<HEAD>\n<TITLE>Your Title Here</TITLE>\n</HEAD>\n<BODY BGCOLOR=\"FFFFFF\">\n<CENTER><IMG SRC=\"pict.png\" ALIGN=\"BOTTOM\" height=\"42\" width=\"42\"> </CENTER>\n<HR>\n<a href=\"http://apple.com\">Link Name</a>\nis a link to another nifty site\n<H1>This is a Header</H1>\n<H2>This is a Medium Header</H2>\nSend me mail at <a href=\"mailto:support@yourcompany.com\">\nsupport@yourcompany.com</a>.\n<P> This is a new paragraph!\n<P> <B>This is a new paragraph!</B>\n<BR> <B><I>This is a new sentence without a paragraph break, in bold italics.</I></B>\n<HR>\n</BODY>\n</HTML>";

			VisorWeb.LoadHtmlString(htmlString, new NSUrl("./", true));

			Seletor.ValueChanged += (sender, e) => { 
				switch (Seletor.SelectedSegment)
				{
					case 0:
						Map.MapType = MKMapType.Standard;
						break;
					case 1:
						Map.MapType = MKMapType.Satellite;
						break;
					case 2:
						Map.MapType = MKMapType.Hybrid;
						break;
					default:
						break;
				}
			};

			//Create pins on map
			lista.ForEach(x => Map.AddAnnotation(new MKPointAnnotation()
			{
				Title = x.Titulo,
				Coordinate = new CLLocationCoordinate2D()
				{
					Latitude = x.Latitude,
					Longitude = x.Longitude
				}
			}));

			//Centralize map on a particular pin
			Map.CenterCoordinate = new CLLocationCoordinate2D(lista[0].Latitude, lista[0].Longitude);


			var Leon = new CLLocationCoordinate2D(21.152676, -101.711698);
			var Cancun = new CLLocationCoordinate2D(21.052743, -86.847242);
			var Tijuana = new CLLocationCoordinate2D(32.526384, -117.028983);

			var info = new NSDictionary();
			var origemDestino = new MKDirectionsRequest()
			{
				Source = new MKMapItem(new MKPlacemark(Leon, info)),
				Destination = new MKMapItem(new MKPlacemark(Cancun, info))
			};
			var origemDestino2 = new MKDirectionsRequest()
			{
				Source = new MKMapItem(new MKPlacemark(Leon, info)),
				Destination = new MKMapItem(new MKPlacemark(Tijuana, info))
			};

			var routeLeonCancun = new MKDirections(origemDestino);
			routeLeonCancun.CalculateDirections((response, error) => {
				if (error == null)
				{
					var rota = response.Routes[0];
					var linha = new MKPolylineRenderer(rota.Polyline)
					{
						LineWidth = 5.0f,
						StrokeColor = UIColor.Red
					};

					Map.OverlayRenderer = (mapView, overlay) => linha;
					Map.AddOverlay(rota.Polyline, MKOverlayLevel.AboveRoads);
				}
			});

			//TODO Add the route2 - Leon -> Tijuana


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
