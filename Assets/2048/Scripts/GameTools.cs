using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTools
{
    /// <summary>
    /// 随机生成数字
    /// </summary>
    /// <param name="allGrid">棋盘格子</param>
    /// <param name="boardSize">棋盘大小</param>
    /// <param name="quantity">生成数量</param>
    /// <param name="number">数字</param>
    public static void RandomBuildNumber(List<GameNumber> allNumber, Grid[,] allGrid, int boardSize, int number, int quantity)
    {
        if (allNumber == null || allGrid == null || allGrid.Length != boardSize * boardSize || number <= 0 || quantity <= 0)
        {
            return;
        }

        for (int i = 0; i < quantity; i++)
        {
            //List<Grid> listGrid = GetEmptyGrid(allGrid, boardSize);

            ////获取一个随机数
            //int random = Random.Range(0, listGrid.Count + 1);

            //Grid grid = listGrid[random];

            //GameNumber numberComponent = grid.gameObject.AddComponent<GameNumber>();
            //numberComponent.Init(number);

            //allNumber.Add(numberComponent);
        }
    }


    /// <summary>
    /// 获取空的格子
    /// </summary>
    /// <param name="allGrid">棋盘格子</param>
    /// <param name="boardSize">棋盘大小</param>
    /// <returns></returns>
    public static List<Grid> GetEmptyGrid(Grid[,] allGrid, int boardSize)
    {
        List<Grid> listGrid = new List<Grid>();

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Grid grid = allGrid[i, j];
                //if (grid.number == null)
                //{
                //    listGrid.Add(grid);
                //}
            }
        }

        return listGrid;
    }

    /// <summary>
    /// 获取所有的分数
    /// </summary>
    /// <param name="allNumber"></param>
    /// <returns></returns>
    public static int GetAllScore(List<GameNumber> allNumber)
    {
        int score = 0;

        if (allNumber == null)
        {
            return score;
        }

        for (int i = 0; i < allNumber.Count; i++)
        {
            GameNumber number = allNumber[i];
            score += number.Number;
        }

        return score;
    }

    public static void MoveLeft(List<GameNumber> allNumber, Grid[,] allGrid, int boardSize)
    {
        if (allNumber == null || allGrid == null || allGrid.Length != boardSize * boardSize)
        {
            return;
        }


    }

    /// <summary>
    /// 合并一排
    /// </summary>
    /// <param name="listGrid"></param>
    public static void Unites(List<Grid> listGrid)
    {
        if (listGrid == null)
        {
            return;
        }

        for (int i = 1; i < listGrid.Count; i++)
        {
            Grid lastGrid = listGrid[i - 1];


            //上一个格子为空
            //if (lastGrid.number == null)
            {


            }
            Grid grid = listGrid[i];


        }
    }

    /// <summary>
    /// 合并格子
    /// </summary>
    /// <param name="lastGrid"></param>
    /// <param name="currentGrid"></param>
    public static void Unites(List<Grid> listGrid, int index, Grid currentGrid)
    {
        //数据错误
        if (listGrid == null || currentGrid == null)
        {
            return;
        }

        for (int i = index - 1; i < 0; i--)
        {
            Grid lastGrid = listGrid[i];

            NumberMoveType numberMoveType = Unites(lastGrid, currentGrid);

            switch (numberMoveType)
            {
                case NumberMoveType.Empty:
                    return;
                case NumberMoveType.Move://添加移动动画数据
                    break;
                case NumberMoveType.End:
                    return;
                case NumberMoveType.Bind:
                    {
                        //添加 合并动画数据

                        //上一个格子数字*2 当前格子制空
                        //lastGrid.number.Unites();
                        //currentGrid.number = null;
                    }
                    return;
            }

        }
    }


    public static NumberMoveType Unites(Grid lastGrid, Grid currentGrid)
    {
        ////数据错误
        //if (lastGrid == null || currentGrid == null)
        //{
        //    return NumberMoveType.Empty;
        //}
        ////当前格子没数字
        //if (currentGrid.number == null)
        //{
        //    return NumberMoveType.Empty;
        //}
        ////上一个格子没数字  当前格子有数字 移动
        //if (lastGrid.number == null && currentGrid.number != null)
        //{
        //    return NumberMoveType.Move;
        //}
        ////当前和上一个格子数字相同
        //if (lastGrid.number != null && currentGrid.number != null && lastGrid.number.Number == currentGrid.number.Number)
        //{
        //    return NumberMoveType.Bind;
        //}
        ////当前和上一个格子数字不同
        //if (lastGrid.number != null && currentGrid.number != null && lastGrid.number.Number != currentGrid.number.Number)
        //{
        //    return NumberMoveType.End;
        //}

        return NumberMoveType.Empty;
    }

}
