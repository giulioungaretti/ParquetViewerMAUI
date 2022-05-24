namespace MauiApp3.Models;
public sealed class Table
{
    public string Name { get; set; }
    public Parquet.Data.Rows.Table Data{ get; set; }
}
