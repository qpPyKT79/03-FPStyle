using System;
using System.Collections.Generic;
using System.Drawing;
using CUI;
using Fclp;

namespace CloudMaker
{
    public class CommandLineArguments
    {
        private string InputType { get; set; }
        private string UiType { get; set; }
        private string ImageFormat { get; set; }

        public Func<string, List<string>> ReaderFunc { get; private set; }
        public Func<UiSettings> Ui { get; private set; }
        public Action<List<CloudTag>, IEnumerable<Color>> WriterFunc { get; private set; }

        public static bool TryGetArguments(string[] args, out CommandLineArguments parsedArguments)
        {
            var argumentsParser = new FluentCommandLineParser<CommandLineArguments>();
            argumentsParser.Setup(a => a.InputType)
                .As('i', "InputType")
                .Required();

            argumentsParser.Setup(a => a.UiType)
                .As('u', "UIType")
                .Required();
            argumentsParser.Setup(a => a.ImageFormat)
                .As('f', "ImageFormat")
                .Required();

            argumentsParser.SetupHelp("?", "h", "help")
                .Callback(text => Console.WriteLine(text));

            var parsingResult = argumentsParser.Parse(args);

            if (parsingResult.HasErrors)
            {
                parsedArguments = DefaultSettings();
                return false;
            }

            parsedArguments = argumentsParser.Object;
            try
            {
                parsedArguments.ReaderFunc = Provider.FileReader[parsedArguments.InputType];
                parsedArguments.Ui = Provider.UiType[parsedArguments.UiType];
                parsedArguments.WriterFunc = Provider.WriterType[parsedArguments.ImageFormat];
            }
            catch (KeyNotFoundException msg)
            {
                parsedArguments = DefaultSettings();
            }
            return !parsingResult.HasErrors;
        }

        private static CommandLineArguments DefaultSettings()
            => new CommandLineArguments()
            {
                ReaderFunc = Provider.FileReader["file"],
                Ui = Provider.UiType["CUI"],
                WriterFunc = Provider.WriterType["png"]
            };
    }
}
