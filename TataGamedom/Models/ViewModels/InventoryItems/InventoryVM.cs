﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.EFModels;

namespace TataGamedom.Models.ViewModels.InventoryItems
{
    public class InventoryItemVM
    {
        public int Id { get; set; }

        [Display(Name = "SKU")]
        public string SKU { get; set; }

		public string Index { get; set; }


		[Required(ErrorMessage = "{0} 必填")]
		[Display(Name = "商品編號")]
		[Range(1, 99999999, ErrorMessage = "{0}不得小於1")]
		public int ProductId { get; set; }

		[Required(ErrorMessage = "{0} 必填")]
		[Display(Name = "進貨單編號")]
		public  int StockInSheetId { get; set; }

		[Display(Name = "進貨單編號")]
        public string StockInSheetIndex { get; set; }

		[Required(ErrorMessage = "{0} 必填")]
		[Display(Name = "成本")]
		[Range(1, 99999999, ErrorMessage = "{0}不得小於1")]
		public decimal Cost { get; set; }

        [Display(Name = "遊戲序號")]
        public string GameKey { get; set; }

        [Display(Name = "遊戲名稱")]
        public string GameName{ get; set; }

        public StockInStatusCode StockInStatusCode { get; set; }
    }

    public class InventoryVM 
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        [Display(Name ="產品編號")]
        public string ProductIndex { get; set; }

        [Display(Name = "遊戲名稱")]
        public string GameName { get; set; }

        [Display(Name = "遊戲圖片")]
        public string GameCoverImage { get; set; }

        [Display(Name = "有無序號")]
        public bool ProductIsVirtual { get; set; }

        public string ProductIsVirtualTText => ProductIsVirtual == true ? "<i class=\"bi bi-check2-circle\"></i>" : string.Empty;

		[Display(Name = "庫存量")]
        public int Count { get; set; } = 0;  

        [Display(Name = "總成本")]
        [DisplayFormat(DataFormatString ="{0:#,#}")]
        public decimal Total { get; set; } = 0; 

    }
}