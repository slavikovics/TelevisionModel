using TelevisionModel;

namespace TelevisionModelConsole;

static class Program
{
    static void Main(string[] args)
    {
        SoundSystem soundSystem = new SoundSystem(24);
        Screen screen = new Screen(4096, 2160, "OLED", 56, 120);
        Television television = new Television(soundSystem, screen);
        RemoteControl remoteControl = new RemoteControl(television, "main_remote_control");
        CommandLineInterface commandLineInterface = new CommandLineInterface(remoteControl);
        commandLineInterface.UserInteraction();
    }
}