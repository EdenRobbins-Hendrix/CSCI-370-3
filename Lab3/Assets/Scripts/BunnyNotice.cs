using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BunnyNotice : MonoBehaviour
{
    public TMP_FontAsset fontA;
    public GameObject self;
    GameObject dialogue;
    TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue = GameObject.FindWithTag("GameController");
        text = dialogue.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.attachedRigidbody.CompareTag("Player")) {
        var go = new GameObject();
        var canvas = go.AddComponent<Canvas>();
        TextMeshProUGUI use = Instantiate(text);
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.sortingOrder = 50;
        canvas.transform.localScale = new Vector3 (0.05f, 0.05f);
        canvas.transform.position = self.transform.position;
        canvas.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y + 0.75f);
        use.transform.SetParent(canvas.transform);
        use.transform.position = canvas.transform.position;
        Destroy(canvas.gameObject, 3.5f);
     }   
    }

}
