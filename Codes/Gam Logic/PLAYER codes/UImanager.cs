using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    GameObject canvasGO;
    Canvas canvas;

    public GameObject player;

    void Start()
    {
        // Canvas占쏙옙 占쏙옙占쌕몌옙 占쏙옙占쏙옙 占쏙옙占쏙옙
        if (canvas == null)
        {
            canvasGO = new GameObject("Canvas");
            canvas = canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }

    public void SpawnImage(Vector3 pos, Quaternion angle, Vector2 size, Sprite spr,GameObject owner)
    {
        GameObject imageGO = new GameObject("Image");
        item_Interaction interaction = imageGO.AddComponent<item_Interaction>();
        interaction.owner = owner;
        interaction.player=player;
        item item_code=imageGO.AddComponent<item>();
        item_code.name1=spr.name;
        Image image = imageGO.AddComponent<Image>();
        image.transform.SetParent(canvas.transform);

        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.localPosition = pos;
        rectTransform.sizeDelta = size;
        rectTransform.localRotation = angle;
        rectTransform.name = spr.name;
        rectTransform.tag = "Inventory";

        image.sprite = spr;
    }
    public void SpawnText(Vector3 pos, Quaternion angle, int size, string str,int width,int height,int alignmenttype)
    {
        GameObject textGO = new GameObject("Text");
        Text textComponent = textGO.AddComponent<Text>();
        textComponent.transform.SetParent(canvas.transform);

        textComponent.text = str;

        textComponent.fontSize = size;

        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        if(alignmenttype==0){
            textComponent.alignment = TextAnchor.UpperRight;
        }
        else if(alignmenttype==1){
            textComponent.alignment=TextAnchor.UpperLeft;
        }

        textComponent.color = Color.black;


        textComponent.rectTransform.localPosition = pos;
        textComponent.rectTransform.localRotation = angle;
        textComponent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,width);
        textComponent.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,height);
        textComponent.rectTransform.localScale = new Vector3(2, 2, 1);
        textComponent.rectTransform.tag = "Inventory";
    }

}
