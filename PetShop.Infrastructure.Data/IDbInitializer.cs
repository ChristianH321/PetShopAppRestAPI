using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public interface IDbInitializer
    {
        void Initialize(TodoContext context);
    }
}
