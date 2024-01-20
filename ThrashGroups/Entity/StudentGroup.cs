namespace ThrashGroups.Entity;

public enum GroupType
{
    AcademicGroup = 1,
    AdditionalStudyGroup
}

public class StudentGroup
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public GroupType Type { get; set; }

    public Group Group { get; set; }
    public Student Student { get; set; }
}