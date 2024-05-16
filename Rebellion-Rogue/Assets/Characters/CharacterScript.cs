using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class CharacterScript : MonoBehaviour
{
    public UIBattleScript UI;
    VisualElement Pin;
    NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Pin != null)
        {
            if (Vector3.Distance(transform.position, agent.destination) > 0.1f)
            {
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }
            Vector3 targetPosition = new Vector3((6.7f * (Pin.worldTransform.GetPosition().x / (Screen.width - Screen.width * 0.07f))) - 3.35f, transform.position.y, transform.position.z);
            agent.SetDestination(targetPosition);
        }
    }

    public void AssignPin(int _Pin)
    {
        print(UI.PinList[_Pin]);
        Pin = UI.PinList[_Pin];
    }
}
