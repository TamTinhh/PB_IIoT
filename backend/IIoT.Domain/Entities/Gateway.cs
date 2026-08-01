namespace IIoT.Domain.Entities;

public class Gateway
{
	public int GatewayId { get; set; }

	public string GatewayCode { get; set; } = string.Empty;

	public string GatewayName { get; set; } = string.Empty;

	public string Model { get; set; } = string.Empty;

	public string IPAddress { get; set; } = string.Empty;

	public int Port { get; set; }

	public bool Status { get; set; }

	public string Location { get; set; } = string.Empty;

	public DateTime CreatedAt { get; set; }

	public DateTime UpdatedAt { get; set; }
}