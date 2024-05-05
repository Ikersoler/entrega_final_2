using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dataPersistans : MonoBehaviour
{
    
    private const string NUMBEROFROUNDS = "rondas vivo";

    private SpawnManager spawnManager;

    public int roundsText;

    private const string SAVE_FILE_NAME = "/save-file.txt";

    private RotateCamera cameraRotate;

    //se esta guardando el numero de rondas que se ha sobrevivido
    private void Start()
    {
         spawnManager = FindObjectOfType<SpawnManager>();
        cameraRotate = FindObjectOfType<RotateCamera>();
    }


    public void Save(int Rounds)
    {
        
        //int Rounds = spawnManager.numeroDeRondas;
        
        PlayerPrefs.SetInt(NUMBEROFROUNDS, Rounds);
        
    }

    public void Load ()
    {
        
        if (PlayerPrefs.HasKey(NUMBEROFROUNDS))
        {
            int Round = PlayerPrefs.GetInt (NUMBEROFROUNDS);
            roundsText = Round;
        }
        else
        {
            Debug.LogError("¡¡¡NO TIENES RONDAS GUARDADO!!!");
        }







    }
    //se guarda la rotacion de la camara 
    public void SaveJSON()
    {
        // Obtenemos la información que queremos guardar
         Quaternion rotacion = cameraRotate.getRotation();

        Debug.Log(rotacion);

        // Creamos el objeto de guardado
        SaveObject saveObject = new SaveObject
        {

            camRotation1 = rotacion.x,
            camRotation2 = rotacion.y,
            camRotation3 = rotacion.z,
            camRotation4 = rotacion.w

        };

        // Jsonificamos el objeto de guardado
        string jsonContent = JsonUtility.ToJson(saveObject);
        Debug.Log(Application.dataPath);

        System.IO.File.WriteAllText(Application.dataPath + SAVE_FILE_NAME,
            jsonContent);
    }
    //con esto se carga la posicion de la camara
    public void LoadJSON()
    {
        cameraRotate = FindObjectOfType<RotateCamera>();

        // Comprobar si el archivo existe
        if (System.IO.File.Exists(Application.dataPath + SAVE_FILE_NAME))
        {

            string jsonContent = System.IO.File.ReadAllText(Application.dataPath + SAVE_FILE_NAME);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(jsonContent);
            Debug.Log(cameraRotate == null);
            
            cameraRotate.saveRotation(new Quaternion (saveObject.camRotation1,saveObject.camRotation2,saveObject.camRotation3,saveObject.camRotation4));
            
        }
        else
        {
            Debug.LogError("¡¡¡ EL ARCHIVO DE GUARDADO NO EXISTE !!!");
        }
    }
}
