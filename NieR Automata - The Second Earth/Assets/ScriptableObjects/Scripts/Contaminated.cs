using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Contaminated")]
public class Contaminated : ScriptableObject, IContaminated
{
    public delegate void SelfControlChanged(int newValue);
    public static event SelfControlChanged OnSelfControlChanged;

    public delegate void SelfControlEmpty();
    public static event SelfControlEmpty OnSelfControlEmpty;

    [SerializeField]
    private AnimationCurve _selfControlCurve;
    public AnimationCurve SelfControlCurve { get => _selfControlCurve; set => _selfControlCurve = value; }

    [SerializeField]
    private int _maxSelfControl;
    public int MaxSelfControl { get => _maxSelfControl; set => _maxSelfControl = value; }

    [SerializeField]
    private int _selfControl;
    public int SelfControl
    {
        get => _selfControl;
        set
        {
            _selfControl = value;
            OnSelfControlChanged(value);
        }
    }

    private float selfControlDecimal;

    [SerializeField]
    private int _drainRate;
    public int DrainRate { get => _drainRate; set => _drainRate = value; }

    [SerializeField]
    private bool _draining;
    public bool Draining { get => _draining; set => _draining = value; }

    public void DrainSelfControl(int drainAmount)
    {
        if (SelfControl > 0)
        {
            selfControlDecimal -= drainAmount * Time.deltaTime;
            SelfControl = Mathf.RoundToInt(selfControlDecimal);

            OnSelfControlChanged(SelfControl);
        }
        else
        {
            Draining = false;
            OnSelfControlEmpty();
        }
    }

    public void RestoreSelfControl(int restoreAmount)
    {
        if (SelfControl < MaxSelfControl)
        {
            selfControlDecimal += restoreAmount * Time.deltaTime;
            SelfControl = Mathf.RoundToInt(selfControlDecimal);

            OnSelfControlChanged(SelfControl);
        }
    }

    public void OnEnable()
    {
        //SelfControl = MaxSelfControl;
        selfControlDecimal = MaxSelfControl;
        Draining = true;
    }
}
