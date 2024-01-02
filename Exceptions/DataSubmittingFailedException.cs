namespace YamatoDaiwa.CSharpExtensions.Exceptions;


public class DataSubmittingFailedException: Exception
{

  public DataSubmittingFailedException(string message) : base(message) {}
  
  public DataSubmittingFailedException(string message, Exception innerException) : base(message, innerException) {}
    
}