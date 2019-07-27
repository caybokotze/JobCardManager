using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.Domain.Configurations;

namespace JobCardSystem.Core.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Select Supplier")]
        [Required]
        public int SupplierId { get; set; }

        public int[] PurchaseOrderItemsIdArray { get; set; }

        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PurchaseOrderJsonPostBackResult> OrderItems { get; set; }
    }

    public class PurchaseOrderJsonPostBackResult
    {
        public int OrderItemId { get; set; }
        //
        public int AmountOfItem { get; set; }
    }

    public class TempPurchaseOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Select Supplier")]
        [Required]
        public int SupplierId { get; set; }

        [Display(Name = "Select stock items")]
        public int[] PurchaseOrderItemsIdArray { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

        public ICollection<StockItem> StockItems { get; set; }
    }

    public class PurchaseOrderFormVm
    {

    }

    public class PurchaseOrderTableVm
    {

    }
}