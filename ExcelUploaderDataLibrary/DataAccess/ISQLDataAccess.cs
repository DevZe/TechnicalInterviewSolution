namespace ExcelUploaderDataLibrary.DataAccess;

public interface ISQLDataAccess
{
    List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
    int SaveData<T>(string storedProcedure, T parameters, string connectionStringName);

}