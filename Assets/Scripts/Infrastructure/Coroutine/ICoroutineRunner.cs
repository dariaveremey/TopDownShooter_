using System.Collections;
using TDS.Assets.Infrastructure.ServicesContainer;

namespace TDS.Assets.Infrastructure.Coroutine
{
    public interface ICoroutineRunner:IService
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator routine);
    }
}