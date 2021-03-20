using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{

    private Vector3 _originalScale;
    // Start is called before the first frame update
    void Start()
    {
        _originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(0, 0, 0);
            // Debug.Log("Invisible");
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = _originalScale;
            // Debug.Log("Visible");
        }
    }
}
