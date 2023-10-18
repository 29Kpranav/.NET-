using System;

public interface Interviewer
{
    void SetNextInterviewer(Interviewer nextInterviewer);
    void HandleInterview(Candidate candidate);
}

public class InitialScreeningInterviewer : Interviewer
{
    private Interviewer _nextInterviewer;

    public void SetNextInterviewer(Interviewer nextInterviewer)
    {
        _nextInterviewer = nextInterviewer;
    }

    public void HandleInterview(Candidate candidate)
    {
        if (candidate.ExperienceYears >= 2)
        {
            Console.WriteLine("Initial Screening: Candidate passes to next round.");
            _nextInterviewer.HandleInterview(candidate); // Pass to the next round
        }
        else
        {
            Console.WriteLine("Initial Screening: Candidate is rejected.");
        }
    }
}

public class TechnicalInterviewer : Interviewer
{
    private Interviewer _nextInterviewer;

    public void SetNextInterviewer(Interviewer nextInterviewer)
    {
        _nextInterviewer = nextInterviewer;
    }

    public void HandleInterview(Candidate candidate)
    {
        if (candidate.TechnicalScore >= 70)
        {
            Console.WriteLine("Technical Interview: Candidate passes to next round.");
            _nextInterviewer.HandleInterview(candidate); // Pass to the next round
        }
        else
        {
            Console.WriteLine("Technical Interview: Candidate is rejected.");
        }
    }
}

public class HRInterviewer : Interviewer
{
    public void SetNextInterviewer(Interviewer nextInterviewer)
    {
        // HR interviewer is the last in the chain
    }

    public void HandleInterview(Candidate candidate)
    {
        if (candidate.FitForCompanyCulture)
        {
            Console.WriteLine("HR Interview: Candidate is selected!");
        }
        else
        {
            Console.WriteLine("HR Interview: Candidate is rejected.");
        }
    }
}

public class InterviewProcess
{
    private Interviewer _initialScreeningInterviewer;
    private Interviewer _technicalInterviewer;
    private Interviewer _hrInterviewer;

    public InterviewProcess()
    {
        _initialScreeningInterviewer = new InitialScreeningInterviewer();
        _technicalInterviewer = new TechnicalInterviewer();
        _hrInterviewer = new HRInterviewer();

        _initialScreeningInterviewer.SetNextInterviewer(_technicalInterviewer);
        _technicalInterviewer.SetNextInterviewer(_hrInterviewer);
    }

    public void StartInterview(Candidate candidate)
    {
        _initialScreeningInterviewer.HandleInterview(candidate);
    }
}

public class Candidate
{
    public int ExperienceYears { get; set; }
    public int TechnicalScore { get; set; }
    public bool FitForCompanyCulture { get; set; }
}

class Program
{
    static void Main()
    {
        InterviewProcess interviewProcess = new InterviewProcess();
        Candidate candidate = new Candidate
        {
            ExperienceYears = 3,
            TechnicalScore = 85,
            FitForCompanyCulture = true
        };
        interviewProcess.StartInterview(candidate);
    }
}