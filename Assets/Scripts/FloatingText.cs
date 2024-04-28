using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float timeToLive = 1;
    public float fallSpeed = 10f;
    private float currentTimeToLive;

    public void Play(Vector2 position, string text, Color color)
    {
        var rect = GetComponent<RectTransform>();
        var tmpText = GetComponent<TMP_Text>();
        tmpText.color = color;
        var newPosition = position;
        rect.anchoredPosition = newPosition;
        tmpText.text = text;
        currentTimeToLive = timeToLive;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (currentTimeToLive > 0)
        {
            var rect = GetComponent<RectTransform>();
            rect.anchoredPosition -= fallSpeed * Time.deltaTime * Vector2.down;
            currentTimeToLive -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
