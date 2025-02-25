﻿namespace Blink.Development.Entities.Dtos.Response.Delivery
{
    public class CreateDeliveryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public Guid BranchId { get; set; }
        public decimal Balance { get; set; }
    }
}
