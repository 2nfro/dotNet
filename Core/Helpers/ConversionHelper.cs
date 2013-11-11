using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Nfro.Core.Helpers {
    public static class ConversionHelper {
        public static T ChangeTo<T>(this Object theObject) {
            MemoryStream stream = null;
            try{
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(theObject.GetType());
                stream = new MemoryStream();
                serializer.WriteObject(stream, theObject);

                stream.Position = 0;
                serializer = new DataContractJsonSerializer(typeof(T));
                Object newObject = serializer.ReadObject(stream);
                return (T)newObject;
            }
            catch(Exception e){

            }
            finally{
                if(stream != null){
                    stream.Close();
                }
            }
            /*MemoryStream stream = null;
            try{
                XmlSerializer serializer = new XmlSerializer(theObject.GetType());
                stream = new MemoryStream();
                serializer.Serialize(stream, theObject);

                stream.Position = 0;
                serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
            catch(Exception e){
                //TODO: Log e
            }
            finally{
                if(stream != null){
                    stream.Close();
                }
            }*/
            return default(T);
        }
    }
}
