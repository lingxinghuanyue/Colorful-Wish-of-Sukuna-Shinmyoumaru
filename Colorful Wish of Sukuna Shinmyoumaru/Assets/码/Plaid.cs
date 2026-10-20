
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Plaid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 pos;
    public PlayerControl playerControl;
    public LevelEditor levelEditor;
    public GameObject Line;
    public GameObject LineEntity;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerControl == null) return;
        if (playerControl.PullCord)
        {            
            if (Vector2.Distance(playerControl.Plaid,pos)<=1)
            {
                if (transform.childCount == 2)
                {
                    if (LineEntity == null)
                    {
                        LineEntity = Instantiate(Line, transform);
                    }
                }
                else if (transform.GetChild(2).GetComponent<Persona>())
                {
                    if (playerControl.Line.transform.position.x < transform.position.x)
                    {
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[1] = transform.GetChild(2).gameObject;
                            playerControl.Line.GetComponent<Line>().Access[1] = false;
                            playerControl.Line.GetComponent<Line>().Achieve();
                            transform.GetChild(2).GetComponent<Persona>().Interface[0] = playerControl.Line.GetComponent<Line>().Color[1];
                            transform.GetChild(2).GetComponent<Persona>().Source[0] = playerControl.Line.GetComponent<Line>();
                            transform.GetChild(2).GetComponent<Persona>().Achieve();
                        }
                    }
                    if (playerControl.Line.transform.position.x > transform.position.x)
                    {
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[0] = transform.GetChild(2).gameObject;
                            playerControl.Line.GetComponent<Line>().Access[0] = false;
                            playerControl.Line.GetComponent<Line>().Achieve();
                            transform.GetChild(2).GetComponent<Persona>().Interface[1] = playerControl.Line.GetComponent<Line>().Color[0];
                            transform.GetChild(2).GetComponent<Persona>().Source[1] = playerControl.Line.GetComponent<Line>();
                            transform.GetChild(2).GetComponent<Persona>().Achieve();
                        }
                    }
                    if (playerControl.Line.transform.position.y < transform.position.y)
                    {
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[3] = transform.GetChild(2).gameObject;
                            playerControl.Line.GetComponent<Line>().Access[3] = false;
                            playerControl.Line.GetComponent<Line>().Achieve();
                            transform.GetChild(2).GetComponent<Persona>().Interface[2] = playerControl.Line.GetComponent<Line>().Color[3];
                            transform.GetChild(2).GetComponent<Persona>().Source[2] = playerControl.Line.GetComponent<Line>();
                            transform.GetChild(2).GetComponent<Persona>().Achieve();
                        }
                    }
                    if (playerControl.Line.transform.position.y > transform.position.y)
                    {
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {                            
                            playerControl.Line.GetComponent<Line>().Interface[2] = transform.GetChild(2).gameObject;
                            playerControl.Line.GetComponent<Line>().Access[2] = false;
                            playerControl.Line.GetComponent<Line>().Achieve();
                            transform.GetChild(2).GetComponent<Persona>().Interface[3] = playerControl.Line.GetComponent<Line>().Color[2];
                            transform.GetChild(2).GetComponent<Persona>().Source[3] = playerControl.Line.GetComponent<Line>();
                            transform.GetChild(2).GetComponent<Persona>().Achieve();
                        }
                    }
                    playerControl.ConfirmationSteps();
                              
                }
                if (LineEntity)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (LineEntity.GetComponent<Line>().Interface[i] == playerControl.Line) return;
                    }
                    if (LineEntity.GetComponent<Line>().Interface[0] == null && playerControl.Line.transform.position.x < transform.position.x)
                    {
                        LineEntity.GetComponent<Line>().Interface[0] = playerControl.Line;
                        LineEntity.GetComponent<Line>().Access[0] = true;
                        LineEntity.GetComponent<Line>().Color[0] = playerControl.PullCordColor;
                        if (playerControl.Line.GetComponent<Line>() != null)
                        {
                            playerControl.Line.GetComponent<Line>().Interface[1] = LineEntity;
                            playerControl.Line.GetComponent<Line>().Access[1] = false;
                            playerControl.Line.GetComponent<Line>().Achieve();
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
                            playerControl.Line.GetComponent<Line>().Achieve();
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
                            playerControl.Line.GetComponent<Line>().Achieve();
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
                            playerControl.Line.GetComponent<Line>().Achieve();
                        }
                    }
                    LineEntity.GetComponent<Line>().Achieve();
                    playerControl.Line = LineEntity;
                    playerControl.PullCordColor = LineEntity.GetComponent<Line>().CenterColor;
                    playerControl.Plaid = pos;
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
        if (playerControl!=null) return;
        levelEditor = transform.parent.parent.parent.GetComponent<LevelEditor>();
        if (levelEditor == null) playerControl = transform.parent.parent.parent.GetComponent<PlayerControl>();        
        if (levelEditor != null)
        {
            GetComponent<Button>().enabled = true;
        }
        else if (playerControl != null)
        {            
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i) == transform) pos.x = i;
            }
            for (int i = 0; i < transform.parent.parent.childCount; i++)
            {
                if (transform.parent.parent.GetChild(i) == transform.parent) pos.y = i;
            }
            GetComponent<Button>().enabled = false;
        }
    }
    public void button()
    {       
        if (levelEditor != null && transform.childCount == 2)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
