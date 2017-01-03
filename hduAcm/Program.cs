using System;

namespace TickAndTick
{
    class Program
    {
        static void Main(string[] args)
        {
            double angle_h, angle_m;
            double angle_s = 0, s_min, s_max;
            while (true)
            {
                double time = 0;
                double angle_min = double.Parse(Console.ReadLine());
                if (angle_min == -1)
                    break;
                for (int i = 0; i < 720; i++)
                {
                    angle_m = (i % 60) * 6;
                    angle_h = (i * 1.0 / 60) * 30;
                    double x;
                    x = Math.Abs(angle_m - angle_h);
                    x = x < 180 ? x : 360 - x;
                    if (x >= angle_min)
                    {
                        s_min = angle_min;
                        s_max = x - angle_min;
                        angle_s = s_max > s_min ? (s_max - s_min) : 0;
                        time = time + Math.Round(angle_s, 3);

                        s_min = angle_min + x;
                        s_max = 360 - angle_min;
                        angle_s = s_max > s_min ? (s_max - s_min) : 0;
                        time = time + Math.Round(angle_s, 3);
                    }
                }
                double res = time / (720 * 360) * 100;
                Console.WriteLine(res.ToString("0.000"));
            }
        }
    }
}
