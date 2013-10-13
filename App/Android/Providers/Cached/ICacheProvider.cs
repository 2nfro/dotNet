using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Java.Nio.Channels;
using Java.Net;
using Android.Webkit;

namespace Nfro.App.Android.Providers.Cached {
	public abstract class ICacheProvider : Application {

        protected enum Storage{
            FILES, CACHE
        }

        private void Save(String directory, String fileName, Object data){
            StreamWriter stream = null;
            try{
                String path = Path.Combine (directory, fileName);
                stream = new StreamWriter(OpenFileOutput(path, FileCreationMode.Private));
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream.BaseStream, data);
            }
            catch(Exception e){
                //TODO: Log Exception
            }
            finally{
                if(stream != null){
                    stream.Close();
                }
            }
        }

        private object Read(String directory, String fileName){
            StreamReader stream = null;
            try{
                String path = Path.Combine (directory, fileName);
                stream = new StreamReader(OpenFileInput (path));
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize (stream.BaseStream);
            }
            catch(Exception e){
                //TODO: Log Exception
                return null;
            }
            finally{
                if(stream != null){
                    stream.Close();
                }
            }
        }

        protected bool isDataPersisted(String fileName, Storage storageType){
            switch(storageType){
                case Storage.CACHE:
                    return File.Exists(Path.Combine(CacheDir.AbsolutePath, fileName));
                default:
                    return File.Exists(Path.Combine(FilesDir.AbsolutePath, fileName));
            }
        }

		protected void SaveInCahce(String fileName, Object data){
            Save(CacheDir.AbsolutePath, fileName, data);
		}

		protected void Save(String fileName, Object data){
            Save(FilesDir.AbsolutePath, fileName, data);
		}

		protected void SaveEncrypted(String fileName, Object data){
			throw new NotImplementedException();
		}

		protected Object ReadFromCache(String fileName){
            return Read(CacheDir.AbsolutePath, fileName);
		}

		protected Object Read(String fileName){
            return Read(FilesDir.AbsolutePath, fileName);
		}

		protected Object ReadEncrypted(String fileName){
			throw new NotImplementedException();
		}
	}
}