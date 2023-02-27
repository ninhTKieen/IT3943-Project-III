namespace DeviceManagement.Dtos;

public class CategoryCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class CategoryUpdateDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}