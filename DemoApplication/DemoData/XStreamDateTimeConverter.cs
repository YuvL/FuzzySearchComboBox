using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Xstream.Core;

namespace DemoApplication.DemoData
{
    internal class XStreamDateTimeConverter : IConverter
    {
        private static readonly Type __type = typeof(DateTime);

        /// <summary>
        /// Register is called by a MarshalContext to allow the
        /// converter instance to register itself in the context
        /// with all appropriate value types and interfaces.
        /// </summary>
        public void Register(IMarshalContext context)
        {
            context.RegisterConverter(__type, this);
            context.Alias("datetime", __type);
        }

        /// <summary>
        /// Converts the object passed in to its XML representation.
        /// The XML string is written on the XmlTextWriter.
        /// </summary>
        public void ToXml(object value, FieldInfo field, XmlTextWriter xml, IMarshalContext context)
        {
            context.WriteStartTag(__type, field, xml);

            string dateTimeWithColon = ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss.fff");
            xml.WriteString(dateTimeWithColon);

            //string dateTimeWithColon = ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
            //System.Text.RegularExpressions.Regex
            //    regexTimeZone
            //        = new System.Text.RegularExpressions.Regex(@"\+(\d{2}):(\d{2})",
            //        System.Text.RegularExpressions.RegexOptions.Compiled |
            //        System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //string res = regexTimeZone.Replace(dateTimeWithColon, @"+$1$2");
            //xml.WriteString(res);

            context.WriteEndTag(__type, field, xml);
        }

        /// <summary>
        /// Converts the XmlNode data passed in back to an actual
        /// .NET instance object.
        /// </summary>
        /// <returns>Object created from the XML.</returns>
        public object FromXml(object parent, FieldInfo field, Type type, XmlNode xml, IMarshalContext context)
        {
            return DateTime.Parse(xml.InnerText);
        }
    }
}
