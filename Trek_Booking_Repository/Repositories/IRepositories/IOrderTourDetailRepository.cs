﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trek_Booking_DataAccess;

namespace Trek_Booking_Repository.Repositories.IRepositories
{
    public interface IOrderTourDetailRepository
    {
        public Task<OrderTourDetail> GetOrderTourDetailByOrderTourHeaderId(int orderTourHeaderId);
    }
}
