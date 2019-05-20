using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const float maxPosition = 2f;
    private const float minPosition = -2f;
    private float position = 0f;
    

    void Start()
    {
    }

    void Update()
    {
        bool gauche = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool droite = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        if (droite || gauche)
        {
            if (droite)
            {
                position = Mathf.Min(maxPosition, position + 1f);
            }
            if (gauche)
            {
                position = Mathf.Max(minPosition, position - 1f);
            }
            transform.position = new Vector3(position, 1f, 0f);
        }
        
    }
}
