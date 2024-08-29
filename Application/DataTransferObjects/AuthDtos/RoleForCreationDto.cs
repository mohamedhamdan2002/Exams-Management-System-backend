namespace Application.DataTransferObjects.AuthDtos
{
    public record RoleForCreationDto
    {
        public string Name { get; init; } = null!;
    }
}
