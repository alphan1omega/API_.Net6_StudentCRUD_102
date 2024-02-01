using System;
using System.Collections.Generic;

namespace APIEntryDtls.AppData;

public partial class EntryDetail
{
    public long EntrId { get; set; }

    public int Pid { get; set; }

    public string Fname { get; set; } = null!;

    public string? Lname { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string Pin { get; set; } = null!;
}
