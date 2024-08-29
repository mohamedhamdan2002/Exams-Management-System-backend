using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.AuthDtos
{
    public record UserDto(
        string Id,
        string FullName,
        string NationalID,
        string Email
    );    
}
