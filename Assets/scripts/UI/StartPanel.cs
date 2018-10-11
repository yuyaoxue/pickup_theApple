using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
		
	}

    public void BtnStartClickHandle()
    {
        SceneManager.LoadScene(GameConst.scene_inGame);
    }
}
