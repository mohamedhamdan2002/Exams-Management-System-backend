using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.CategoryDtos
{
    public abstract record CategoryForManipulationDto
    {
        public string? Name { get; init; }
        public string? Description { get; init; }

    }
        
}
