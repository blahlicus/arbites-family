using System;
using Xunit;
using ArbitesEto2;
using System.Linq;

namespace ArbitesEto2.Tests
{
    public class DeserializeTests
    {
        static readonly string XmlConfiguration = string.Concat(new string[] {
            @"<?xml version=""1.0"" encoding=""utf-8""?>",
            @"<MdConfig xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">",
            @"  <ConfigVersion>2</ConfigVersion>",
            @"  <KeyMenuTopmost>false</KeyMenuTopmost>",
            @"  <DisplayOutput>true</DisplayOutput>",
            @"  <UploadDelay>20</UploadDelay>",
            @"  <CurrentInputMethod>US-ANSI.arb2im</CurrentInputMethod>",
            @"</MdConfig>"});

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

        [Fact]
        public void ShouldHandleOldXmlConfigurations()
        {
            var config = MdCore.Deserialize<MdConfig>(XmlConfiguration);

            Assert.NotNull(config);
            Assert.Equal(2, config.ConfigVersion);
            Assert.False(config.KeyMenuTopmost);
            Assert.True(config.DisplayOutput);
            Assert.Equal(20, config.UploadDelay);
            Assert.Equal("US-ANSI.arb2im", config.CurrentInputMethod);
        }
    }
}
