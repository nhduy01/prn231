﻿using Application.ViewModels.PaintingViewModels;

namespace Application.ViewModels.ScheduleViewModels;

public class AwardScheduleListModels
{
    public int Quantity { get; set; }
    public Guid? AwardId { get; set; }
    public Guid? ScheduleId { get; set; }
    public List<PaintingViewModel> PaintingViewModelsList { get; set; }

}