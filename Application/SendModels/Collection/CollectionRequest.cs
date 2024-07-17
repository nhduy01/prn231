﻿namespace Application.SendModels.Collection;

public class CollectionRequest
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

    public Guid CurrentUserId { get; set; }
}