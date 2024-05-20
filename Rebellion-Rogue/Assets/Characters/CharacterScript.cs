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
    public float range;

    //attack stats
    bool attacking = false;
    public float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * range));
        Movement();
        if (!attacking)
        {
            StartCoroutine(AttackCheckRoutine());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Movement()
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

    void Attack()
    {
        RaycastHit hit;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, 1 << 3);

        foreach (var hitCollider in hitColliders)
        {

            print(hitCollider.name);
        }
        print("///////////");
    }

    public void AssignPin(int _Pin)
    {
        Pin = UI.PinList[_Pin];
    }

    IEnumerator AttackCheckRoutine()
    {
        attacking = true;
        yield return new WaitForSeconds(attackSpeed);
        Attack();
        attacking = false;
    }
}
