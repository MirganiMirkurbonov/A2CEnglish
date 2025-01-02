namespace Domain.Models.Infrastructure.File;

public record FileInfoView(
    string Path,
    string Extension,
    long Size);