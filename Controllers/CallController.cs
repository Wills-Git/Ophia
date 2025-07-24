using Microsoft.AspNetCore.Mvc;
using VoiceCallApi.Models;

namespace VoiceCallApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        [HttpPost("control")]
        public IActionResult ControlCall()
        {
            var responsePayload = new CallControllResponse
            {
                PlayPrompt = new PlayPrompt
                {
                    TextToSpeech = new TextToSpeech
                    {
                        Text = "hello handsome",
                        VoiceGender = "Male",
                        VoiceName = "en-US-AriaNeural"
                    }
                },
                Record = new RecordOptions
                {
                    MaxDurationSeconds = 30,
                    StopTones = new[] { "#" },
                    PlayBeep = true,
                    RecordingFormat = "wav"
                }

            };

            return new JsonResult(responsePayload);

        }
    }
}