using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Image;
using FluentValidation;

namespace Application.IValidators
{
    public interface IImageValidator
    {
        IValidator<ImageRequest> ImageRequestValidator { get; }
    }
}
