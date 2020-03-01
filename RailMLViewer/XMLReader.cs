using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RailMLViewer
{
    class XMLReader
    {
		static public T DeSerializeObject<T>(string fileName, out string errorText)
		{
			errorText = "";

			if (string.IsNullOrEmpty(fileName)) { return default(T); }

			T objectOut = default(T);

			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(fileName);
				string xmlString = xmlDocument.OuterXml;

				using (StringReader read = new StringReader(xmlString))
				{
					Type outType = typeof(T);

					XmlSerializer serializer = new XmlSerializer(outType);
					using (XmlReader reader = new XmlTextReader(read))
					{
						objectOut = (T)serializer.Deserialize(reader);
						reader.Close();
					}

					read.Close();
				}
			}
			catch (Exception ex)
			{
				errorText = ex.ToString();
			}
			return objectOut;
		}
	}
}
