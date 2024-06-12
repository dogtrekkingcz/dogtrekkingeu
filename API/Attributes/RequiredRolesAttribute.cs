namespace PetsOnTrail.Actions.Attributes;

[AttributeUsage(AttributeTargets.Method)]
internal class RequiredRolesAttribute : Attribute
{
    public Guid[] Roles { get; set; }

    public RequiredRolesAttribute(params string[] roles)
    {
        Roles = roles.Select(role => Guid.Parse(role)).ToArray();
    }
}