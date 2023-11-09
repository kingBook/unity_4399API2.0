4399API2.0

使用步骤：

1. 拷贝以下两个文件夹到新的项目下：
Assets\API4399
Assets\WebGLTemplates

2. 将Assets/API4399/API4399.prefab拖入场景实例化.
注意：
a. 名称必须为“API4399”.
b. “API4399”游戏对象必须在根层级.
c. 在Inspector面板，需勾选EnableAPI，否则调用不起作用.
d. “API4399”游戏对象在整个游戏周期中不销毁（API4399\Plugins\WebGL\4399API.jslib中会使用SendMessage方法发送消息给此对象）.
