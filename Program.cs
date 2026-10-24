using System;

namespace Lab3
{
    interface IStat
    {
        string Info();
        double Help();
    }

    // Клас Child1 - допомога з інвалідності
    class Child1 : IStat, IComparable
    {
        double minHelp;
        int group;
        double benefit;

        public Child1(double minHelp, int group)
        {
            this.minHelp = minHelp;
            this.group = group;
        }

        public double Help()
        {
            if (group == 1) benefit = minHelp * 3;
            else if (group == 2) benefit = minHelp * 2;
            else benefit = minHelp * 2;
            return benefit;
        }

        public string Info()
        {
            return $"Мін допомога={minHelp} Група={group} ";
        }

        public int CompareTo(object o)
        {
            Child1 p = o as Child1;
            return this.group.CompareTo(p.group);
        }
    }

    // Клас Child2 - допомога багатодітним
    class Child2 : IStat, IComparable
    {
        double minHelp;
        int children;
        double benefit;

        public Child2(double minHelp, int children)
        {
            this.minHelp = minHelp;
            this.children = children;
            this.benefit = Help();
        }

        public double Help()
        {
            if (children >= 3 && children <= 5) benefit = minHelp * 1.3;
            else if (children > 5) benefit = minHelp * 1.5;
            else benefit = minHelp;
            return benefit;
        }

        public string Info()
        {
            return $"Мін допомога={minHelp} дітей={children} ";
        }

        public int CompareTo(object o)
        {
            Child2 p = o as Child2;
            this.benefit = this.Help();
            p.benefit = p.Help();
            return this.benefit.CompareTo(p.benefit);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rnd = new Random();
            double minHelp = 1262;

            Child1[] arr1 = new Child1[3];
            Console.WriteLine("------По інвалідності-----");
            for (int i = 0; i < 3; i++)
            {
                int group = rnd.Next(1, 4);
                arr1[i] = new Child1(minHelp, group);
                Console.Write(arr1[i].Info());
                Console.WriteLine($"Допомога={arr1[i].Help()}");
            }

            Array.Sort(arr1);
            Console.WriteLine("------сортування по групі------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(arr1[i].Info());
                Console.WriteLine($"Допомога={arr1[i].Help()}");
            }

            Child2[] arr2 = new Child2[3];
            Console.WriteLine("------Багатодітним-----");
            for (int i = 0; i < 3; i++)
            {
                int children = rnd.Next(3, 9);
                arr2[i] = new Child2(minHelp, children);
                Console.Write(arr2[i].Info());
                Console.WriteLine($"Допомога={arr2[i].Help()}");
            }

            Array.Sort(arr2);
            Console.WriteLine("------сортування по допомозі------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(arr2[i].Info());
                Console.WriteLine($"Допомога={arr2[i].Help()}");
            }

            Console.ReadLine();
        }
    }
}