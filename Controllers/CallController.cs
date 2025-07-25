using Azure.Messaging;
using Azure.Communication.CallAutomation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using System.IO;

namespace VoiceCallApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        private readonly CallAutomationClient _callAutomationClient;
        private readonly CallService _callService;

        public CallController(CallAutomationClient callAutomationClient, CallService callService)
        {
            _callAutomationClient = callAutomationClient;
            _callService = callService;
        }

        [HttpPost("makecall")]
        public async Task<IActionResult> MakeCall([FromBody] string targetPhoneNumber)
        {
            await _callService.MakeCallAsync(targetPhoneNumber);
            return Ok("call initiated");
        }


        [HttpPost("control")]
        public async Task<IActionResult> ControlCall()
        {
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();

            var cloudEvents = CloudEvent.ParseMany(BinaryData.FromString(body));

            var events = CallAutomationEventParser.ParseMany(cloudEvents);

            foreach (var callEvent in events)
            {
                if (callEvent is CallConnected connected)
                {
                    var callConnection = _callAutomationClient.GetCallConnection(connected.CallConnectionId);

                    var playSource = new TextSource("hello handsome")
                    {
                        VoiceName = "en-US-AriaNeural"
                    };


                    await callConnection.GetCallMedia().PlayToAllAsync(playSource);

                    var recordOptions = new StartRecordingOptions(new ServerCallLocator(connected.ServerCallId))
                    {
                        RecordingChannel = RecordingChannel.Mixed,
                        RecordingContent = RecordingContent.Audio,
                        RecordingFormat = RecordingFormat.Wav
                    };

                    await _callAutomationClient.GetCallRecording().StartAsync(recordOptions);
                }
            }


            return Ok();

        }
    }
}