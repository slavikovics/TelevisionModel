using TelevisionModel;
using TelevisionModel.Utils;

namespace TelevisionModelConsole;

static class Program
{
    static void Main(string[] args)
    {
        Television television = Saver.TryLoadFromFile();
        RemoteControl remoteControl = new RemoteControl(television);
        CommandLineInterface commandLineInterface = new CommandLineInterface(remoteControl);
        commandLineInterface.UserInteraction();
    }
}