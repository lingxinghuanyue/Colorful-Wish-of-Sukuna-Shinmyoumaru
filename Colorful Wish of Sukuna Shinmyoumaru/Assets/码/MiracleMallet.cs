
using UnityEngine;
using UnityEngine.UI;

public class MiracleMallet : Entity
{
    public PlayerControl playerControl;
    public LevelEditor levelEditor;
    public Image image;
    // Start is called before the first frame update
    public void Start()
    {
        if (playerControl != null) return;
        if (levelEditor == null)
        {
            levelEditor = transform.parent.parent.parent.parent.GetComponent<LevelEditor>();
            if (levelEditor != null)
            {
                pos = transform.parent.GetComponent<Plaid>().pos;
                levelEditor.EntityList.Add(this);
            }
        }
        if (levelEditor == null) playerControl = transform.parent.parent.parent.parent.GetComponent<PlayerControl>();      
        if (Color == 1) image.color = new Color(1, 0, 0);
        else if (Color == 2) image.color = new Color(1, 0.5f, 0);
        else if (Color == 3) image.color = new Color(1, 1, 0);
        else if (Color == 4) image.color = new Color(0.5f, 1, 0);
        else if (Color == 5) image.color = new Color(0, 1, 1);
        else if (Color == 6) image.color = new Color(0, 0.5f, 1);
        else if (Color == 7) image.color = new Color(0.5f, 0, 1);
    }
    private void Update()
    {
        if (playerControl != null)
        {
            if (TriggerEvent != 0 && !playerControl.Event[TriggerEvent])
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.25f);
                return;
            }
            else
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            }
        }
        if (levelEditor != null)
        {
            if (TriggerEvent != 0)
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.25f);
                return;
            }
            else
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            }
        }
    }
    public void PullCord()
    {
        if (levelEditor != null)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (playerControl != null)
        {
            if (TriggerEvent != 0 && !playerControl.Event[TriggerEvent]) return;
            if (!playerControl.PullCord)
            {
                playerControl.PullCordColor = Color;
                playerControl.Line = gameObject;
                playerControl.Plaid = transform.parent.GetComponent<Plaid>().pos;
                playerControl.PullCord = true;
            }
        }        
    }
}
