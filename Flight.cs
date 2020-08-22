using System;
using System.Xml.Schema;

namespace FlightInfo
{
    public class Flight
    {

        //Properties
        private string _airline;
        

        public string airline
        {
            get { return _airline; }
            set { _airline = SetAirline(value); }
        }

        private string SetAirline(string value)
        {
            string target = "0123456789";
            char[] anyOf = target.ToCharArray();
            string temp1 = value.Substring(0, value.IndexOfAny(anyOf));
            return temp1;
        }

        private string _consolidatedFlightNumber;


        public string consolidatedFlightNumber
        {
            get { return _consolidatedFlightNumber; }
            set { _consolidatedFlightNumber = SetConsolidatedFlightNumber(value); }
        }

        private string _departingFrom;

        public string departingFrom
        {
            get { return _departingFrom; }
            set { _departingFrom = SetICAO(value); }
        }
        private string _arrivingAt;

        public string arrivingAt
        {
            get { return _arrivingAt; }
            set { _arrivingAt = SetICAO(value); }
        }


        private string SetICAO(string value)
        {
            return value.Substring(0, 4);
            throw new NotImplementedException();
        }

        private string SetConsolidatedFlightNumber(string value)
        {
            //string target = "0123456789";
            //char[] anyOf = target.ToCharArray();
            //string temp1 = value.Substring(0, value.IndexOfAny(anyOf));
            string temp1 = SetAirline(value);
            string temp2 = value.Substring(temp1.Length, value.Length - temp1.Length);
            return temp1 + " " + temp2;

        }

        public Flight()
        {

        }
        public Flight(string Airline)
        {
            airline = Airline;
        }
    }
}
