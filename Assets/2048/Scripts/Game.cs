using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Game : MainBase
{
    public int boardSize = 5;
    public GameType gameType = GameType.Powers_2;

    GameController gameController = new GameController();

    void Awake()
    {
        InitBase();
    }

    // Use this for initialization
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 重置游戏
    /// </summary>
    public void ResetGame()
    {
        gameController.ResetGame(boardSize, gameType);
    }

    public void drag()
    {

    }









}
