using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBestTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteBestTime()
    {
        PlayerPrefs.DeleteKey("BestTime"); //удаляю из памяти компа лучшее время
        //BestTimeScript.instance.successDeletionText.SetActive(true); //показываю надпись о том что лучшее время было удалено
    }
}
