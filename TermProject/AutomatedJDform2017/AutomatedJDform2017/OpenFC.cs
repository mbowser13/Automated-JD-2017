using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.Geometry;
using System.Runtime.InteropServices;

namespace AutomatedJDform2017
{
    class OpenFC
    {
        public static IFeatureClass OpenArcGisFeatureClassFromDialog(int hwnd, string dialogTitle, esriGeometryType possibleInputFeatureClassGeometry)

        {

            IFeatureClass result = null;

            IGxDialog gxDialog = new GxDialog();

            IEnumGxObject gxEnum;



            switch (possibleInputFeatureClassGeometry)

            {

                case esriGeometryType.esriGeometryPoint:

                    gxDialog.ObjectFilter = new GxFilterPointFeatureClasses();

                    break;

                case esriGeometryType.esriGeometryPolyline:

                    gxDialog.ObjectFilter = new GxFilterPolylineFeatureClasses();

                    break;

                case esriGeometryType.esriGeometryPolygon:

                    gxDialog.ObjectFilter = new GxFilterPolygonFeatureClasses();

                    break;

                default:

                    gxDialog.ObjectFilter = new GxFilterFeatureClasses();

                    break;

            }

            gxDialog.AllowMultiSelect = false;

            gxDialog.Title = dialogTitle;

            if (gxDialog.DoModalOpen(hwnd, out gxEnum) && gxEnum != null)

            {

                IGxObject gxObject = gxEnum.Next();

                if (gxObject is IGxDataset)

                {

                    IGxDataset gxDataset = (IGxDataset)gxObject;

                    if (gxDataset.Dataset is IFeatureClass)

                        result = (IFeatureClass)gxDataset.Dataset;

                }

            }

            gxDialog.InternalCatalog.Close();

            Marshal.FinalReleaseComObject(gxDialog);

            return result;

        }

    }
}
