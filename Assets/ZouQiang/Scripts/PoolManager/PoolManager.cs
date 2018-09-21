using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ZouQiang
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        public Dictionary<string, PrefabPool> AllPrefabPool = new Dictionary<string, PrefabPool>();
        public List<PrefabPool> prefabPoolOption = new List<PrefabPool>();


        public void CreationPool(string name, Transform prefab, int preloadAmount)
        {
            if (AllPrefabPool.ContainsKey(name))
            {
                Debug.LogError("创建重复的对象池:"+ name);
                return;
            }

            AllPrefabPool.Add(name, new PrefabPool(prefab, preloadAmount));
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


