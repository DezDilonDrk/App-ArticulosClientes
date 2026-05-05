using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.DTO;

public class DatabaseMigrateRequest
{
    public string SourceDB { get; set; }
    public string TargetDB { get; set; }
}
