using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float timeToLive = 1;
    public float fallSpeed = 10f;
    private float currentTimeToLive;

    public void Play(Vector3 position, string text)
    {
        var rect = GetComponent<RectTransform>();
        var tmpText = GetComponent<TMP_Text>();

        var newPosition = new Vector2(200, 200);
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
