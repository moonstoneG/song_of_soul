using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AS_2D.DiaInfo;

public class DIalogueTest : MonoBehaviour
{
    public DialogueCanvasController CanvasOBJ;

    // Start is called before the first frame update
    void Start()
    {
        CanvasOBJ.ActivateCanvasWithTranslatedText("key1");
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
