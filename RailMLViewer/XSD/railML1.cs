using System;
using System.Collections.Generic;
using System.Text;

namespace RailMLViewer.XSD
{
    //[System.Xml.Serialization.XmlRoot("railML")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://www.railml.org/schemas/3.2", IsNullable = false)]
    public partial class railML
    {
        [System.Xml.Serialization.XmlElement("infrastructure")]
        public Schemas.Infrastructure infra;
    }
}
