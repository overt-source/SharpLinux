using System;
using System.Speech.Synthesis;

namespace cmdlinux
{
class SpeechBox
{
static void Main(string[] args)
{

// Initialize a new instance of the SpeechSynthesizer.
Console.WriteLine("**********");
Console.WriteLine("SpeechBox version 0.1-leilu-SharpLinux 2017-06-21");
Console.WriteLine("**********");
Console.WriteLine("\r\n\r\n\r\nType text to have it read by the synthesizer.");
Console.WriteLine("type .quit to exit.");
input:
Console.Write("\r\n\r\n\r\n\r\n(SpeechBox)");
string text=Console.ReadLine();
using (SpeechSynthesizer synth = new SpeechSynthesizer())
{

// Configure the audio output. 
synth.SetOutputToDefaultAudioDevice();

// Speak a string synchronously.
synth.Speak(text);
goto input;
}
}
}
}