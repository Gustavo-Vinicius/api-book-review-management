using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Evaluation_Management_System.Core.Interfaces.Services
{
    public interface IGenerativeBookAI
    {
        Task<string> GenerateContentAsync();
    }
}