namespace SmartVector;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ValueOperationAttribute : Attribute
{
    public Type OperationProviderType { get; }


    public ValueOperationAttribute(Type operationProviderType)
    {

        OperationProviderType = operationProviderType;
    }
}
