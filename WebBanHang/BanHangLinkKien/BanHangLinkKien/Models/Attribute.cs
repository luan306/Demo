using System;
using System.Collections.Generic;

namespace BanHangLinkKien.Models;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<AttributePrice> AttributePrices { get; } = new List<AttributePrice>();
}
