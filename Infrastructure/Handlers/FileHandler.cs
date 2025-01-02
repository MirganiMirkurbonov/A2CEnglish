using Domain.Models.Infrastructure.File;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Handlers;

internal class FileHandler : IFileHandler
{
    public async Task<FileInfoView?> UploadFileAsync(IFormFile file, string path)
    {
        try
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Files\" + path);
            if(file.ContentType.StartsWith("image/"))
                filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + path);

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            FileInfo fileInfo = new(file.FileName);

            var newFileName = Guid.NewGuid().ToString().Replace("-", "") + fileInfo.Extension;

            var fullPath = Path.Combine(filePath, newFileName);

            path = Path.Combine(path, newFileName);

            await using var stream = new FileStream(fullPath, FileMode.Create);

            await file.CopyToAsync(stream);

            await stream.FlushAsync();

            var info = new FileInfoView(Extension: fileInfo.Extension, Path: path, Size: file.Length);

            return info;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<DownloadFileViewModel?> DownloadFileAsync(string? filePath)
    {
        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Files\" + filePath);

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return null;

            var memory = new MemoryStream();

            await using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return new DownloadFileViewModel(Path: path, MemoryStream: memory);
        }
        catch (Exception ex)
        {
            return null;
        }
    }


}