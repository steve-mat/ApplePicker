using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePickerMenu : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void EasyDifficulty() {
        //SceneManager.LoadScene();
    }

    public void NormalDifficulty() {
        //SceneManager.LoadScene();
    }

    public void HardDifficulty() {
        //SceneManager.LoadScene();
    }



}

