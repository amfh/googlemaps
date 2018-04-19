using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    class Program
    {

        static void Main(string[] args)
        {
            //string address = "3036, norway"; // THIS IS A VALID NORWEGIAN ZIP CODE THAT WORKS FINE HERE AND IN BROWSER. lat and lng is correct coordiantes as in https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyBv4ZqpeMIDBDavvI2arWLOVg7VOMg_7Mo&address=3036,norway&sensor=false
            string address = "1610, norway"; // THIS IS A VALID NORWEGIAN ZIP CODE THAT DOES NOT WORKS FINE HERE AND IN BROWSER. for correct coordinates see Location here https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyBv4ZqpeMIDBDavvI2arWLOVg7VOMg_7Mo&address=1610,norway&sensor=false

            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyBv4ZqpeMIDBDavvI2arWLOVg7VOMg_7Mo&address={0}&sensor=false", Uri.EscapeDataString(address));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");
        }
    }
}
