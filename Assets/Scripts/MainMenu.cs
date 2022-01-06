using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Button playButton;
    public Button quitButton;
	public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

	// Use this for initialization
	void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
        quitButton.onClick.AddListener(QuitMaze);
    }

	public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
        if (colorblindMode.isOn)
        {
            goalMat.color = Color.blue;
            trapMat.color = new Color32(255, 112, 0, 1);
        }
        else
        {
            goalMat.color = Color.green;
            trapMat.color = Color.red;
        }
    }

	// Ends the game...
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
