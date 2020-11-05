using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NineS : PlayerCharacterBase, IHacker
{
    [SerializeField]
    private float _hackingRange;
    public float HackingRange { get => _hackingRange; }

    [SerializeField]
    private int _hackingSpeed;
    public int HackingSpeed { get => _hackingSpeed; }

    [SerializeField]
    private Contaminated _hackingTarget;
    public Contaminated HackingTarget { get => _hackingTarget; }

    [SerializeField]
    private bool _inRange;
    public bool InRange { get => _inRange; private set => _inRange = value; }

    [SerializeField]
    private bool _hacking;

    [SerializeField]
    private SphereCollider hackingRangeCollider;

    [SerializeField]
    private SpriteRenderer hackingRangeIndicator;

    protected override void Awake()
    {
        base.Awake();

        // When the left stick is moved (mapped to MoveCharacter1), it will call performed.
        // performed will give a context (mv) which has a readable value of the stick's direction.
        // move is then set to the stick's direction.
        controls.NinesControls.Move.performed += MovePerformed;
        // When the stick is idle, canceled will be called setting move to Vector2.zero.
        controls.NinesControls.Move.canceled += MoveCanceled;

        controls.NinesControls.Interact.performed += InteractPerformed;

        if(SceneManager.GetActiveScene().name == "TrialScene")
        {
            controls.TwobControls.Interact.performed += ConvictTarget;
        }

        hackingRangeCollider.radius = HackingRange;
        hackingRangeIndicator.color = new Color(1f, 1f, 1f, 0.5f);
        hackingRangeIndicator.size = new Vector2(HackingRange * 2.1f, HackingRange * 2.1f);
    }

    new protected void FixedUpdate()
    {
        base.FixedUpdate();

        if (InRange && _hacking)
        {
            HackingTarget.RestoreSelfControl(HackingSpeed);
        }

    }
    public void ControlContamination(IContaminated contaminated)
    {
        contaminated.RestoreSelfControl(HackingSpeed);
    }

    public override void UpdateCharacterDialogueState(DialogueState state)
    {
        base.UpdateCharacterDialogueState(state);
        if (state != DialogueState.Disabled)
        {
            controls.NinesControls.Move.performed -= MovePerformed;
            if (_inRange) { _hacking = false; } 
        }
        else if (state == DialogueState.Disabled)
        {
            controls.NinesControls.Move.performed += MovePerformed;
            if (_inRange) { _hacking = true; }
        }
    }

    public delegate void SuspectConvicted(SuspectInteractable suspect);
    public event SuspectConvicted OnSuspectConvicted;

    private void ConvictTarget(InputAction.CallbackContext obj)
    {
        SuspectInteractable sus = ObjectInRange.GetComponent<SuspectInteractable>();
        if (ObjectInRange != null && sus != null && characterDialogue.GetDialogueState() == DialogueState.Disabled)
        {
            OnSuspectConvicted(sus);
            controls.NinesControls.Interact.Disable();
            controls.NinesControls.Move.Disable();
        }
        else if(characterDialogue.GetDialogueState() != DialogueState.Disabled)
        {
            if(characterDialogue.DialogueText == "You have finished the current version of the game.")
            {
                Application.Quit();
            }
            else
            {
                characterDialogue.NextState();
            }

        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        controls.NinesControls.Enable();
        if(SceneManager.GetActiveScene().name == "TrialScene")
        {
            controls.TwobControls.Interact.Enable();
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        controls.NinesControls.Disable();
        if (SceneManager.GetActiveScene().name == "TrialScene")
        {
            controls.TwobControls.Interact.Disable();
        }
    }

    public void OnTriggerEnter(Collider c)
    {
        if(c.tag == "TwoB")
        {
            InRange = true;
            _hacking = true;
            hackingRangeIndicator.color = new Color(1f, 1f, 1f, 0.9f);
            HackingTarget.Draining = false;
        }
    }
    public void OnTriggerExit(Collider c)
    {
        if(c.tag == "TwoB")
        {
            HackingTarget.Draining = true;
            hackingRangeIndicator.color = new Color(1f, 1f, 1f, 0.5f);
            InRange = false;
            _hacking = false;
        }
    }
}
