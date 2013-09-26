using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using PetaPoco;

namespace Test {
    [TestFixture]
    public class DatabaseTests {

        private String connection;
        private PetaPoco.Database db;
        private readonly String deltaFolder = "..\\..\\..\\Core\\Models\\Deltas\\";

        [TestFixtureSetUp]
        public void Init() {
            connection = ConfigurationManager.ConnectionStrings["master"].ConnectionString;
            db = new PetaPoco.Database("default");
            RunDatabaseScripts();
        }

        [Test]
        public void TablesShouldExist() {
            AssertTableExists("tbUser");
            AssertTableExists("tbToken");
            AssertTableExists("tbUserCode");
        }

        private void AssertTableExists(String tableName) {
            Boolean exists = db.ExecuteScalar<Boolean>(String.Format(@"IF EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                AND  TABLE_NAME = '{0}')
                    SELECT 1
                ELSE
                    SELECT 0", tableName));
           Assert.True(exists, String.Format("Table {0} does not exist.", tableName));
        }

        private void RunDatabaseScripts() {
            String[] files = Directory.GetFiles(deltaFolder);
            int deltaCount = files.Length;
            String[] sortedDeltas = new String[deltaCount];
            Console.Out.WriteLine("Processing Deltas...");
            foreach(String file in files) { 
                int deltaIndex;
                if(!int.TryParse(Path.GetFileNameWithoutExtension(file), out deltaIndex)) {
                    Assert.Fail(String.Format("Could not parse delta file {0}", Path.GetFileName(file)));
                }

                if(deltaIndex >= deltaCount) {
                    Assert.Fail(String.Format("Cannot skip delta numbers. Delta file {0} is not a valid delta nummber.", Path.GetFileName(file)));
                }
                sortedDeltas[deltaIndex] = file;
            }
            for(int index = 0; index < deltaCount; index++) {
                if(sortedDeltas[index] == null) {
                    Assert.Fail(String.Format("Missing delta {0}. Cannot skip delta numbers.", index));
                }
                SqlConnection sqlConnection = null;
                try {
                    sqlConnection = new SqlConnection(connection);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(File.ReadAllText(sortedDeltas[index]), sqlConnection);
                    command.ExecuteNonQuery();
                }
                catch(Exception e) {
                    Assert.Fail(String.Format("Failed to run Delta {0}: {1}", Path.GetFileName(sortedDeltas[index]), e.Message));
                }
                finally {
                    if(sqlConnection != null) {
                        sqlConnection.Close();
                    }
                }
                Console.Out.WriteLine("Processed Delta {0}", Path.GetFileName(sortedDeltas[index]));
            }
            Console.Out.WriteLine("Proceessed all Deltas");
        }
    }
}
