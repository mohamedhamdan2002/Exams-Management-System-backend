namespace Application.DataTransferObjects.AuthDtos
{
    public record RoleForUpdateDto
    {
        public string Name { get; init; } = null!;
    }
}
