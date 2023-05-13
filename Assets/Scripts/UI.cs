using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

    [SerializeField] GameObject objGameOver;
    [SerializeField] GameObject objGameWon;
    [SerializeField] TextMeshProUGUI txtCounter;

    void Start()
    {
        
    }

    public void Counter(int count)
    {
        txtCounter.text = count + " / 5";
    }

    public void ShowGameOver()
    {
        objGameOver.SetActive(true);
    }

    public void ShowGameWon()
    {
        objGameWon.SetActive(true);
    }

    public void BtnNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
