using SQLite;


namespace SUBIFICATION.Entities;

[Table ("Subscriptions")]
public class Subscriptions
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime RenewDate { get; set; }
    public string Note { get; set; }

}
