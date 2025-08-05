using System.IO;
using System.Xml.Serialization;

namespace LibrarySimpleGraphCalculator
{
    public class DataManager : IDataManager
    {
     
        public StoreData Load(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StoreData));

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    StoreData data = (StoreData)serializer.Deserialize(fileStream);

                    return data;
                }
            }
            else
            {
                return null;
            }
        }

        public DataErrorCode Save(string filePath, StoreData storeData)
        {
            if (!string.IsNullOrEmpty(filePath) && storeData != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StoreData));

                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, storeData);
                }
            }
            if (string.IsNullOrEmpty(filePath))
            {
                return DataErrorCode.filePathNotFound;
            }
            if(storeData == null)
            {
                return DataErrorCode.dataParamIsNull;
            }
            return DataErrorCode.ok;
        }
    }
}
