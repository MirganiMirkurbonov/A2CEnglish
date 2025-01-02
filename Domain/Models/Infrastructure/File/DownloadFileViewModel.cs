namespace Domain.Models.Infrastructure.File;

public record DownloadFileViewModel(
    string Path,
    MemoryStream MemoryStream);