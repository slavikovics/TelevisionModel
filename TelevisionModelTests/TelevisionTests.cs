using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using TelevisionModel;
using TelevisionModel.Devices;
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

        if (remoteControl.EditVolumeButtonPushed == null) Assert.Fail();
        remoteControl.EditVolumeButtonPushed(55);
        Assert.AreEqual(television.Specifications.CurrentVolume, 0);

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
        
        if (remoteControl.PowerSwitchButtonPushed == null) Assert.Fail();
        remoteControl.PowerSwitchButtonPushed();
        Assert.AreEqual(television.Specifications.State, States.MainMenu);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "1.0");
        
        if (remoteControl.EditVolumeButtonPushed == null) Assert.Fail();
        remoteControl.EditVolumeButtonPushed(55);
        Assert.AreEqual(television.Specifications.CurrentVolume, 55);

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
        
        if (remoteControl.PowerSwitchButtonPushed == null) Assert.Fail();
        remoteControl.PowerSwitchButtonPushed();
        
        if (remoteControl.TelevisionBroadcastingButtonPushed == null) Assert.Fail();
        remoteControl.TelevisionBroadcastingButtonPushed();
        Assert.AreEqual(television.Specifications.State, States.TelevisionBroadcasting);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "0.0");
        
        if (remoteControl.EditVolumeButtonPushed == null) Assert.Fail();
        remoteControl.EditVolumeButtonPushed(55);
        Assert.AreEqual(television.Specifications.CurrentVolume, 55);

        int selectedChannel = television.Specifications.SelectedChannelIndex;
        if (remoteControl.NextChannelButtonPushed == null) Assert.Fail();
        remoteControl.NextChannelButtonPushed();
        Assert.AreEqual(selectedChannel + 1, television.Specifications.SelectedChannelIndex);
        
        if (remoteControl.PreviousChannelButtonPushed == null) Assert.Fail();
        remoteControl.PreviousChannelButtonPushed();
        Assert.AreEqual(selectedChannel, television.Specifications.SelectedChannelIndex);
    }

    [TestMethod]
    public void TelevisionStreamingTest()
    {
        Television television = BuildTelevision();
        
        RemoteControl remoteControl = new RemoteControl(television);
        Assert.AreEqual(television.Specifications.State, States.TurnedOff);
        
        if (remoteControl.PowerSwitchButtonPushed == null) Assert.Fail();
        remoteControl.PowerSwitchButtonPushed();
        
        if (remoteControl.StreamingButtonPushed == null) Assert.Fail();
        remoteControl.StreamingButtonPushed();
        Assert.AreEqual(television.Specifications.State, States.Streaming);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "0.0");
        
        if (remoteControl.EditVolumeButtonPushed == null) Assert.Fail();
        remoteControl.EditVolumeButtonPushed(55);
        Assert.AreEqual(television.Specifications.CurrentVolume, 55);
        
        if (remoteControl.NextChannelButtonPushed == null) Assert.Fail();
        int selectedStreaming = television.Specifications.SelectedChannelIndex;
        remoteControl.NextChannelButtonPushed();
        
        Assert.AreEqual(selectedStreaming + 1, television.Specifications.SelectedTelevisionSeriesIndex);
        if (remoteControl.PreviousChannelButtonPushed == null) Assert.Fail();
        remoteControl.PreviousChannelButtonPushed();
        Assert.AreEqual(selectedStreaming, television.Specifications.SelectedTelevisionSeriesIndex);
    }

    [TestMethod]
    public void ExternalDevicesScreencastTests()
    {
        Television television = BuildTelevision();

        Device device = new Device("PS4");
        
        RemoteControl remoteControl = new RemoteControl(television);
        Assert.AreEqual(television.Specifications.State, States.TurnedOff);
        
        if (remoteControl.PowerSwitchButtonPushed == null) Assert.Fail();
        remoteControl.PowerSwitchButtonPushed();
        if (remoteControl.ExternalDeviceScreencastButtonPushed == null) Assert.Fail();
        remoteControl.ExternalDeviceScreencastButtonPushed(device);
        Assert.AreEqual(television.Specifications.State, States.ExternalDeviceScreencast);
        
        if (remoteControl.EditVolumeButtonPushed == null) Assert.Fail();
        remoteControl.EditVolumeButtonPushed(55);
        Assert.AreEqual(television.Specifications.CurrentVolume, 55);

        remoteControl.UpdateSoftware("1.0");
        Assert.AreEqual(television.Specifications.SoftwareVersion, "0.0");
    }

    private Television BuildTelevision()
    {
        SoundSystem soundSystem = new SoundSystem(10);
        Screen screen = new Screen(2560, 1440, "ips", 
            80, 120);
        return new Television(soundSystem, screen);
    }
}