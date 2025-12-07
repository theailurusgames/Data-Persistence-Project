using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMenu : MonoBehaviour
{
    private UIMenu menuData;
    public TMP_InputField nameBox;
    public TMP_Text bestScoreText;

    private string playerName;
    private int bestScoreStored;
    private string bestScoreNameStored;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScoreStored = DataDB.Instance.bestScoreStored;
        bestScoreNameStored = DataDB.Instance.bestScoreNameStored;
        if (bestScoreStored == 0)
        {
            bestScoreText.text = "No Best Score";
        }
        else
        {
            bestScoreText.text = "Best Score:" + bestScoreNameStored + " : " + bestScoreStored;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButtonPressed()
    {
        string boxText = nameBox.text;
 
        if (boxText != "")
        {
            SceneManager.LoadScene(1);
            DataDB.Instance.playerName = boxText;
            //DataDB.Instance.nameBoxText = boxText;
        }
        else
        {
            Debug.Log("Nessun nome inserito.");
        }
        

    }

}
