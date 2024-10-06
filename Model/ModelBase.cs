namespace Kutubxona.Model;

public abstract class ModelBase
{
    private static int identyficator = 0;
    protected internal int Id { get; set; }
    protected ModelBase()
    {
        
    }

    protected void SetId()
    {
        Id++;
    }
    protected int GetId()
    {
        return identyficator++;
    }
}