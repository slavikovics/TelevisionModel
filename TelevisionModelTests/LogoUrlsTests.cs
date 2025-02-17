using TelevisionModel;

namespace TelevisionModelTests
{
    [TestClass]
    public sealed class LogoUrlsTests
    {
        [TestMethod]
        public void JsonParsingTest()
        {
            Television television = new Television(new SoundSystem(12), new Screen(1920, 1080, "IPS", 120, 50));
            television.FindChannels();
        }
    }
}
