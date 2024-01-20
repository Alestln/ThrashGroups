namespace ThrashGroups.Entity;

public class Student
{
    public int Id { get; set; }
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }

    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<StudentUnderGroup> StudentUnderGroups { get; set; }
}