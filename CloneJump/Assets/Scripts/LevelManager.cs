using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    //UI
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;
    [SerializeField] private RawImage lvlBar;
    //
    private Vector2 lvlBarValue;
    //XP
    private float nextLevelXp = 510;
    private float currentXp = 0;
    private float xp = 12;
    //
    private int level;
    private int nextLevel;
    private float rateValue;
    private void Start() 
    {
        startGame();
        lvlBarValue = lvlBar.rectTransform.sizeDelta;
        rateValue = 560 / 100;
    }
    private void Update()
    {
        upLevel();
    }
    public void AddXP()
    {
        currentXp += xp * rateValue ;
        updateXpUI(currentXp);
    }
    private void upLevel()
    {
        if (currentXp >= nextLevelXp)
        {
            currentXp = 0;
            level += 1;
            nextLevel += 1;      
           updateXpUI(currentXp);
        }
    }
    private void updateXpUI(float _currentXp)
    {
        lvlBar.rectTransform.sizeDelta = new Vector2( _currentXp,20);
        levelText.text = level.ToString();
        nextLevelText.text = nextLevel.ToString();
    }

    private void startGame()
    {
       if (!SaveLoadSystem.Load())
       {
            level = System.Convert.ToInt32(levelText.text);
            nextLevel = System.Convert.ToInt32(nextLevelText.text);
       }
       else
       {
            level = SaveLoadSystem.level;
            nextLevel = SaveLoadSystem.nextLevel;
            currentXp = SaveLoadSystem.xp;
            updateXpUI(currentXp);
       }
    }
    public void SaveGame()
    {
        SaveLoadSystem.level = System.Convert.ToInt32(levelText.text);
        SaveLoadSystem.nextLevel = System.Convert.ToInt32(nextLevelText.text);
        SaveLoadSystem.xp = currentXp;
        SaveLoadSystem.Save();
    }
    public void restartGame()
    {
        SaveGame();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        UIManager.endPanelisOpen = false;
    }
}