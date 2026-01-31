using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Aura.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Aura.Core.Services;

public class DocumentService : IDocumentService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;

    public DocumentService(IConfiguration configuration)
    {
        var connectionString = configuration["AzureStorage:ConnectionString"];
        _containerName = configuration["AzureStorage:ContainerName"] ?? "aura-documents";
        _blobServiceClient = new BlobServiceClient(connectionString);
    }

    public async Task<string> UploadDocumentAsync(Stream fileStream, string fileName, string contentType)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType });

        return blobClient.Uri.ToString();
    }

    public async Task<Stream> GetDocumentAsync(string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        
        var response = await blobClient.DownloadStreamingAsync();
        return response.Value.Content;
    }

    public async Task DeleteDocumentAsync(string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }
}
