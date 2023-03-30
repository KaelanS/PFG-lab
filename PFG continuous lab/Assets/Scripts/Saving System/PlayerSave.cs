using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    [SerializeField] private int Points = 0;
    private SaveManager saveManager;

    void Start() {
        saveManager = FindObjectOfType<SaveManager>();
        Points = saveManager.LoadGame();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Points++;
            print("Score up");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            saveManager.SaveGame(Points);
            print("Data saved");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Points = saveManager.LoadGame();
            print($"Saved score is: {Points}");
        }
    }
}