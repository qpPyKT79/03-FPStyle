using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUI;
using Fclp;

namespace CloudMaker
{
    public class CommandLineArguments
    {
        private string InputType { get; set; }
        private string UIType { get; set; }
        private string ImageFormat { get; set; }

        public Func<string, List<string>> ReaderFunc { get; private set; }
        public Func<UiSettings> UI { get; private set; }
        public Action<List<CloudTag>, Color[]> WriterFunc { get; private set; }

        public static bool TryGetArguments(string[] args, out CommandLineArguments parsedArguments)
        {
            var argumentsParser = new FluentCommandLineParser<CommandLineArguments>();
            argumentsParser.Setup(a => a.InputType)
                .As('t', "InputType")
                .Required();

            argumentsParser.Setup(a => a.UIType)
                .As('u', "UIType")
                .Required();
            argumentsParser.Setup(a => a.ImageFormat)
                .As('i', "ImageFormat")
                .Required();

            argumentsParser.SetupHelp("?", "h", "help")
                .Callback(text => Console.WriteLine(text));

            var parsingResult = argumentsParser.Parse(args);

            if (parsingResult.HasErrors)
            {
                //argumentsParser.HelpOption.ShowHelp(argumentsParser.Options);
                parsedArguments = new CommandLineArguments()
                {
                    ReaderFunc = Provider.FileReader["file"],
                    UI = Provider.UiType["CUI"],
                    WriterFunc = Provider.WriterType["png"]
                };
                return false;
            }

            parsedArguments = argumentsParser.Object;
            parsedArguments.ReaderFunc = Provider.FileReader[parsedArguments.InputType];
            parsedArguments.UI = Provider.UiType[parsedArguments.UIType];
            parsedArguments.WriterFunc = Provider.WriterType[parsedArguments.ImageFormat];

            return !parsingResult.HasErrors;
        }
    }
}
