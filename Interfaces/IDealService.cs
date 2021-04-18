using System.Collections.Generic;
using PQ_API.Classes;

namespace PQ_API.Interfaces
{
    public interface IDealService
    {
        List<Deal> GetAll(string brandId);
        Deal GetById(string dealId, string brandId);
        AskQuestion AskQuestion(AskQuestion question);
    }
}