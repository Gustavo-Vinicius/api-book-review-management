using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.Book.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}