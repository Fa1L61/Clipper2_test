using Clipper2Lib;

namespace clipper_test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите колличество точек в 1 полигоне: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] answer1 = new int[n*2];
            for (int i = 0; i < answer1.Length; i++)
            {

                Console.WriteLine("Введите значение: ");
                answer1[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите колличество точек вo 2 полигоне: ");
            n = Convert.ToInt32(Console.ReadLine());

            int[] answer2 = new int[n * 2];
            for (int i = 0; i < answer2.Length; i++)
            {
                Console.WriteLine("Введите значение: ");
                answer2[i] = Convert.ToInt32(Console.ReadLine());
            }

            Paths64 subj = new Paths64();
            Paths64 clip = new Paths64();

            subj.Add(Clipper.MakePath(answer1));
            clip.Add(Clipper.MakePath(answer2));
            Paths64 solution = Clipper.Intersect(subj, clip, FillRule.NonZero);

            double res = 0;

            for (int i = 1; i < solution[0].Count; i++)
            {
                //Console.WriteLine(solution[0][i]);
                res += Math.Sqrt(Math.Pow((solution[0][i].X - solution[0][i-1].X),2) + Math.Pow((solution[0][i].Y - solution[0][i - 1].Y), 2)) ;
            }

            res += Math.Sqrt(Math.Pow((solution[0][0].X) - solution[0][solution[0].Count - 1].X, 2) + Math.Pow((solution[0][0].Y) - solution[0][solution[0].Count - 1].Y, 2));


            Console.WriteLine($"Координаты контура пересечения полигонов: \n {solution}");
            Console.WriteLine($"Площадь контура пересечения: {Clipper.Area(solution)}");
            Console.WriteLine($"Периметр контура: {res}");
            //
        }
    }
}