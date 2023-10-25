namespace ValdoBase.Configuration
{
    public interface IValdoBaseConfiguration
    {
        string GetConnectionString(string name);
    }
}