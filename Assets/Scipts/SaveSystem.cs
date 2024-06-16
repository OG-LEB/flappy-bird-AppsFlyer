using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string _ComplexityDataKey = "ComplexityID";
    private string _MuteStateKey = "MuteState";
    public void SaveComplexityID(int complexityID) 
    {
        PlayerPrefs.SetInt(_ComplexityDataKey, complexityID);
    }
    public int LoadComplexityID() 
    { 
        return PlayerPrefs.GetInt(_ComplexityDataKey); 
    }
    public void SaveMuteState(bool value) 
    {
        if (value)
        {
            PlayerPrefs.SetInt(_MuteStateKey, 1);
        }
        else
        {
            PlayerPrefs.SetInt(_MuteStateKey, 0);
        }
    }
    public bool LoadMuteState() 
    {
        int value = PlayerPrefs.GetInt(_MuteStateKey);
        if (value == 1)
            return true;
        else
            return false;
    }
}
