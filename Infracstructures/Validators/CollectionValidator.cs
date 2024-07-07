using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Category;
using Application.SendModels.Collection;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class CollectionValidator : ICollectionValidator
    {
        private readonly IValidator<CollectionRequest> _collectionvalidator;
        private readonly IValidator<UpdateCollectionRequest> _updatecollectionvalidator;

        public CollectionValidator(IValidator<CollectionRequest> collectionvalidator, IValidator<UpdateCollectionRequest> updatecollectionvalidator)
        {
            _collectionvalidator = collectionvalidator;
            _updatecollectionvalidator = updatecollectionvalidator;
        }

        public IValidator<CollectionRequest> AwardCreateValidator => _collectionvalidator;
        public IValidator<UpdateCollectionRequest> UserAwardValidator => _updatecollectionvalidator;
    }
}
