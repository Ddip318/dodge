using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recodrText;
    private float surviveTime;
    private bool isGameover;
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover){
            surviveTime += Time.deltaTime;
            timeText.text = "Time" + (int)surviveTime;
        }
        else{
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame(){
        isGameover = true;
        gameoverText.SetActive(true);
        float bestTime = PlayerPrefs.GetFloat("BestTime"); // Get할 값이 없으면 0을 가져옴

        if(surviveTime>bestTime){
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime",bestTime);
        }
        recodrText.text = "Best Time : "+(int)bestTime;
    }
}
