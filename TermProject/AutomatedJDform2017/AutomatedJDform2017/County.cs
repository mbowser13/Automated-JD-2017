using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatedJDform2017
{
    class County
    {
        private static dynamic name;

        public static string ReturnCounty(IFeatureClass SiteLayer, IFeatureClass intersectLayer, string fieldName)
        {//Returns a string saying what County and State the SiteLayer is in

            // Get the feature and its geometry given an Object ID.
            IFeature stateFeature = SiteLayer.GetFeature(0);
            IGeometry queryGeometry = stateFeature.Shape;

            IFeature intersectFeature = intersectLayer.GetFeature(0);

            // Create the spatial filter. 
            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.Geometry = queryGeometry;
            spatialFilter.GeometryField = intersectLayer.ShapeFieldName;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            spatialFilter.SubFields = fieldName;

            // Find the position of the field provided the fieldName variable
            int nameFieldPosition = intersectLayer.FindField(fieldName);

            // Execute the query and iterate through the cursor's results.
            IFeatureCursor highwayCursor = intersectLayer.Search(spatialFilter, false);
            IFeature highwayFeature = null;
            while ((highwayFeature = highwayCursor.NextFeature()) != null)
            {
                name = Convert.ToString(highwayFeature.get_Value(nameFieldPosition));
            }

            // The cursors is no longer needed, so dispose of it.
            Marshal.ReleaseComObject(highwayCursor);

            return name;

        }
    }
}
