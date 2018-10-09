using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    void Update()
    {
        // 从 Input 中获取鼠标在屏幕中的当前位置
        Vector3 mousePos2D = Input.mousePosition;
        // 摄像机的 z 坐标决定在三维空间中将鼠标沿 z 轴向前移动多远
        mousePos2D.z = -Camera.main.transform.position.z;
        // 将该点从二维屏幕空间转换为三维游戏世界空间
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //将篮筐的 x 位置移动到鼠标处的 x 位置处
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            //通知 controller 记录积分，并通知 view 更新显示

        }
    }
}
