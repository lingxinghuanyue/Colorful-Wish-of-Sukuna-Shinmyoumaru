using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiracleMallet : Entity
{
    public Image image;    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = transform.parent.parent.parent.GetComponent<PlayerControl>();
        if (Color == 1) image.color = new Color(1,0,0);
        else if (Color == 2) image.color = new Color(1,0.5f,0);
        else if (Color == 3) image.color = new Color(1,1,0);
        else if (Color == 4) image.color = new Color(0.5f,1,0);
        else if (Color == 5) image.color = new Color(0,1, 1);
        else if (Color == 6) image.color = new Color(0,0.5f,1);
        else if (Color == 6) image.color = new Color(0.5f,0, 1);
    }    
    public void PullCord()
    {
        if (!playerControl.PullCord)
        {
            playerControl.PullCordColor = Color;
            playerControl.Line = gameObject;
            playerControl.Plaid = transform.parent.GetComponent<Plaid>().pos;
            playerControl.PullCord = true;
        }       
    }
}
