using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public class GeoCoordinatesArray
    {
        private GeoCoordinates[] coordinatesArr;

        private static Random rnd = new Random();

        public static int arrCount = 0;

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
            arrCount++;
        }
        // create random 
        public GeoCoordinatesArray(int length, bool isRandom = true)
        {
            CoordinatesArr = new GeoCoordinates[length];

            if (isRandom)
            {
                for (int i = 0; i < length; i++)
                {
                    CoordinatesArr[i] = new GeoCoordinates(NextDouble(-90, 90), NextDouble(-180, 180));
                }
            }
            arrCount++;
        }
        // copying
        public GeoCoordinatesArray(GeoCoordinatesArray arrToCopy)
        {
            CoordinatesArr = new GeoCoordinates[arrToCopy.coordinatesArr.Length];

            for (int i = 0; i < arrToCopy.coordinatesArr.Length; i++)
            {
                CoordinatesArr[i] = new GeoCoordinates(arrToCopy.coordinatesArr[i]);
            }
            arrCount++;
        }

        public GeoCoordinates this[int index]
        {
            get {
                if (index < 0 || index >= CoordinatesArr.Length)
                {
                    throw new Exception($"Индекс {index} за пределами массива");
                }
                return CoordinatesArr[index];
            }
            set
            {
                if (index < 0 || index >= CoordinatesArr.Length)
                {
                    throw new Exception($"Индекс {index} за пределами массива");
                }
                CoordinatesArr[index] = value;
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
