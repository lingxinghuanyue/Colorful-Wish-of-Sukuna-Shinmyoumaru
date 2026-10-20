
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
    public List<Persona> EventSource;
    public bool[] Event;
    public bool wthdraw;
    bool UpdatePersona;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void EventUpdate()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            List<Persona> ImpactSource = new List<Persona>();
            for (int j = 0; j < EventSource.Count; j++)
            {               
                for (int k = 0; k < EventSource[j].ImpactEvent.Count; k++)
                {
                    if (EventSource[j].ImpactEvent[k] == i)
                    {
                        ImpactSource.Add(EventSource[j]); break;
                    }
                }
            }
            
            int Num = 0;
            for (int j = 0; j < ImpactSource.Count; j++)
            {
                for (int k = 0; k < ImpactSource[j].ImpactEvent.Count; k++)
                {
                    if (EventSource[j].ImpactEvent[k] == i && Num < ImpactSource[j].ImpactEventNum[k]) Num = ImpactSource[j].ImpactEventNum[k];                    
                }
            }
            bool[] bools = new bool[Num+1];
            for (int j = 0; j < Num+1; j++)
            {
                List<bool> bools1 = new List<bool>();
                for (int k = 0; k < ImpactSource.Count; k++)
                {
                    for (int i1 = 0; i1 < ImpactSource[k].ImpactEvent.Count; i1++)
                    {
                        if (ImpactSource[k].ImpactEvent[i1] == i && j == ImpactSource[k].ImpactEventNum[i1])
                        {
                            bools1.Add(ImpactSource[k].PositiveImpact[i1] ? ImpactSource[k].wish == ImpactSource[k].Wish[i1] : ImpactSource[k].wish == ImpactSource[k].Wish[i1]);
                            break;
                        }
                    }
                }
                bool b = false;
                for (int k = 0; k < bools1.Count; k++)
                {
                    if(k==0)b = true;
                    b = b && bools1[k];
                }
                bools[j]=b;
            }            
            for (int j = 0; j < bools.Length; j++)
            {               
                if (bools[j])
                {
                    Event[i] = true;
                    break;
                }
                else
                {
                    Event[i] = false;
                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (UpdatePersona)
        {
            for (int i = 0; i < EventSource.Count; i++)
            {
                EventSource[i].Achieve();
            }
            UpdatePersona = false;
        }
        if (wthdraw)
        {
            wthdraw = false;
            UpdatePersona = true;
        }       
        if (Line!=null&&Line.GetComponent<Line>()) Line.transform.parent.GetComponent<Image>().color = Line.GetComponent<Line>().Center.GetComponent<RawImage>().color;
        if (Input.GetMouseButton(1))
        {
            PullCord = false;
            Plaid = new Vector2();
            if (Line != null) Line.transform.parent.GetComponent<Image>().color = Color.white;
            Line = null;
        }
    }
    public void Withdraw()
    {
        if (Steps != 0)
        {
            wthdraw = true;
            Steps--;
        }
    }
    public void ConfirmationSteps()
    {
        PullCord = false;
        Plaid = new Vector2();
        if (Line != null) Line.transform.parent.GetComponent<Image>().color = Color.white;
        Line = null;
        Steps++;
    }
}
