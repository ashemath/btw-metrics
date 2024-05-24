using LibreMonitor;

namespace BtwMetrics{
    class MakeTextfileMetrics
    {
        static void Main(string[] args)
        {
            LibreMonitor.Monitor _monitor = new LibreMonitor.Monitor();
            Console.WriteLine(_monitor.Cpu());
            //Console.ReadLine();
        }
    }
}