namespace IIoT.Domain.Entities;

public class Device
{
    public int DeviceId { get; set; }

    public int GatewayId { get; set; }

    public string DeviceCode { get; set; } = string.Empty;

    public string DeviceName { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    public string Protocol { get; set; } = string.Empty;

    public int SlaveId { get; set; }

    public int BaudRate { get; set; }

    public byte DataBits { get; set; }

    public string Parity { get; set; } = string.Empty;

    public byte StopBits { get; set; }

    public int PollingIntervalMs { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation Property
    public Gateway Gateway { get; set; } = null!;

    public ICollection<DeviceTag> DeviceTags { get; set; } = new List<DeviceTag>();
}