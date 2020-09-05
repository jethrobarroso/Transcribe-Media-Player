using Castle.Components.DictionaryAdapter;
using MahApps.Metro.IconPacks;
using Newtonsoft.Json.Linq;
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
        public void StringToKey_SingleKeyString_KeyWithoutModifier(string input, Key expected)            
        {
            (Key key, ModifierKeys mod) actual = KeyParser.StringToKey(input);

            Assert.That(expected, Is.EqualTo(actual.key));
        }

        [Test]
        public void StringToKey_InvalidSingleKey_ThrowsArgumentException()
        {
            string expectedMsg = $"Cannot convert \"Bad input\" to a valid Key value.";
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo(expectedMsg), () => KeyParser.StringToKey("Bad input"));
        }

        [Test]
        public void StringToKey_InvalidModifierKey_ThrowsArgumentException()
        {
            string expectedMsg = $"Cannot convert \"bad\" to a valid ModifierKeys value.";
            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo(expectedMsg), () => KeyParser.StringToKey("bad+value"));
        }

        [TestCase("Control+E", ModifierKeys.Control, Key.E)]
        [TestCase("Shift+Oem1", ModifierKeys.Shift, Key.Oem1)]
        [TestCase("Alt+F1", ModifierKeys.Alt, Key.F1)]
        [TestCase("Control+D1", ModifierKeys.Control, Key.D1)]
        public void StringToKey_Key_Combination(string input, ModifierKeys expectedMod, Key expectedKey)
        {
            (Key key, ModifierKeys mod) actual = KeyParser.StringToKey(input);

            Assert.That(expectedMod, Is.EqualTo(actual.mod));
            Assert.That(expectedKey, Is.EqualTo(actual.key));
        }

        [TestCase("1", Key.D1, ModifierKeys.None)]
        [TestCase("Shift+2", Key.D2, ModifierKeys.Shift)]
        [TestCase("Control+3", Key.D3, ModifierKeys.Control)]
        [TestCase("Alt+4", Key.D4, ModifierKeys.Alt)]
        public void StringToKey_NumberedKeys_ParseToLetterDPrefixKeyEnum(
            string input, Key expectedKey, ModifierKeys expectedModifier)
        {
            (Key key, ModifierKeys mod) actual = KeyParser.StringToKey(input);

            Assert.That(actual.key, Is.EqualTo(expectedKey));
            Assert.That(actual.mod, Is.EqualTo(expectedModifier));
        }

        [TestCase(Key.E, "E")]
        [TestCase(Key.Oem1, "Oem1")]
        [TestCase(Key.F1, "F1")]
        public void KeyToString_SingleKeyEnum_ReturnSingleString(Key inputKey, string expected)
        {
            var actual = KeyParser.KeyToString(inputKey);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(Key.E, ModifierKeys.Control, "Control+E")]
        [TestCase(Key.F1, ModifierKeys.Alt, "Alt+F1")]
        [TestCase(Key.OemPlus, ModifierKeys.Shift, "Shift+OemPlus")]
        public void KeyToString_KeyGesture_ReturnGestureString(Key inputKey, ModifierKeys inputModifier, string expected)
        {
            var actual = KeyParser.KeyToString(inputKey, inputModifier);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(Key.D1, ModifierKeys.None, "1")]
        [TestCase(Key.D2, ModifierKeys.Shift, "Shift+2")]
        [TestCase(Key.D3, ModifierKeys.Control, "Control+3")]
        [TestCase(Key.D4, ModifierKeys.Alt, "Alt+4")]
        public void KeyToString_DNumberedKey_RemovesLetterDPrefix(Key inputKey, ModifierKeys inputModifier, string expected)
        {
            var actual = KeyParser.KeyToString(inputKey, inputModifier);

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
