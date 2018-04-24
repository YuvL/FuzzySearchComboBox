using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xstream.Core;

namespace DemoApplication.DemoData
{
    public class XStreamFactory
    {
        private static XStream xStream = new XStream();

        static XStreamFactory()
        {
            xStream.AddConverter(new XStreamDateTimeConverter());
            xStream.AddConverter(new InvalidXmlConverter());

            //xStream.Alias<RnisGlonassIntegration>("RnisGlonassIntegration");
        }

        public static XStream XStream
        {
            get
            {
                return xStream;
            }
        }
    }
}
