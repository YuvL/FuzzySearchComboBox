using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Xstream.Core;

namespace DemoApplication.DemoData
{
    public class InvalidXmlConverter : IConverter
    {
        private static readonly Type __type = typeof(string);

        public void Register(IMarshalContext context)
        {
            context.RegisterConverter(__type, this);
        }

        public void ToXml(object value, FieldInfo field, XmlTextWriter xml, IMarshalContext context)
        {
            var removedString = value.ToString().Replace("\b", "").Replace("\0", "");

            context.WriteStartTag(__type, field, xml);
            xml.WriteString(removedString);
            context.WriteEndTag(__type, field, xml);
        }

        public object FromXml(object parent, FieldInfo field, Type type, XmlNode xml, IMarshalContext context)
        {
            return xml.InnerText;
        }
    }
}
