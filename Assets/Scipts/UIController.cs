using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI Windows")]
    [SerializeField] private GameObject MainMenuWin;
    [SerializeField] private GameObject PlayWin;
    [SerializeField] private GameObject GameOverWin;
    [SerializeField] private GameObject PauseWin;

    [Space]
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI PlayWinScoreText;
    [SerializeField] private TextMeshProUGUI GameOverScoreText;
    [SerializeField] private TMP_Dropdown ComplexityDropDown;
    [SerializeField] private GameObject MuteButtonObj;
    [SerializeField] private GameObject UnmuteButtonObj;
    [SerializeField] private GameObject ConversioDataWin;
    [SerializeField] private TextMeshProUGUI ConversionDataText;


    public void OpenConversionDataWin(string output) 
    {
        ConversionDataText.text = output;
        ConversioDataWin.SetActive(true);
    }
    public void CloseConversionDataWin() 
    {
        ConversioDataWin.SetActive(false);
    }
    public void OpenMainMenu() 
    {
        MainMenuWin.SetActive(true);
        PlayWin.SetActive(false);
        GameOverWin.SetActive(false);
        PauseWin.SetActive(false);
    }
    public void OpenPlayWin() 
    {
        MainMenuWin.SetActive(false);
        PauseWin.SetActive(false);
        PlayWin.SetActive(true);
    }
    public void OpenGameOverWin() 
    {
        PlayWin.SetActive(false);
        GameOverWin.SetActive(true);
    }
    public void OpenPauseWin() 
    {
        PlayWin.SetActive(false);
        PauseWin.SetActive(true);
    }
    public void UpdatePlayWinScoreText(int value) 
    {
        PlayWinScoreText.text = value.ToString();
    }
    public void UpdateGameOverScoreText(int value)
    {
        GameOverScoreText.text = $"Score: {value}";
    }
    public int GetComplexityId() { return ComplexityDropDown.value; }
    public void UpdateDropDown(int value) 
    {
        ComplexityDropDown.value = value;
    }
    public void TurnOnUnmuteButton() 
    {
        UnmuteButtonObj.SetActive(true);
        MuteButtonObj.SetActive(false);
    }
    public void TurnOnMuteButton() 
    {
        UnmuteButtonObj.SetActive(false);
        MuteButtonObj.SetActive(true);
    }
    
}
