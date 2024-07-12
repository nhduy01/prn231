using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Resources;
using FluentValidation;

namespace Application.IValidators
{
    public interface IResourceValidator
    {
        IValidator<ResourcesRequest> ResourcesRequestValidator { get; }
        IValidator<ResourcesUpdateRequest> ResourcesUpdateRequestValidator { get; }
    }
}
