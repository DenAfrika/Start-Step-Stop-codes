using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SSS
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Если вы хотите воспользоваться программой, нажмите Enter.");
            Console.WriteLine("Если вы хотите посмотреть тесты, нажмите 1.");
            if (Console.ReadLine().Length > 0)
            {
                Console.WriteLine("(i, j, k) = (3, 2, 11)");
                Console.WriteLine("Число : 6");
                int[] arr = new int[]{ 3, 2, 11};
                int input = 6;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                string str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (3, 2, 11)");
                Console.WriteLine("Число : 40");
                arr = new int[] { 3, 2, 11 };
                input = 40;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (3, 2, 11)");
                Console.WriteLine("Число : 2000");
                arr = new int[] { 3, 2, 11 };
                input = 2000;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (1, 1, 6)");
                Console.WriteLine("Число : 40");
                arr = new int[] { 1, 1, 6 };
                input = 40;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (3, 2, 11)");
                Console.WriteLine("Число : 2500");
                arr = new int[] { 3, 2, 11 };
                input = 2500;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (3, 2, 11)");
                Console.WriteLine("Число : 2341");
                arr = new int[] { 3, 2, 11 };
                input = 2341;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (3, 2, 11)");
                Console.WriteLine("Число : 500");
                arr = new int[] { 3, 2, 11 };
                input = 500;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();

                Console.WriteLine("(i, j, k) = (5, 2, 7)");
                Console.WriteLine("Число : 150");
                arr = new int[] { 5, 2, 7 };
                input = 150;
                Console.WriteLine("Code :{0}", Encode(arr, input));
                str = Encode(arr, input);
                Console.WriteLine("Decode :{0}", Decode(arr, str));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Введите ключ (i, j, k) через пробел и нажмите Enter : ");
                int[] arr = Console.ReadLine().Split().Select(i => int.Parse(i)).ToArray();
                Console.WriteLine("Введите число для кодирования : ");
                int input = Convert.ToInt32(Console.ReadLine());
                string str = Encode(arr, input);
                Console.WriteLine("Code :{0}", Encode(arr, input));
            
                
                Console.WriteLine("Decode :{0}", Decode(arr, str));
            }
        }

        static String EncodeShort(int[] arr, int num)
        {
            String prefix = "";
            int prevMax = 0;
            for(int i = 0, step = arr[0]; step <= arr[2]; step += arr[1], i++)
            {
                int max = Convert.ToInt32(Math.Pow(2, step)) + prevMax;
                if (i > 0)
                    prefix += "1";
                if (num <= max)
                {
                    if (step != arr[2])
                        prefix += "0";
                    StringBuilder suffix = new StringBuilder(Convert.ToString(num - prevMax - 1, 2));
                    while (suffix.Length != step)
                        suffix.Insert(0, "0");
                    return prefix + suffix.ToString();
                }
                prevMax = max;
            }
            return "";
        }
        static String Encode(int[] arr, int input)
        {

            int i = arr[0];
            int j = arr[1];
            int k = arr[2];
            int LastPoz = Convert.ToInt32(Math.Pow(2, i));
            int firstPoz = 1;
            int degree = i;
            int k1 = (k - i) / j + 1;
            string rez = "0";

            for (int count = 0; count < k1; count++)
            {
                if (count > 0)
                {
                    firstPoz = LastPoz + 1;
                    rez = "1" + rez;
                    degree = i + count * j;
                    LastPoz += Convert.ToInt32(Math.Pow(2, degree));
                }
                if(input <= LastPoz)
                {
                    StringBuilder suffix = new StringBuilder(Convert.ToString(input - firstPoz, 2));
                    while (suffix.Length != degree)
                    {
                        suffix.Insert(0, "0");
                    }
                    rez += suffix.ToString();
                    break;
                }
            }
            return rez;
        }
        static int Decode(int[] arr, string input)
        {
            int firstPoz = 1;
            int LastPoz = Convert.ToInt32(Math.Pow(2, arr[0]));
            int k = input.IndexOf('0') + 1;
            int kek = (arr[2] - arr[0]) / arr[1] + 1;
            if (k > kek || k < 0)
                k = kek;
            int degree = arr[0];
            for (int i = 0; i < k; i++)
            {
                if (i > 0)
                {
                    firstPoz = LastPoz + 1;
                    degree = arr[0] + i * arr[1];
                    LastPoz += Convert.ToInt32(Math.Pow(2, degree));
                }
            }
            int lol = Convert.ToInt32(input.Substring(input.IndexOf("0") + 1, degree), 2);
            k = firstPoz + lol;
            return k;
        }
    }
}
