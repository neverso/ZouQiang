using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ZouQiang
{
    public class WindowManager : MonoSingleton<WindowManager>
    {
        static string mLayer = "UI";

        private GameObject uiRoot;

        Camera currentCamera;

        private Dictionary<string, GameObject> allWindow;


        public override void OnSingletonInit()
        {
            base.OnSingletonInit();


        }

        /// <summary>
        /// 当前最高的Panel层.
        /// </summary>
        public int DepthIndex = -1;

        public Camera CurrentCamera
        {
            get
            {
                return currentCamera;
            }

            set
            {
                currentCamera = value;
            }
        }

        void Awake()
        {
            CreateRoot();

            allWindow = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// 创建根目录.
        /// </summary>
        public void CreateRoot()
        {
            uiRoot = new GameObject("UIRoot");
            uiRoot.transform.SetParent(this.transform);

            UIRoot Root = uiRoot.AddComponent<UIRoot>();

            Rigidbody rigidbody = uiRoot.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                Destroy(rigidbody);
            }


            Root.scalingStyle = global::UIRoot.Scaling.Constrained;

            Root.manualWidth = 1024;
            Root.minimumHeight = 768;


            //需要计算屏幕分辨率 和 设计分辨率 的宽高比 来决定使用宽度适配还是高度适配
            float tmpScreenAspectRatio = (Screen.width * 1.0f) / Screen.height;
            float tmpDesignAspectRatio = 1024 / 768;
            if (tmpScreenAspectRatio < tmpDesignAspectRatio)
            {
                Root.fitWidth = true;
                Root.fitHeight = false;
            }
            else
            {
                Root.fitWidth = false;
                Root.fitHeight = true;
            }

            uiRoot.AddComponent<UIPanel>();

            GameObject UICameraObj = new GameObject("UICamera");
            UICameraObj.transform.SetParent(uiRoot.transform);

            CurrentCamera = UICameraObj.AddComponent<Camera>();

            //清除标识;
            CurrentCamera.clearFlags = CameraClearFlags.SolidColor;

            //设置为正交相机
            CurrentCamera.orthographic = true;

            CurrentCamera.orthographicSize = 1.0f;

            //camera.nearClipPlane = 0.0f;

            //相机到开始和结束渲染的距离;
            CurrentCamera.nearClipPlane = -50;

            CurrentCamera.farClipPlane = 50;

            //设置显示层;
            CurrentCamera.cullingMask = OnlyIncluding(LayerMask.NameToLayer(mLayer));

            UICamera uiCamera = UICameraObj.AddComponent<UICamera>();
        }

        private void Start()
        {
        }

        public static int OnlyIncluding(params int[] layers)
        {
            int mask = 0;
            for (int i = 0; i < layers.Length; i++)
            {
                mask |= 1 << layers[i];
            }
            return mask;
        }


        public GameObject OpenWindow(string varWindowPath)
        {
            //如果已经打开过了窗口;
            if (allWindow.ContainsKey(varWindowPath))
            {
                return null;
            }

            string WindowPath = "Assets/Resources/ui/" + varWindowPath + "/" + varWindowPath + ".prefab";

            GameObject prefab = ResourcesManager.Instance.Load(WindowPath) as GameObject;
            if (prefab == null)
            {
                Debug.LogError("WindowManager : OpenWindow() Obj == null varWindowPath : " + varWindowPath);
                return null;
            }

            Transform tempUI = prefab.transform.Find(varWindowPath);

            GameObject ui = GameObject.Instantiate(tempUI.gameObject) as GameObject;

            ui.transform.parent = uiRoot.transform;

            ui.transform.name = varWindowPath;

            allWindow.Add(varWindowPath, ui);

            SetLayer();

            SetPanelDepth();

            return ui;
        }



        public void CloseWindow(string varWindowPath)
        {
            if (allWindow.ContainsKey(varWindowPath) == false)
            {
                Debug.LogError("WindowManager : CloseWindow() varWindowPath : " + varWindowPath);

                return;
            }

            Destroy(allWindow[varWindowPath]);
        }

        /// <summary>
        /// 设置UI层级.
        /// </summary>
        void SetLayer()
        {
            NGUITools.SetLayer(this.gameObject, LayerMask.NameToLayer(mLayer));
        }

        /// <summary>
        /// 设置Panel深度.
        /// </summary>
        void SetPanelDepth()
        {
            //获取所有的Panel
            UIPanel[] tmpPanels = transform.GetComponentsInChildren<UIPanel>(true);

            //遍历Panel，Depth 递增
            for (int i = 0; i < tmpPanels.Length; i++)
            {
                tmpPanels[i].depth = 1 + i * 50;
            }

        }







        /// <summary>
        /// 获取NGUI坐标 根据屏幕坐标;
        /// </summary>
        /// <param name="varVec3"></param>
        /// <returns></returns>
        //public Vector3 GetPosition(Vector3 varVec3)
        //{
        //    Camera camera = Helper.GetComponent<Camera>(transform, "UIRoot/UICamera");
        //    if (camera == null)
        //    {
        //        Debug.LogError("WindowManager : GetPosition() camera == null");
        //        return Vector3.zero;
        //    }

        //    varVec3.z = 0;

        //    varVec3 = camera.WorldToScreenPoint(varVec3);

        //    varVec3.x -= (Screen.width / 2.0f);
        //    varVec3.y -= (Screen.height / 2.0f);


        //    return varVec3;
        //}

        /// <summary>
        /// 世界坐标转屏幕坐标.
        /// </summary>
        /// <param name="varVec3">transform的世界坐标为 transform.position</param>
        /// <returns></returns>
        public Vector3 WorldToScreenPoint(Vector3 varVec3)
        {
            varVec3.z = 0;

            varVec3 = currentCamera.WorldToScreenPoint(varVec3);

            return varVec3;
        }

    }
}

