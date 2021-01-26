using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public Text GameOverText;
    public Camera Camera;
    public Animator ButtonRestart;
    
    private int _i = 0;
    private SmoothFollow _smoothFollow;
    private static readonly int New = Animator.StringToHash("New");

    // Start is called before the first frame update
    void Start()
    {
        _smoothFollow = Camera.GetComponent<SmoothFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(ButtonRestart.GetInteger("RestartButtonShow"));
    }

    public void IncrementalScore()
    {
        _i++;
        ScoreText.text = $"Score: {_i}";
    }

    public void CheckGameOver()
    {
        _smoothFollow.enabled = false;
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = $"Game Over!";
        ButtonRestart.SetInteger("RestartButtonShow", 0);
    }

    public void Finish()
    {
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = $"Сongratulations!";
    }

    public void RestartGameButton()
    {
        ButtonRestart.SetInteger("RestartButtonHide", 1);
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    
}
