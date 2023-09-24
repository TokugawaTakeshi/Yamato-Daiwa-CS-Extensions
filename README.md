# Yamato Daiwa CS(harp) extensions

## Extensions of `DateOnly` class

* `DateOnly CreateDateOnlyFromISO8601_String(string ISO8601_String)`
* `string ToISO8601_String()`


## Extensions of `DateTime` class

* `DateOnly CreateDateOnlyFromISO8601_String(string ISO8601_String)`
* `string ToISO8601_String()`


## Extensions of `List` class

* `List<TElement> AddElementsToEnd<TElement> (params TElement[] newElements) `
* `AddElementToEndIf`
  * `List<TElement> AddElementToEndIf<TElement>(TElement newElement, bool condition)`
  * `List<TElement> AddElementToEndIf<TElement>(TElement newElement, Func<TElement?, bool> condition)`
* `StringifyEachElementAndJoin<TElement>(string separator)` 
* `ReplaceArrayElementsByPredicate`
  * `List<TElement> ReplaceArrayElementsByPredicate<TElement>(Func<TElement, bool> predicate, TElement newElement, bool mustReplaceOnlyFirstOne)`
  * `List<TElement> ReplaceArrayElementsByPredicate<TElement>(Func<TElement, bool> predicate, Func<TElement, TElement> replacer, bool mustReplaceOnlyFirstOne)`


## Extensions of `String` class

* `bool IsNonEmpty()`
* `string ToUpperCamelCase()`
* `string ToLowerCamelCase()`
* `string RemoveAllSpecifiedCharacters(char[] charactersToRemove)`
