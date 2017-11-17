using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuyBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
