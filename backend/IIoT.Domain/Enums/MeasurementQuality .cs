namespace IIoT.Domain.Enums;

public enum MeasurementQuality : byte
{
    Good = 0,
    Timeout = 1,
    CrcError = 2,
    Invalid = 3
}