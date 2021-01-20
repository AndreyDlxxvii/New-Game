using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public Text GameOverText;
    public Camera Camera;
    private int _i = 0;

    private SmoothFollow _smoothFollow;

    // Start is called before the first frame update
    void Start()
    {
        _smoothFollow = Camera.GetComponent<SmoothFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void Finish()
    {
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = $"Сongratulations!";
    }
}
