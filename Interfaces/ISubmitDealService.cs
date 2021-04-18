using PQ_API.Classes;

namespace PQ_API.Interfaces
{
    public interface ISubmitDealService
    {
        SubmitDealResponse SubmitDeal(SubmitDealRequest model);
    }
}