using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ToDolist
{
   public class xmlAktarOku
    {
        public void Serialize(string path, object obj)
        {
            System.Xml.Serialization.XmlSerializer serialize = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            XmlWriter write = XmlWriter.Create(path);
            serialize.Serialize(write, obj);
            write.Close();
            write.Dispose();
        }

        public object Deserialize(string path , Type type)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
            XmlReader read = XmlReader.Create(path);
            object obj = serializer.Deserialize(read);

            read.Close();
            read.Dispose();

            return obj;

        }


        public void Serialize<T>(string path, T obj)
        {
            System.Xml.Serialization.XmlSerializer serialize =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            XmlWriter writer = XmlWriter.Create(path);

            serialize.Serialize(writer, obj);

            writer.Close();
            writer.Dispose();
        }

        public T Deserialize<T>(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            XmlReader reader = XmlReader.Create(path);

            object obj = serializer.Deserialize(reader);

            reader.Close();
            reader.Dispose();

            return (T)obj;
        }

    }
}
