﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ZouQiang
{
    public class ResourcesManager : MonoSingleton<ResourcesManager> 
    {

        /// <summary>
        /// 加载对象.
        /// </summary>
        /// <param name="assetPaths">路径格式"Assets/Resources/a1.prefab"</param>
        /// <returns></returns>
        public Object Load(string assetPaths)
        {
            //float startTime = Time.realtimeSinceStartup;

            Object prefab = null;

            //prefab = UnityEditor.AssetDatabase.LoadMainAssetAtPath(assetPaths);

            //float elapsedTime = Time.realtimeSinceStartup - startTime;

            ////Debug.Log(assetPaths + (prefab == null ? " was not" : " was") + " loaded successfully in " + elapsedTime + " seconds");

            return prefab;
        }



    }
}


