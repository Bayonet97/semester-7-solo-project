using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        hackingRangeCollider.radius = HackingRange;
        hackingRangeIndicator.size = new Vector2(HackingRange * 2.1f, HackingRange * 2.1f);
    }

    new protected void Update()
    {
        base.Update();

        if (InRange)
        {
            HackingTarget.RestoreSelfControl(HackingSpeed);
        }

    }
    public void ControlContamination(IContaminated contaminated)
    {
        contaminated.RestoreSelfControl(HackingSpeed);
    }

    public override void ChangePausedState(bool paused)
    {
        if (paused)
        {
            oldMovementInput = Vector2.zero;
            Move();
            StopMovementAnimation();
            controls.NinesControls.Move.performed -= MovePerformed;
        }
        else if (!paused)
        {
            controls.NinesControls.Move.performed += MovePerformed;
        }
    }

    protected override void OnEnable()
    {
        controls.NinesControls.Enable();
    }

    protected override void OnDisable()
    {
        controls.NinesControls.Disable();
    }

    public void OnTriggerEnter(Collider c)
    {
        if(c.tag == "TwoB")
        {
            InRange = true;
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
        }
    }
}
