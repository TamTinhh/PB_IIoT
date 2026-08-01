using IIoT.Domain.Enums;

namespace IIoT.Domain.Entities;

public class Measurement
{
    public long MeasurementId { get; set; }

    public int DeviceTagId { get; set; }

    public decimal Value { get; set; }

    public MeasurementQuality Quality { get; set; }

    public DateTime Timestamp { get; set; }

    // Navigation Property
    public DeviceTag DeviceTag { get; set; } = null!;
}