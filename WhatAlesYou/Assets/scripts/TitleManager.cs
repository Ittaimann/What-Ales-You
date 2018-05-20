using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

	public void StartGameButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SeanScene");
    }

}
