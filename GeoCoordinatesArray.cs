using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal class GeoCoordinatesArray
    {
        private GeoCoordinates[] coordinatesArr;

        private static Random rnd = new Random();

        public static double NextDouble(
            double minValue,
            double maxValue
        )
        {
            return rnd.NextDouble() * (maxValue - minValue) + minValue;
        }

        public GeoCoordinates[] CoordinatesArr
        {
            get => coordinatesArr;
            set => coordinatesArr = value;
        }

        // constructor with no arguments
        public GeoCoordinatesArray()
        {
            CoordinatesArr = [];
        }
        // create random 
        public GeoCoordinatesArray(int length)
        {
            CoordinatesArr = new GeoCoordinates[length];

            for (int i = 0; i < length; i++)
            {
                CoordinatesArr[i] = new GeoCoordinates(NextDouble(-90, 90), NextDouble(-180, 180));
            }
        }
        // copying
        public GeoCoordinatesArray(GeoCoordinatesArray arrToCopy)
        {
            CoordinatesArr = new GeoCoordinates[arrToCopy.coordinatesArr.Length];

            for (int i = 0; i < arrToCopy.coordinatesArr.Length; i++)
            {
                CoordinatesArr[i] = new GeoCoordinates(arrToCopy.coordinatesArr[i]);
            }
        }

        public void Show()
        {
            if (CoordinatesArr == null || CoordinatesArr.Length == 0)
            {
                throw new Exception("Коллекция пустая");
            }

            foreach(GeoCoordinates c in CoordinatesArr)
            {
                c.Show();
            }
        }
    }
}
