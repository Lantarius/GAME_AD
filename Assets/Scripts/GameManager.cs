using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public bool isGameActive { get; private set; }
    [SerializeField] AudioSource BackgroundMusic;
    [SerializeField] Image FadeScreen;
    float RestartTime = 2;
    void Start()
    {
        isGameActive = true;
        EventManager.Restart.AddListener(ResetGame);
        EventManager.StopGame.AddListener(StopGame);
        EventManager.StartGame.AddListener(StartGame);
        Time.timeScale = 1.5f;
    }
    public void StartGame()
    {
        isGameActive = true;
        BackgroundMusic.Play();
    }
    public void StopGame()
    {
        isGameActive = false;
        StartCoroutine(EndGame());
    }
    void ResetGame()
    {
        isGameActive = false;
        StartCoroutine(RestartGame());
    }
    IEnumerator StopMusic() 
    {
        for (float i = 1; i > 0; i -= 1f * Time.deltaTime / RestartTime)
        {
            BackgroundMusic.pitch = i;
            BackgroundMusic.volume = i;
            yield return null;
        }
        yield return null;
    }
    IEnumerator ResumeMusic()
    {
        for (float i = 0; i < 1; i += 1 * Time.deltaTime / RestartTime)
        {
            BackgroundMusic.pitch = i;
            BackgroundMusic.volume = i;
            yield return null;
        }
        yield return null;
    }
    IEnumerator RestartGame()
    {
        Color tmp = FadeScreen.color;
        StartCoroutine(StopMusic()); //ћузыка останавливаетс€
        for (float i = 0; i <= 1; i += 1 * Time.deltaTime / RestartTime)
        {
            tmp.a = i * 2;
            FadeScreen.color = tmp;//Ёкран темнеет
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//–еспаемс€
        StartCoroutine(ResumeMusic());//ћузыка востанавливаетс€
        for (float i = 1; i >= 0; i -= 1 * Time.deltaTime / RestartTime)
        {
            tmp.a = i;
            FadeScreen.color = tmp;//Ёкран про€сн€етс€
            yield return null;
        }
        isGameActive = true;//”правление снова у игрока
        yield return null;
    }
    IEnumerator EndGame()
    {
        Color tmp = FadeScreen.color;
        isGameActive = false;;
        for (float i = 0; i <= 0.9; i += 1 * Time.deltaTime)
        {
            tmp.a = i;
            FadeScreen.color = tmp;//Ёкран темнеет
            yield return null;
        }
        yield return null;
    }
}
