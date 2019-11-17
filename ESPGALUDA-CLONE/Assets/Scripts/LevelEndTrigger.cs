using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour {

    public string stopAudioEvent;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Camera")) {
            SceneManager.LoadScene("WinScreen");
            //Fabric.EventManager.Instance.PostEvent(stopAudioEvent);
        }
    }
}
