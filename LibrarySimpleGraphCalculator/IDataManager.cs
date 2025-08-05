
namespace LibrarySimpleGraphCalculator
{
    public interface IDataManager
    { 
        DataErrorCode Save(string filePath, StoreData storeData);

        StoreData Load(string filePath);
    }
}
