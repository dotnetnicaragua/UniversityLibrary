using GraphQL.Types;
using Library.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.GraphQL
{
    public class LibraryUniversityQuery : ObjectGraphType
    {
        public LibraryUniversityQuery(BookRepository bookRepository)
        {
            Field<ListGraphType<ProductType>>(
                "books",
                resolve: context => bookRepository.GetAll()
            );
        }
    }
}
