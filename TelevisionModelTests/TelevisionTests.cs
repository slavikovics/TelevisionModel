using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using TelevisionModel;
using TelevisionModel.TelevisionSubsystems;
using TelevisionModel.Utils;

namespace TelevisionModelTests;

[TestClass]
public class TelevisionTests
{
    [TestMethod]
    public void TelevisionLoadingTests()
    {
        Television television = BuildTelevision();
        
        Assert.AreEqual(television.Specifications.ResolutionX, 2560);
        Assert.AreEqual(television.Specifications.ResolutionY, 1440);
    }

    [TestMethod]
    public void TurnedOffStateTests()
    {
        Television television = BuildTelevision();
        
        RemoteControl remoteControl = new RemoteControl(television);
        Assert.AreEqual(television.Specifications.State, States.TurnedOff);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "0.0");

        remoteControl.ChangeResolution(1920, 1080);
        
        Assert.AreEqual(television.Specifications.ResolutionX, 2560);
        Assert.AreEqual(television.Specifications.ResolutionY, 1440);
    }

    [TestMethod]
    public void MainMenuTest()
    {
        Television television = BuildTelevision();
        
        RemoteControl remoteControl = new RemoteControl(television);
        Assert.AreEqual(television.Specifications.State, States.TurnedOff);
        
        remoteControl.PowerSwitchButtonPushed();
        Assert.AreEqual(television.Specifications.State, States.MainMenu);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "1.0");

        remoteControl.ChangeResolution(1920, 1080);
        
        Assert.AreEqual(television.Specifications.ResolutionX, 1920);
        Assert.AreEqual(television.Specifications.ResolutionY, 1080);
    }
    
    [TestMethod]
    public void TelevisionBroadcastingTest()
    {
        Television television = BuildTelevision();
        
        RemoteControl remoteControl = new RemoteControl(television);
        Assert.AreEqual(television.Specifications.State, States.TurnedOff);
        
        remoteControl.PowerSwitchButtonPushed();
        remoteControl.TelevisionBroadcastingButtonPushed();
        Assert.AreEqual(television.Specifications.State, States.TelevisionBroadcasting);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "0.0");

        int selectedChannel = television.Specifications.SelectedChannelIndex;
        remoteControl.NextChannelButtonPushed();
        Assert.AreEqual(selectedChannel + 1, television.Specifications.SelectedChannelIndex);
        remoteControl.PreviousChannelButtonPushed();
        Assert.AreEqual(selectedChannel, television.Specifications.SelectedChannelIndex);
    }

    private Television BuildTelevision()
    {
        SoundSystem soundSystem = new SoundSystem(10);
        Screen screen = new Screen(2560, 1440, "ips", 
            80, 120);
        return new Television(soundSystem, screen);
    }
}