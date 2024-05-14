using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCursor : MonoBehaviour
{
    [SerializeField] Fade fade;                // FadeCanvas
    [SerializeField] RectTransform[] ObjRect;  // 座標参照のtext
    [SerializeField] GameObject OptionBox;     // オプションを開く
    RectTransform myObjRect;                   // 動かすtext
    int num;
    int Max;
    int Min;
    void Start()
    {
        // コンポーネント取得
        myObjRect = GetComponent<RectTransform>();
        // 配列番号のMaxを取得
        Max = ObjRect.Length-1;
        // 配列番号のMinを0とする
        Min = 0;
    }
    // 入力関連
    void InputKey() {
        if(Input.GetKeyDown(KeyCode.W)
            ||Input.GetKeyDown(KeyCode.UpArrow)) // 上
        {
            if(num==Min)
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
            if(num==Max)
            {
                num = Min;
            }
            else
            {
                num += 1;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return)) // 決定
        {
            switch (num)
            {
                case 0: // STARTボタン
                    fade.FadeIn(0.5f, () => SceneManager.LoadScene("StageSelectScene"));
                    break;
                case 1: // OPTIONボタン
                    OptionBox.SetActive(true);
                    break;
                case 2: // ENDボタン 
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif

                    break;
            }
        }
    }
    void RectPos()
    {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition =
          ObjRect[num].anchoredPosition ;
    }
    // Update is called once per frame
    void Update()
    {
        if (OptionBox.activeSelf == true) { return; }
        InputKey();
        RectPos();
    }
}
