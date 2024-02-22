using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;
using static Unity.Burst.Intrinsics.X86.Avx;

[System.Serializable]
public class MenuManager : MonoBehaviour
{
    public BaseHero hero;
    public Button newGame;
    public Button loadGame;
    public Button saveGame;
    public Button setting;
    public Button exitGame;
    public GameObject UIName;
    public float delayTime = 10f;
    private void Start()
    {
        StartCoroutine(HideUINameAfterDelay());
    }
    public void OnButtonNewGame()
    {        
        SceneManager.LoadScene("Player");
        hero.Reset();
        UIName.SetActive(true);
        
    }
    public void OnButtonSaveGame()
    {
        SaveHeroDataToJson();
        savePositon();
        
    }
    public void OnButtonLoadGame()
    {
        LoadHeroDataFromJson();
        loadPositon();
    }
    public void ButtonQuitGame()
    {
        // Thoát ứng dụng
        Application.Quit();
    }
    private IEnumerator HideUINameAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        UIName.SetActive(false);
    }
    public void ButtonHideHuongDan()
    {
        UIName.SetActive(false);
    }    
    private void SaveHeroDataToJson()
    {
        // Chuyển đổi đối tượng BaseHero thành chuỗi JSON
        string jsonData = JsonConvert.SerializeObject(hero);

        // Lưu chuỗi JSON vào tệp tin
        string filePath = Application.dataPath + "/HeroData.json";
        System.IO.File.WriteAllText(filePath, jsonData);

        Debug.Log("Hero data saved to JSON file." + Application.dataPath);
    }
    private void LoadHeroDataFromJson()
    {
        string filePath = Application.dataPath + "/HeroData.json";

        if (System.IO.File.Exists(filePath))
        {
            // Đọc nội dung từ tệp tin JSON
            string jsonData = System.IO.File.ReadAllText(filePath);

            // Chuyển đổi chuỗi JSON thành đối tượng BaseHero
            BaseHero loadedHero = JsonConvert.DeserializeObject<BaseHero>(jsonData);

            // Gán dữ liệu từ đối tượng tải vào đối tượng BaseHero hiện tại
            hero.CopyFrom(loadedHero);

            Debug.Log("Hero data loaded from JSON file.");
        }
        else
        {
            Debug.Log("Hero data file not found.");
        }
    }
    private void loadPositon()
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            // Khôi phục lại vị trí của Player
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX") + 1f;
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector2(playerPosX, playerPosY);

            // Xóa vị trí đã lưu trong PlayerPrefs
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.Save();
        }

    }
    private void savePositon()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.transform.position;

        // Lưu vị trí của Player vào PlayerPrefs
        PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
        PlayerPrefs.Save();
    }
}