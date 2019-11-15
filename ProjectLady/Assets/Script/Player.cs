using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    private Vector3 _scale;
    private GameObject _player;
    private float _direction = 1;

    //プレイヤーの加速量を保存する変数
    private float _playerRun;

    //イベント終了
    public delegate void EndEvent();
    public EndEvent _endEvent;

    //リジットボディ変数
    private Rigidbody2D _rb2d;

    //プレイヤーの持っているアイテムのリスト変数
    private List<ItemManager.ITEM> _itemList = new List<ItemManager.ITEM>();
    //プレイヤーが今さわっているアイテムの情報変数
    private ItemManager.ITEM _item;
    private Item currentItem;

    private ItemWindow itemWindow;
    private GameControl gameControl;

    //アニメーターコンポーネント変数
    Animator animator;

    private void Awake()
    {
        gameControl = FindObjectOfType<GameControl>();
    }

    void Start()
    {
        //リジットボディの読み込み
        _rb2d = transform.GetComponent<Rigidbody2D>();

        //アニメーターの読み込み
        animator = GetComponent<Animator>();

        itemWindow = FindObjectOfType<ItemWindow>();
        itemWindow.AddEventUseItem(UseItem);
    }
    void Update()
    {
        PlayerRun();　//プレイヤーのダッシュ（加速）を生成
        PlayerWallk();　//プレイヤーの歩行速度を生成
        transform.localScale = SetPlayerDirection();　//オブジェクトの大きさを取得する関数
        DirectionUpdate();　//プレイヤーの向きをスティックの入力値で変更する関数
        InputKey(); //ボタン入力でアイテムのデータを取得をする関数
        //SetAllItem();
        //SetRemoveItem();
        
    }

    private void SetRemoveItem()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetAllItem();
        }
        //if (Input.GetKeyDown("enterbutton"))
        //{
        //    _itemList.Remove(ItemManager.ITEM.FLAG);
        //}
    }

   //プレイヤーの歩行速度を生成
    private void PlayerWallk()
    {
        var wallk = Vector3.zero; //Vector3(0,0,0)を代入で初期化
        wallk.x = Input.GetAxis("Horizontal") + _playerRun;
        wallk.y = Input.GetAxis("Vertical") + _playerRun;
        if (wallk.y * wallk.y + wallk.x * wallk.x > 0f)
        {
            // 4方向にスナップしたいなら360/4で90を渡す
            var snapped = SnapAngle(new Vector2(wallk.x, wallk.y), 90f * Mathf.Deg2Rad);
            transform.position += (Vector3)snapped * Time.deltaTime;
        }

    }

    Vector2 SnapAngle(Vector2 vector, float angleSize)
    {
        var angle = Mathf.Atan2(vector.y, vector.x);

        var index = Mathf.RoundToInt(angle / angleSize);
        var snappedAngle = index * angleSize;
        var magnitude = vector.magnitude;
        return new Vector2(
            Mathf.Cos(snappedAngle) * magnitude,
            Mathf.Sin(snappedAngle) * magnitude);
    }

    //プレイヤーの向きをスティックの入力値で変更する関数
    private void DirectionUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _direction = Mathf.Sign(Input.GetAxis("Horizontal"));

        }
    }

    //オブジェクトの大きさを取得する関数
    private Vector3 SetPlayerDirection()
    {
        _scale = new Vector3((Mathf.Abs(transform.localScale.x) * _direction), 
            transform.localScale.y, transform.localScale.z);

        return _scale;
    }

    //プレイヤーのダッシュ（加速）を生成している関数
    private void PlayerRun()
    {
        //ダッシュを開始させる条件式(R2,L2トリガー)
        if (Input.GetAxisRaw("runtrigger1")==1 || Input.GetAxisRaw("runtrigger2")==1) 
        {
            if(Input.GetAxisRaw("Horizontal") ==1)   //スティックを右に倒した判定
                _playerRun = 3.0f; //加速量

            if (Input.GetAxisRaw("Horizontal") == -1) //スティックを左を倒した判定
                _playerRun = -3.0f; //加速量

            if (Input.GetAxisRaw("Vertical") == 1)   //スティックを上に倒した判定
                _playerRun = 3.0f; //加速量

            if (Input.GetAxisRaw("Vertical") == -1) //スティックを下に倒した判定
                _playerRun = -3.0f; //加速量
        }
        else if (Input.GetAxisRaw("runtrigger1")==0 || Input.GetAxisRaw("runtrigger2")==0)  //ダッシュ終了の条件式(R2,L2 トリガーを離す)
        {
            _playerRun = 0.0f; //加速量を0にして歩く速度を戻す
        }
    }

    //ボタン入力でアイテムの取得をする関数
    private void InputKey()
    {
        //ボタンを押してアイテムを取得する条件式
        if (Input.GetButtonDown("enterbutton") && currentItem != null)　
        {
            if (_item != ItemManager.ITEM.NULL) _itemList.Add(currentItem._item); //今さわっているアイテムのデータを取得
            currentItem.GetItem();
            SetAllItem();
            Debug.Log("アイテム取得");
            
        }
    }

    private void SetAllItem()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i < _itemList.Count)
            {
            itemWindow.SetItemWindow(i, _itemList[i]);

            }
            else
            {
                itemWindow.SetItemWindow(i, ItemManager.ITEM.NULL);
            }
        }
    }

    //オブジェクトに衝突した際に取得を発生
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")　//Itemのタグがついてるオブジェクトかを認識
        {
            _item = collision.GetComponent<Item>()._item;　//さわっているアイテムの情報の呼び出し
            currentItem = collision.GetComponent<Item>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item")　//Itemのタグがついてるオブジェクトかを認識
        {
            _item = collision.GetComponent<Item>()._item;　//さわっているアイテムの情報の呼び出し
            currentItem = collision.GetComponent<Item>();
        }
    }

    //衝突したオブジェクトから離れた後の処理
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")  //Itemのタグがついてるオブジェクトかを認識
        {
            Item collisionItem = collision.GetComponent<Item>();
            if(currentItem == collisionItem)
            {
                _item = ItemManager.ITEM.NULL;  //変数"_item"の中身を空にする       
                currentItem = null;
            }
        }
    }

    public void UseItem(ItemManager.ITEM item)
    {
        Debug.Log(item);
        gameControl.UseItemCurrentEvent(item);
        //if(item == ItemManager.ITEM.FLAG)
        //{
        //    Debug.Log("サクランボ使ったよ");

        //}
    }
    
}
