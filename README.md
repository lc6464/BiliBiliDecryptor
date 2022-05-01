## BiliBiliDecryptor - 哔哩哔哩视频解密工具

众所周知，自 2.14.72 版本开始，Microsoft Store 中“哔哩哔哩动画”应用下载的视频会被“加密”。

~~所谓“加密”，不过就是在文件最开头加入了三个字节，均为 0xFF.~~

此工具可用于快速解密这样的视频，在原视频目录下创建解密后的视频文件。

如 `C:\Users\LC\Downloads\BiliBili\abcd.mp4` -> `C:\Users\LC\Downloads\BiliBili\abcd - decrypted.mp4`

### 下载
1. 在[发行版](https://github.com/lc6464/BiliBiliDecryptor/releases "Releases · lc6464/BiliBiliDecryptor")中下载。
2. 克隆项目到本地，自行使用 Visual Studio 发布或 `dotnet publish` 命令发布。

### 使用方法
1. 图形界面使用：直接将加密的视频文件拖到下载下来的 EXE 文件上。
2. CLI：`.\BiliBiliDecryptor.exe [File0] [File1] [File2] [File3] ...`