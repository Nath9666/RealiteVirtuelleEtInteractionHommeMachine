using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPNJ : MonoBehaviour
{
    [SerializeField] private string characterMsg;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CreateChatBubble(characterMsg);
        }
    }

    public void CreateChatBubble(string characterMsg)
    {
        GameObject canvasGO = new GameObject("Canvas");
        canvasGO.tag = "CanvasPNJ";
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject panelGO = new GameObject("Panel");
        panelGO.transform.SetParent(canvasGO.transform);
        RectTransform panelRect = panelGO.AddComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(500, 100);

        panelRect.anchorMin = new Vector2(0.5f, 0); // Ancre minimum en bas de la page
        panelRect.anchorMax = new Vector2(0.5f, 0); // Ancre maximum en bas de la page
        panelRect.pivot = new Vector2(0.5f, 0); // Pivot au centre de la base du panneau
        panelRect.anchoredPosition = new Vector2(0, 15); // Ajustez la position y si nécessaire

        Image panelImage = panelGO.AddComponent<Image>();
        panelImage.color = Color.white;

        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(panelGO.transform);
        RectTransform textRect = textGO.AddComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(500, 300);
        textRect.anchoredPosition = Vector2.zero;

        Text text = textGO.AddComponent<Text>();
        text.text = characterMsg;
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.fontSize = 24;
        text.color = Color.black;
        text.alignment = TextAnchor.MiddleCenter;
    }
}

