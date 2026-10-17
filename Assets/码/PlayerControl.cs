using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int PullCordColor;
    public bool PullCord;
    public int Steps;
    public GameObject Line;
    public Vector2 Plaid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Line.GetComponent<Line>()) Line.transform.parent.GetComponent<Image>().color = Line.GetComponent<Line>().Center.GetComponent<RawImage>().color;
        if (Input.GetMouseButton(1))
        {
            PullCord = false;
            Plaid = new Vector2();
            Line.transform.parent.GetComponent<Image>().color = Color.white;
            Line = null;
        }
    }
}
