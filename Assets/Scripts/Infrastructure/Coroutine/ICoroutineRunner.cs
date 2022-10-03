using System.Collections;

namespace TDS.Assets.Infrastructure
{
    public interface ICoroutineRunner:IService
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator routine);
    }
}