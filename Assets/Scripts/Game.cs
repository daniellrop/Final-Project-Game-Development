using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }



    void Start()
    {
        
    }

    int currentTarget = 0;
    public void IsGameComplete()
    {
        currentTarget++;
        if (currentTarget >= 5)
        {
            UI.Instance.ShowGameWon();
        }
        else UI.Instance.Counter(currentTarget);
    }
   
}
