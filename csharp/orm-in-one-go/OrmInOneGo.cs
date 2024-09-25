using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        database.BeginTransaction();
        using (database)
        {
            database.Write(data);
            database.EndTransaction();
        }
    }

    public bool WriteSafely(string data)
    {
        database.BeginTransaction();
        using var db = database;
        try
        {
            db.Write(data);
            db.EndTransaction();
            return true;
        }
        catch
        {
            database.Dispose();
            return false;
        }
    }
}
