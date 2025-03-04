using System.Net.Security;
using System.Security.Cryptography;
using TelevisionModel;
using TelevisionModel.TelevisionSubsystems;

namespace TelevisionModelTests;

[TestClass]
public class RemoteControlTests
{
    [TestMethod]
    public void RemoteControlTest()
    {
        RemoteControl remoteControl = new RemoteControl(BuildTestTelevision());
        Assert.AreEqual(remoteControl.MainMenuButtonPushed, null);
    }

    public Television BuildTestTelevision()
    {
        SoundSystem soundSystem = new SoundSystem(12);
        Screen screen = new Screen(1920, 1080, "OLED", 120, 230);
        
        return new Television(soundSystem, screen);
    }
}