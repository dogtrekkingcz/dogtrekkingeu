namespace PetsOnTrail.Actions.Attributes;

[AttributeUsage(AttributeTargets.Method)]
internal class RequiredRolesAttribute : Attribute
{
    public string[] Roles { get; set; }

    public RequiredRolesAttribute(params string[] roles)
    {
        Roles = roles;
    }
}