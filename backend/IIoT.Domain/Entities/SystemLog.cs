namespace IIoT.Domain.Entities;

using IIoT.Domain.Enums;

public class SystemLog
{
    public long LogId { get; set; }

    public string Module { get; set; } = string.Empty;

    public LogLevel Level { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Detail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}