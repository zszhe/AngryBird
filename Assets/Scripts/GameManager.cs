using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Bird> birds;
    public List<Pigs> pigs;

    public static GameManager _instance;

    private Vector3 originPos;

    public GameObject lose;
    public GameObject win;

    void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
    }

    void Start()
    {
        Choose();
    }

    void Choose()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
                birds[i].done = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
                birds[i].done = false;
            }

        }
    }

    public void NextBird()
    {
        if(pigs .Count > 0)
        {
            if(birds .Count > 0)
            {
                //下一只
                Choose();
            }
            else
            {
                //输了
                lose.SetActive(true);
            }
        }
        else
        {
            //赢了
            win.SetActive(true);
        }
    }

    public void ShowStar()
    {

    }
}
