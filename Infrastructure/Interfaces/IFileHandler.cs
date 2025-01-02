using Domain.Models.Infrastructure.File;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Interfaces;

public interface IFileHandler
{
    Task<FileInfoView?> UploadFileAsync(IFormFile file, string path);
    Task<DownloadFileViewModel?> DownloadFileAsync(string? filePath);
}