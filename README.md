# MOBAGame
仿moba类游戏demo，服务器使用PhotonServer。

先上图 演示为固定15帧的gif
![演示图片](https://github.com/anlingbbq/MOBAGame/raw/master/Demo.gif)

## 实现功能

## 主要问题

## 简单的写一些日志：

### -17/3/29 
　这两天折腾服务器的缓存层，由于nhibernate中对数据对象的外键列表，即一对多的关系中，操作时会进行关联查询，单纯的当作对象使用，容易出现类似no session or session was closed的错误，每次都在session中处理又感频繁，这里我使用一个缓存层将用户的角色列表进行深拷贝保存起来。不知道这种处理好不好。
### -17/3/31
　感慨一下，服务器端数据的逻辑真的好容易搞晕，缓存层，数据库层，表，外键，各种缓存的关系很容易乱，调试起来也很麻烦，不知道有没有更好维护的框架。
### -17/5/4
　这几天摸索技能模块的写法，简单记一下，游戏中的技能十分灵活，有伤害类型的，有buff类型的，同时一个技能可能有多种效果，我希望能有一种方式来控制所有的技能，大体思路是技能是通过组合效果的方式来实现技能，一个技能就是实现几种效果函数，核心是利用委托来添加所有的效果函数，执行这个委托就是使用技能。
 
　思路感觉挺简单，但是写了好几天。。有一点比较麻烦的是前期的工作，原始数据是技能，而实际使用的时候需要将技能的数据拆分成效果，再将效果函数组合成技能委托，也许一开始将技能和效果写成两份数据比较好。目前来看这样写的好处是比较灵活，英雄，技能和效果可以自由搭配，增加复用性，所有的技能可以用一套方式处理，加上反射的运用，整体完成后我只需要写效果函数和技能数据，但是效果只能以函数为单位去表现也有一定的限制。
