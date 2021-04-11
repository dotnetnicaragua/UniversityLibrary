using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.GraphQL
{
    public class LibraryUniversitySchema : Schema
    {
        public LibraryUniversitySchema(LibraryUniversityQuery query)
        {
            Query = query;
        }
    }
}

