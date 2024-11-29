// See https://aka.ms/new-console-template for more information
using Test.Worker;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            App app = new App();

            app.Init();

            app.Run();

            Console.WriteLine("\n서버 네트워크 시작\nq키를 누르면 종료한다....");
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }
        }
    }
}