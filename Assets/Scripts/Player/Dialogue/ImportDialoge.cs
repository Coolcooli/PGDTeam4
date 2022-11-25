using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportDialoge : MonoBehaviour
{
    public TextAsset jsonFile;
    public List<Dialoge> dialoges;
    // Start is called before the first frame update
    void Start()
    {
        Dialoges dialog = JsonUtility.FromJson<Dialoges>(jsonFile.text);

        foreach(Dialoge dialoge in dialog.dialoges)
        {
            dialoges.Add(dialoge);
        }
    }

}
