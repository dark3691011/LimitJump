using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reStartbtn : MonoBehaviour
{
	private int loadS;
    // Start is called before the first frame update
    void Start()
    {
        loadS = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    public void reStart()
    {
        SceneManager.LoadScene(loadS);
    }
}
