using System;
using Firebase.Firestore;
using UnityEngine;

[FirestoreData]
public class UserSaveData// попробовать сделать структурой
{
    private int currentLevel;
    private int currentWave;

    private static readonly Lazy<UserSaveData> _instance = new Lazy<UserSaveData>(() => new UserSaveData());
    public static UserSaveData Instance => _instance.Value;

    [FirestoreProperty]
    public int CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }

    [FirestoreProperty]
    public int CurrentWave
    {
        get => currentWave;
        set => currentWave = value;
    }

    private UserSaveData()
    {
        currentLevel = 0;
        currentWave = 0;
    }

}