using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace AutomatedJDform2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            //Open ESRI dialog to choose site boundary
            IFeatureClass siteFeatureClass = OpenFC.OpenArcGisFeatureClassFromDialog(0, "Select Site Boundary", esriGeometryType.esriGeometryPolygon);


            //***Obtain string containing the COUNTY NAME which the site falls within***//
            //Set county feature layer using the shapefileFromString class
            IFeatureLayer countyFeatureLayer = shapefileFromString.getShapefile("C:\\Users\\micha\\Documents\\GEOG 489\\TermProject\\GISData\\", "usCounties.shp");
            IFeatureClass countyFeatureClass = countyFeatureLayer.FeatureClass; //Create feature class object from the county feature layer


            //***Obtain string containing the STATE NAME which the site falls within****//
            //Set state feature layer using the shapefileFromString class
            IFeatureLayer stateFeatureLayer = shapefileFromString.getShapefile("C:\\Users\\micha\\Documents\\GEOG 489\\TermProject\\GISData\\", "usStates.shp");
            IFeatureClass stateFeatureClass = stateFeatureLayer.FeatureClass; //Create feature class object from the county feature layer


            //***Obtain string containing the WATERSHED HUC 12 NAME which the site falls within****//
            //Set HUC 12 feature layer using the shapefileFromString class
            IFeatureLayer watershedFeatureLayer = shapefileFromString.getShapefile("C:\\Users\\micha\\Documents\\GEOG 489\\TermProject\\GISData\\", "watershedHUC12.shp");
            IFeatureClass watershedFeatureClass = watershedFeatureLayer.FeatureClass; //Create feature class object from the county feature layer





            //Below are the string variables that will be used in the output form
            //**************************************************************************//
            string countyMSWord = County.ReturnCounty(siteFeatureClass, countyFeatureClass, "NAME"); //use this variable to display the county name of the site
            string stateMSWord = County.ReturnCounty(siteFeatureClass, stateFeatureClass, "NAME"); //use this variable to display the state name of the site
            string watershedMSWord = County.ReturnCounty(siteFeatureClass, watershedFeatureClass, "HUC12"); //use this variable to display the state name of the site


            string latlongMSWord = Coordinates.latlongCoordinates(siteFeatureClass);



            //****************************************FOR TESTING***************************************//
            MessageBox.Show("County: " + countyMSWord + "\r\n" + "State: " + stateMSWord + "\r\n" + "HUC Code: " + watershedMSWord + "\r\n" + "Lat/Long Coordinates" + latlongMSWord);

        }
    }
}