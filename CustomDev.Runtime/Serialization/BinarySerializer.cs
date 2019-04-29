using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomDev.Runtime.Serialization
{
    public static class BinarySerializer
    {
        /// <summary>
        /// Serializes an object to a byte array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public static byte[] SerializeToBinary<T>(this T objectToSerialize)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objectToSerialize);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a byte array into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataToDeserialize"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] dataToDeserialize)
        {
            using (MemoryStream stream = new MemoryStream(dataToDeserialize))
            {
                return Deserialize<T>(stream);
            }
        }

        /// <summary>
        /// Deserializes a stream into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataToDeserialize"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream streamToDeserialize)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object o = formatter.Deserialize(streamToDeserialize);
            return (T)o;
        }
    }
}
