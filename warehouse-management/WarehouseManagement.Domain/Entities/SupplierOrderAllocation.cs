namespace WarehouseManagement.Domain.Entities
{
    public class SupplierOrderAllocation(int id) : Entity<int>(id)
    {
        public int Quantity { get; set; }

        public int? BinNumber { get; set; }

        public int SourceType { get; set; }

        public DateTime? OrderInReceiveDate { get; set; }

        public int? OrderInNumber { get; set; }

        public int OrderOutType { get; init; }

        public int OrderOutNumber { get; init; }

        public int OrderOutItemNumber { get; init; }

        public DateTime OrderOutItemDate { get; init; }

        public string? OrderOutEntityName { get; init; }

        public string? OrderOutEntityReference { get; init; }

        public int OrderOutEntityNumber { get; init; }

        public int? OrderOutEntitySubNumber { get; init; }

        public int OrderOutTeamMemberNumber { get; init; }

        public DateTime OrderOutTargetShipDate { get; init; }

        public DateTime OrderOutOnDockdate { get; init; }

        public bool OrderOutSOR { get; init; }

        public int CompanyNumber { get; init; }
    }
}
