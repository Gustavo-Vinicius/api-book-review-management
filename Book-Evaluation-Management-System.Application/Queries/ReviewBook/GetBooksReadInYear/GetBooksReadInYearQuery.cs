using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetBooksReadInYear
{
    public class GetBooksReadInYearQuery : IRequest<int>
    {
        public int Year { get; set; }

        public GetBooksReadInYearQuery(int year)
        {
            Year = year;
        }
    }
}