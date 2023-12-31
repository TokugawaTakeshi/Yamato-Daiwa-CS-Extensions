﻿namespace YamatoDaiwa.CSharpExtensions;


public static class DateTimeExtensions
{
  
  public static DateTime CreateDateTimeFromISO8601_String(string ISO8601_String) {
    return DateTime.Parse(ISO8601_String, null, System.Globalization.DateTimeStyles.RoundtripKind);
  }

  public static string ToISO8601_String(this DateTime self) {
    return self.ToString( "yyyy-MM-dd'T'HH:mm:ss'Z'");
  }

}