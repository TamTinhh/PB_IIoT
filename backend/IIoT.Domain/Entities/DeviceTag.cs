namespace IIoT.Domain.Entities;

public class DeviceTag
{
    public int DeviceTagId { get; set; }
    public int DeviceId { get; set; }

    public string TagCode { get; set; } = string.Empty;
    public string TagName { get; set; } = string.Empty;

    public int RegisterAddress { get; set; }

    public byte FunctionCode { get; set; }

    public string DataType { get; set; } = string.Empty;

    public decimal Scale { get; set; }

    public string Unit { get; set; } = string.Empty;

    public bool IsAlarmEnabled { get; set; }

    public bool IsHistoryEnabled { get; set; }

    public Device Device { get; set; } = null!;

    public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public ICollection<AlarmRule> AlarmRules { get; set; } = new List<AlarmRule>();
}