﻿using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class Announcement
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }
}
