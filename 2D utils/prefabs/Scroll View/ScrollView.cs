using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollView : MonoBehaviour
{
    //public List<GameObject> content;

    // Start is called before the first frame update
    void Start()
    {
    }

    //Instansiates content
    public void DisplayContent(List<GameObject> content)
    {
        GameObject scroll = transform.GetChild(0).gameObject;
        for(int i = 0; i < content.Count; i++)
        {
            Instantiate(content[0], scroll.transform);
        }
        AdjustScrollSize();

    }

    //Changes scrolls size according to amount of content
    public void AdjustScrollSize()
    {
        //Get info
        float scrollViewHeight = GetComponent<RectTransform>().sizeDelta.y;
        float cellSizeY = transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize.y;
        float cellSpacingY = transform.GetChild(0).GetComponent<GridLayoutGroup>().spacing.y;
        RectTransform contentTransform = transform.GetChild(0).GetComponent<RectTransform>();
        int contentCount = transform.GetChild(0).childCount;

        //Calculate required scrolls size
        float requiredScrollHeight
            = contentCount * cellSizeY + contentCount * cellSpacingY;

        //Make size andjustments
        contentTransform.sizeDelta = new Vector2(
                contentTransform.sizeDelta.x,
                requiredScrollHeight
            );

        //Calculate how much scroll needs to be moved so it starts from the top
        contentTransform.position = new Vector2(0, -(requiredScrollHeight / 2));

        //If scroll size is smaller than container, make it as tall as container
        if(contentTransform.sizeDelta.y < scrollViewHeight)
        {
            contentTransform.sizeDelta
            = new Vector2(
                contentTransform.sizeDelta.x,
                scrollViewHeight
            );
        }
    }
}
