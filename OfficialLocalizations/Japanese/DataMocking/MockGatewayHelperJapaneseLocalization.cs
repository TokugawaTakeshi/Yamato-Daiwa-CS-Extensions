using YamatoDaiwa.CSharpExtensions.DataMocking;


namespace YamatoDaiwa.CSharpExtensions.OfficialLocalizations.Japanese.DataMocking;


public struct MockGatewayHelperJapaneseLocalization: MockGatewayHelper.ILocalization
{

  public Func<MockGatewayHelper.ILocalization.ErrorSimulationCompletedLog.TemplateVariables, string>
      GenerateErrorSimulationCompletedLog =>
          (MockGatewayHelper.ILocalization.ErrorSimulationCompletedLog.TemplateVariables templateVariables) =>
              $"取り引き「{ templateVariables.GatewayName }.{ templateVariables.TransactionName }」にとって「mustSimulateError」" +
                $"フラグは「真」に指定してあるので、「MockGatewayHelper」クラスはエラーを再現した。";
  
  public Func<MockGatewayHelper.ILocalization.DataRetrievingSimulationCompletedLog.TemplateVariables, string> 
      GenerateDataRetrievingSimulationCompletedLog =>
          (MockGatewayHelper.ILocalization.DataRetrievingSimulationCompletedLog.TemplateVariables templateVariables) =>
              $"クラス「MockGatewayHelper」は取り引き「${ templateVariables.GatewayName }.${ templateVariables.TransactionName }」" + 
                "にとってデータの仮取得を完了した。\n" +
              ( 
                templateVariables.FormattedRequestParameters is not null ? 
                    $"\n\n◇　リクエストパラメーター：\n{ templateVariables.FormattedRequestParameters }" : "" 
              ) +
              ( 
                 templateVariables.FormattedResponseData is not null ? 
                     $"\n\n◇　リスポンスデータ：\n{ templateVariables.FormattedResponseData }" : "" 
              );

  public Func<MockGatewayHelper.ILocalization.DataSubmittingSimulationCompletedLog.TemplateVariables, string> 
      GenerateDataSubmittingSimulationCompletedLog =>
          (MockGatewayHelper.ILocalization.DataSubmittingSimulationCompletedLog.TemplateVariables templateParameters) =>
              $"クラス「MockGatewayHelper」は取り引き「${ templateParameters.GatewayName }.${ templateParameters.TransactionName }」" +
                "にとってデータの仮送信完了した。\n" +
                ( 
                  templateParameters.FormattedRequestData is not null ? 
                      $"\n\n◇　リクエストデータ：\n{ templateParameters.FormattedRequestData }" : "" 
                ) +
                ( 
                  templateParameters.FormattedResponseData is not null ? 
                    $"\n\n◇　リスポンスデータ：\n{ templateParameters.FormattedResponseData }" : "" 
                );
  
}