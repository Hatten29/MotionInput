using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float inputWindow = 0.5f;

    private Rigidbody2D rb;

    private bool isAttacking1 = false;
    private bool isAttacking2 = false;
    private bool isAttacking3 = false;
    private bool isSpotDodging = false;

    private List<KeyCode> inputSequence = new List<KeyCode>();
    private float inputTimer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleAnimationStates();
    }
    private void HandleInput()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    inputSequence.Add(key);
                    ProcessInputSequence();
                    inputTimer = inputWindow;
                }
            }
        }

        if (inputTimer > 0)
        {
            inputTimer -= Time.deltaTime;
            if (inputTimer <= 0)
            {
                inputSequence.Clear();
            }
        }
    }


    private void ProcessInputSequence()
    {
   
        if (SequenceContains(new KeyCode[] { KeyCode.S, KeyCode.D, KeyCode.J }))
        {
            isAttacking1 = true;
            inputSequence.Clear(); 
        }
        else if (SequenceContains(new KeyCode[] { KeyCode.S, KeyCode.A, KeyCode.J }))
        {
            isAttacking2 = true;
            inputSequence.Clear(); 
        }
        else if (SequenceContains(new KeyCode[] { KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.J }))
        {
            isAttacking3 = true;
            inputSequence.Clear(); 
        }
        else if (SequenceContains(new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.W }))
        {
            isSpotDodging = true;
            inputSequence.Clear(); 
        }
    }

    private bool SequenceContains(KeyCode[] sequence)
    {
        if (sequence.Length > inputSequence.Count) return false;
    
        for (int i = 0; i < sequence.Length; i++)
        {
            if (inputSequence[inputSequence.Count - sequence.Length + i] != sequence[i])
            {
                return false;
            }
        }
        return true;
    }



    private void HandleAnimationStates()
    {
        animator.SetBool("Attack1", isAttacking1);
        animator.SetBool("Attack2", isAttacking2);
        animator.SetBool("Attack3", isAttacking3);
        animator.SetBool("SpotDodge", isSpotDodging);

        ResetAnimationStates();
    }

    private void ResetAnimationStates()
    {
        isAttacking1 = false;
        isAttacking2 = false;
        isAttacking3 = false;
        isSpotDodging = false;
    }
}
