using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class Line : MonoBehaviour
{
    public PlayerControl playerControl;
    public bool Updated;
    public int Steps;
    public bool Confirm;
    public GameObject[] Interface = new GameObject[4]; 
    public GameObject[] FourCorners = new GameObject[4];
    public int[] Color = new int[4];
    public bool[] Access = new bool[4];
    public GameObject Center;
    public Texture CenterTexture;
    public int CenterColor;
    public int ColoredStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = transform.parent.parent.parent.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Updated = false;
        if (CenterColor == 0)
        {
            if (ColoredStatus == 0)
            {
                Center.GetComponent<RawImage>().color += new Color(0, Time.unscaledDeltaTime, 0);
                if (Center.GetComponent<RawImage>().color.g >= 1) ColoredStatus = 1;
            }
            if (ColoredStatus == 1)
            {
                Center.GetComponent<RawImage>().color -= new Color(Time.unscaledDeltaTime, 0, 0);
                if (Center.GetComponent<RawImage>().color.r <= 0) ColoredStatus = 2;
            }
            if (ColoredStatus == 2)
            {
                Center.GetComponent<RawImage>().color += new Color(0, 0, Time.unscaledDeltaTime);
                if (Center.GetComponent<RawImage>().color.b >= 1) ColoredStatus = 3;
            }
            if (ColoredStatus == 3)
            {
                Center.GetComponent<RawImage>().color -= new Color(0, Time.unscaledDeltaTime, 0);
                if (Center.GetComponent<RawImage>().color.g <= 0) ColoredStatus = 4;
            }
            if (ColoredStatus == 4)
            {
                Center.GetComponent<RawImage>().color += new Color(Time.unscaledDeltaTime, 0, 0);
                if (Center.GetComponent<RawImage>().color.r >= 1) ColoredStatus = 5;
            }
            if (ColoredStatus == 5)
            {
                Center.GetComponent<RawImage>().color -= new Color(0, 0, Time.unscaledDeltaTime);
                if (Center.GetComponent<RawImage>().color.b <= 0) ColoredStatus = 0;
            }
            Center.GetComponent<RawImage>().color = new Color(Mathf.Clamp(Center.GetComponent<RawImage>().color.r, 0, 1), Mathf.Clamp(Center.GetComponent<RawImage>().color.g, 0, 1), Mathf.Clamp(Center.GetComponent<RawImage>().color.b, 0, 1));
            for (int i = 0; i < 4; i++)
            {
                if (Color[i] == 0) FourCorners[i].GetComponent<RawImage>().color = Center.GetComponent<RawImage>().color;
            }
        }
    }
    public void Show()
    {
        if (Updated) return;
        Updated = true;
        bool r = false;
        bool y = false;
        bool b = false;
        bool a = false;
        for (int i = 0; i < 4; i++)
        {
            if (Interface[i] == null)
            {
                FourCorners[i].SetActive(false);
            }
            else
            {
                FourCorners[i].SetActive(true);
                if (Access[i]) 
                {
                    if (Color[i] == 0)
                    {
                        r = true;
                        y = true;
                        b = true;
                    }
                    if (Color[i] == 1)
                    {
                        r = true;
                    }
                    if (Color[i] == 2)
                    {
                        r = true;
                        y = true;
                    }
                    if (Color[i] == 3)
                    {                        
                        y = true;
                    }
                    if (Color[i] == 4)
                    {
                        y = true;
                        b = true;
                    }
                    if (Color[i] == 5)
                    {
                        a = true;                       
                    }
                    if (Color[i] == 6)
                    {
                        b = true;
                    }
                    if (Color[i] == 7)
                    {
                        r = true;
                        b = true;
                    }
                }
            }            
        }
        if ((r && y && b) || (a && r) || (a && y) || (a && b))
        {
            Center.GetComponent<RawImage>().color = new Color(1,0,0);
            CenterColor = 0;
        }
        else if (y && b) CenterColor = 4;
        else if (r && b) CenterColor = 7;
        else if (r && y) CenterColor = 2;
        else if (a) CenterColor = 5;
        else if (b) CenterColor = 6;
        else if (y) CenterColor = 3;
        else if (r) CenterColor = 1;
        for (int i = 0; i < 4; i++)
        {
            if (!Access[i]) Color[i] = CenterColor;
            if (Color[i] == 1) FourCorners[i].GetComponent<RawImage>().color = new Color(1, 0, 0);
            else if (Color[i] == 2) FourCorners[i].GetComponent<RawImage>().color = new Color(1, 0.5f, 0);
            else if (Color[i] == 3) FourCorners[i].GetComponent<RawImage>().color = new Color(1, 1, 0);
            else if (Color[i] == 4) FourCorners[i].GetComponent<RawImage>().color = new Color(0.5f, 1, 0);
            else if (Color[i] == 5) FourCorners[i].GetComponent<RawImage>().color = new Color(0, 1, 1);
            else if (Color[i] == 6) FourCorners[i].GetComponent<RawImage>().color = new Color(0, 0.5f, 1);
            else if (Color[i] == 7) FourCorners[i].GetComponent<RawImage>().color = new Color(0.5f, 0, 1);            
        }
        FourCorners[0].transform.eulerAngles = new(0, 0, Access[0] ? -90 : 90);
        FourCorners[1].transform.eulerAngles = new(0, 0, !Access[1] ? -90 : 90);
        FourCorners[2].transform.eulerAngles = new(0, 0, Access[2] ? 0 : 180);
        FourCorners[3].transform.eulerAngles = new(0, 0, !Access[3] ? 0 : 180);
        if (Interface[0] != null&& Interface[0].GetComponent<Line>() && !Access[0])
        {
            Interface[0].GetComponent<Line>().Color[1] = Color[0];
            Interface[0].GetComponent<Line>().Show();
        }
        if (Interface[1] != null && Interface[1].GetComponent<Line>() && !Access[1])
        {
            Interface[1].GetComponent<Line>().Color[0] = Color[1];
            Interface[1].GetComponent<Line>().Show();
        }
        if (Interface[2] != null && Interface[2].GetComponent<Line>() && !Access[2])
        {
            Interface[2].GetComponent<Line>().Color[3] = Color[2];
            Interface[2].GetComponent<Line>().Show();
        }
        if (Interface[3] != null && Interface[3].GetComponent<Line>() && !Access[3])
        {
            Interface[3].GetComponent<Line>().Color[2] = Color[3];
            Interface[3].GetComponent<Line>().Show();
        }
        if (((!Access[2] && Access[3])||(Access[2]&&!Access[3])) && (Interface[0] == null&& Interface[1] == null&& Interface[2] != null && Interface[3] != null))
        {
            Center.GetComponent<RawImage>().texture = FourCorners[2].GetComponent<RawImage>().texture;
            Center.transform.eulerAngles = FourCorners[2].transform.eulerAngles;
        }
        else if (((!Access[0] && Access[1]) || (Access[0] && !Access[1])) && Interface[2] == null && Interface[3] == null && Interface[0] != null && Interface[1] != null)
        {
            Center.GetComponent<RawImage>().texture = FourCorners[0].GetComponent<RawImage>().texture;
            Center.transform.eulerAngles = FourCorners[0].transform.eulerAngles;
        }
        else
        {
            Center.GetComponent<RawImage>().texture =CenterTexture;
            Center.transform.eulerAngles = new(0,0,0);
        }        
        if (CenterColor == 1) Center.GetComponent<RawImage>().color = new Color(1, 0, 0);
        else if (CenterColor == 2) Center.GetComponent<RawImage>().color = new Color(1, 0.5f, 0);
        else if (CenterColor == 3) Center.GetComponent<RawImage>().color = new Color(1, 1, 0);
        else if (CenterColor == 4) Center.GetComponent<RawImage>().color = new Color(0.5f, 1, 0);
        else if (CenterColor == 5) Center.GetComponent<RawImage>().color = new Color(0, 1, 1);
        else if (CenterColor == 6) Center.GetComponent<RawImage>().color = new Color(0, 0.5f, 1);
        else if (CenterColor == 7) Center.GetComponent<RawImage>().color = new Color(0.5f, 0, 1);        
    }
    public void PullCord()
    {
        if (!playerControl.PullCord)
        {
            playerControl.PullCordColor = CenterColor;
            playerControl.Line = gameObject;
            playerControl.Plaid = transform.parent.GetComponent<Plaid>().pos;
            playerControl.PullCord = true;
        }
    }
} 
