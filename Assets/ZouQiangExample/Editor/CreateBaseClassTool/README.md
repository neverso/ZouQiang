# Unity 自动生成组件索引类工具 #

----------

## 需求由来 ##
我们在写UI类时 需要获取预设中的组件
```C#
joystick = transform.Find("joystick");
background = transform.Find("joystick/background");
stick = transform.Find("joystick/stick");
direction = transform.Find("joystick/direction");
```
> 缺点
> 1. 需要手写代码
> 2. 修改游戏对象名字需要手动修改代码
> 3. 修改层级需要手动修改代码
> 4. 手写容易出问题


----------
## 解决方案 ##
使用编辑器自动生成如下索引类
```C#
public class MianBase : MonoBehaviour
{
    protected UISprite Left_Sprite;
    protected UITexture Right_Texture;
    protected UISprite Bottom_Sprite;
    protected UILabel Top_Label;

    public void InitBase()
    {
        Left_Sprite = transform.Find("Left/Sprite").GetComponent<UISprite>();
        Right_Texture = transform.Find("Right/Texture").GetComponent<UITexture>();
        Bottom_Sprite = transform.Find("Bottom/Sprite").GetComponent<UISprite>();
        Top_Label = transform.Find("Top/Label").GetComponent<UILabel>();
    }
}
```
然后UI代码继承这个类 
就可以很方便的使用这些组件


----------
## 工具制作 ##
效果如图所示

![](https://i.imgur.com/I8JRpRD.png)

> 工具制作核心思想
> -  选中预设父级
> -  迭代获取子对象和子对象上的脚本
> -  索引变量名可自动填充可自定义
> -  序列化类


----------
## 工具使用方法 ##

1. 选择预设父级
2. 左上角菜单栏ZouQiang/UI/创建预设索引类（快捷键Ctrl+Alt+1）打开窗口
3. 自定义变量名或自动填充变量名
4. 点击生成代码按钮

----------

*如果您有更好的解决方案，请一定不吝赐教,感谢不尽！*

源码：[https://github.com/QiangZou/ZouQiang/blob/master/Assets/ZouQiang/Editor/AssetBundlesTool.cs](https://github.com/QiangZou/ZouQiang/blob/master/Assets/ZouQiang/Editor/AssetBundlesTool.cs)