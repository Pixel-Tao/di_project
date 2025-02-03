using System;

// 필드와 프로퍼티에 주입을 받을 수 있도록 하는 특성
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class InjectAttribute : Attribute
{
    
}