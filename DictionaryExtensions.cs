namespace YamatoDaiwa.CSharpExtensions;


public static class Dictionary
{
  
  /* ━━━ SetPairIfValueNotIsNull ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static Dictionary<TKey, TValue> SetPairIfValueNotIsNull<TKey, TValue>(
    this Dictionary<TKey, TValue> self,
    TKey key,
    TValue? value
  ) where TKey : notnull
  {
    
    if (value is not null)
    {
      self[key] = value;
    }
    
    return self;
    
  }
  
  
  /* ━━━ SetPairIf ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static Dictionary<TKey, TValue> SetPairIf<TKey, TValue>(
    this Dictionary<TKey, TValue> self,
    TKey key,
    TValue value,
    bool condition
  ) where TKey : notnull
  {

    if (condition)
    {
      self[key] = value;
    }

    return self;

  }
  
  public static Dictionary<TKey, TValue> SetPairIf<TKey, TValue>(
    this Dictionary<TKey, TValue> self,
    TKey key,
    TValue value,
    Func<TKey, TValue, bool> condition
  ) where TKey : notnull
  {

    if (condition(key, value))
    {
      self[key] = value;
    }

    return self;

  }
  
}