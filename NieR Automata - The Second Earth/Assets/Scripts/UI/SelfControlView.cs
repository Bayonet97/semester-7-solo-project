using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfControlView : MonoBehaviour
{

    [SerializeField]
    private NineS nines;

    // Start is called before the first frame update
    void Start()
    {
      //  nines = FindObjectOfType<NineS>();
        nines.OnSuspectConvicted += Disable;
    }

    public void OnEnable()
    {


    }
    public void OnDisable()
    {
        nines.OnSuspectConvicted -= Disable;
    }

    private void Disable(SuspectInteractable sus)
    {
        gameObject.SetActive(false);
    }
}
