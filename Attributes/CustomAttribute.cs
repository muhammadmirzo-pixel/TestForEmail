namespace TestForEmail.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |  AttributeTargets.Property)]
public class CustomAttribute : Attribute
{
    public string Description { get; }
    public CustomAttribute(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length < 10)
            throw new ArgumentException("Description must be least 10 characters long");
        Description = description;
    }
}
