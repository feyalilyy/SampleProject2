using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        foreach (Rigidbody rigidbody in  gameObject.GetComponentsInChildren<Rigidbody>())
        {
            rigidbody.isKinematic = true;
        }
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetTrigger("Run");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetInteger("Attack", Random.Range(1, 3));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.enabled = false;
            foreach (Rigidbody rigidbody in  gameObject.GetComponentsInChildren<Rigidbody>())
            {
                rigidbody.isKinematic = false;
            }
        }

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        int specialHash = Animator.StringToHash("SpecialAttack");
        int clawHash = Animator.StringToHash("ClawAttack");

        if ((stateInfo.shortNameHash ==  specialHash || stateInfo.shortNameHash == clawHash)
        && stateInfo.normalizedTime >= 1f)
        {
            _animator.SetInteger("Attack", 0);
        }

        _animator.ResetTrigger("Run");
    }
}
