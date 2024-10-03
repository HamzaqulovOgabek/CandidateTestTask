namespace CandidateTestTask.Application.Exceptions;

public class CandidateNotFoundException : Exception
{
    public CandidateNotFoundException(string message) : base(message)
    {
    }
}
