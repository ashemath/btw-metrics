using System;
using System.IO;
using LibreMonitor;

namespace BtwMetrics{
    class MakeTextfileMetrics
    {
        static void Main()
        {
            LibreMonitor.Monitor _monitor = new LibreMonitor.Monitor();
            while(true){
                File.WriteAllText("C:\\Program Files\\windows_exporter\\textfile_inputs\\cpu.prom",_monitor.Cpu());
                Thread.Sleep(5000);
            }
        }
    }
}