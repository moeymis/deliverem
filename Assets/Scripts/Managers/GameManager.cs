﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Attributes
    Vector2 startPosition; 
    ZuAnimation zuAnimation;
    #endregion
    private void Awake()
    {
        zuAnimation = GameObject.FindGameObjectWithTag("Zu").GetComponent<ZuAnimation>();
        GameState newState = new GameState("Assets/Readables/state1.txt");
        WorldManager.GenerateWorld(newState);
        Debug.Log(newState.GetStringHashcode());
        zuAnimation.transform.position = new Vector2(newState.ZuPosition.y + 0.5f, newState.ZuPosition.x + 0.5f);
    }

    void RunFinalPath(Stack<GameState> finalPath)
    {

    }

    private void Update()
    {
        KeyBoard();
    }
    void KeyBoard()
    {
        Vector2Int newPos = new Vector2Int(
            Mathf.RoundToInt(zuAnimation.transform.position.x - 0.5f),
            Mathf.RoundToInt(zuAnimation.transform.position.y - 0.5f)
            );
        if (Input.GetKeyDown(KeyCode.A))
        {
            newPos.x--;
            zuAnimation.Act(newPos);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            newPos.y--;
            zuAnimation.Act(newPos, Action.Deliver);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            newPos.x++;
            zuAnimation.Act(newPos);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            newPos.y++;
            zuAnimation.Act(newPos);
        }
    }
    static public bool isFinalState(GameState state)
    {
        return true; 
    }

}
