using Microsoft.Extensions.Options;

namespace WebApplication1;

public class OptionMap<T> 
    where T : class
{
    public OptionMap(IOptions<Dictionary<string, T>> option)
    {
        Option = option;
    }

    IOptions<Dictionary<string, T>> Option { get; }

    public T GetValue(AppName key) => Option.Value[Enum.GetName(key)];
}
