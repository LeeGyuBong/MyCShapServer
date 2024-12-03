using Google.FlatBuffers;
using Test.Network;
using WebPacketLib;

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
            WebClient? webClient = WebClient.GetInstance();
            if (webClient == null)
                return;

            FlatBufferBuilder fbb = new FlatBufferBuilder(1024);
            var packetData = NetGame.Test.CreateTest(fbb, 1, 3.141592, fbb.CreateString("가나다zdzzd"));
            fbb.Finish(packetData.Value);

            MyWebRequest request = new MyWebRequest
            {
                Data = fbb.SizedByteArray()
            };

            await webClient.PostAsync("api/Login", request);

            Console.WriteLine($"Worker{ID} is Run!");
            await Task.Delay( 1000 );
        }
    }
}
