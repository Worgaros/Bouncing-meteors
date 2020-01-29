using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCounter : MonoBehaviour
{
    [SerializeField] GameObject panel;
    int ballsNumber = 6;
    
    public void ballsCounter()
    {
        ballsNumber--;
        
        if (ballsNumber <= 0)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }
    
}
