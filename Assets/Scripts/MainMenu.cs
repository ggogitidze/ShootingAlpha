using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame updatepub
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void delayLoad(){
        Invoke("PlayGame", 0.5f);
    }
    
}
