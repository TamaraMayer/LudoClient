using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string playerID;

    public List<Stone> stones;

    public Player()
    {
        stones = new List<Stone>();
    }

    public void MakeNewMove()
    {
        //Check if stones on field
        //Roll dice
        //Evaluate possible Moves
        //Ask what move to Make
        //make move + evaluate for actual kick
        //send to server
    }

    public void MakeReceivedMove(int stoneID, int steps)
    {
        Stone stone = stones.Find((s) => s.StoneID == stoneID);

        stone.steps = steps;
    }
}
