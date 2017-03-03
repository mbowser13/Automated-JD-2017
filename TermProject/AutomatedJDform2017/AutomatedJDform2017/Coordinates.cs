using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace AutomatedJDform2017
{
    class Coordinates
    {
        public static string latlongCoordinates(IFeatureClass SiteLayer)
        {
            // Get the feature and its geometry given an Object ID.
            IFeature stateFeature = SiteLayer.GetFeature(0);
            IGeometry shapeGeometry = stateFeature.Shape;

            IArea pArea;
            pArea = shapeGeometry as IArea;

            IPoint pPoint;
            pPoint = pArea.Centroid;

            IGeometry pGeometry = (IGeometry)pPoint;
            ISpatialReferenceFactory pSpatFactory = new SpatialReferenceEnvironment();
            IGeographicCoordinateSystem pGeoSystem = pSpatFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_NAD1983);
            ISpatialReference pSpatReference = (ISpatialReference)pGeoSystem;
            pSpatReference.SetFalseOriginAndUnits(-180, -90, 1000000);
            pGeometry.Project(pSpatReference);

            double Longitude = Math.Abs(pPoint.X);
            double Latitude = Math.Abs(pPoint.Y);

            return Longitude.ToString("#.######") + "° W, " + Latitude.ToString("#.######") + "° N";
        }
    }
}
