using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.EducationalLevel;
using Application.SendModels.Image;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ImageValidator : IImageValidator
    {
        private readonly IValidator<ImageRequest> _imagevalidator;

        public ImageValidator(IValidator<ImageRequest> levelvalidator)
        {
            _imagevalidator = levelvalidator;
        }

        public IValidator<ImageRequest> ImageRequestValidator => _imagevalidator;
    }
}
