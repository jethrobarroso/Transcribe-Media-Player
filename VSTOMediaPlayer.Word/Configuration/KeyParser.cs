using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VSTOMediaPlayer.Word.Configuration
{
    public static class KeyParser
    {
        public static (Key, ModifierKeys) StringToKey(string keyValue)
        {
            (Key key, ModifierKeys mod) result = (0, 0);

            var items = keyValue.Split('+');

            if (items.Length > 1 && items.Length < 5)
            {
                for (int i = 0; i < items.Length - 1; i++)
                {
                    _ = Enum.TryParse(items[i], out result.mod) ? true : throw new ArgumentException(
                        $"Cannot convert \"{items[i]}\" to a valid ModifierKeys value.");
                }
            }

            if (Regex.IsMatch(items.Last(), @"^\d$"))
                items[items.Length - 1] = "D" + items.Last();

            _ = Enum.TryParse(items.Last(), out result.key) ? true : throw new ArgumentException(
                $"Cannot convert \"{items.Last()}\" to a valid Key value.");
            return result;
        }

        public static string KeyToString(Key key, ModifierKeys modifier = ModifierKeys.None)
        {
            string result = string.Empty;

            if (modifier != ModifierKeys.None)
                result = modifier.ToString() + "+";

            if (Regex.IsMatch(key.ToString(), @"^D\d$"))
                result += key.ToString().Remove(0, 1);
            else
                result += key.ToString();

            return result;
        }
    }
}
