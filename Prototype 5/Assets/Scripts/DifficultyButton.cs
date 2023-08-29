using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManager;
    public int difficulty; 
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        gameObject.transform.parent.gameObject.SetActive(false); 
        gameManager.StartGame(difficulty);
    }
}
