using Inetis;

namespace InetisTest
{
    [TestClass]
    public sealed class JourneyTests
    {
        [TestMethod]
        [DataRow(200, 1, "_", 18)]
        [DataRow(200, 200, "_", 3600)]
        [DataRow(200, 1060, "T_T__P__P__NNN__N_T", 41040)]
        [DataRow(200, 1071, "T_T__NNNN__T__T__P_T", 35298)]
        public void CalculateTotalTravelTimeTests(int maxSpeed, int totalDistance, string rawEvents, int expectedResult)
        {
            var journey = new Journey(maxSpeed, totalDistance, rawEvents);

            var result = journey.CalculateTotalTravelTime();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
