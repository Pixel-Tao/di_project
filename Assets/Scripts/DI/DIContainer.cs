using System;
using System.Collections.Generic;
using System.Reflection;

public class DIContainer
{
    private Dictionary<Type, object> _container = new Dictionary<Type, object>();
    
    public void Register<T>(T obj)
    {
        if (_container.ContainsKey(typeof(T)))
        {
            throw new Exception($"Type {typeof(T)} already exists in container");
        }
        
        _container.Add(typeof(T), obj);
    }
    
    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }
    public object Resolve(Type type)
    {
        if (!_container.ContainsKey(type))
        {
            throw new Exception($"Type {type} not found in container");
        }
        
        return _container[type];
    }
    
    public void Clear()
    {
        foreach (var obj in _container.Values)
        {
            if (obj is BaseManager disposable)
            {
                disposable.Dispose();
            }
        }

        _container.Clear();
    }
    
    public void Dispose()
    {
        Clear();
        _container = null;
    }
    
    // 의존선 주입 할 인터페이스 구현체들을 초기화
    public void Initialize()
    {
        foreach (var obj in _container.Values)
        {
            if (obj is IInitializer initializable)
            {
                Inject(obj);
                initializable.Initialize();
            }
        }
    }
    
    // 객체에 있는 InjectAttribute 대상에 대해 의존성 주입
    public void Inject<T>(T target)
    {
        // 필드 처리
        var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            if (field.GetCustomAttribute<InjectAttribute>() != null && field.IsInitOnly == false)
            {
                object dependency = Resolve(field.FieldType);
                field.SetValue(target, dependency);
            }
        }

        // 프로퍼티 처리 (Setter가 있는 경우)
        var properties = target.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<InjectAttribute>() != null && property.CanWrite)
            {
                object dependency = Resolve(property.PropertyType);
                property.SetValue(target, dependency);
            }
        }
    }
    
}