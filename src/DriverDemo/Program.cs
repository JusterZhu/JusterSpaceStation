using GeneralUpdate.Core.Driver;

namespace DriverDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var driverInformation = new DriverInformation.Builder()
                .SetDriverNames(null)
                .SetDriverNames(null)
                .SetOutPutDirectory(null)
                .Build();

            var driverProcessor = new DriverProcessor();
            driverProcessor.AddCommand(new BackupDriverCommand(driverInformation));
            driverProcessor.ProcessCommands();
        }
    }
}
