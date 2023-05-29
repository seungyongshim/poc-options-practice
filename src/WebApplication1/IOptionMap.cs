namespace WebApplication1
{
    public interface IOptionMap<T> where T : class
    {
        T GetValue(string key);
    }
}