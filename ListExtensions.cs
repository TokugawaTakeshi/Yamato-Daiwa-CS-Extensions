namespace YamatoDaiwaCS_Extensions;


public static class ListExtensions
{

  public static List<TElement> AddElementsToEnd<TElement> (
    this List<TElement> self,
    params TElement[] newElements
  ) {

    foreach (TElement element in newElements)
    {
      self.Add(element);   
    }

    return self;

  }
  
  
  public static List<TElement> AddElementToEndIf<TElement>(
    this List<TElement> self,
    TElement newElement,
    bool condition
  )
  {

    if (condition)
    {
      self.Add(newElement);
    }

    return self;

  }
  
  public static List<TElement> AddElementToEndIf<TElement>(
    this List<TElement> self,
    TElement newElement,
    Func<TElement?, bool> condition
  )
  {

    if (condition(newElement))
    {
      self.Add(newElement);
    }

    return self;

  }
  

  public static string StringifyEachElementAndJoin<TElement>(
    this List<TElement> self,
    string separator
  )
  {
    return String.Join(separator, self);
  }


  public static List<TElement> ReplaceArrayElementsByPredicate<TElement>(
    this List<TElement> self,
    Func<TElement, bool> predicate,
    TElement newElement,
    bool mustReplaceOnlyFirstOne
  )
  {
      
    foreach ((TElement element, int index) in self.Select((element, index) => (element, index)))
    {

      if (!predicate(element))
      {
        continue;
      }
      
      
      self[index] = newElement;
          
      if (mustReplaceOnlyFirstOne) {
        return self;
      }
      
    }
      
    return self;
      
  }

  public static List<TElement> ReplaceArrayElementsByPredicate<TElement>(
    this List<TElement> self,
    Func<TElement, bool> predicate,
    Func<TElement, TElement> replacer,
    bool mustReplaceOnlyFirstOne
  )
  {
      
    foreach ((TElement element, int index) in self.Select((element, index) => (element, index)))
    {
      if (!predicate(element))
      {
        continue;
      }
      
      
      self[index] = replacer(element);
          
      if (mustReplaceOnlyFirstOne) {
        return self;
      }
      
    }
      
    return self;
      
  }
  
}