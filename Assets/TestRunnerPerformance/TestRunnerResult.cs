using System;

namespace TestRunnerPerformance
{
    [Serializable]
    public class TestRunnerResult
    {
        public _Base BaseSetUp;
        public _Worker Worker;
        public _Results TestResults;

        [Serializable]
        public class _Base
        {
            public string TestName;
            public int DataSize;
            public int TotalRuns;
        }

        [Serializable]
        public class _Worker
        {
            public string Name;
            public string NameSpace;
            public string JobType;
            public string Config;
            public string Data;
        }

        [Serializable]
        public class _Results
        {
            public double First;
            public double Min;
            public double Max;
            public double Median;
            public double Average;
            public double StandardDeviation;
        }
    }
}