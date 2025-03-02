using UnityEngine;

public class PlayerConvo : MonoBehaviour
{   public GameManager manager;
    public DialogueAsset intro;
    bool noDoubleClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   noDoubleClick = true;;
        Invoke("Intro", 1);

        
    }

    // Update is called once per frame
    void Update()
    { 
        if (noDoubleClick && Input.GetMouseButtonDown(0)) {
            noDoubleClick = false;
            manager.SkipLine();

        }
        if (Input.GetMouseButtonUp(0)) {
            noDoubleClick = true;
        }
        
    }

    void Intro() {
        manager.StartDialogue(intro.dialogue,0,"Bunny");
        manager.intro = false;

    }

}
