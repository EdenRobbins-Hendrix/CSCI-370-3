using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI collectionCount;
    public TextMeshProUGUI carrotCount;
    int collected;
    public int carrots;
    public MusicPlayer jb;
    bool winstate;
    public bool intro;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject dialoguePanel;
    bool skipLineTriggered;
    public float charactersPerSec = 90;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnAwake() {

    }
    void Start()
    {
        jb = GameObject.FindWithTag("Respawn").GetComponent<MusicPlayer>();
        collected = 0;
        carrots = 0;
        winstate = false;
        intro = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == 20 && !winstate) {
            winstate = true;
            Win();
        }
        
    }

    public void Collect() {
        collected++;
        collectionCount.text = "Babies: " + collected + "/20";
    }

    public void GetCarrot() {
        carrots++;
        carrotCount.text = "Carrot: " + carrots;
    }

    public void DecrementCarrot() {
        carrots--;
        carrotCount.text = "Carrot: " + carrots;
    }

    void Win() {
        Initiate.Fade("Congratulations", Color.black, 1.5f);
        jb.GetComponent<AudioSource>().Stop();
    }

    public void IntroComplete() {
        intro = true;
    }

    public void StartDialogue(string[] dialogue, int StartPosition, string name) {
        Debug.Log("2");
        dialoguePanel.SetActive(true);
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(RunDialogue(dialogue, StartPosition));
    }

    IEnumerator RunDialogue(string[] dialogue, int StartPosition) {
        skipLineTriggered = false;

        for (int i = StartPosition; i < dialogue.Length; i++) {
            dialogueText.text = null;
            StartCoroutine(TypeTextUncapped(dialogue[i]));

            while (!skipLineTriggered) {
                yield return null;
            }
            skipLineTriggered = false;
        }
        EndDialogue();

    }

    public void SkipLine(){
        Debug.Log("5");
        skipLineTriggered = true;
    }

    public void ShowDialogue(string dialogue, string name)
    {
        nameText.text = name;
        StartCoroutine(TypeTextUncapped(dialogue));
        
    }

    public void EndDialogue()
    {
        nameText.text = null;
        dialogueText.text = null;
        dialoguePanel.SetActive(false);
    }

    IEnumerator TypeTextUncapped(string text) {
        float timer = 0;
        float interval = 1 / charactersPerSec;
        string textBuffer = null;
        char[] chars = text.ToCharArray();
        int i = 0;

        while (i < chars.Length) {
            if (timer < Time.deltaTime) {
                textBuffer += chars[i];
                dialogueText.text = textBuffer;
                timer += interval;
                i++;
            }
            else{
                timer -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
