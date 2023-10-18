using System;

// Subsystem components
class AudioPlayer
{
    public void TurnOn() => Console.WriteLine("Audio Player: Turned on");
    public void PlayAudio(string audio) => Console.WriteLine($"Audio Player: Playing '{audio}'");
    public void TurnOff() => Console.WriteLine("Audio Player: Turned off");
}

class VideoPlayer
{
    public void TurnOn() => Console.WriteLine("Video Player: Turned on");
    public void PlayVideo(string video) => Console.WriteLine($"Video Player: Playing '{video}'");
    public void TurnOff() => Console.WriteLine("Video Player: Turned off");
}

class Projector
{
    public void TurnOn() => Console.WriteLine("Projector: Turned on");
    public void Project(string source) => Console.WriteLine($"Projector: Projecting '{source}'");
    public void TurnOff() => Console.WriteLine("Projector: Turned off");
}

// Facade class
class MultimediaFacade
{
    private AudioPlayer audioPlayer;
    private VideoPlayer videoPlayer;
    private Projector projector;

    public MultimediaFacade()
    {
        audioPlayer = new AudioPlayer();
        videoPlayer = new VideoPlayer();
        projector = new Projector();
    }

    public void StartMovie(string audio, string video)
    {
        Console.WriteLine("Starting movie...");

        audioPlayer.TurnOn();
        audioPlayer.PlayAudio(audio);

        videoPlayer.TurnOn();
        videoPlayer.PlayVideo(video);

        projector.TurnOn();
        projector.Project(video);
    }

    public void EndMovie()
    {
        Console.WriteLine("Ending movie...");

        audioPlayer.TurnOff();
        videoPlayer.TurnOff();
        projector.TurnOff();
    }
}

class Program
{
    static void Main()
    {
        MultimediaFacade multimediaFacade = new MultimediaFacade();

        multimediaFacade.StartMovie("Movie Audio", "Movie Video");
        Console.WriteLine("--------------------");
        multimediaFacade.EndMovie();
    }
}
