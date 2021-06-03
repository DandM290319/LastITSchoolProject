using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
            PlayerPrefs.SetString("Scene", SceneName);
        }
    }
}
