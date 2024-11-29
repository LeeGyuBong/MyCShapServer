using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Worker;

namespace Test
{
    internal class App
    {
        List<WorkerGroup> mWorkerGroupList = new List<WorkerGroup>();

        public void Init()
        {
            for(int i = 0; i < 5; ++i)
            {
                WorkerGroup workerGroup = new(i + 1);
                workerGroup.Init(10);

                mWorkerGroupList.Add(workerGroup);
            }
        }

        public void Run()
        {
            mWorkerGroupList.ForEach(workerGroup => workerGroup.Run());
        }

        public void Stop()
        {
        }
    }
}
