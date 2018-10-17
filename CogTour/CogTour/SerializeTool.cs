using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Windows;

namespace CogTour
{
    class SerializeTool
    {
        public static void BinarySerialize(Object obj, Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Close();

        }

        public static Object BinaryDeserializer(Stream stream)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Object obj = formatter.Deserialize(stream);
                return obj;
            }catch(Exception e)
            {
                MessageBox.Show("Exception found: " + e.Message);
                return null;
            }
            
        }
    }
}
