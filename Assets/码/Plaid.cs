using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Plaid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 pos;
    public PlayerControl playerControl;
    public GameObject Line;
    public GameObject LineEntity;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerControl.PullCord)
        {            
            if (Vector2.Distance(playerControl.Plaid,pos)<=1)
            {
                if (transform.childCount == 0)
                {
                    if (LineEntity == null)
                    {
                        LineEntity = Instantiate(Line, transform);                        
                    }
                }
                if (LineEntity)
                {
                    if (LineEntity.GetComponent<Line>().Interface[0]==null&&playerControl.Line.transform.position.x < transform.position.x)
                    {                        
                        LineEntity.GetComponent<Line>().Interface[0] = playerControl.Line;
                        LineEntity.GetComponent<Line>().Access[0] = true;
                        LineEntity.GetComponent<Line>().Color[0] = playerControl.PullCordColor;
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[1] = LineEntity;
                            playerControl.Line.GetComponent<Line>().Access[1] = false;
                            playerControl.Line.GetComponent<Line>().Show();
                        }
                    }
                    if (LineEntity.GetComponent<Line>().Interface[1] == null && playerControl.Line.transform.position.x > transform.position.x)
                    {                        
                        LineEntity.GetComponent<Line>().Interface[1] = playerControl.Line;
                        LineEntity.GetComponent<Line>().Access[1] = true;
                        LineEntity.GetComponent<Line>().Color[1] = playerControl.PullCordColor;
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[0] = LineEntity;
                            playerControl.Line.GetComponent<Line>().Access[0] = false;
                            playerControl.Line.GetComponent<Line>().Show();
                        }
                    }
                    if (LineEntity.GetComponent<Line>().Interface[2] == null && playerControl.Line.transform.position.y < transform.position.y)
                    {
                        LineEntity.GetComponent<Line>().Interface[2] = playerControl.Line;
                        LineEntity.GetComponent<Line>().Access[2] = true;
                        LineEntity.GetComponent<Line>().Color[2] = playerControl.PullCordColor;
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[3] = LineEntity;
                            playerControl.Line.GetComponent<Line>().Access[3] = false;
                            playerControl.Line.GetComponent<Line>().Show();
                        }
                    }
                    if (LineEntity.GetComponent<Line>().Interface[3] == null && playerControl.Line.transform.position.y > transform.position.y)
                    {
                        LineEntity.GetComponent<Line>().Interface[3] = playerControl.Line;
                        LineEntity.GetComponent<Line>().Access[3] = true;
                        LineEntity.GetComponent<Line>().Color[3] = playerControl.PullCordColor;
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[2] = LineEntity;
                            playerControl.Line.GetComponent<Line>().Access[2] = false;
                            playerControl.Line.GetComponent<Line>().Show();
                        }
                    }
                   
                    LineEntity.GetComponent<Line>().Show();
                    playerControl.Line = LineEntity;
                    playerControl.Plaid = pos;
                }                     
                if (LineEntity)
                {                   
                    playerControl.PullCordColor = LineEntity.GetComponent<Line>().CenterColor;
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControl = transform.parent.parent.GetComponent<PlayerControl>();
        for (int i = 0; i < transform.parent.childCount; i++)
        {
           if(transform.parent.GetChild(i) == transform)pos.x = i;
        }
        for (int i = 0; i < transform.parent.parent.childCount; i++)
        {
            if (transform.parent.parent.GetChild(i) == transform.parent) pos.y = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
