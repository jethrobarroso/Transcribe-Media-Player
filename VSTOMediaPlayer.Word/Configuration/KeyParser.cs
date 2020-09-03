using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VSTOMediaPlayer.Word.Configuration
{
    public static class KeyParser
    {
        public static (Key, ModifierKeys) Parse(string keyValue)
        {
            (Key key, ModifierKeys mod) result = (0, 0);

            var items = keyValue.Split('+');

            result.key = (Key)Enum.Parse(typeof(Key), items[1]);

            return result;
        }
    }
}
