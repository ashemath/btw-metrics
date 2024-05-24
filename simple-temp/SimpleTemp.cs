using System.Threading.Tasks.Dataflow;
using HidSharp.Reports.Encodings;
using LibreHardwareMonitor.Hardware;

namespace  SimpleTemp
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

    public class Simple
    {
        public void Monitor()
        {
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

            foreach (IHardware hardware in computer.Hardware)
            {
                //Console.WriteLine("Hardware: {0}", hardware.Name);
        
                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    //Console.WriteLine("\tSubhardware: {0}", subhardware.Name);
            
                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        //Console.WriteLine("\t\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                    
                    }
                }

            foreach (ISensor sensor in hardware.Sensors)
            {
                if (sensor.Name == "CPU Package" && sensor.Value > 20){
                    Console.WriteLine(sensor.Value);
                }
            }
        }   
            computer.Close();
    }
}
}