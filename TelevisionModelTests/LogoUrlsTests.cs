using TelevisionModel;

namespace TelevisionModelTests
{
    [TestClass]
    public sealed class LogoUrlsTests
    {
        [TestMethod]
        public void JsonParsingTest()
        {
            List<TelevisionChannel> channels = SignalTransmitter.FindChannels();
            foreach (var channel in channels)
            {
                if (channel.Name == "" || channel.LogoPath == "") Assert.Fail();
            }
        }
    }
}
