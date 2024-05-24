using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using System.Xml.XPath;
using HidSharp.Reports.Encodings;
using LibreHardwareMonitor.Hardware;

namespace  LibreMonitor
{
    public class UpdateVisitor : IVisitor
    {   
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }

    public class Monitor
    {
        public string Cpu()
        {
            string _metric = "";
            const string _metric_type = "# TYPE ohm_cpu_celsius gauge\n";
            const string _metric_help = "# HELP ohm_cpu_celsius CPU Package Temperature by LibreHardwareMonitorLib\n";

            Computer computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = false,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = false,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false,
            };

            computer.Open();
            computer.Accept(new UpdateVisitor());
            var CpuName="";
            foreach (IHardware hardware in computer.Hardware)
            {
                CpuName=hardware.Name;
        
                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    Console.WriteLine("\tSubhardware: {0}", subhardware.Name);
            
                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        Console.WriteLine("\t\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                    
                    }
                }
            
            foreach (ISensor sensor in hardware.Sensors)
            {
                if (sensor.Name == "CPU Package"){
                    _metric = "ohm_cpu_celsius{{hardware=\""+CpuName+"\",sensor=\"CPU Package\"}} " + sensor.Value  +"\n";
                    break;
                }
            }
        }   
            computer.Close();
        
        return (_metric_type +_metric_help + _metric);
    }
}
}