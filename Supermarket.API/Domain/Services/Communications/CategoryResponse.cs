using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communications
{
    public class CategoryResponse: BaseResponse<Category>
    {
        public CategoryResponse(Category resource): base(resource)
        { 
        }

        public CategoryResponse(string message) : base(message)
        {

        }
    }
}
