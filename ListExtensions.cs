namespace YamatoDaiwa.CSharpExtensions;


public static class ListExtensions
{

  /* ━━━ AddElementsToStart ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static List<TElement> AddElementsToStart<TElement> (
    this List<TElement> self,
    params TElement[] newElements
  )
  {
    
    foreach (TElement element in newElements)
    {
      self.Insert(0, element);   
    }
    
    return self;
    
  }
  
  
  /* ━━━ AddElementsToEnd ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static List<TElement> AddElementsToEnd<TElement> (
    this List<TElement> self,
    params TElement[] newElements
  )
  {
    self.AddRange(newElements);
    return self;
  }
  
  
  /* ━━━ AddElementToEndIfNotNull ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static List<TElement?> AddElementToEndIfNotNull<TElement>(
    this List<TElement?> self,
    TElement? newElement
  )
  {
    
    if (newElement is not null)
    {
      self.Add(newElement);
    }
    
    return self;
    
  }
  
  
  /* ━━━ AddElementToEndIf ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
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
  

  /* ━━━ StringifyEachElementAndJoin ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static string StringifyEachElementAndJoin<TElement>(
    this List<TElement> self,
    string separator
  )
  {
    return String.Join(separator, self);
  }


  /* ━━━ ReplaceArrayElementsByPredicate ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
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
  
  
  /* ━━━ LogEachElement ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static List<TElement> LogEachElement<TElement>(
    this List<TElement> self,
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