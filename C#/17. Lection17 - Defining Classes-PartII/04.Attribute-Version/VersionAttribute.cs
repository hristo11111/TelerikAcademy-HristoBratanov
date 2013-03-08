using System;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | 
    AttributeTargets.Enum | AttributeTargets.Method)]
public class Version : Attribute
{
    public string Ver { get; private set; }

    public Version(string ver)
    {
        this.Ver = ver;
    }
    
}
