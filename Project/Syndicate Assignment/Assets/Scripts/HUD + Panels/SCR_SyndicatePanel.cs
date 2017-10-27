using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_SyndicatePanel : MonoBehaviour {

    // ================================== 
    // SyndicatePanel class: 
    // ================================== 
    // - Initialize
    // - Refresh
    // ----------------------------------

    public string Name;                     //panel name

    public virtual void Initialize(){}
    public virtual void Refresh() {}
}
