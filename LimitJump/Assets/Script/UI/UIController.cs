using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public GameObject Player;
	public Text txtJumpValue,txtLevel;
	public GameObject txtLose,txtWin;
	public GameObject btnReStart,btnNextLevel;


	int jumpValue;
	bool dead;
	bool completed;


    // Start is called before the first frame update
    void Start()
    {
        txtWin.SetActive(false);
        txtLose.SetActive(false);
        btnReStart.SetActive(false);
        btnNextLevel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for Jump value Player
        jumpValue = Player.GetComponent<PlayerControllerAndroid>().jumpValue;
        dead=Player.GetComponent<PlayerControllerAndroid>().dead;
        completed=Player.GetComponent<PlayerControllerAndroid>().completed;

        /*jumpValue = Player.GetComponent<PlayerController>().jumpValue;
        dead=Player.GetComponent<PlayerController>().dead;
        completed=Player.GetComponent<PlayerController>().completed;*/


        txtJumpValue.text="Have : "+ jumpValue +" Jump";

        // for level
        int numberScene = SceneManager.GetActiveScene().buildIndex;
        txtLevel.text = "Level : "+ numberScene;

        //for dead text player
        if(dead==true){
        	txtLose.SetActive(true);
        	btnReStart.SetActive(true);
        } else if (completed==true) {
        	txtWin.SetActive(true);
        	btnReStart.SetActive(true);
        	btnNextLevel.SetActive(true);
            int tmp = PlayerPrefs.GetInt("levelReached",1);
            if(tmp <numberScene+1){
        	   PlayerPrefs.SetInt("levelReached",numberScene+1);
            }
        }
    }
}
