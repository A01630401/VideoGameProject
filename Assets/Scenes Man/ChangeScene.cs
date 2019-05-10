using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private int difficulty;
    private bool destroyFlag = false;
    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void loadsScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void loadDifficulty(int difficulty) {
        if (!destroyFlag) {
            DontDestroyOnLoad(this.gameObject);
            destroyFlag = true;
        }
        this.gameObject.GetComponent<ChangeScene>().difficulty = difficulty;
    }

    public int getDifficulty() {
        return this.difficulty;
    }

}
