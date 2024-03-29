﻿using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public virtual Image Image { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
