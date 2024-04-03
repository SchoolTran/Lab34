using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuChinh;
    public GameObject menuTrangPhuc;
    void Start()
    {
        HideMenu();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuChinh.activeSelf)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    void ShowMenu()
    {
        menuChinh.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian trong trò chơi khi hiển thị menu
    }

    void HideMenu()
    {
        menuChinh.SetActive(false);
        menuTrangPhuc.SetActive(false);
        Time.timeScale = 1f; // Khôi phục thời gian khi ẩn menu
    }
}
