using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Media;
using System.Globalization;
using System.Windows.Forms;

namespace Nadhemni
{
    class SpeechRec
    {
        // create the SpeechSynthesizer.
        private SpeechSynthesizer synthesizer;

        //create the speech recognizer.
        private SpeechRecognitionEngine SeRec;
        public SpeechRec()
        {
            // Initialize the SpeechSynthesizer.
            synthesizer = new SpeechSynthesizer();
            //Initialize the speech recognizer.
            SeRec = new SpeechRecognitionEngine();

        }
        public SpeechSynthesizer GetSynthesizer()
        {
            return synthesizer;
        }
        public SpeechRecognitionEngine GetRecognitionEngine()
        {
            return SeRec;
        }
        public void createRec()
        {
            try
            {

                //Create a Speech Recognition Grammar
                Choices choice = new Choices();
                String[] stringsChoice = new string[] { "family", "health", "job", "pets", "beauty", "event"
            , "bank", "bills"};
                choice.Add(stringsChoice);
                // Create a GrammarBuilder object and append the Choices object.
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(choice);
                //Create the Grammar instance
                Grammar grammar = new Grammar(gBuilder);
                //Load the Grammar into the Speech Recognizer
                SeRec.LoadGrammarAsync(grammar);
                SeRec.SetInputToDefaultAudioDevice();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void speak(String speak,String FileName)
        {
            try
            {
                // Configure the audio output.
                synthesizer.SetOutputToDefaultAudioDevice();
                //change speech language to English 
                synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("en-US"));//("fr-fr") for frensh
                synthesizer.SetOutputToWaveFile(@"D:\"+ FileName);
                //Create a SoundPlayer instance to play the output audio file.
                SoundPlayer sp = new SoundPlayer(@"D:\"+ FileName);
                // Speak a string and play back the output file.
                synthesizer.Speak(speak);
                sp.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void desable()
        {
            SeRec.RecognizeAsyncStop();
        }
        public void enable()
        {
            try
            {
                SeRec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        


    }
}
