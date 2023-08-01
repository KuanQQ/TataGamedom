﻿using System;
using System.Collections.Generic;
using TataGamedomWebAPI.Models.Common;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class InventoryItem : BaseEntity
{
    public string Index { get; set; } = null!;

    public int ProductId { get; set; }

    public int StockInSheetId { get; set; }

    public decimal Cost { get; set; }

    public string? GameKey { get; set; }

    public virtual OrderItem? OrderItem { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual StockInSheet StockInSheet { get; set; } = null!;
}
