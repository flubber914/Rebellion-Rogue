using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    public int PinNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AssignPinRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AssignPinRoutine()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<CharacterScript>().AssignPin(PinNumber);
        }
    }
}
