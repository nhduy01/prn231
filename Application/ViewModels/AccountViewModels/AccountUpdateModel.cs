using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountViewModels
{
    public class AccountUpdateModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string IsMale { get; set; }
        public int RoleId { get; set; }
        public string Level { get; set; }
        public string Status { get; set; }
        public string? AvatarURL { get; set; }

    }
}
