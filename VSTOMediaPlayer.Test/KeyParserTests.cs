using Castle.Components.DictionaryAdapter;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using VSTOMediaPlayer.Word.Configuration;

namespace VSTOMediaPlayer.Test
{
    public class KeyParserTests
    {
        [TestCase("E", Key.E)]
        [TestCase("OemPlus", Key.OemPlus)]
        [TestCase("Oem1", Key.Oem1)]
        public void Parse_Single_Key(string input, Key expected)            
        {
            (Key key, ModifierKeys mod) actual = KeyParser.Parse(input);

            Assert.That(expected, Is.EqualTo(actual.key));
        }

        [Test]
        public void Parse_Exception_On_Invalid_Argument()
        {
            string expectedMsg = "Requested value 'Bad input' was not found.";
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo(expectedMsg), () => KeyParser.Parse("Bad input"));
        }

        [TestCase("Ctrl+E", ModifierKeys.Control, Key.E)]
        public void Parse_Key_Combination(string input, ModifierKeys expectedMod, Key expectedKey)
        {
            (Key key, ModifierKeys mod) actual = KeyParser.Parse(input);

            Assert.That(expectedMod, Is.EqualTo(actual.mod));
            Assert.That(expectedKey, Is.EqualTo(actual.key));
        }
    }
}
