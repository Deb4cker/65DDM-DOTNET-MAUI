using MauiAppXml.Commons;
using MauiAppXml.Entities;
using MauiAppXml.Repositories.Interface;
using SQLite;

namespace MauiAppXml.Repositories;

public class UserRepository : IRepository<int, User>
{

    private SQLiteConnection _connection;

    public UserRepository() { }

    public int Add(User value)
    {
        Init();
        return _connection.Insert(value);
    }

    public int Delete(int key)
    {
        Init();
        return _connection.Delete(key);
    }

    public List<User> GetAll()
    {
        Init();
        return _connection.Table<User>().ToList();
    }

    public User GetById(int key)
    {
        Init();
        return _connection.Find<User>(key);
    }

    public List<User> Query(string query, params object[] args)
    {
        Init();

        var result = _connection.Query<User>(query, args);

        return result;

    }

    private void Init()
    {
        if (_connection is not null) return;

        string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constants.DbFilePath);
        System.IO.Directory.CreateDirectory(applicationFolderPath);

        string databaseFileName = Path.Combine(applicationFolderPath, Constants.DbFile);
        
        _connection = new SQLiteConnection(databaseFileName);
        _connection.CreateTable<User>();
    }
}
