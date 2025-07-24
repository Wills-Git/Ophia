namespace VoiceCallApi.Models
{
    public class CallControllResponse
    {
        public PlayPrompt? PlayPrompt { get; set; }
        public RecordOptions? Record { get; set; }
    }

    public class PlayPrompt
    {
        public TextToSpeech? TextToSpeech { get; set; }

    }

    public class TextToSpeech
    {
        public string? Text { get; set; }
        public string? VoiceGender { get; set; }
        public string? VoiceName { get; set; }
    }

    public class RecordOptions
    {
        public int MaxDurationSeconds { get; set; }
        public string[]? StopTones { get; set; }
        public bool PlayBeep { get; set; }
        public string? RecordingFormat { get; set; }
        
    }
}