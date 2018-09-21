using UnityEngine;
using System.Collections;

public class GameController
{
    GameModel gameModel = new GameModel();

    /// <summary>
    /// 重置游戏
    /// </summary>
    public void ResetGame(int boardSize, GameType gameType)
    {
        gameModel.boardSize = boardSize;
        gameModel.gameType = gameType;
        gameModel.gameType_Fibonacci = true;


        //回收所有对象
        

    }

    public void SwitchGameState()
    {

    }


    void BuilduNumberState()
    {

    }



    /// <summary>
    /// 初始化游戏棋盘
    /// </summary>
    public void InitGame(Transform parent)
    {
        //allGrid = new Grid[boardSize, boardSize];

        //for (int i = 0; i < boardSize; i++)
        //{
        //    for (int j = 0; j < boardSize; j++)
        //    {
        //        string name = string.Format("{0}_{1}", i, j);
        //        GameObject gameobject = new GameObject(name);
        //        gameobject.transform.parent = parent;
        //        gameobject.transform.localPosition = Vector3.zero;
        //        gameobject.transform.localScale = Vector3.one;

        //        allGrid[i, j] = gameobject.AddComponent<Grid>();
        //    }
        //}
    }


    /// <summary>
    /// 随机生成数字
    /// </summary>
    public void RandomBuildNumber()
    {
        //switch (gameType)
        //{
        //    case GameType.Powers_2:
        //        GameTools.RandomBuildNumber(allNumber, allGrid, boardSize, 2, 2);
        //        break;
        //    case GameType.Powers_3:
        //        GameTools.RandomBuildNumber(allNumber, allGrid, boardSize, 3, 2);
        //        break;
        //    case GameType.Fibonacci:
        //        int number = 2;
        //        if (gameType_Fibonacci)
        //        {
        //            number = 2;
        //            gameType_Fibonacci = false;
        //        }
        //        else
        //        {
        //            number = 3;
        //            gameType_Fibonacci = true;
        //        }
        //        GameTools.RandomBuildNumber(allNumber, allGrid, boardSize, 1, number);
        //        break;
        //    default:
        //        break;
        //}
    }
}
