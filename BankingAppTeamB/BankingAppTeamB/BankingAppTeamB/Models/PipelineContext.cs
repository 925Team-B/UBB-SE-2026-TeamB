namespace BankingAppTeamB.Models
{
    public class PipelineContext
    {
        public int UserId { get; set; }
        public int SourceAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public decimal Fee { get; set; }
        public string CounterpartyName { get; set; }
        public string RelatedEntityType { get; set; }
        public int RelatedEntityId { get; set; }
    }
}
