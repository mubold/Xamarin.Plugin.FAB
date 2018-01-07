using System;
using Xamarin.Forms;

namespace FAB.Forms
{
    public class ImageSourceConverter : TypeConverter
    {
        public override bool CanConvertFrom(Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFromInvariantString(string value)
        {
            if (value == null)
            {
                return null;
            }
            
            if (!Uri.TryCreate(value, UriKind.Absolute, out var result) || !(result.Scheme != "file"))
            {
                return ImageSource.FromFile(value);
            }
            return ImageSource.FromUri(result);
        }
    }
}

