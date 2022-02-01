using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace VoiceInputEntry
{
    public partial class MainPage : ContentPage
    {
        public Command SpeakCommand { get; set; }
        public MainPage()
        {
            InitializeComponent();
            SpeakCommand = new Command(async () =>
            {
                var locales = await TextToSpeech.GetLocalesAsync();
                var settings = new SpeechOptions()
                {
                    Volume = 1f,
                    Pitch = 1f,
                    Locale = locales.FirstOrDefault(t => t.Language == "cs")
                };
                if (string.IsNullOrEmpty(TextEntry.Text) == false)
                await TextToSpeech.SpeakAsync(TextEntry.Text, settings);
            });
            BindingContext = this;
        }
    }
}
