
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonImageSwitch : MonoBehaviour
{
    
    private Image _buttonImg;
    
    /*
    public Sprite originalButtonImage;
    public Sprite newButtonImage;
    */

    public Color normalCol;
    public Color selectedCol;
    private void Start()
    {
        _buttonImg = GetComponent<Image>();
        
    }

    public void OnSelect()
    {
        //_buttonImg.sprite = newButtonImage;
        _buttonImg.color = selectedCol;
        Debug.Log("selected");
    }

    public void OnDeselect()
    {
        _buttonImg.color = normalCol;
        //_buttonImg.sprite = originalButtonImage;
        Debug.Log("deselect");
    }
    
}