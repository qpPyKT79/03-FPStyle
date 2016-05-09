using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.CloudMaker;
using CloudMaker.Filters;

namespace CloudMaker
{
    class Program
    {
        static void Main(string[] argv)
        {
            var parsedArgs = new CommandLineArguments();
            CommandLineArguments.TryGetArguments(argv, out parsedArgs);
            var uiSettings = parsedArgs.UI();
            var inputText = new Filter().ReadAndFilterInputData(
                parsedArgs.ReaderFunc,
                uiSettings.Filters.Select(filterName=>Provider.FilterTypes[filterName]).ToList(),
                uiSettings.Filename);
            var cloud = new CloudMaker.CloudMaker().CreateCloud(inputText, uiSettings.MinFontSize, uiSettings.MaxFontSize,Provider.Packers[uiSettings.PackerAlg]);
            parsedArgs.WriterFunc(cloud, uiSettings.Colors);
        }
    }
}
