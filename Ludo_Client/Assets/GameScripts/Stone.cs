using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Transform originalHouseField;
    public int StoneID
    {
        get
        {
            return stoneID;
        }
    }
    public Route currentRoute;

    public int routePosition;

    public int steps;

    public bool isMoving;

    [SerializeField]
    private int stoneID;

    void Start()
    {
        stoneID = int.Parse(this.name[this.name.Length - 1].ToString());
    }

    //TODO whole method more or less for testing
    public void StartMove()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        //{
        if (!isMoving)
        {
            steps = Random.Range(1, 3);
            Debug.Log("Stone (Blue) Rolled: " + steps);

            //StartCoroutine(Move());

            //todo: only for testing
            steps = 5;

            if (routePosition + steps < currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("Rolled number too high");
            }
        }
    }

    public bool EvaluateMovePossible()
    {
        if (routePosition + steps < currentRoute.childNodeList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            Vector3 nextPos;

            nextPos = currentRoute.childNodeList[routePosition + 1].position;

            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }

        isMoving = false;
    }

    public bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
