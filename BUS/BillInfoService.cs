using CoffeeShop.DAO;
using CoffeeShop.DTO;
using System.Collections.Generic;

namespace CoffeeShop.BUS
{
    /// <summary>
    /// Service class for handling bill detail logic (items within a bill).
    /// </summary>
    internal class BillInfoService
    {
        private BillInfoRepository repo;

        public BillInfoService()
        {
            repo = new BillInfoRepository();
        }

        // Retrieves the list of items by bill ID.
        public List<BillInfo> GetByBillId(int billId) => repo.GetByBillId(billId);
        
        // Finds a specific item within a bill.
        public BillInfo GetByBillIdAndProductId(int billId, int productId) => repo.GetByBillIdAndProductId(billId, productId);
        
        // Adds a new item to a bill.
        public void Add(BillInfo billInfo) => repo.Add(billInfo);
        
        // Updates the quantity of an item.
        public void Update(BillInfo billInfo) => repo.Update(billInfo);
        
        // Deletes an item from a bill.
        public void Delete(int id) => repo.Delete(id);
    }
}
