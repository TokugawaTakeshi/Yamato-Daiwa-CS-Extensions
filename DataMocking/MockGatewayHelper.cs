using System.Text.Json;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace YamatoDaiwa.CSharpExtensions.DataMocking;


public abstract class MockGatewayHelper
{

  protected const ushort MINIMAL_PENDING_PERIOD__SECONDS = 1;
  protected const ushort MAXIMAL_PENDING_PERIOD__SECONDS = 2;

  
  public struct SimulationOptions
  {
    public ushort? MinimalPendingPeriod__Seconds { get; init; }
    public ushort? MaximalPendingPeriod__Seconds { get; init; }
    public bool? MustSimulateError { get; init; }
    public bool MustLogResponseData { get; init; }
    public required string GatewayName { get; init; }
    public required string TransactionName { get; init; }
  }

  
  /* ━━━ Logging ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public delegate void Log(string message);

  protected static Log? log;

  public static void SetLogger(Log? log)
  {
    MockGatewayHelper.log += log;
  }
  

  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public interface ILocalization
  {

    public abstract class ErrorSimulationCompletedLog
    {
      public struct TemplateVariables
      {
        public required string GatewayName { get; init; }
        public required string TransactionName { get; init; }
      }
    }
    
    public Func<ErrorSimulationCompletedLog.TemplateVariables, string> GenerateErrorSimulationCompletedLog { get; }


    public abstract class DataRetrievingSimulationCompletedLog
    {
      public struct TemplateVariables
      {
        public required string GatewayName { get; init; }
        public required string TransactionName { get; init; }
        public string? FormattedRequestParameters { get; init; }
        public string? FormattedResponseData { get; init; }
      }
    }
    
    public Func<DataRetrievingSimulationCompletedLog.TemplateVariables, string> GenerateDataRetrievingSimulationCompletedLog { get; }
    
    
    public abstract class DataSubmittingSimulationCompletedLog
    {
      public struct TemplateVariables
      {
        public required string GatewayName { get; init; }
        public required string TransactionName { get; init; }
        public string? FormattedRequestData { get; init; }
        public string? FormattedResponseData { get; init; }
      }
    }
    
    public Func<DataSubmittingSimulationCompletedLog.TemplateVariables, string> GenerateDataSubmittingSimulationCompletedLog { get; }
    
  }

  public static ILocalization Localization = new MockGatewayHelperEnglishLocalization();


  /* ━━━ Public methods ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static async Task<TResponseData> SimulateDataRetrieving<TRequestParameters, TResponseData>(
    TRequestParameters requestParameters,
    Func<TResponseData> getResponseData,
    SimulationOptions options
  )
  {

    await Task.Delay(new Random(DateTime.Now.Millisecond).Next(
      minValue: (int)TimeSpan.
          FromSeconds(options.MinimalPendingPeriod__Seconds ?? MockGatewayHelper.MINIMAL_PENDING_PERIOD__SECONDS).
          TotalMilliseconds,
      maxValue: (int)TimeSpan.
          FromSeconds(options.MaximalPendingPeriod__Seconds ?? MockGatewayHelper.MAXIMAL_PENDING_PERIOD__SECONDS).
          TotalMilliseconds
    ));

    if (options.MustSimulateError == true)
    {
      throw new DataRetrievingFailedException(
        Localization.GenerateErrorSimulationCompletedLog(
          new ILocalization.ErrorSimulationCompletedLog.TemplateVariables
          {
            GatewayName = options.GatewayName,
            TransactionName = options.TransactionName
          }  
        )
      );
    }


    TResponseData responseData = getResponseData();

    MockGatewayHelper.log?.Invoke(
      MockGatewayHelper.Localization.GenerateDataRetrievingSimulationCompletedLog(
        new ILocalization.DataRetrievingSimulationCompletedLog.TemplateVariables
        {
          GatewayName = options.GatewayName,
          TransactionName = options.TransactionName,
          FormattedRequestParameters = System.Text.Json.JsonSerializer.Serialize(
            requestParameters, new JsonSerializerOptions { WriteIndented = true}
          ),
          FormattedResponseData = options.MustLogResponseData ? 
              System.Text.Json.JsonSerializer.Serialize(
                responseData, new JsonSerializerOptions { WriteIndented = true}
              ) :
              null
        }
      )
    );

    return responseData;
    
  }

  public static async Task<TResponseData> SimulateDataSubmitting<TRequestData, TResponseData>(
    TRequestData requestData,
    Func<TResponseData> getResponseData,
    SimulationOptions options
  )
  {

    await Task.Delay(new Random(DateTime.Now.Millisecond).Next(
      minValue: (int)TimeSpan.
          FromSeconds(options.MinimalPendingPeriod__Seconds ?? MockGatewayHelper.MINIMAL_PENDING_PERIOD__SECONDS).
          TotalMilliseconds,
      maxValue: (int)TimeSpan.
          FromSeconds(options.MaximalPendingPeriod__Seconds ?? MockGatewayHelper.MAXIMAL_PENDING_PERIOD__SECONDS).
          TotalMilliseconds
    ));

    if (options.MustSimulateError == true)
    {
      throw new DataSubmittingFailedException(
        Localization.GenerateErrorSimulationCompletedLog(
          new ILocalization.ErrorSimulationCompletedLog.TemplateVariables
          {
            GatewayName = options.GatewayName,
            TransactionName = options.TransactionName
          }  
        )
      );
    }


    TResponseData responseData = getResponseData();

    MockGatewayHelper.log?.Invoke(
      Localization.GenerateDataSubmittingSimulationCompletedLog(
        new ILocalization.DataSubmittingSimulationCompletedLog.TemplateVariables()
        {
          GatewayName = options.GatewayName,
          TransactionName = options.TransactionName,
          FormattedRequestData = System.Text.Json.JsonSerializer.Serialize(
            requestData, new JsonSerializerOptions { WriteIndented = true}
          ),
          FormattedResponseData = options.MustLogResponseData ?
              System.Text.Json.JsonSerializer.Serialize(
                responseData, new JsonSerializerOptions { WriteIndented = true}
              ) :
              null
        }  
      )
    );

    return responseData;
    
  }
  
}
