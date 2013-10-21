using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RedGate.SIPFrameworkShared
{
    public static class SerializationUtils
    {
        public static string SerializeToTempFile(ObjectExplorerNodeDescriptorBase node)
        {
            node = GetObjectDescriptor(node);

            string tempFile = GetTempName();
            using (FileStream stream = new FileStream(tempFile, FileMode.CreateNew))
            {
                XmlSerializer xs = new XmlSerializer(node.GetType());
                xs.Serialize(stream, node);
                stream.Flush();
                stream.Close();
            }
            return tempFile;
        }

        private static ObjectExplorerNodeDescriptorBase GetObjectDescriptor(ObjectExplorerNodeDescriptorBase node)
        {
            IOeNode oeNode = node as IOeNode;
            if (oeNode == null)
                return node;
            return oeNode.GetLegacyObjectDescriptor();
        }

        private static string GetTempName()
        {
            while (true)
            {
                string path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                if (!File.Exists(path)) return path;
            }
        }

        public static ObjectExplorerNodeDescriptorBase DeserializeFromFile(string fullPath)
        {
            string xml;

            using (StreamReader stream = new StreamReader(fullPath))
            {
                xml = stream.ReadToEnd();
            }
            File.Delete(fullPath);

            List<Type> typeList = new List<Type>
                                      {
                                          typeof (ObjectExplorerColumnNodeDescriptor),
                                          typeof (ObjectExplorerParameterNodeDescriptor),
                                          typeof (ObjectExplorerObjectNodeDescriptor),
                                          typeof (ObjectExplorerFolderNodeDescriptor),
                                          typeof (ObjectExplorerDatabaseNodeDescriptor),
                                          typeof (ObjectExplorerNodeDescriptorWithConnection),
                                          typeof (ObjectExplorerNodeDescriptorBase)
                                      };

            foreach (Type type in typeList)
            {
                object obj = XmlDeserializationString(type, xml);
                if (obj != null) return (ObjectExplorerNodeDescriptorBase)obj;
            }

            return null;
        }

        private static object XmlDeserializationString(Type T, string xml)
        {
            object obj = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(T);
                using (StringReader stringReader = new StringReader(xml))
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(stringReader))
                    {
                        obj = ser.Deserialize(xmlReader);
                    }
                }
            }
            catch (Exception)
            {
            }
            return obj;
        }
    }
}