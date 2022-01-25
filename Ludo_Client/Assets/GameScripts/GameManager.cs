using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

public class GameManager : MonoBehaviour
{
    public HubConnection Connection;

    string myPlayerID_ConnectionID;

    public List<Stone> blueStones;
    public List<Stone> greenStones;
    public List<Stone> redStones;
    public List<Stone> yellowStones;


    // Start is called before the first frame update
    void Start()
    {
        //TODO some starting things :D xD

        //TODO: only for testing
        //SetColor(stone);
        //SetColor(stone2);

        //StartCoroutine(MoveToStart(stone));


        Debug.Log("Start done");
    }

    private void SetColor(Stone stone)
    {
        Renderer[] test = stone.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in test)
        {
            r.material.color = Color.green;
        }
    }

    void Update()
    {
        //Brauch ma glaub i ned
    }


    IEnumerator CheckForKick(Stone stone)
    {
        while (stone.isMoving)
        {
            yield return new WaitForSeconds(0.5f);
        }

        //if (stone.currentRoute.childNodeList[stone.routePosition].name == stone2.currentRoute.childNodeList[stone2.routePosition].name)
        //{
        //    Debug.Log("Blue got kicked by Red on " + stone.currentRoute.childNodeList[stone.routePosition].name);
        //    UnityEditor.EditorApplication.ExitPlaymode();
        //    //Application.Quit();
        //}
    }

    IEnumerator MoveToStart(Stone stone)
    {
        stone.isMoving = true;
        stone.gameObject.SetActive(false);

        // I think that start field is 4, should be
        while (stone.MoveToNextNode(stone.currentRoute.childNodeList[4].position))
        {
            yield return null;
        }

        stone.routePosition = 4;
        stone.gameObject.SetActive(true);
        stone.isMoving = false;

        //TODO only for testing:
        // stone.StartMove();
    }

    private void Move(Stone stone, int steps)
    {


        stone.StartMove();
    }

    //Sollt schon so passen :D
    IEnumerator GotKicked(Stone stone)
    {
        while (stone.isMoving)
        {
            yield return new WaitForSeconds(0.1f);
        }

        stone.gameObject.SetActive(false);

        while (stone.MoveToNextNode(stone.originalHouseField.position))
        {
            yield return null;
        }

        stone.gameObject.SetActive(true);
    }
}
