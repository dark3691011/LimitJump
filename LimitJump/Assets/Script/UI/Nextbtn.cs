using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextbtn : MonoBehaviour
{
    private int loadS;
    // Start is called before the first frame update
    void Start()
    {
        loadS = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    public void next()
    {
        SceneManager.LoadScene(loadS);
    }
}
