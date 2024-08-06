using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Evaluation_Management_System.Core.Entities;
using MediatR;

namespace Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetAllReview
{
    public class GetAllReviewQuery : IRequest<List<Assessment>>
    {
        
    }
}