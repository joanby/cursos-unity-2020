using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditorInternal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    private const string MAX_SCORE = "MAX_SCORE";

    
    public enum GameState
    {
         loading,
         inGame,
         gameOver
    }

    public GameState gameState;
    
    public List<GameObject> targetPrefabs;

    private float spawnRate = 1.5f;
    
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    
    private int _score;
    private int Score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 99999);
        }
        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOverText;

    public GameObject titleScreen;

    private int numberOfLives = 4;
    public List<GameObject> lives;
    
    private void Start()
    {
        ShowMaxScore();
    }

    /// <summary>
    /// Método que inicia la partida cambiado el valor del estado del juego
    /// </summary>
    /// <param name="difficulty">Número entero que indica el grado de dificultad del juego</param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);

        //x op= y <-> x = x op y
        spawnRate /= difficulty;
        numberOfLives -= difficulty;

        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        

        StartCoroutine(SpawnTarget());

        Score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }



    /// <summary>
    /// Actualiza la puntuación y lo muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreText.text = "Score: \n" + Score;
    }

    
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Max Score: \n" + maxScore;
    }

    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (Score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, Score);
            //TODO: Si hay nueva puntuación máxima, lanzar cohetes
        } 
        
    }
    public void GameOver()
    {

        numberOfLives--;

        if (numberOfLives>=0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        
        
        if (numberOfLives<=0)
        {
            SetMaxScore();
        
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
