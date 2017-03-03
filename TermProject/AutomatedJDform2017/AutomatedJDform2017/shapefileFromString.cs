using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace AutomatedJDform2017
{
    class shapefileFromString
    {
        public static IFeatureLayer getShapefile(string FullPathDirectory, string FileName)
        {
            IWorkspaceFactory pWorkspaceFactory;
            IFeatureWorkspace pFeatureWorkspace;
            IFeatureClass pFeatureClass;
            IFeatureLayer pFeatureLayer;

            pWorkspaceFactory = new ShapefileWorkspaceFactory();
            pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(FullPathDirectory, 0); //TODO - check if zero is the correct thing to put here
            pFeatureClass = pFeatureWorkspace.OpenFeatureClass(FileName);
            pFeatureLayer = new FeatureLayer();
            pFeatureLayer.FeatureClass = pFeatureClass;

            return pFeatureLayer;
        }
    }
}
