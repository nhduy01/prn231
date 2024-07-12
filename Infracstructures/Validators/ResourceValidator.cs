using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Report;
using Application.SendModels.Resources;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ResourceValidator : IResourceValidator
    {
        private readonly IValidator<ResourcesRequest> _resourcevalidator;
        private readonly IValidator<ResourcesUpdateRequest> _updateresourcetvalidator;

        public ResourceValidator(IValidator<ResourcesRequest> resourcevalidator, IValidator<ResourcesUpdateRequest> updateresourcevalidator)
        {
            _resourcevalidator = resourcevalidator;
            _updateresourcetvalidator = updateresourcevalidator;
        }

        public IValidator<ResourcesRequest> ResourcesRequestValidator => _resourcevalidator;
        public IValidator<ResourcesUpdateRequest> ResourcesUpdateRequestValidator => _updateresourcetvalidator;
    }
}
