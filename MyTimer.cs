using System.Diagnostics;

namespace SerializerHomework
{
    public class MyTimer<T>(int numberOfIterations)
    {
        private readonly int NumberOfIterations = numberOfIterations;

        public delegate string ActionToMeasure();
        public delegate T AnotherActionToMesure();

        public string MeasureTime(ActionToMeasure actionToMeasure, string additionalInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();

            string info = string.Format("____________________\r\n\r\nEnvironment = {0}\r\nIterations = {1}\r\nAdditionalInfo = {2}\r\n\r\n", 
                Environment.Version, NumberOfIterations, additionalInfo);

            sw.Start();

            for (int i = 0; i < NumberOfIterations; i++)
            {
                actionToMeasure();
            }

            sw.Stop();

            info += string.Format("ElapsedMilliseconds = {0}\r\n", sw.ElapsedMilliseconds);

            return info;
        }

        public string MeasureTime(AnotherActionToMesure actionToMeasure, string additionalInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();

            string info = string.Format("____________________\r\n\r\nEnvironment = {0}\r\nIterations = {1}\r\nAdditionalInfo = {2}\r\n\r\n",
                Environment.Version, NumberOfIterations, additionalInfo);

            sw.Start();

            for (int i = 0; i < NumberOfIterations; i++)
            {
                actionToMeasure();
            }

            sw.Stop();

            info += string.Format("ElapsedMilliseconds = {0}\r\n", sw.ElapsedMilliseconds);

            return info;
        }
    }
}
