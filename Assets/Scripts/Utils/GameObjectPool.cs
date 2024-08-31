using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utils
{

    public class GameObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T prototype;
        private Stack<T> pool = new Stack<T>();

        public void Push(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
            pool.Push(obj);
        }
        public T Pop()
        {
            T returnObject = null;
            if (pool.Count == 0)
            {
                Push(Instantiate(prototype, transform));
            }
            returnObject = pool.Pop();
            returnObject.gameObject.SetActive(true);
            returnObject.transform.SetParent(null);
            return returnObject;
        }

    }
}