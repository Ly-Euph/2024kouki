using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionUICur : MonoBehaviour
{
    // フェードの実装
    [SerializeField] Fade fade;

    // ターゲット座標
    [SerializeField] RectTransform[] List;

    // Optionを表示
    [SerializeField] GameObject OpBox;

    [SerializeField] GameObject UIPre;

    int num = 0;
    int Max = 1;
    int Min = 0;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }
    private void OnEnable()
    {
        num = 0;
    }
    // Update is called once per frame
    void Update()
    {
        InputKey();
        RectPos();
    }
    void RectPos()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition =
          List[num].anchoredPosition;
    }
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.UpArrow)) // 上
        {
            if (num == Min)
            {
                num = Max;
            }
            else
            {
                num -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.DownArrow)) // 下
        {
            if (num == Max)
            {
                num = Min;
            }
            else
            {
                num += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)) // 決定
        {
            switch (num)
            {
                case 0: // Option
                    OpBox.SetActive(true);
                    UIPre.SetActive(false);
                    break;
                case 1:
                    fade.FadeIn(0.5f,()=> SceneManager.LoadScene("TitleScene"));
                    UIPre.SetActive(false);
                    break;
            }
        }
    }
}
