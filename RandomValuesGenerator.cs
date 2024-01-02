﻿namespace YamatoDaiwa.CSharpExtensions;


public abstract class RandomValuesGenerator
{

  public static bool GetRandomBoolean()
  {
    return new Random().Next() > (Int32.MaxValue / 2);
  }

  public static byte GetRandomByte(byte minimalValue = Byte.MinValue, byte maximalValue = Byte.MaxValue)
  {
    return Convert.ToByte(new Random().Next(minValue: minimalValue, maxValue: maximalValue));
  }

  public static ushort GetRandomUShort(ushort minimalValue = ushort.MinValue, ushort maximalValue = ushort.MaxValue)
  {
    return Convert.ToUInt16(new Random().Next(minValue: minimalValue, maxValue: maximalValue));
  }
  
  public static TArrayElement GetRandomArrayElement<TArrayElement>(TArrayElement[] targetArray)
  {
    if (targetArray == null || targetArray.Length == 0)
    {
      throw new ArgumentException("Array must not be null or empty.");
    }
    
    return targetArray[new Random().Next(0, targetArray.Length)];
    
  }
  
  public static DateOnly GetRandomDate(DateOnly earliestDate, DateOnly latestDate)
  {
    
    DateTime earliestDateTime = earliestDate.ToDateTime(new TimeOnly(0, 0, 0));
    DateTime latestDateTime = latestDate.ToDateTime(new TimeOnly(23, 59, 59));

    TimeSpan randomTimeSpan = TimeSpan.FromTicks((long)(new Random().NextDouble() * (latestDateTime - earliestDateTime).Ticks));

    DateTime randomDateTime = earliestDateTime + randomTimeSpan;
    return DateOnly.FromDateTime(randomDateTime.Date);
    
  }
  
  public static DateTime GetRandomDateTime(DateOnly earliestDate, DateOnly latestDate)
  {
    
    DateTime earliestDateTime = earliestDate.ToDateTime(new TimeOnly(0, 0, 0));
    DateTime latestDateTime = latestDate.ToDateTime(new TimeOnly(23, 59, 59));

    TimeSpan randomTimeSpan = TimeSpan.FromTicks((long)(new Random().NextDouble() * (latestDateTime - earliestDateTime).Ticks));

    DateTime randomDateTime = earliestDateTime + randomTimeSpan;
    
    return randomDateTime;
    
  }
  
}