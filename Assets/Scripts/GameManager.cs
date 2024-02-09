using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerBehaviour Player;
    public StopwatchBehaviour Stopwatch;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI SurvivalTime;
    public GameObject DeathWindow;

    private float _cooldownMulti;
    private float _speedMulti;
    private bool _lockIncreased;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        _cooldownMulti = 1.2f;
        _speedMulti = 0.8f;
        _lockIncreased = false;
        DeathWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Mathf.Round(Stopwatch.GetCurrentTime() * 100) / 100;
        Timer.text = currentTime.ToString();
        if(!_lockIncreased) StartCoroutine(IncreasedMulti());
    }

    private IEnumerator IncreasedMulti()
    {
        _lockIncreased = true;
        _cooldownMulti -= 0.2f;
        _speedMulti += 0.2f;
        yield return new WaitForSeconds(20);
        _lockIncreased = false;
    }

    public float GetCooldownMulti()
    {
        return _cooldownMulti;
    }

    public float GetSpeedMulti()
    {
        return _speedMulti;
    }

    public void GameOver()
    {
        Player.Die();
        StartCoroutine(ShowDeathWindow());
    }

    IEnumerator ShowDeathWindow()
    {
        Stopwatch.StopTimer();
        yield return new WaitForSeconds(2);
        SurvivalTime.text = $"{(Mathf.Round(Stopwatch.GetCurrentTime() * 100) / 100).ToString()} secondes";
        DeathWindow.SetActive(true);
    }

    public void PlayAgain()
    {
        DeathWindow.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
