using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\USER\Desktop\folder\5_2.txt"; // Укажите путь к вашему файлу

        List<(int, int)> points = ReadFileData(filePath);

        bool result = Solve(points);
        Console.WriteLine(result ? "Можно сделать ломаную четной функцией" : "Невозможно сделать ломаную четной функцией");
    }

    static bool Solve(List<(int, int)> points)
    {
        int n = points.Count;
        if (n % 2 == 0)
            return false;

        int sumX = 0;
        int sumY = 0;

        foreach ((int x, int y) in points)
        {
            sumX += x;
            sumY += y;
        }

        int avgX = sumX / n;

        foreach ((int x, int y) in points)
        {
            if (Math.Sign(y) != Math.Sign(y - avgX))
                return false;
        }

        return true;
    }

    static List<(int, int)> ReadFileData(string filePath)
    {
        List<(int, int)> points = new List<(int, int)>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(' ');
                    int x = int.Parse(values[0]);
                    int y = int.Parse(values[1]);
                    points.Add((x, y));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка чтения файла: " + e.Message);
        }

        return points;
    }
}
