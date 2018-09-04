using UnityEngine;
using UnityEditor;
using System.IO;

namespace ZouQiang
{
    public class AssetBundlesTool : Editor
    {
        /// <summary>
        /// 保存AssetBundles路径
        /// </summary>
        static string assetBundleSavePath = Application.dataPath + "/../AssetBundle";

        /// <summary>
        /// 设置资源名字
        /// </summary>
        [MenuItem("ZouQiang/AssetBundles/设置名字")]
        static void SetAssetBundleName()
        {
            string tmpStringPathR = Application.dataPath + "/R";

            //找到目录里所有文件
            string[] filesPash = Directory.GetFiles(tmpStringPathR, "*.*", SearchOption.AllDirectories);

            for (int i = 0; i < filesPash.Length; i++)
            {
                string filePash = filesPash[i];

                if (filePash.EndsWith(".meta")) continue;

                filePash = filePash.Replace('\\', '/');
                filePash = filePash.Replace(Application.dataPath, "Assets");

                AssetImporter tmpAssetImport = AssetImporter.GetAtPath(filePash);

                if (tmpAssetImport == null) continue;

                string assetBundleName = tmpAssetImport.assetPath.Replace("Assets/", "");

                tmpAssetImport.assetBundleName = assetBundleName;
            }

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();

            Debug.Log("SetAssetBundleName Succeed ");
        }

        [MenuItem("ZouQiang/AssetBundles/打包")]
        static void BuildAssetBundles()
        {
            //若文件夹不存在则新建文件夹  
            if (!Directory.Exists(assetBundleSavePath))
            {
                Directory.CreateDirectory(assetBundleSavePath);
            }

            //打包资源
            BuildPipeline.BuildAssetBundles(assetBundleSavePath, BuildAssetBundleOptions.DeterministicAssetBundle, EditorUserBuildSettings.activeBuildTarget);

            Debug.Log("BuildAssets Succeed ");
        }

    }
}


