using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogeTrigger : MonoBehaviour
{
    public UnityEvent<Dialoge> onDialogeTrigger;
    private Dialoges dialoges;
    [SerializeField]
    private DialogeManager dialogeManager;
    public int index;
    [SerializeField]
    //public ImportDialoge dialogeImporter;

    public void OnTriggerEnter(Collider other)
    {
        Dialoge dialoge = dialogeManager.dialoges[index];
        onDialogeTrigger.Invoke(dialoge);
    }
}
