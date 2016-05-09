using System.Linq;
using CloudMaker.Filters;

namespace CloudMaker
{
    class Program
    {
        static void Main(string[] argv)
        {
            CommandLineArguments parsedArgs;
            CommandLineArguments.TryGetArguments(argv, out parsedArgs);
            var uiSettings = parsedArgs.Ui();
            var inputText = new Filter().ReadAndFilterInputData(
                parsedArgs.ReaderFunc,
                uiSettings.Filters.Select(filterName=>Provider.FilterTypes[filterName]).ToList(),
                uiSettings.Filename);
            var cloud = new CloudMaker.CloudMaker().CreateCloud(inputText, uiSettings.MinFontSize,
                uiSettings.MaxFontSize, Provider.Packers[uiSettings.PackerAlg]);
            parsedArgs.WriterFunc(cloud, uiSettings.Colors);
        }
    }
}
