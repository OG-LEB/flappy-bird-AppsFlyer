using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController GetInstance() {return instance; }
    private SaveSystem _SaveSystem;


    [SerializeField] private AudioSource UISound;
    [SerializeField] private AudioSource ScoreSound;
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource HitSound;
    private bool isMuted;
    private void Awake()
    {
        instance = this;
        _SaveSystem = GetComponent<SaveSystem>();
    }
    public void PlayUISound() { if(!isMuted)UISound.Play(); }
    public void PlayScoreSound() { if (!isMuted) ScoreSound.Play(); }
    public void PlayJumpSound() { if (!isMuted) JumpSound.Play(); }
    public void PlayHitSound() { if (!isMuted) HitSound.Play(); }
    public void Mute() 
    {
        isMuted = true;
        UISound.Stop();
        ScoreSound.Stop();
        JumpSound.Stop();
        HitSound.Stop();
        _SaveSystem.SaveMuteState(isMuted);
    }
    public void Unmute()
    {
        isMuted = false;
        _SaveSystem.SaveMuteState(isMuted);
    }
}
