using System.Collections.Generic;
using PQ_API.Classes;

namespace PQ_API.Interfaces
{
    public interface IBrandService
    {
        List<BrandInfo> GetAll();
        BrandInfo GetById(string userId);
    }
}