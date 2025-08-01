
using Azure.Communication;
using Azure.Communication.CallAutomation;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

public class CallService
{
    private readonly CallAutomationClient _callAutomationClient;
    private readonly PhoneNumberIdentifier _sourceNumber;
    private readonly Uri _speechEndpoint;

    public CallService(IConfiguration configuration)
    {
        var connectionString = configuration["ACS:ConnectionString"];
        _callAutomationClient = new CallAutomationClient(connectionString);

        _sourceNumber = new PhoneNumberIdentifier("+18332449646");
        _speechEndpoint = new Uri(configuration["ACS:SpeechEndpoint"]);
    }
    public async Task MakeCallAsync(string targetPhoneNumber)
    {
        var invite = new CallInvite(
            new PhoneNumberIdentifier(targetPhoneNumber), _sourceNumber
        );

        var callbackUri = new Uri("https://ophiaapi-fdc7dvfhfahqhdhq.centralus-01.azurewebsites.net/api/call/control");

       
        var result = await _callAutomationClient.CreateCallAsync(invite, callbackUri);
    }
}
