namespace MerchantGuideToGalaxy.Test
{
    using MerchantGuideToGalaxy.Core;
    using Xunit;

    public class TestGalactic
    {
        [Fact]
        public void TestCommandsWithoutMetal()
        {
            var result = Galactic.ToAsk("how much is pish tegj glob glob ?");
            Assert.Equal("pish tegj glob glob is 42", result);
        }

        [Fact]
        public void TestCommandsWithMetal()
        {
            var result = Galactic.ToAsk("how many Credits is glob prok Silver ?");
            Assert.Equal("glob prok Silver is 68 Credits", result);
        }

        [Fact]
        public void TestNoCommands()
        {
            var result = Galactic.ToAsk("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            Assert.Equal("I have no idea what you are talking about", result);
        }

        [Fact]
        public void NoAsk()
        {
            var result = Galactic.ToAsk("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            Assert.Equal("I have no idea what you are talking about", result);
        }
    }
}
