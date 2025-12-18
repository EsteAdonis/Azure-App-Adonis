using Microsoft.Azure.Cosmos;

namespace azure_app_adonis.Data
{
  public class EngineerService : IEngineerService
  {
    private readonly string CosmosDBConnectionString = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
    private readonly string CosmosDbName = "Contractors";
    private readonly string CosmosDbContainerName = "Engineers";

		private Container GetContainerClient()
		{
			var cosmosDbClient = new CosmosClient(CosmosDBConnectionString);
			cosmosDbClient.CreateDatabaseIfNotExistsAsync(CosmosDbName).Wait();
			var container = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
			return container;
		}

    public async Task AddEngineer(Engineer engineer)
    {
      try
      {
        var container = GetContainerClient();
        var response = await container.CreateItemAsync(engineer, new PartitionKey(engineer.Id));
        if (response.StatusCode == System.Net.HttpStatusCode.Created)
        {
          Console.WriteLine($"Engineer {engineer.Id} created successfully.");
        }
        else
        {
          Console.WriteLine($"Failed to create engineer {engineer.Id}. Status code: {response.StatusCode}");
        }
      }
      catch (CosmosException ex)
      {
        Console.WriteLine($"Cosmos DB error: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }

    }

    public async Task UpdateEngineer(Engineer engineer)
    {
      try
      {
        var container = GetContainerClient();
        var response = await container.UpsertItemAsync(engineer, new PartitionKey(engineer.Id));
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
          Console.WriteLine($"Engineer {engineer.Id} updated successfully.");
        }
        else
        {
          Console.WriteLine($"Failed to update engineer {engineer.Id}. Status code: {response.StatusCode}");
        }
      }
      catch (CosmosException ex)
      {
        Console.WriteLine($"Cosmos DB error: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }
    }

    public async Task DeleteEngineer(string id, string? PartitionKey)
    {
      try
      {
        var container = GetContainerClient();
        var response = await container.DeleteItemAsync<Engineer>(id, new PartitionKey(PartitionKey));
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
          Console.WriteLine($"Engineer {id} deleted successfully.");
        }
        else
        {
          Console.WriteLine($"Failed to delete engineer {id}. Status code: {response.StatusCode}");
        }
      }
      catch (CosmosException ex)
      {
        Console.WriteLine($"Cosmos DB error: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }
    }

    public async Task<List<Engineer>> GetEngineerDetails()
    {
      var engineers = new List<Engineer>();
      try
      {
        var container = GetContainerClient();
        var sqlQuery = "Select * From c";
        var query = new QueryDefinition(sqlQuery);
        var iterator = container.GetItemQueryIterator<Engineer>(query);

        while (iterator.HasMoreResults)
        {
          var response = await iterator.ReadNextAsync();
          foreach (var engineer in response)
          {
            engineers.Add(engineer);
          }
        }
      }
      catch (CosmosException ex)
      {
        Console.WriteLine($"Cosmos DB error: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }
      return engineers;
    }

    public async Task<Engineer?> GetEngineerDetailsById(string id, string? PartitionKey)
    {
      try
      {
        var container = GetContainerClient();
        var response = await container.ReadItemAsync<Engineer>(id, new PartitionKey(id));
        return response.Resource;
      }
      catch (CosmosException ex)
      {
        Console.WriteLine($"Cosmos DB error: {ex.Message}");
        return null;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
        return null;
      }
    }
  }
}



