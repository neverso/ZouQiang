using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏数字
/// </summary>
public class GameNumber : MonoBehaviour
{
    /// <summary>
    /// 数字
    /// </summary>
    private int number;
    public int Number { get { return number; } }


    /// <summary>
    /// 移动时间
    /// </summary>
    public float moveTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="number"></param>
    public void Init(int number)
    {
        this.number = number;
        //位置
    }

    /// <summary>
    /// 清理
    /// </summary>
    public void Clear()
    {
        number = 0;
        //隐藏
    }

    /// <summary>
    /// 移动
    /// </summary>
    public void Move()
    {
        //播放动画
    }

    /// <summary>
    /// 合并
    /// </summary>
    public void Unites()
    {
        number += number;
        //播放动画
    }




}
