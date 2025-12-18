namespace azure_app_adonis.Data;
public interface IEngineerService
{
  Task AddEngineer(Engineer engineer);
  Task DeleteEngineer(string id, string? PartitionKey);
  Task<List<Engineer>> GetEngineerDetails();
  Task<Engineer?> GetEngineerDetailsById(string id, string? PartitionKey);
  Task UpdateEngineer(Engineer engineer);
}