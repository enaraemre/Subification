using SQLite;
using SUBIFICATION.Entities;

namespace SUBIFICATION.Data;

public class SubificationDatabase
{
    SQLiteAsyncConnection Database;
    public SubificationDatabase()
    {
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Subscriptions>();
    }

    public async Task<List<Subscriptions>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<Subscriptions>().ToListAsync();
    }



    public async Task<Subscriptions> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<Subscriptions>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Subscriptions item)
    {
        await Init();
        if (item.ID != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(Subscriptions item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}