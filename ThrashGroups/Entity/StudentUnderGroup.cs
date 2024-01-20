namespace ThrashGroups.Entity;

public class StudentUnderGroup
{
    public int StudentId { get; set; }
    public int UnderGroupId { get; set; }

    public Student Student { get; set; }
    public UnderGroup UnderGroup { get; set; }
}