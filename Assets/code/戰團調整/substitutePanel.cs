using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class substitutePanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject headPrafeb;
    public teamPanel girdControl;
    public GameObject rolePanel;
    public GameObject root;
    List<GameObject> heads = new List<GameObject>();
    public const float x_start = 0.6f;
    public const float x_offset = 1f;
    public const float y_pos = 0.25f;
    protected float scale = 1;
    public static substitutePanel main;
    void OnEnable()
    {
        if (main != null)
        {
            Destroy(this);
        }
        else
        {
            main = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        int height = Camera.main.scaledPixelHeight;
        int width = Camera.main.scaledPixelWidth;
        Vector2 s_LU = teamPanel.ScreenLeftUp();
        Vector2 s_RD = teamPanel.ScreenRightDown();
        float screen_up = s_LU.y;
        float screen_height = s_RD.y - s_LU.y;
        float screen_width = s_RD.x - s_LU.x;
        float screen_left = s_LU.x;
        float screen_right = s_RD.x;

        Vector2 team0_lu = new Vector2(screen_left, screen_up);
        Vector2 team0_rd = new Vector2(screen_right, screen_up + 0.4f * screen_height);
        Vector2 team1_lu = new Vector2(screen_left, screen_up + 0.4f * screen_height);
        Vector2 team1_rd = new Vector2(screen_right, screen_up + 0.8f * screen_height);
        //Debug.Log("camera width:"+width+" height:"+height);
        //Debug.Log("screen left up:"+teamPanel.ScreenLeftUp());
        //Debug.Log("screen right down:" + teamPanel.ScreenRightDown());
        girdControl.createGroup(null, new vec2i(5, 4), team0_lu, team0_rd);
        girdControl.createGroup(null, new vec2i(5, 4), team1_lu, team1_rd);
        initForPlayerInf(dataWarehouse.main.nowData);
    }
    public void initForPlayerInf(PlayerInf inf)
    {
        foreach(RoleRecord role in inf.army)
        {
            Debug.Log("創建頭像 location:"+role.location);
            if (role.location == null)
            {
                createHead(role);
            }
            else {
                createHead(1, role);
            }
        }
    }
    public void deleteHeads()
    {
        foreach (GameObject head in heads)
        {
            Destroy(head);
        }
        heads.Clear();
    }
    public void updatePanel(PlayerInf inf)
    {
        deleteHeads();
        initForPlayerInf(inf);
    }
    public void createHead(RoleRecord data)
    {
        GameObject headIcon = Instantiate(headPrafeb, panel.transform);
        headIcon.transform.localPosition = new Vector2(x_start + x_offset * heads.Count, y_pos);
        headIcon.GetComponent<headEvent>().data = data;
        headIcon.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[data.race];
        heads.Add(headIcon);
    }
    public void createHead(int groupNo, RoleRecord data) {
        GameObject[,] map = girdControl.girdGroups[groupNo];
        vec2i location = data.location;
        Vector2 pos = map[location.y, location.x].transform.position;
        GameObject headIcon = Instantiate(headPrafeb, pos, Quaternion.Euler(0, 0, 0));
        headIcon.GetComponent<headEvent>().data = data;
        headIcon.GetComponent<headEvent>().rolePanel = rolePanel;
        heads.Add(headIcon);
        headIcon.GetComponent<SpriteRenderer>().sprite = ImageList.main.headIcons[data.race];
        headIcon.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
    }
    public void onPhantomDele(headPhantom phantom)
    {
        string message = "刪除幻影時gird物件數量為:" + phantom.girdsAttach.Count;
        if (phantom.girdsAttach.Count > 0)
        {
            gird nearest = phantom.girdsAttach[0].GetComponent<gird>();
            float min_dist = (phantom.girdsAttach[0].transform.position - nearest.transform.position).magnitude;
            foreach (GameObject gird in phantom.girdsAttach)
            {

                float dist = (gird.transform.position - phantom.transform.position).magnitude;
                if (dist < min_dist)
                {
                    nearest = gird.GetComponent<gird>();
                }
                //message += "  " + gird.gameObject.name + "pos:(" + script.x + "," + script.y + ")";
                phantom.data.location = new vec2i(nearest.x, nearest.y);
            }
            
        }
        else
        {
            phantom.data.location = null;
        }
        updatePanel(dataWarehouse.main.nowData);
        Debug.Log(message);
    }
    public void saveInf() {
        dataWarehouse.main.nowData.saveInf();
    }
    public void quit()
    {
        deleteHeads();
        girdControl.deleteGirds();
        root.SetActive(false);
    }
}
