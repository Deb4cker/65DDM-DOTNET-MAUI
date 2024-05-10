namespace MauiAppXml.Repositories.Interface;

public interface IRepository<TKey, TValue>
{
    TKey Add(TValue value);

    TKey Delete(TKey key);

    List<TValue> GetAll();

    TValue GetById(TKey key);

    List<TValue> Query(string query, params object[] args);
}
