using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	void OnEnable()
	{
		
	}
	
	void OnDisable()
	{
		
	}
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        }
	}
}
