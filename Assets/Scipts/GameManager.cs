using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager GetInstance() { return instance; }
    //Links
    private UIController _UIController;
    private LocationController _LocationController;
    private SaveSystem _SaveSystem;
    //Data
    private int _Points;
    private bool _isFirstTap;
    private int _CurrentComplexityId;
    [Header("Data")]
    [SerializeField] private Bird _Bird;
    private void Awake()
    {
        instance = this;
        _UIController = GetComponent<UIController>();
        _LocationController = GetComponent<LocationController>();
        _SaveSystem = GetComponent<SaveSystem>();
        Application.targetFrameRate = 120;
    }
    private void Start()
    {
        LoadData();
        Restart();
    }
    public void PlayButton()
    {
        _UIController.OpenPlayWin();
    }

    public void Tap()
    {
        if (_isFirstTap)
        {
            _Bird.Activate();
            _isFirstTap = false;
            _LocationController.StartMovement();
        }
        _Bird.Jump();
        SoundController.GetInstance().PlayJumpSound();
    }
    public void GameOver()
    {
        _UIController.UpdateGameOverScoreText(_Points);
        _UIController.OpenGameOverWin();
        _LocationController.StopMovement();
        SoundController.GetInstance().PlayHitSound();
    }
    public void Restart()
    {
        Debug.Log("Restared!");
        _UIController.OpenMainMenu();
        _Bird.Respawn();
        _Points = 0;
        _isFirstTap = true;
        _LocationController.Restart();
        _UIController.UpdatePlayWinScoreText(0);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        _UIController.OpenPauseWin();
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        _UIController.OpenPlayWin();
    }
    public void AddPoint()
    {
        _Points++;
        _UIController.UpdatePlayWinScoreText(_Points);
        SoundController.GetInstance().PlayScoreSound();
    }
    public void ChangeComplexity()
    {
        _CurrentComplexityId = _UIController.GetComplexityId();
        _LocationController.ChangeComplexity(_CurrentComplexityId);
        _SaveSystem.SaveComplexityID(_CurrentComplexityId);
    }
    private void LoadData()
    {
        //Complexity load
        _CurrentComplexityId = _SaveSystem.LoadComplexityID();
        _LocationController.ChangeComplexity(_CurrentComplexityId);
        _UIController.UpdateDropDown(_CurrentComplexityId);

        //SoundValue
        bool isMute = _SaveSystem.LoadMuteState();
        if (isMute)
        {
            SoundController.GetInstance().Mute();
            _UIController.TurnOnUnmuteButton();
        }
        else
        {
            SoundController.GetInstance().Unmute();
            _UIController.TurnOnMuteButton();
        }
    }
}
