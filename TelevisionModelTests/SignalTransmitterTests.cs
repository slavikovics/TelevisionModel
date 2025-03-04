using TelevisionModel;
using TelevisionModel.Content;

namespace TelevisionModelTests
{
    [TestClass]
    public sealed class SignalTransmitterTests
    {
        [TestMethod]
        public void FindingSeriesTest()
        {
            List<TelevisionSeries> tvSeries = SignalTransmitter.FindSeries();
            foreach (TelevisionSeries series  in tvSeries)
            {
                if (series.ImageUrl == "") Assert.Fail();
                if (series.Name == "") Assert.Fail();
                if (series.Summary == "") Assert.Fail();
                if (series.Url == "") Assert.Fail();
            }
        }
    }
}
