using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Screensui
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Route { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public bool? State { get; set; }

    public virtual ICollection<Rolscreenui> Rolscreenuis { get; } = new List<Rolscreenui>();
}
