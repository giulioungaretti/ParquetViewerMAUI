using Parquet;
using Parquet.Data.Rows;

namespace MauiApp3.Services;

public class FileService
{
    public string Path { get; set; } = @"C:\Users\giuli\Downloads\data.parquet";

    public FileService() { }

    public FileService(string path) => Path = path;

    public static Table LoadAsync(Stream parquetFileStream)
    {

        var formatOptions = new ParquetOptions
        {
            // TODO: read docs
            TreatByteArrayAsString = true
        };

        using var reader = new ParquetReader(parquetFileStream, formatOptions);
        return reader.ReadAsTable();
    }
}
