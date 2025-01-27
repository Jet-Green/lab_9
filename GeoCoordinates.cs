using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace lab_9
{
    internal class GeoCoordinates
    {
        private double latitude; // широта
        private double longitude; // долгота

        public static int objCount = 0;

        static double R = 6371;

        public double Latitude
        {
            get => latitude;

            set
            {
                if (value > 90 || value < -90)
                {
                    throw new Exception("Широта должна находиться в пределах от -90 до 90");
                }
                latitude = value;
            }
        }

        public double Longitude
        {
            get => longitude;

            set
            {
                if (value < -180 || value > 180)
                {
                    throw new Exception("Долгота должна находиться в пределах от -180 до 180");
                }
                longitude = value;
            }
        }

        public GeoCoordinates()
        {
            Longitude = 0;
            Latitude = 0;
            objCount++;
        }

        public GeoCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            objCount++;
        }
        public GeoCoordinates(GeoCoordinates obj)
        {
            Latitude = obj.latitude;
            Longitude = obj.longitude;
            objCount++;
        }

        public double GetDistance(double lat2, double lon2)
        {
            double lat = (lat2 - Latitude) * (PI / 180);
            double lon = (lon2 - Longitude) * (PI / 180);
            double rez = Sin(lat / 2) * Sin(lat / 2) + Cos(Latitude * (PI / 180)) * Cos(lat2 * (PI / 180)) * Sin(lon / 2) * Sin(lon / 2);
            double d = 2 * R * Atan2(Sqrt(rez), Sqrt(1 - rez));

            return d;
        }

        public static double GetDistance(GeoCoordinates c1, GeoCoordinates c2)
        {
            double lat = (c2.Latitude - c1.Latitude) * (PI / 180);
            double lon = (c2.Longitude - c1.Longitude) * (PI / 180);
            double rez = Sin(lat / 2) * Sin(lat / 2) + Cos(c1.Latitude * (PI / 180)) * Cos(c2.Latitude * (PI / 180)) * Sin(lon / 2) * Sin(lon / 2);
            double d = 2 * R * Atan2(Sqrt(rez), Sqrt(1 - rez));

            return d;
        }

        public void Show()
        {
            Console.WriteLine($"Широта: {Latitude}, долгота: {Longitude}");
        }

        public static GeoCoordinates operator ++ (GeoCoordinates c)
        {
            c.Latitude += 0.01;
            c.Longitude += 0.01;

            return c;
        }

        // противоположное значение
        public static GeoCoordinates operator -(GeoCoordinates c)
        {
            c.Latitude = -c.Latitude;
            c.Longitude = -c.Longitude;

            return c;
        }
        // расположена ли на экваторе; явный
        public static explicit operator bool(GeoCoordinates c)
        {
            if (c.Latitude == 0)
            {
                return true;
            }
            return false;
        }
        // неявный
        public static implicit operator string(GeoCoordinates c)
        {
            if (c.Longitude == 0)
            {
                return "Нулевой меридиан";
            }
            else if (c.Latitude > 0)
            {
                return "Восточная долгота";
            }
            else if (c.Longitude < 0)
            {
                return "Западная долгота";
            }
            return "";
        }

        // если на одной параллели
        public static bool operator == (GeoCoordinates c1, GeoCoordinates c2)
        {
            if (c1.Longitude == c2.Longitude)
            {
                return true;
            }
            return false;
        }

        // true, если на разных меридианах
        public static bool operator != (GeoCoordinates c1, GeoCoordinates c2)
        {
            if (c1.Latitude != c2.Latitude) {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is GeoCoordinates)) return false;

            var objToCompare = obj as GeoCoordinates;
            if (Longitude == objToCompare.Longitude && Latitude == objToCompare.Latitude)
            {
                return true;
            }
            return false;
        }
    }
}
