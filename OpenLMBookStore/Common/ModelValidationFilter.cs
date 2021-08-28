using OpenLMBookStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpenLMBookStore.Common
{
    public static class ModelValidationFilter
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationModelAttribute());
        }
    }
}
