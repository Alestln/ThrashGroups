﻿namespace ThrashGroups.Entity;

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<UnderGroup> UnderGroups { get; set; }
}