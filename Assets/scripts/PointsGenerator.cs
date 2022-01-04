using UnityEngine;
using UnityEngine.UI;
public class PointsGenerator : MonoBehaviour {
    public Canvas canvas;
    public Texture2D image;
    public Vector2 size;
    public float pointDelay = 5f;
    public float fallingSpeed = 60f;
    private float timer;
    private float maximumDepth;
    private GameObject point;
    private RectTransform rectTransform;

    void Start() {
        timer = pointDelay;
        maximumDepth = -canvas.GetComponent<RectTransform>().rect.height - (size.y/2);
    }

    void Update() {
        if (timer <= 0f) {
            timer = pointDelay;
            generateCanvasPoint();
        }

        if (point == null) {
            timer -= Time.deltaTime;
        } else {
            Vector2 pos = rectTransform.anchoredPosition;
            pos.y -= fallingSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = pos;
            if (pos.y < maximumDepth) {
                Destroy(point);
            }
        }
    }

    void generateCanvasPoint() {
        point = new GameObject("point");
        rectTransform = point.AddComponent<RectTransform>();
        rectTransform.transform.SetParent(canvas.transform);
        rectTransform.localScale = Vector3.one;
        rectTransform.anchorMin = new Vector2(0.5f, 1f);
        rectTransform.anchorMax = new Vector2(0.5f, 1f);
        float tmp = canvas.GetComponent<RectTransform>().rect.width;
        float x = Random.Range(-tmp/4, tmp/4);
        rectTransform.anchoredPosition = new Vector2(x, size.y/2);
        rectTransform.sizeDelta= size;

        Image imageObject = point.AddComponent<Image>();
        imageObject.sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
        point.transform.SetParent(canvas.transform);

        Button btn = point.AddComponent<Button>();
        btn.onClick.AddListener(() => {
            MoneyManager.instance.onPointClicked();
            Destroy(point);
        });
    }
}
