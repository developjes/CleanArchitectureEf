namespace Example.Ecommerce.Application.DTO.Common;

public class SqlParam
{
    public string? Name { get; set; }
    public object? Value { get; set; }
    public SqlParamConfig? Config { get; set; }
}