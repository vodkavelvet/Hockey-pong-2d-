using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ScoreLeft;
    public int ScoreRight;

    public TMP_Text uIScoreLeft;  // Tambahkan titik koma
    public TMP_Text uIScoreRight; // Tambahkan titik koma

    void Awake()
    {
        if (instance == null) 
            instance = this;
        else 
            Destroy(gameObject);
    }

    public void Score(string SideWallName)
    {
        if(SideWallName == "SideWallLeft") 
        {
            ScoreRight += 10; 
            uIScoreRight.text = ScoreRight.ToString(); // Update UI untuk Right
        }
        else if(SideWallName == "SideWallRight") 
        {
            ScoreLeft += 10;
            uIScoreLeft.text = ScoreLeft.ToString(); // Update UI untuk Left
        }
    }
}
