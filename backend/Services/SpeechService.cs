// using Azure.Communication.CallAutomation;
// using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
// using Microsoft.CognitiveServices.Speech;
// using Microsoft.CognitiveServices.Speech.Audio;
// using System;
// using System.IO;
// using System.Threading.Tasks;

// public class SpeechService
// {
//     private readonly SpeechConfig _speechConfig;

//     public SpeechService(string subscriptionKey, string region)
//     {
//         _speechConfig = SpeechConfig.FromSubscription(subscriptionKey, region);
//         _speechConfig.SpeechSynthesisVoiceName = "en-US-AriaNeural";
//         _speechConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Raw16Khz16BitMonoPcm);
//     }


//     public async Task<byte[]> SythesizeSpeechAsync(string text)
//     {
//         using var synthesizer = new SpeechSynthesizer(_speechConfig, null);
//         using var result = await synthesizer.StartSpeakingTextAsync(text);

//         if (result.Reason == ResultReason.SynthesizingAudioCompleted)
//         {
//             using var audioStream = AudioDataStream.FromResult(result);
//             var filename = Path.GetTempFileName();
//             var wavFilePath = Path.ChangeExtension(filename, ".wav");
//             await audioStream.SaveToWaveFileAsync(wavFilePath);
//             var 
//         }
//         else
//         {
//             throw new Exception($"Speech synthesis failed: {result.Reason}");
//         }
//     }

// }