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
    /// Service class for handling table logic.
    /// </summary>
    internal class TableService
    {
        private TableRepository repo;
        public TableService()
        {
            repo = new TableRepository();
        }

        // Retrieves a list of all tables.
        public List<Table> GetAll() => repo.GetAll();

        /// <summary>
        /// Automatically updates table status based on whether there is an unpaid bill.
        /// </summary>
        public void UpdateStatusBasedOnBill(int tableId, BillService billService)
        {
            var unpaidBill = billService.GetBillByTableId(tableId);
            if (unpaidBill == null)
                SetStatus(tableId, "Free");
            else
                SetStatus(tableId, "Occupied");
        }

        // Retrieves a list of all free tables.
        public List<Table> GetAllFree() => repo.GetAllFree();

        // Updates table status directly.
        public void SetStatus(int tableId, string status) => repo.SetStatus(tableId, status);
    }
}
