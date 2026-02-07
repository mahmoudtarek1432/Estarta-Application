using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.BranchDtos
{
    public class BranchUpdateDto
    {
        public string BranchId { get; set; }
        public string MerchantId { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerContact { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public bool DisableRefund { get; set; }
        public bool DisablePartialRefund { get; set; }
        public bool DisableCollection { get; set; }
        public bool DisableVouchers { get; set; }
        public BranchStatus Status { get; set; }

    }
}
