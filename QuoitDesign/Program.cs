using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoitDesign
{
    struct ToyPoint
    {
        public double x;
        public double y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<ToyPoint> toyPoint;
                int N = int.Parse(Console.ReadLine());
                //对输入进行排序
                toyPoint = new List<ToyPoint>();
                for (int i = 0; i < N; i++)
                {
                    string[] str = Console.ReadLine().Split(' ');
                    ToyPoint point = new ToyPoint();
                    point.x = double.Parse(str[0]);
                    point.y = double.Parse(str[1]);
                    int j;
                    for (j = 0; j < toyPoint.Count; j++)
                    {
                        if (toyPoint[j].x > point.x)
                            break;
                    }
                    toyPoint.Insert(j, point);
                }
                PointMinDis pointMinDis = new PointMinDis();
                double d = Math.Round(pointMinDis.minDis(toyPoint) / 2, 2);
                Console.Write(d + "\n");
            }
        }
    }
    /// <summary>
    /// 在点集合中找到最小的两点距离
    /// </summary>
    class PointMinDis
    {
        /// <summary>
        /// 计算任意点集合中两点的最小距离
        /// </summary>
        /// <param name="toyPoint">点集合</param>
        /// <returns>最小距离</returns>
        public double minDis(List<ToyPoint> toyPoint)
        {
            int count = toyPoint.Count;
            switch (count)
            {
                case 1:
                    return 10000;
                case 2:
                    return distance(toyPoint[0], toyPoint[1]);
            }
            double d1 = minDis(toyPoint.GetRange(0, count / 2));
            double d2 = minDis(toyPoint.GetRange(count / 2, count - count/2));
            double d = d1 > d2 ? d2 : d1;
            return trueDis(d, toyPoint);
        }
        /// <summary>
        /// 对分离计算的结果进行合并，找到真正的最小距离
        /// </summary>
        /// <param name="d">两边最小距离中小的</param>
        /// <param name="toyPoint"></param>
        /// <returns></returns>
        public double trueDis(double d, List<ToyPoint> toyPoint)
        {
            int count = toyPoint.Count();
            if (toyPoint[count / 2].x - toyPoint[count / 2-1].x >= d)
            {
                return d;
            }
            List<ToyPoint> area = new List<ToyPoint>();
            for (int i = 1; i < count / 2; i++)
            {
                if (toyPoint[count / 2 + i].x - toyPoint[count / 2 - 1].x < d)
                {
                    area.Add(toyPoint[count / 2 + i]);
                }
                if (toyPoint[count / 2].x - toyPoint[count / 2 - 1 - i].x < d)
                {
                    area.Add(toyPoint[count / 2 + 1 + i]);
                }
            }
            double d2 = forceDis(area);
            return d < d2 ? d : d2;
        }
        /// <summary>
        /// 采用暴力遍历每两点之间的距离
        /// </summary>
        /// <param name="area">点集合</param>
        /// <returns></returns>
        public double forceDis(List<ToyPoint> area)
        {
            double d_best = 100000;
            double d;
            for (int i = 0; i < area.Count; i++)
            {
                ToyPoint a = area[i];
                for (int j = i + 1; j < area.Count; j++)
                {
                    ToyPoint b = area[j];
                    d = distance(a, b);
                    if (d < d_best)
                    {
                        d_best = d;
                    }
                }
            }
            return d_best;
        }
        /// <summary>
        /// 计算两点之间的距离
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double distance(ToyPoint a, ToyPoint b)
        {
            double dx = (a.x - b.x) * (a.x - b.x);
            double dy = (a.y - b.y) * (a.y - b.y);
            return Math.Sqrt(dx + dy);
        }
    }
}