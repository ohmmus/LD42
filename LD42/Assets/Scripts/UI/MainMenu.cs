using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private ShipBehaviorController _ShipController = null;
    public Text SpacebarHelpText = null;
    public Text PitchHelpText = null;
    public Text StartGameHelpText = null;
    public Image StartImage = null;
    
	void Start () 
	{
        _ShipController = GetComponent<ShipBehaviorController>();
    }

    void Update () 
	{
        SpacebarHelpText.enabled = !TimeAuthority.timeFrozen;
        PitchHelpText.enabled = TimeAuthority.timeFrozen;
        StartImage.enabled = _ShipController._PitchAngle < 0 ;
        StartGameHelpText.enabled = false;
        StartImage.color = Color.white;

        if (_ShipController._PitchAngle < -20 && Input.GetKey(KeyCode.Space))
        {
            SpacebarHelpText.enabled = false;
            PitchHelpText.enabled = false;
            StartGameHelpText.enabled = true;
            StartImage.color = Color.green;
        }

        if (_ShipController._PitchAngle < -20 && Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        }
    }
}
