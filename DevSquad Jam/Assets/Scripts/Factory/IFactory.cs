/// <summary>
/// Factory
/// </summary>
/// <typeparam name="T">Specifies the type to create</typeparam>
public interface IFactory<T>
{
    T Create();
}