
﻿using System;
namespace G
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Метод PrintArray уже написан за вас
            PrintArray(GetPoweredArray(arrayToPower, 1));

            // если вы будете менять исходный массив, то следующие два теста сработают неверно:
            PrintArray(GetPoweredArray(arrayToPower, 2));
            PrintArray(GetPoweredArray(arrayToPower, 3));

            // не забывайте про частные случаи:
            PrintArray(GetPoweredArray(new int[0], 1));
            PrintArray(GetPoweredArray(new[] { 42 }, 0));
        }

        public static void PrintArray(int[] arr) {
            foreach (var item in arr)
                Console.WriteLine(item);
        }

        public static int[] GetPoweredArray(int[] arr, int power)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr), "Array cannot be null.");

            int[] poweredArray = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                poweredArray[i] = (int)Math.Pow(arr[i], power);
            }

            return poweredArray;
        }
    }
}
