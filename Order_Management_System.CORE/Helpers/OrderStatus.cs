using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repositories.Helpers
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Processing")]
        Processing,
        [EnumMember(Value = "Placed")]
        Placed,
        [EnumMember(Value = "Delivered")]
        Delivered,
        [EnumMember(Value = "Cancelled")]
        Cancelled,
    }
}
