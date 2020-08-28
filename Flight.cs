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

        private string _departureTime;

        public string departureTime
        {
            get { return _departureTime; }
            set { _departureTime = SetDepartureTime( value); }
        }

        private string SetDepartureTime(string value)
        {
            double tempHour = Convert.ToDouble(value.Substring(6, 2));
            double tempMins = Convert.ToDouble(value.Substring(8, 2));
            string tempTime = " ";
            DateTime dtToday = DateTime.Today.AddHours(tempHour).AddMinutes(tempMins);
            tempTime = dtToday.ToString("yyyy/MM/dd HH:mm");
            return tempTime;
        }




        private string _arrivingAt;

        public string arrivingAt
        {
            get { return _arrivingAt; }
            set { _arrivingAt = SetICAO(value); }
        }

        private string _arrivalTime;

        public string arrivalTime
        {
            get { return _arrivalTime; }
            set { _arrivalTime = SetArrivalTime(value); }
        }

        private string SetArrivalTime(string value)
        {
            DateTime tempDate = Convert.ToDateTime(_departureTime);
            int i = value.IndexOf(':');
            double durationHours =Convert.ToDouble( value.Substring(0, i));
            double durationMins = Convert.ToDouble(value.Substring(i + 1, 2)); 
            DateTime tempTime = tempDate.AddHours(durationHours).AddMinutes(durationMins);

            return tempTime.ToString("yyyy/MM/dd HH:mm");
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

    public class Arival
    {
        string duration;
        string departureTime;
    }
}
