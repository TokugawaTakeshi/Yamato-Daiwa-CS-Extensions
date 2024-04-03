namespace YamatoDaiwa.CSharpExtensions;


public static class ArrayExtensions
{
  
  public static TElement[] LogEachElement<TElement>(
    this TElement[] self,
    Action<TElement>? logger = null
  )
  {

    ArgumentNullException.ThrowIfNull(self);

    logger ??= element => Console.WriteLine(element);

    foreach (TElement element in self)
    {
      logger(element);
    }

    return self;
    
  }
  
}