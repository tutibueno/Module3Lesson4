// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Modulo3Lesson4
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView Map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl Seletor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Visor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView VisorWeb { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Map != null) {
                Map.Dispose ();
                Map = null;
            }

            if (Seletor != null) {
                Seletor.Dispose ();
                Seletor = null;
            }

            if (Visor != null) {
                Visor.Dispose ();
                Visor = null;
            }

            if (VisorWeb != null) {
                VisorWeb.Dispose ();
                VisorWeb = null;
            }
        }
    }
}