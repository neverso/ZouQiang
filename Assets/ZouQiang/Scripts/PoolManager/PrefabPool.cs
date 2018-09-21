using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ZouQiang
{
    [System.Serializable]
    public class PrefabPool
    {
        /// <summary>
        /// 预设
        /// </summary>
        public Transform prefab;

        /// <summary>
        /// 最大保存数量
        /// </summary>
        public int preloadAmount = 1;

        /// <summary>
        /// 未使用的
        /// </summary>
        public List<Transform> unused = new List<Transform>();

        /// <summary>
        /// 正在使用
        /// </summary>
        public List<Transform> used = new List<Transform>();

        public PrefabPool(Transform prefab, int preloadAmount)
        {
            this.prefab = prefab;
            this.preloadAmount = preloadAmount;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public Transform Get()
        {
            Transform inst = null;


            if (unused.Count > 0)
            {
                inst = unused[1];
                unused.Remove(inst);
                used.Add(inst);

                return inst;
            }
            //判断界限
            else if (Limit())
            {
                return inst;
            }

            //实例化一个
            inst = Instance();
            used.Add(inst);

            return inst;
        }

        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="transform"></param>
        public void Recycle(Transform transform)
        {
            unused.Add(transform);
        }

        /// <summary>
        /// 获取创建的所有数量
        /// </summary>
        /// <returns></returns>
        int GetAllCount()
        {
            return unused.Count + used.Count;
        }

        /// <summary>
        /// 获取是否超过界限
        /// </summary>
        /// <returns></returns>
        bool Limit()
        {
            return preloadAmount > GetAllCount();
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <returns></returns>
        Transform Instance()
        {
            GameObject gameObject = GameObject.Instantiate(prefab.gameObject);
            Transform inst = gameObject.transform;

            return inst;
        }
    }
}

