using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.TopicViewModels;

namespace Application.ViewModels.RoundViewModels
{
    public class ListTopicViewModel
    {
        ICollection<TopicViewModel> Topic { get; set; }
    }
}
