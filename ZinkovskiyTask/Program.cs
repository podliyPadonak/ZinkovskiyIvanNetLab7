using System;
using System.IO;
using ZinkovskiyTask;

namespace FileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("РОБОТА ЗІНКОВСЬКОГО ІВАНА, ОНЛАЙН ГРУПА");

            while(true) 
            {
                Console.Write("\nУведіть каталог:");
                string path = Console.ReadLine();
                Console.Write("Уведіть шукану фразу:");
                string srch_text = Console.ReadLine();

                Console.WriteLine("\nРезультати:");
                DateTime start_time = DateTime.Now;
                DirectoryScanner scanner = new DirectoryScanner();
                List<string> pathes = null;
                try
                {
                    pathes = scanner.GetTextFilesWithString(new string[] { path }, srch_text);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Вказаної директорії не існує!");
                    continue;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Немає доступу до вказаної директорії!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                DateTime end_time = DateTime.Now;
                TimeSpan time_total = end_time - start_time;
                foreach (var item in pathes)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Витрачено часу: {time_total.TotalSeconds.ToString()} секунд");
                Console.ReadKey();
            }
        }
    }
}
