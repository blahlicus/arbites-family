using System;
using Xunit;
using ArbitesEto2;
using System.Linq;

namespace ArbitesEto2.Tests
{
    public class DeserializeTests
    {
        // config.arb2cfg
        static readonly string XmlConfiguration = string.Concat(new string[] {
            @"<?xml version=""1.0"" encoding=""utf-8""?>",
            @"<MdConfig xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">",
            @"  <ConfigVersion>2</ConfigVersion>",
            @"  <KeyMenuTopmost>false</KeyMenuTopmost>",
            @"  <DisplayOutput>true</DisplayOutput>",
            @"  <UploadDelay>20</UploadDelay>",
            @"  <CurrentInputMethod>US-ANSI.arb2im</CurrentInputMethod>",
            @"</MdConfig>"
        });

        static readonly string JsonConfiguration = @"{
        	""ConfigVersion"":3,
			""KeyMenuTopmost"":false,
			""DisplayOutput"":true,
			""UploadDelay"":20,
			""CurrentInputMethod"":""US-ANSI.arb2im""
		}";

        // keygroup/Core.arb2kg
        static readonly string XmlKeyGroup = string.Concat(new string[] {
            @"<?xml version=""1.0"" encoding=""utf-8""?>",
            @"<ClKeyGroup xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">",
            @"  <Keys>",
            @"    <ClKey>",
            @"      <DisplayID>0</DisplayID>",
            @"      <ValASCII>0</ValASCII>",
            @"      <ValScan>0</ValScan>",
            @"      <KeyType>0</KeyType>",
            @"      <AllLayers>false</AllLayers>",
            @"      <HasASCII>false</HasASCII>",
            @"    </ClKey>",
            @"  </Keys>",
            @"</ClKeyGroup>"
        });

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

        [Fact]
        public void ShouldHandleNewJsonConfiguration()
        {
            var config = MdCore.Deserialize<MdConfig>(JsonConfiguration);

            Assert.NotNull(config);
            Assert.Equal(3, config.ConfigVersion);
            Assert.False(config.KeyMenuTopmost);
            Assert.True(config.DisplayOutput);
            Assert.Equal(20, config.UploadDelay);
            Assert.Equal("US-ANSI.arb2im", config.CurrentInputMethod);
        }

        [Fact]
        public void ShouldHandleOldXmlKeyGroup()
        {
            var config = MdCore.Deserialize<KeyGroup>(XmlKeyGroup);
            Assert.NotNull(config);
            Assert.Single(config.Keys);
        }
    }
}
