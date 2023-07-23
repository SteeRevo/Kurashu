using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystems ds;
        TextArchitect architect;

        string[] lines = new string[5]
        {
            "This is random dialogue",
            "Hello there",
            "GOD I LOVE SELEN",
            "persona 5",
            "wack"
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystems.instance;
            
            //Debug.Log(ds.dialogueContainer.dialogueText);
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.instant;
        }

        // Update is called once per frame
       void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                architect.Build(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}

