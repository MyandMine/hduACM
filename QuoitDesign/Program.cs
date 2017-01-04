using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoitDesign
{
    struct ToyPoint
    {
        public int x;
        public int y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ToyPoint> toyPoint;
            int N = int.Parse(Console.ReadLine());
            //对输入进行排序
            toyPoint = new List<ToyPoint>();
            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(' ');
                ToyPoint point = new ToyPoint();
                point.x = int.Parse(str[0]);
                point.y = int.Parse(str[1]);
                int j;
                for (j = 0; j < toyPoint.Count; j++)
                {
                    if (toyPoint[j].x > point.x)
                        break;
                }
                toyPoint.Insert(j, point);
            }
            for (int i = 0; i < toyPoint.Count/2; i++)
            {
                
            }
        }
        /// <summary>
        /// 计算任意点集合中两点的最小距离
        /// </summary>
        /// <param name="toyPoint">点集合</param>
        /// <returns>最小距离</returns>
        double minDis(List<ToyPoint> toyPoint)
        {
            int count = toyPoint.Count;
            switch(count)
            {
                case 1:
                    return 10000;
                case 2:
                    int dx = (toyPoint[0].x - toyPoint[1].x) * (toyPoint[0].x - toyPoint[1].x);
                    int dy = (toyPoint[0].y - toyPoint[1].y) * (toyPoint[0].y - toyPoint[1].y);
                    return Math.Sqrt(dx + dy);
            }
            double d1 = minDis(toyPoint.GetRange(0, count / 2));
            double d2 = minDis(toyPoint.GetRange(count / 2 + 1, count));
            double d = d1 > d2 ? d2 : d1;
            ToyPoint m; 
            m.x = (toyPoint[count / 2].x + toyPoint[count / 2 + 1].x) / 2;
            m.y = (toyPoint[count / 2].y + toyPoint[count / 2 + 1].y) / 2;
            return 0;
        }
    }
}
