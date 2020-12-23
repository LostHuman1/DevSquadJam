using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "NewSoundEmitterPool", menuName = "Pool/SoundEmitterPool")]

public class SoundEmitterPoolSO : ComponentPoolISO<SoundEmitter>
{
    [SerializeField]
    private SoundEmitterFactorySO factory;
    public override IFactory<SoundEmitter> Factory
    {
        get
        {
            return factory;
        }
        set
        {
            factory = value as SoundEmitterFactorySO;
        }
    }
}
