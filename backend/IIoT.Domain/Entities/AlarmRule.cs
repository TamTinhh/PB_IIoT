namespace IIoT.Domain.Entities;

using IIoT.Domain.Enums;

public class AlarmRule
{
    public int AlarmRuleId { get; set; }

    public int DeviceTagId { get; set; }

    public string AlarmName { get; set; } = string.Empty;

    public AlarmCondition Condition { get; set; }

    public decimal Threshold { get; set; }

    public AlarmSeverity Severity { get; set; }

    public bool IsEnable { get; set; }

    // Navigation Property
    public DeviceTag DeviceTag { get; set; } = null!;
}