using Book_Evaluation_Management_System.Core.DTOs;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.Book.GetBooks
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDTO>>
    {
        
    }
}