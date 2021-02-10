using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParsingManager.DL;
using ParsingManager.DL.Services;
using ParsingManager.Models.Concrete;
using ParsingManager;
using ParsingManager.Interfaces;


namespace NMEA_Parser
{
	public partial class Details : Form
	{
		public Details(Vehicle desiredDUT)
		{
			InitializeComponent();
			DesiredDUT = desiredDUT;
		}
		public Vehicle DesiredDUT { get; set; }

		private void Details_Load(object sender, EventArgs e)
		{
			PrepareGridView();
			ConstructColumns();
			LoadSelectedVehicleData();
		}
		private void ConstructColumns()
		{

			DetailedInfoGrid.Columns.Add("No", "No");
			DetailedInfoGrid.Columns.Add("UTC", "UTC");
			DetailedInfoGrid.Columns.Add("SVs Tracked", "SVs Tracked");
			DetailedInfoGrid.Columns.Add("SV C/N0", "SV C/N0");
			DetailedInfoGrid.Columns.Add("PDOP", "PDOP");
			DetailedInfoGrid.Columns.Add("Lat", "Lat");
			DetailedInfoGrid.Columns.Add("Lon", "Lon");
			DetailedInfoGrid.Columns.Add("X", "X");
			DetailedInfoGrid.Columns.Add("Y", "Y");
			DetailedInfoGrid.Columns.Add("Alt(HAE)", "Alt (HAE)"); //MSLGeoidSeparation expected in meters
			DetailedInfoGrid.Columns.Add("SoG", "SoG"); //expected to be in m/s
		}
		void PrepareGridView()
		{
			DetailedInfoGrid.AllowUserToDeleteRows = false;
			DetailedInfoGrid.ReadOnly = true;
			DetailedInfoGrid.DefaultCellStyle.Format = "0.00######";
			DetailedInfoGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			DetailedInfoGrid.Rows.Clear();
			DetailedInfoGrid.Columns.Clear();
			DetailedInfoGrid.Refresh();
		}
		private void LoadSelectedVehicleData()
		{
			long i = 0;
			foreach (var dat in DesiredDUT.Data)
			{
				i++;
				double X;
				double Y;
				double Z;
				double lat;
				double lon;
				double countitySVs = dat.SatellitesInfo.Count(k => k.SatelliteCNO > 0 && k.SatelliteCNO < 99);
				lat = CalculateDecimalDegrees(dat.Latitude, dat.DirLatitude);
				lon = CalculateDecimalDegrees(dat.Longitude, dat.DirLongitude);
				CalculateECF(lat, lon, dat.MSLAltitude+dat.GeoidSeparation, out X, out Y, out Z);
				DetailedInfoGrid.Rows.Add(new object[]
				{
				i,	
				dat.TimeStampUTC,
				dat.QuantityOfSatellites,
				dat.AvgCNO/countitySVs,
				dat.PDOP,
				lat,
				lon,
				X,
				Y,
				dat.MSLAltitude+dat.GeoidSeparation,
				dat.Speed
				});
			}
		}
		private void CalculateECF(double lat, double lon, double alt, out double X, out double Y, out double Z)
		{
			const double a= 6378137.0;
			double eSqrd = 6.6943799901377997e-3;
			double latinRad = lat/180 * Math.PI;
			double lonInRad = lon/180 * Math.PI;
			double N = a / (Math.Sqrt(1 - (eSqrd * (Math.Sin(latinRad) * Math.Sin(latinRad)))));
			if (lat != 0 && lon != 0 && alt != 0)
			{
				X = (N + alt) * Math.Cos(latinRad) * Math.Cos(lonInRad);
				Y = (N + alt) * Math.Cos(latinRad) * Math.Sin(lonInRad);
				Z = (((1 - eSqrd) * N) + alt) * Math.Sin(latinRad);
			}
			else
			{
				X = 0; Y = 0; Z = 0;
			}

		}
		double CalculateDecimalDegrees(double degMinSec, char hemisphere)
		{
			int degrees = (int)(degMinSec / 100);
			double minutes = (degMinSec % 100);

			double Calculated = degrees + minutes / 60;
			return hemisphere.Equals('N')||hemisphere.Equals('E')||hemisphere.Equals('\0')? Calculated: Calculated*-1;
		}

	}
}
