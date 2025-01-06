namespace Schulungsplanung;

public class CourseLimitExceededException : Exception
{
    public CourseLimitExceededException() : base("Attempt to assign more than 15 courses to participant!")
    {
    }
}

public class ParticipantLimitExceededException : Exception
{
    public ParticipantLimitExceededException() : base("Attempt to assign more than 15 participant to course!")
    {
    }
}