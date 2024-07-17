using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.ViewModels.TopicViewModels;

public class RoundTopicViewModel
{
    public Guid Id { get; set; }
    public String Name { get; set; } = null!;
}