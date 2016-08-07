using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JpegRemover.Utils
{
    public class Enums
    {
        public enum RawFormats
        {
            [Description("Canon digital camera RAW image format")]
            Crw,
            [Description("Canon digital camera RAW image format version 2.0")]
            Cr2,
            [Description("Nikon Digital SLR camera RAW image")]
            Nef,
            [Description("Sony digital camera RAW image format")]
            Arw,
            [Description("Type in the name of the format you are looking for")]
            Other = 999
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}
