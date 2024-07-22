using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;


public class LuaMgr : SingletonBase<LuaMgr>
{
    private LuaEnv luaEnv;

    public void Init()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(CustomLoader);

        luaEnv.DoString("require('main')");
    }

    private byte[] CustomLoader(ref string filePath)
    {
        //通过函数中的逻辑 去加载lua文件

        //传入的参数是 require执行的Lua脚本文件名
        Debug.Log(filePath);

        //拼接一个lua文件所在路径
        //Application.dataPath 可以得到Assets路径 
        //记得加上lua后缀
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";

        //有路径 就去加载文件
        //File知识点 C#提供的文件读写的类
        //需要 System.IO命名空间
        //判断文件是否存在
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);

        }
        else
        {
            Debug.Log("不存在lua文件：" + filePath);
        }


        return null;
    }
}
