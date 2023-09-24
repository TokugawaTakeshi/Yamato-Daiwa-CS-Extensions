﻿namespace YamatoDaiwaCS_Extensions;


public static class StringExtensions
{

  public static bool IsNonEmpty(this string self)
  {
    return !String.IsNullOrEmpty(self);
  }

  public static string ToUpperCamelCase(this string self)
  {
    return self.Insert(0, char.ToUpperInvariant(self[0]).ToString()).Remove(1, 1);
  }

  public static string ToLowerCamelCase(this string self)
  {
    return self.Insert(0, char.ToLowerInvariant(self[0]).ToString()).Remove(1, 1);
  }
  
  public static string RemoveAllSpecifiedCharacters(this string self, char[] charactersToRemove)
  {

    string interimResult = self;

    foreach (char characterToRemove in charactersToRemove)
    {
      interimResult = interimResult.Replace(characterToRemove.ToString(), String.Empty);
    }

    return interimResult;
    
  }
  
}