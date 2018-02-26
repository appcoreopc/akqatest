using System;
using System.Collections.Generic;

namespace AkqaDataServices.DataModel
{
    public partial class UserAmount
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public decimal? Amount { get; set; }
    }
}
