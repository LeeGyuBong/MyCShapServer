using Test.Network;

namespace Test.Worker
{
    internal class Worker(int id) : IDisposable
    {
        public int ID { get; init; } = id;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Run()
        {
            HttpCore? httpCore = HttpCore.GetInstance();
            if (httpCore == null)
                return;

            await httpCore.GetAsync("https://localhost:7234/WeatherForecast");

            Console.WriteLine($"Worker{ID} is Run!");
            //await Task.Delay( 1000 );
        }
    }
}
