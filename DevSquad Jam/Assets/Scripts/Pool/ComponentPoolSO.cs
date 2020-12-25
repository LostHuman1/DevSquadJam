using UnityEngine;
/// <summary>
/// Pool for Component types
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ComponentPoolISO<T> : PoolSO<T> where T : Component
{
    private Transform poolRoot;
    private Transform PoolRoot
    {
        get
        {
            if (poolRoot == null)
            {
                poolRoot = new GameObject(name).transform;
                poolRoot.SetParent(parent);
            }
            return poolRoot;
        }
    }
    private Transform parent;

    public void SetParent(Transform t)
    {
        parent = t;
        PoolRoot.SetParent(parent);
    }
    public override T Request()
    {
        T member = base.Request();
        member.gameObject.SetActive(true);
        return member;
    }
    public override void Return(T member)
    {
        member.transform.SetParent(PoolRoot.transform);
        member.gameObject.SetActive(false);
        base.Return(member);
    }
    protected override T Create()
    {
        T newMember = base.Create();
        newMember.transform.SetParent(PoolRoot.transform);
        newMember.gameObject.SetActive(false);
        return newMember;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        if(poolRoot != null)
        {
#if UNITY_EDITOR
            DestroyImmediate(poolRoot.gameObject);
#else
            Destroy(poolRoot.gameObject);
#endif
        }
    }
}