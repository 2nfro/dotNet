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
using AndroidOs = Android.OS;

namespace Nfro.App.Android.Providers.Cached {
	public abstract class ICacheProvider {

        protected enum Storage{
            FILES, CACHE
        }

        protected String FILES_DIR{ get { return Application.Context.FilesDir.AbsolutePath; } }
        protected String CACHE_DIR{ get { return Application.Context.CacheDir.AbsolutePath; } }

        private void Save(String directory, String fileName, Object data){
            StreamWriter stream = null;
            try{
                String path = Path.Combine (directory, fileName);
                stream = new StreamWriter(path);
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
                stream = new StreamReader(path);
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

        protected bool IsDataPersisted(String fileName, Storage storageType){
            switch(storageType){
                case Storage.CACHE:
                    return File.Exists(Path.Combine(CACHE_DIR, fileName));
                default:
                    return File.Exists(Path.Combine(FILES_DIR, fileName));
            }
        }

		protected void SaveInCahce(String fileName, Object data){
            Save(CACHE_DIR, fileName, data);
		}

		protected void Save(String fileName, Object data){
            Save(FILES_DIR, fileName, data);
		}

		protected void SaveEncrypted(String fileName, Object data){
			throw new NotImplementedException();
		}

		protected Object ReadFromCache(String fileName){
            return Read(CACHE_DIR, fileName);
		}

		protected Object Read(String fileName){
            return Read(FILES_DIR, fileName);
		}

		protected Object ReadEncrypted(String fileName){
			throw new NotImplementedException();
		}
	}
}