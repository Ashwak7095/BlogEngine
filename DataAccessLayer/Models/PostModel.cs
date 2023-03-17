using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public partial class PostModel
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime PublishDate { get; set; }
}
