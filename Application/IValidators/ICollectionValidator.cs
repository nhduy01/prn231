using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Collection;
using FluentValidation;

namespace Application.IValidators
{
    public interface ICollectionValidator
    {
        IValidator<CollectionRequest> CollectionRequestValidator { get; }
        IValidator<UpdateCollectionRequest> UpdateCollectionRequestValidator { get; }
    }
}
