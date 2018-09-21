using UnityEngine;
using System.Collections;

/// <summary>
/// 该类由 CreateBaseClassTool 自动创建，请勿修改！
/// </summary>
public class MainBase : MonoBehaviour
{
    protected UIWidget bg;
    protected UIGrid Grid;

    public void InitBase()
    {
        bg = transform.Find("bg").GetComponent<UIWidget>();
        Grid = transform.Find("Grid").GetComponent<UIGrid>();
    }
}
