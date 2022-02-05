using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.SpecificationSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Specification pattern");
                Console.WriteLine(" 1. Exercise");
                Console.WriteLine(" 2. Benchmark (LinqExpression vs ObjectOriented)");
                Console.WriteLine(" 3. Exit");

                var choice = '0';
                while (true)
                {
                    choice = Console.ReadKey().KeyChar;
                    if (choice != '1' && choice != '2' && choice != '3')
                        Console.WriteLine(" is wrong, please enter 1, 2 or 3 ...");
                    else
                        break;
                }

                switch (choice)
                {
                    case '1':
                        ExecuteExercise();
                        break;
                    case '2':
                        ExecuteBenchmark();
                        break;
                    case '3':
                        Environment.Exit(0);
                        return;
                }
            }

        }
        private static List<Campaign> GeneareCampainList(int count = 30)
        {
            var today = DateTime.Today;
            var list = new List<Campaign>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                var pastDaysFromRegister = (double)random.Next(400, 1200) / 100;
                var registrationDate = today.AddDays(-1 * pastDaysFromRegister);
                if (random.Next() % 2 == 0)
                    list.Add(new Campaign(i + 1, registrationDate, null));
                else
                {
                    var pastDays = (double)random.Next(100, 900) / 100;
                    list.Add(new Campaign(i + 1, registrationDate, today.AddDays(-1 * pastDays)));
                }
            }

            return list;
        }

        private static void ExecuteExercise()
        {
            var campaigns = GeneareCampainList();

            Console.WriteLine("-----< All >-----");
            foreach (var item in campaigns)
                Console.WriteLine(item.ToString());
            Console.WriteLine("\r\n");
            ExecuteExercise_LinqExpression(campaigns);
            Console.WriteLine("\r\n");
            ExecuteExercise_ObjectOriented(campaigns);

            Console.WriteLine("\r\n");
        }


        private static void ExecuteExercise_LinqExpression(List<Campaign> campaigns)
        {
            var campainRepo = new LinqExpression.Repository<Campaign>(campaigns);
            var notConfimed = new LinqExpression.NotConfimedSpecification();
            var confimationDelay_7Days = new LinqExpression.ConfimationDelaySpecification(7);
            //Console.WriteLine("-----< LinqExpression - Not confimed >-----");
            //foreach (var item in campainRepo.Find(notConfimed))
            //    Console.WriteLine(item.ToString());
            //Console.WriteLine("-----< LinqExpression - More than 7 days delay >-----");
            //foreach (var item in campainRepo.Find(confimationDelay_7Days))
            //    Console.WriteLine(item.ToString());
            Console.WriteLine("-----< LinqExpression - Not confimed and More than 7 days delay >-----");
            foreach (var item in campainRepo.Find(notConfimed.And(confimationDelay_7Days)))
                Console.WriteLine(item.ToString());
        }
        private static void ExecuteExercise_ObjectOriented(List<Campaign> campaigns)
        {
            var campainRepo = new ObjectOriented.Repository<Campaign>(campaigns);
            var notConfimed = new ObjectOriented.NotConfimedSpecification();
            var confimationDelay_7Days = new ObjectOriented.ConfimationDelaySpecification(7);
            //Console.WriteLine("-----< ObjectOriented - Not confimed >-----");
            //foreach (var item in campainRepo.Find(notConfimed))
            //    Console.WriteLine(item.ToString());
            //Console.WriteLine("-----< ObjectOriented - More than 7 days delay >-----");
            //foreach (var item in campainRepo.Find(confimationDelay_7Days))
            //    Console.WriteLine(item.ToString());
            Console.WriteLine("-----< ObjectOriented - Not confimed and More than 7 days delay >-----");
            foreach (var item in campainRepo.Find(notConfimed.And(confimationDelay_7Days)))
                Console.WriteLine(item.ToString());
        }

        private static void ExecuteBenchmark()
        {
            var campaigns = GeneareCampainList(100 * 1000);
            Console.WriteLine($" -> Benchmark campaigns count: {campaigns.Count}");

            var LinqExpressionElapsedMillisecondsSet = new List<double>();
            var ObjectOrientedElapsedMillisecondsSet = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                LinqExpressionElapsedMillisecondsSet.Add(Benchmark_LinqExpression(campaigns));
                ObjectOrientedElapsedMillisecondsSet.Add(Benchmark_ObjectOriented(campaigns));
            }

            Console.WriteLine($" -> Benchmark LinqExpression Mem: {LinqExpressionElapsedMillisecondsSet.Sum() / LinqExpressionElapsedMillisecondsSet.Count:N2} Milliseconds");
            Console.WriteLine($" -> Benchmark ObjectOriented Mem: {ObjectOrientedElapsedMillisecondsSet.Sum() / ObjectOrientedElapsedMillisecondsSet.Count:N2} Milliseconds");

            Console.WriteLine("\r\n");
        }


        private static long Benchmark_LinqExpression(List<Campaign> campaigns)
        {
            var campainRepo = new LinqExpression.Repository<Campaign>(campaigns);
            var notConfimed = new LinqExpression.NotConfimedSpecification();
            var confimationDelay_7Days = new LinqExpression.ConfimationDelaySpecification(7);
            var notConfimed_And_confimationDelay_7Days = notConfimed.And(confimationDelay_7Days);

            var stopwatch = Stopwatch.StartNew();
            campainRepo.Find(notConfimed_And_confimationDelay_7Days);
            stopwatch.Stop();

            //Console.WriteLine($" -> LinqExpression: {stopwatch.ElapsedMilliseconds} milliseconds");
            return stopwatch.ElapsedMilliseconds;
        }
        private static long Benchmark_ObjectOriented(List<Campaign> campaigns)
        {
            var campainRepo = new ObjectOriented.Repository<Campaign>(campaigns);
            var notConfimed = new ObjectOriented.NotConfimedSpecification();
            var confimationDelay_7Days = new ObjectOriented.ConfimationDelaySpecification(7);
            var notConfimed_And_confimationDelay_7Days = notConfimed.And(confimationDelay_7Days);
            var stopwatch = Stopwatch.StartNew();
            campainRepo.Find(notConfimed_And_confimationDelay_7Days);
            stopwatch.Stop();

            //Console.WriteLine($" -> ObjectOriented: {stopwatch.ElapsedMilliseconds} milliseconds");
            return stopwatch.ElapsedMilliseconds;
        }

    }
}
