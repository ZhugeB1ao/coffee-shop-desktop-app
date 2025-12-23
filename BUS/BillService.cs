using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.DAO;
using CoffeeShop.DTO;

namespace CoffeeShop.BUS
{
    /// <summary>
    /// Service class for handling bill-related business logic.
    /// </summary>
    internal class BillService
    {
        private BillRepository repo;
        public BillService()
        {
            repo = new BillRepository();
        }

        // Retrieves the unpaid bill for a specific table.
        public Bill GetBillByTableId(int tableId) => repo.GetUnpaidBillByTableId(tableId);
        
        // Creates a new bill.
        public void CreateBill(int tableId) => repo.CreateBill(tableId);
        
        // Processes bill payment.
        public void PayBill(int billId, float price) => repo.PayBill(billId, price);
        
        // Retrieves a bill by its ID.
        public Bill GetById(int id) => repo.GetById(id);
        
        // Updates bill information.
        public void Update(Bill bill) => repo.Update(bill);
        
        // Retrieves a list of bills for statistics by date range.
        public IEnumerable<dynamic> GetBillListByDate(DateTime from, DateTime to) => repo.GetBillListByDate(from, to);
    }
}
