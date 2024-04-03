using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trangPhuc; // Menu cần tắt
    void Start()
    {
        // Đăng ký sự kiện
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        HideMenu();
        // Viết mã xử lý bạn muốn thực hiện khi nút được nhấn ở đây
    }
    public void HideMenu()
    {
        trangPhuc.SetActive(false); // Hiển thị Menu
    }
}
