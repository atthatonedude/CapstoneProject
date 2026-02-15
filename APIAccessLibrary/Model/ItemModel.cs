using System;
using System.Collections.Generic;
using System.Text;

namespace APIAccessLibrary.Model
{
    public  class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemPartNumber { get; set; }
    }
}
