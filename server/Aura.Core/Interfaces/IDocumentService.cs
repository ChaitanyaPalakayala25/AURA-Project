namespace Aura.Core.Interfaces;

public interface IDocumentService
{
    Task<string> UploadDocumentAsync(Stream fileStream, string fileName, string contentType);
    Task<Stream> GetDocumentAsync(string fileName);
    Task DeleteDocumentAsync(string fileName);
}
