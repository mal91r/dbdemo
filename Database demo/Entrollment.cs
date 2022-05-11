using Database_demo;

public class Enrollment
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public int ChallengeId { get; set; }
    public Challenge? Challenge { get; set; }

    public bool isCompleted { get; set; }       // оценка студента
}