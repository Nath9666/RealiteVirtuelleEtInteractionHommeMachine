using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public ObjectStorage weaponsStorage;

    void Update()
    {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = Camera.main.transform.forward;

        RaycastHit hit;
        Debug.DrawRay(rayOrigin, rayDirection * 3, Color.red);
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "PickUpObject")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    weaponsStorage.AddObjectToStorage(hit.collider.gameObject);
                    DisplayObjectName(hit.collider.gameObject.name);
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

    public void DisplayObjectName(string ObjectName)
    {
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject panelGO = new GameObject("Panel");
        panelGO.transform.SetParent(canvasGO.transform);
        RectTransform panelRect = panelGO.AddComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(300, 50);

        panelRect.anchorMin = new Vector2(0.5f, 0);
        panelRect.anchorMax = new Vector2(0.5f, 0);
        panelRect.pivot = new Vector2(0.5f, 0);
        panelRect.anchoredPosition = new Vector2(0, 50);

        Image panelImage = panelGO.AddComponent<Image>();
        panelImage.color = Color.white;

        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(panelGO.transform);
        RectTransform textRect = textGO.AddComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(500, 300);
        textRect.anchoredPosition = Vector2.zero;

        Text text = textGO.AddComponent<Text>();
        text.text = ObjectName;
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.fontSize = 24;
        text.color = Color.black;
        text.alignment = TextAnchor.MiddleCenter;

        Destroy(canvasGO, 2f);
    }


}