using System;
using Xunit;
using ArbitesEto2;

namespace ArbitesEto2.Tests
{
    public class XmlSerializeTests
    {
        [Fact]
        public void ShouldReturnNewObjectsOnNullStrings()
        {
            var config = MdCore.Deserialize<MdConfig>(null);
            Assert.NotNull(config);
        }

        [Fact]
        public void ShouldReturnNewObjectsOnEmptyStrings()
        {
            var config = MdCore.Deserialize<MdConfig>("");
            Assert.NotNull(config);
        }
    }
}
