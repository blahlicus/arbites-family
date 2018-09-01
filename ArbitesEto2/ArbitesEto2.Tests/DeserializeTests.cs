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

        // config.arb2cfg
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
            @"    </ClKey>",
            @"  </Keys>",
            @"</ClKeyGroup>"
        });

        // keyboard-type/diverge-tm-1-2.arb2kbt
        static readonly string XmlKeyboardType = string.Concat(new string[] {
            @"<?xml version=""1.0"" encoding=""utf-8""?>",
            @"<ClKeyboard xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">",
            @"  <Buttons>",
            @"    <ClButtonInfo>",
            @"    </ClButtonInfo>",            @"  </Buttons>",
            @"</ClKeyboard>"
        });

        // input-method/US-ANSI.arb2im
        static readonly string XmlInputMethod = string.Concat(new string[] {
            @"<?xml version=""1.0"" encoding=""utf-8""?>",
            @"<ClDisplayCharacterContainer xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">",
            @"  <Name>US-ANSI</Name>",
            @"</ClDisplayCharacterContainer>"
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
            var keyGroup = MdCore.Deserialize<KeyGroup>(XmlKeyGroup);
            Assert.NotNull(keyGroup);
            Assert.Single(keyGroup.Keys);
        }

        [Fact]
        public void ShouldHandleOldXmlKeyboardType()
        {
            var keyboard = MdCore.Deserialize<Keyboard>(XmlKeyboardType);
            Assert.NotNull(keyboard);
            Assert.Single(keyboard.Buttons);
        }

        [Fact]
        public void ShouldHandleOldXmlInputMethod()
        {
            var inputMethod = MdCore.Deserialize<DisplayCharacterContainer>(XmlInputMethod);
            Assert.NotNull(inputMethod);
            Assert.Equal("US-ANSI", inputMethod.Name);
        }
    }
}
