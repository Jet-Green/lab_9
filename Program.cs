﻿

namespace lab_9
{
    internal class Money
    {
        // private by default
        int rub;
        int kop;

        static int count;

        public static int GetCount
        {
            get => count;
        }

        // инкапсуляция через свойство
        public int Rub
        {
            get
            {
                return rub;
            }
            set
            {
                if (value < 0)
                {
                    rub = 0;
                    Console.WriteLine("Error!");
                }
                else
                {
                    rub = value;
                }
            }
        }

        public int Kop
        {
            get => kop;
            set
            {
                if (value < 0)
                {
                    kop = 0;
                    Console.WriteLine("Error!");
                }
                else if (value > 99)
                {
                    Rub += value / 100;
                    kop = value % 100;
                }
                else
                {
                    kop = value;
                }
            }
        }
        // минимум 2, без параметров и с параметрами
        public Money()
        {
            Rub = 0;
            Kop = 0;
            count++;
        }

        public Money(int rub, int kop)
        {
            Rub = rub;
            Kop = kop;
            count++;
        }

        public void Show()
        {
            Console.WriteLine($"{Rub} руб., {Kop} коп.");
        }

        public void AddKop(int sum)
        {
            Kop = Kop + sum;
        }

        public static void AddKop(Money m, int sum)
        {
            m.Kop = m.Kop + sum;
        }

        // перегрузка унарных операторов
        public static Money operator ++(Money m)
        {
            m.Kop += 1;
            return m;
        }

        public static Money operator +(Money m, int sum)
        {
            Money temp = new Money(m.Rub, m.Kop);

            temp.Kop += sum;
            return temp;
        }
        // два варианта бинарного оператора для разного расположения.
        public static Money operator +(int sum, Money m)
        {
            Money temp = new Money(m.Rub, m.Kop);

            temp.Kop += sum;
            return temp;
        }

        public static Money operator +(Money m1, Money m2)
        {
            Money temp = new Money();

            temp.Kop = m1.Kop + m2.Kop;
            temp.Rub = m1.Rub + m2.Rub;

            return temp;
        }

        // неявное преобразование типа
        public static implicit operator double(Money m)
        {
            double temp = m.Rub + m.Kop / 100.0;

            return temp;
        }

        public static explicit operator int(Money m)
        {
            return m.Rub;
        }

        public static bool operator == (Money m1, Money m2)
        {
            return m1.Rub == m2.Rub && m1.Kop == m2.Kop;
        }

        public static bool operator != (Money m1, Money m2)
        {
            return !(m1.Rub != m2.Rub && m1.Kop != m2.Kop);
        }
    }


    internal class Program
    {
        public static GeoCoordinates NearestToNemo(GeoCoordinatesArray arr)
        {
            double min = double.MaxValue;
            GeoCoordinates minCoord = new GeoCoordinates();

            for(int i = 0; i < arr.CoordinatesArr.Length; i++)
            {
                GeoCoordinates gc = arr[i];

                double dist = gc.GetDistance(0, 0);
                if (dist < min)
                {
                    minCoord = gc;
                    min = dist; 
                }
            }

            return minCoord;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1");
            try
            {
                GeoCoordinates c0 = new GeoCoordinates(-1000, 20);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            try
            {
                GeoCoordinates c0 = new GeoCoordinates(20.123, -200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            GeoCoordinates c1 = new GeoCoordinates(57.973190, 56.168477);
            c1.Show();
            GeoCoordinates c2 = new GeoCoordinates(57.727685, 54.765219);
            c2.Show();

            Console.WriteLine($"Кол-во созданных объектов: {GeoCoordinates.objCount}");

            Console.WriteLine(c1.GetDistance(57.727685, 54.765219));
            Console.WriteLine(GeoCoordinates.GetDistance(c1, c2));

            Console.WriteLine();
            Console.WriteLine("Задание №2");

            GeoCoordinates c3 = new GeoCoordinates(23, 44);
            c3++;
            c3.Show();

            GeoCoordinates c4 = -c3;

            c4.Show();

            bool a = (bool)c4;
            Console.WriteLine(a);
            bool b = (bool)new GeoCoordinates(0, 12);
            Console.WriteLine(b);

            Console.WriteLine(c3);

            GeoCoordinates c5 = new GeoCoordinates(44, 2.55);
            GeoCoordinates c6 = new GeoCoordinates(44, -56.55);

            Console.WriteLine(c5 == c6);

            GeoCoordinates c7 = new GeoCoordinates(-68.66, 71);
            GeoCoordinates c8 = new GeoCoordinates(-67.66, 71);

            Console.WriteLine(c7 != c8);

            GeoCoordinates c9 = new GeoCoordinates(12, 123);
            GeoCoordinates c10 = new GeoCoordinates(12, 123);

            Console.WriteLine(c9.Equals(c10));

            Console.WriteLine("\n\n\nЗадание №3");

            GeoCoordinatesArray emptyCoordinatesArray = new GeoCoordinatesArray();
            try
            {
                emptyCoordinatesArray.Show();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            GeoCoordinatesArray coordinatesArray = new GeoCoordinatesArray(12);
            coordinatesArray.Show();
            try
            {
                Console.WriteLine(coordinatesArray[123]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            double DoubleInput(string msg)
            {
                double res = 0;

                Console.WriteLine(msg);

                double.TryParse(Console.ReadLine(), out res);

                return res;
            }

            GeoCoordinatesArray gca = new GeoCoordinatesArray(3, false);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Объект №{i + 1}");
                double lat = DoubleInput("Введите широту: ");
                double lon = DoubleInput("Введите долготу: ");
                
                try
                {
                    gca[i] = new GeoCoordinates(lat, lon);
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            gca.Show();

            Console.WriteLine("копия: ");
            GeoCoordinatesArray copiedArr = new GeoCoordinatesArray(gca);

            copiedArr.Show();

            Console.WriteLine("№ 4.4");
            GeoCoordinatesArray gca1 = new GeoCoordinatesArray(3);
            gca1.Show();
            gca1[0] = new GeoCoordinates(12, 44);
            Console.WriteLine("Обновленный массив: ");
            gca1.Show();
            Console.WriteLine("с индексом 0: " + gca1[0].ToString());

            try
            {
                gca1[123] = new GeoCoordinates(12, 33);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine(gca1[123]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("№4.5");
            Console.WriteLine("Ищем в массиве:");
            gca1.Show();

            Console.WriteLine("Найдено: " + NearestToNemo(gca1).ToString());

            Console.WriteLine("\n\n\n");
            Console.WriteLine($"Кол-во созданных объектов: {GeoCoordinates.objCount}");
            Console.WriteLine($"Кол-во созданных массивов: {GeoCoordinatesArray.arrCount}");
        }
    }
}
