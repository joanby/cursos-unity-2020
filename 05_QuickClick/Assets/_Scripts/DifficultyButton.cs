using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager gameManager;

    [Range(1,3)]
    public int difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log("El botón " + gameObject.name + " ha sido pulsado.");
        gameManager.StartGame(difficulty);
    }
    
}
