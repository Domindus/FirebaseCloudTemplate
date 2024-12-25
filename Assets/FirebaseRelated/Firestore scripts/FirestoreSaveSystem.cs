using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirestoreSaveSystem : MonoBehaviour
{
    private FirebaseFirestore db;
    private string userID;
    UserSaveData userSaveData;

    private static FirestoreSaveSystem _instance;
    public static FirestoreSaveSystem Instance => _instance;

    ListenerRegistration listenerRegistration;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
        db = FirebaseFirestore.DefaultInstance;
        userID = "testID";

    }
    private void Start()
    {
        userSaveData = UserSaveData.Instance;

        listenerRegistration = UserDocSave().Listen(snapshot =>
        {
            //Код здесь выполнится при изменении сейва на облаке
        });
    }

    public void SaveToCloud()
    {
        if(userSaveData !=null)
           UserDocSave().SetAsync(userSaveData);
    }

    public async Task<UserSaveData> GetDataFromCloudAsync()
    {
        var snapshot = await UserDocSave().GetSnapshotAsync();
        UserSaveData data = null;

        if (snapshot.Exists)
        {
            data = snapshot.ConvertTo<UserSaveData>();
            userSaveData = data;
            Debug.Log($"CurrentLevel: {data.CurrentLevel}, CurrentWave: {data.CurrentWave}");
        }

        return data;
    }

    private DocumentReference UserDocSave()
    {
        return db.Collection("Users").Document(userID);
    }
}
