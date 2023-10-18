using System;

// Subsystem components
class Amplifier
{
    public void TurnOn() => Console.WriteLine("Amplifier: Turned on");
    public void SetVolume(int level) => Console.WriteLine($"Amplifier: Volume set to {level}");
    public void TurnOff() => Console.WriteLine("Amplifier: Turned off");
}

class DVDPlayer
{
    public void TurnOn() => Console.WriteLine("DVD Player: Turned on");
    public void PlayMovie(string movie) => Console.WriteLine($"DVD Player: Playing '{movie}'");
    public void TurnOff() => Console.WriteLine("DVD Player: Turned off");
}

class TV
{
    public void TurnOn() => Console.WriteLine("TV: Turned on");
    public void SetInputChannel(string channel) => Console.WriteLine($"TV: Switched to channel '{channel}'");
    public void TurnOff() => Console.WriteLine("TV: Turned off");
}

// Facade class
class HomeTheaterFacade
{
    private Amplifier amplifier;
    private DVDPlayer dvdPlayer;
    private TV tv;

    public HomeTheaterFacade()
    {
        amplifier = new Amplifier();
        dvdPlayer = new DVDPlayer();
        tv = new TV();
    }

    public void WatchMovie(string movie, string channel)
    {
        Console.WriteLine("Getting ready to watch a movie...");

        amplifier.TurnOn();
        amplifier.SetVolume(7);

        dvdPlayer.TurnOn();
        dvdPlayer.PlayMovie(movie);

        tv.TurnOn();
        tv.SetInputChannel(channel);
    }

    public void EndMovie()
    {
        Console.WriteLine("Ending the movie...");

        amplifier.TurnOff();
        dvdPlayer.TurnOff();
        tv.TurnOff();
    }
}

class Program2
{
    static void Main2()
    {
        HomeTheaterFacade homeTheater = new HomeTheaterFacade();

        homeTheater.WatchMovie("Star Wars", "HDMI 1");
        Console.WriteLine("--------------------");
        homeTheater.EndMovie();
    }
}
