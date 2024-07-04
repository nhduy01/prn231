using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.PaintingCollection
{
    public class PaintingCollectionRequest
    {
        public Guid? PaintingId { get; set; }

        public Guid? CollectionId { get; set; }
    }
}
