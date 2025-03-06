using TelevisionModel;
using TelevisionModel.Data;
using TelevisionModel.Devices;

namespace TelevisionModelConsole;

public class CommandLineInterface
{
    private readonly RemoteControl _remoteControl;

    private string _options;
    
    private delegate void Command();

    private readonly Dictionary<string, Command> _commands = new Dictionary<string, Command>();

    public CommandLineInterface(RemoteControl remoteControl)
    {
        _options = string.Empty;
        _remoteControl = remoteControl;
        FillCommands();
        BuildOptions();
    }

    private void FillCommands()
    {
        _commands.Add("1", PressPowerSwitchButton);
        _commands.Add("2", PressNextButton);
        _commands.Add("3", PressPreviousButton);
        _commands.Add("4", EditVolume);
        _commands.Add("5", ChangeResolution);
        _commands.Add("6", UpdateSoftware);
        _commands.Add("7", MainMenu);
        _commands.Add("8", TelevisionBroadcast);
        _commands.Add("9", Streaming);
        _commands.Add("10", ScreencastFromExternalDevice);
    }
    
    private void BuildOptions()
    {
        _options += "1. Press power switch button\n";
        _options += "2. Press next button\n";
        _options += "3. Press previous button\n";
        _options += "4. Change volume\n";
        _options += "5. Change resolution\n";
        _options += "6. Update software\n";
        _options += "7. Main menu\n";
        _options += "8. Television broadcast\n";
        _options += "9. Streaming\n";
        _options += "10. Screencast from external device\n";
        _options += "11. save and exit\n";
    }

    public void UserInteraction()
    {
        while (true)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(_options);
            string? userInput = Console.ReadLine();
            Console.Clear();
            
            if (userInput == null) continue;

            if (_commands.ContainsKey(userInput))
            {
                _commands[userInput]();
            }
            else if (userInput == "11") return;
        }
    }

    private void PressPowerSwitchButton()
    {
        Console.WriteLine(_remoteControl.PowerSwitch());
    }

    private void PressNextButton()
    {
        Console.WriteLine(_remoteControl.NextChannel());
    }

    private void PressPreviousButton()
    {
        Console.WriteLine(_remoteControl.PreviousChannel());
    }

    private void EditVolume()
    {
        Console.WriteLine(ConsoleMessages.EditVolume);
        try
        {
            double newVolume = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(_remoteControl.EditVolume(newVolume));
        }
        catch (FormatException e)
        {
            Console.WriteLine(ConsoleMessages.WrongValueMessage);
        }
    }

    private void ChangeResolution()
    {
        Console.WriteLine(ConsoleMessages.ChangeResolution);
        try
        {
            int newResolutionX = Convert.ToInt32(Console.ReadLine());
            int newResolutionY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(_remoteControl.ChangeResolution(newResolutionX, newResolutionY));
        }
        catch (FormatException e)
        {
            Console.WriteLine(ConsoleMessages.WrongValueMessage);
        }
    }

    private void UpdateSoftware()
    {
        Console.WriteLine(ConsoleMessages.Software);
        string? newVersion = Console.ReadLine();
        if (newVersion != null) Console.WriteLine(_remoteControl.UpdateSoftware(newVersion));
        else Console.WriteLine(ConsoleMessages.WrongValueMessage);
    }

    private void MainMenu()
    {
        Console.WriteLine(_remoteControl.MainMenu());
    }

    private void TelevisionBroadcast()
    {
        Console.WriteLine(_remoteControl.TelevisionBroadcasting());
    }

    private void Streaming()
    {
        Console.WriteLine(_remoteControl.Streaming());
    }

    private void ScreencastFromExternalDevice()
    {
        Console.WriteLine(ConsoleMessages.ExternalDeviceName);
        string? externalDeviceName = Console.ReadLine();
        if (!string.IsNullOrEmpty(externalDeviceName))
        {
            Device device = new Device(externalDeviceName);
            Console.WriteLine(_remoteControl.ExternalDeviceScreencast(device));
        }
        else Console.WriteLine(ConsoleMessages.WrongValueMessage);
    }
}