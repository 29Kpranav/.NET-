using System;

// Context (Audio Player)
class AudioPlayer
{
    private IAudioPlayerState _state;

    public AudioPlayer()
    {
        _state = new StoppedState();
    }

    public void SetState(IAudioPlayerState state)
    {
        _state = state;
    }

    public void Play()
    {
        _state.Play(this);
    }

    public void Pause()
    {
        _state.Pause(this);
    }

    public void Stop()
    {
        _state.Stop(this);
    }
}

// State interface
interface IAudioPlayerState
{
    void Play(AudioPlayer player);
    void Pause(AudioPlayer player);
    void Stop(AudioPlayer player);
}

// Concrete State: Playing
class PlayingState : IAudioPlayerState
{
    public void Play(AudioPlayer player)
    {
        Console.WriteLine("Already playing.");
    }

    public void Pause(AudioPlayer player)
    {
        Console.WriteLine("Pausing playback.");
        player.SetState(new PausedState());
    }

    public void Stop(AudioPlayer player)
    {
        Console.WriteLine("Stopping playback.");
        player.SetState(new StoppedState());
    }
}

// Concrete State: Paused
class PausedState : IAudioPlayerState
{
    public void Play(AudioPlayer player)
    {
        Console.WriteLine("Resuming playback.");
        player.SetState(new PlayingState());
    }

    public void Pause(AudioPlayer player)
    {
        Console.WriteLine("Already paused.");
    }

    public void Stop(AudioPlayer player)
    {
        Console.WriteLine("Stopping playback.");
        player.SetState(new StoppedState());
    }
}

// Concrete State: Stopped
class StoppedState : IAudioPlayerState
{
    public void Play(AudioPlayer player)
    {
        Console.WriteLine("Starting playback.");
        player.SetState(new PlayingState());
    }

    public void Pause(AudioPlayer player)
    {
        Console.WriteLine("Cannot pause, not playing.");
    }

    public void Stop(AudioPlayer player)
    {
        Console.WriteLine("Already stopped.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        AudioPlayer audioPlayer = new AudioPlayer();

        audioPlayer.Play();
       audioPlayer.Pause();
        audioPlayer.Play();
        audioPlayer.Stop();
    }
}
