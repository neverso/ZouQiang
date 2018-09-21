using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ZouQiang;

/// <summary>
/// 游戏类型
/// </summary>
public enum GameType
{
    /// <summary>
    /// 每次生成2个2
    /// </summary>
    Powers_2,
    /// <summary>
    /// 每次生成2个3
    /// </summary>
    Powers_3,
    /// <summary>
    /// 2、3间隔生成
    /// </summary>
    Fibonacci
}

/// <summary>
/// 游戏状态
/// </summary>
public enum GameState
{
    BuilduNumber,
    Move_Up,
    Move_Down,
    Move_Left,
    Move_Right,
    GameOver,
}

public enum NumberMoveType
{
    /// <summary>
    /// 空
    /// </summary>
    Empty,
    /// <summary>
    /// 移动
    /// </summary>
    Move,
    /// <summary>
    /// 结束
    /// </summary>
    End,
    /// <summary>
    /// 结合
    /// </summary>
    Bind,
}

/// <summary>
/// 游戏格子
/// </summary>
public class Grid
{
    public GameObject background;
    public GameNumber gameNumber;

}

/// <summary>
/// 游戏数据
/// </summary>
[System.Serializable]
public class GameModel
{
    /// <summary>
    /// 格子大小
    /// </summary>
    public int boardSize = 5;
    /// <summary>
    /// 游戏类型
    /// </summary>
    public GameType gameType = GameType.Powers_2;
    public bool gameType_Fibonacci = true;


    /// <summary>
    /// 所有的格子
    /// </summary>
    public Grid[,] allGrid;

    /// <summary>
    /// 所有的游戏数字
    /// </summary>
    public GameNumber[,] allGameNumber;


    PrefabPool backgroundPool;
    PrefabPool gameNumberPool;


    


}
