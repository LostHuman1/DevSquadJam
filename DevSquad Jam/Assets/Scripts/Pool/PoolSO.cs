using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic pool that generates members of type T on-demand via a factory.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PoolSO<T> : ScriptableObject, IPool<T>
{
    protected readonly Stack<T> Available = new Stack<T>();

    /// <summary>
    /// The factory which will be used to create
    /// </summary>
    public abstract IFactory<T> Factory { get; set; }
    protected bool HasBeenPrewarmed { get; set; }

    protected virtual T Create()
    {
        return Factory.Create();
    }

    /// <summary>
    /// Prewarm the pool
    /// </summary>
    /// <param name="num"></param>
    public virtual void Prewarm(int num)
    {
        if (HasBeenPrewarmed)
        {
            Debug.LogWarning($"Pool {name} has already been prewarmed.");
            return;
        }
        for (int i = 0; i < num; i++)
        {
            Available.Push(Create());
        }
        HasBeenPrewarmed = true;
    }

    /// <summary>
    /// Request a <typeparamref name="T"/> from pull
    /// </summary>
    /// <returns><typeparamref name="T"/></returns>
    public virtual T Request()
    {
        return Available.Count > 0 ? Available.Pop() : Create();
    }

    /// <summary>
    /// Returns a <typeparamref name="T"/> to the pool.
    /// </summary>
    /// <param name="member">The <typeparamref name="T"/></param>
    public virtual void Return(T member)
    {
        Available.Push(member);
    }

    /// <summary>
    /// Returns a <typeparamref name="T"/> collection to the pool.
    /// </summary>
    /// <param name="members">The <typeparamref name="T"/> collection to return.</param>
    public virtual void Return(IEnumerable<T> members)
    {
        foreach (T member in members)
        {
            Return(member);
        }
    }

    public virtual void OnDisable()
    {
        Available.Clear();
    }
}
