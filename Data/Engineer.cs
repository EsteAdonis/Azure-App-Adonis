using Newtonsoft.Json;

namespace azure_app_adonis.Data;

public class Engineer
{
	[JsonProperty("id")]
	public string Id { get; set; } = Guid.NewGuid().ToString();
	public string? Name { get; set; }
	public string? Country { get; set; }
	public string? Speciality { get; set; }
}
