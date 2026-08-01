namespace IIoT.Domain.Entities;

using IIoT.Domain.Enums;

public class AlarmHistory
{
    public long AlarmHistoryId { get; set; }

    public int AlarmRuleId { get; set; }

    public decimal Value { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? AcknowledgeBy { get; set; }

    public AlarmStatus Status { get; set; }

    // Navigation Property
    public AlarmRule AlarmRule { get; set; } = null!;

    public User? AcknowledgeUser { get; set; }
}