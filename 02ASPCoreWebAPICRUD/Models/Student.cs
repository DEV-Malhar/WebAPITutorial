using System;
using System.Collections.Generic;

namespace _02ASPCoreWebAPICRUD.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int StdAge { get; set; }

    public int StdStd { get; set; }
}
