
using Azure.Communication;
using Azure.Communication.CallAutomation;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

public class CallService
{
    private readonly CallAutomationClient _callAutomationClient;
    private readonly PhoneNumberIdentifier _sourceNumber;

    public CallService(IConfiguration configuration)
    {
        var connectionString = configuration["ACS:ConnectionString"];
        _callAutomationClient = new CallAutomationClient(connectionString);

        _sourceNumber = new PhoneNumberIdentifier("+18332449646");
    }
    public async Task MakeCallAsync(string targetPhoneNumber)
    {
        var invite = new CallInvite(
            new PhoneNumberIdentifier(targetPhoneNumber), _sourceNumber
        );

        var callbackUri = new Uri("https://yourdomain.com/api/call/control");
        var result = await _callAutomationClient.CreateCallAsync(invite, callbackUri);
    }
}
