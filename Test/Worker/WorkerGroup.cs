using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Worker
{
    internal class WorkerGroup(int id)
    {
        public int ID { get; init; } = id;

        bool mIsWork { get; set; } = true;
        Thread? mThread = null;
        List<Worker> mWorkerList = new List<Worker>();

        public void Init(int workerCnt)
        {
            int id = ID * 10000000;
            for (int i = 0; i < workerCnt; ++i)
            {
                mWorkerList.Add(new Worker(id + i + 1));
            }
        }

        public void Run()
        {
            mThread = new Thread(async () =>
            {
                while (mIsWork)
                {
                    foreach(var worker in mWorkerList)
                    {
                        if (worker == null)
                            continue;

                        await worker.Run();
                    }
                }
            });
            mThread.Start();
        }
    }
}
