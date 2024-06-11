using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.IService.ICommonService
{
    public interface IClaimsService
    {
        Guid? GetCurrentUserId();
    }

}
