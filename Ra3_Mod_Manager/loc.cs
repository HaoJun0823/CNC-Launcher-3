using System;
using System.Collections.Generic;
using System.Text;

namespace Ra3_Mod_Manager
{
    public static class loc
    {
        public static String[] inf = { "English", "简体中文", "繁體中文" };
        public static String[] infcode = { "english", "schinese", "tchinese" };
        public static int current = 2;

        public static String[]

            con_title = new String[inf.Length],
            btn_information = new String[inf.Length],
            btn_modfolder = new String[inf.Length],
            btn_ra3ui = new String[inf.Length],
            btn_saveoption = new String[inf.Length],
            btn_startgame = new String[inf.Length],
            btn_website = new String[inf.Length],
            cb_customresolution = new String[inf.Length],
            cb_media = new String[inf.Length],
            cb_windowed = new String[inf.Length],
            in_author = new String[inf.Length],
            in_error = new String[inf.Length],
            in_execption = new String[inf.Length],
            in_game = new String[inf.Length],
            in_game_dlc = new String[inf.Length],
            in_information = new String[inf.Length],
            in_noinf = new String[inf.Length],
            in_notfound = new String[inf.Length],
            lb_game = new String[inf.Length],
            lb_height = new String[inf.Length],
            lb_version = new String[inf.Length],
            lb_width = new String[inf.Length],
            in_running = new String[inf.Length],
            cb_bfs = new String[inf.Length],
            set_lang_title = new String[inf.Length],
            btn_map = new String[inf.Length],
            btn_document = new String[inf.Length],
            in_notDir = new string[inf.Length],
            btn_shortcut = new string[inf.Length],

            //2019/05/11
            cb_mouse_locked = new string[inf.Length],
            cb_dynamic_mouse = new string[inf.Length],
            btn_extra = new string[inf.Length],
            dat_desc = new string[inf.Length],
            info_first = new string[inf.Length],
            btn_author = new string[inf.Length],
            open_page = new string[inf.Length],
            open_extra_page = new string[inf.Length],
            open_extra_page_cb = new string[inf.Length],
            open_extra_page_btn = new string[inf.Length],
            open_extra_page_title = new string[inf.Length],
            open_extra_page_always = new string[inf.Length],
            lang_label_text = new string[inf.Length],
            lang_label_text_author = new string[inf.Length],
            lang_label_button = new string[inf.Length],
            lang_label_title = new string[inf.Length],
            lang_label_message_title = new string[inf.Length],
            lang_label_message_description = new string[inf.Length],
            check_vaild_description = new string[inf.Length],
            check_vaild_title = new string[inf.Length],
            first_time_run_title = new string[inf.Length],
            first_time_run_description = new string[inf.Length],


            //2019/10/17

            plugin_title = new string[inf.Length],
            plugin_activate = new string[inf.Length],
            plugin_deactivate = new string[inf.Length],
            plugin_dll = new string[inf.Length],
            plugin_txt = new string[inf.Length],
            plugin_del = new string[inf.Length],
            plugin_download = new string[inf.Length],
            plugin_delete_confirm = new string[inf.Length],
            plugin_choose = new string[inf.Length]




            ;




        static loc()
        {
            int i = 0;
            //English
            con_title[i] = "Command & Conquer:Red Alert 3 Mod Manager";
            btn_information[i] = "Introduce";
            btn_modfolder[i] = "Mod Folder";
            btn_ra3ui[i] = "Ra3 Panel";
            btn_saveoption[i] = "Save Options";
            btn_startgame[i] = "Start Game";
            btn_website[i] = "Web Site";
            cb_customresolution[i] = "Custom Resolution";
            cb_media[i] = "Media";
            cb_windowed[i] = "Windowed";
            in_author[i] = "Red Alert 3 Mod Manager Author:Randerion(HaoJun0823) from China Version:" + Config.exeVersion;
            in_error[i] = "Error:";
            in_execption[i] = "Execption:";
            in_game[i] = "Command & Conquer:Red Alert 3";
            in_game_dlc[i] = "Uprising";
            in_information[i] = "Information:";
            in_noinf[i] = "This mod doesn't have any introduce";
            in_notfound[i] = "Please move this application into the Red Alert 3 Game Directory.Error:Cannot find game file:";
            lb_game[i] = "Game:";
            lb_version[i] = "Version:";
            lb_height[i] = "Height:";
            lb_width[i] = "Width:";
            in_running[i] = "I'm running, don't open the second.";
            cb_bfs[i] = "Borderless Windowed (Full Screen)";
            set_lang_title[i] = "Language Chooser";
            btn_map[i] = "Maps";
            btn_document[i] = "Replays";
            in_notDir[i] = "Directory is not exists:";
            btn_shortcut[i] = "Create Shortcut";
            cb_mouse_locked[i] = "(Border Windowed)Mouse locked?";
            cb_dynamic_mouse[i] = "(Border Windowed)Mouse edge movement?";
            btn_extra[i] = "Extra";
            btn_author[i] = "Tool Homepage";
            info_first[i] = "Thank you for using this tool! (Or maybe it has a problem recovery)\nThis tool is made to share the \"Command and Conquer\" series of games, so that more people like this classic masterpiece.\nToday, there are still a large number of players and Modders in the world to enrich the game in their own way, maps, models, videos, music, various ideas...\nIf you have any talents or ideas, please share them with others to create more fun!Of course, I will also write the problems we are currently experiencing in this software.If you are willing to help me, please contact me via email: modder@haojun0823.xyz\nEnjoy the game!\nRanderion(HaoJun0823)\nblog.haojun0823.xyz";
            dat_desc[i] = "This file is generated by the RA3 ModManager and is used to record the relevant configuration. If you can't open the program, you can manually delete this file.";
            open_page[i] = "Open a webpage from a browser?";
            open_extra_page[i] = "Open mod's built-in webpage?\n Warning!Please ensure that the mod is trusted!Because web pages can contain dangerous content!\n(This feature commemorates the \"Commander News\" of the original game)";
            open_extra_page_title[i] = "Commander News";
            open_extra_page_cb[i] = "OK";
            open_extra_page_btn[i] = "Don't show me this panel";
            open_extra_page_always[i] = "Warning! The author wants to pop up a news board similar to the original game. \nBecause this is made with a web page, malicious content may be implanted, you can view it, or cancel it and never look at it(but you can still view it with the \"extra\" button).";
            lang_label_title[i] = "Choose your language:";
            lang_label_button[i] = "Gocha!";
            lang_label_text[i] = "This is English,Example:\nBe one with Yuri!";
            lang_label_text_author[i] = "\n\nEnglish,By Randerion(HaoJun0823)";
            lang_label_message_title[i] = "Ah?";
            lang_label_message_description[i] = "Your need choose a language to continue!\nApplication will closed, please open again...";
            check_vaild_description[i] = "Unable to find the mod in the configuration, please reconfigure.";
            check_vaild_title[i] = "error:";
            first_time_run_title[i] = "Prompt:";
            first_time_run_description[i] = "You can add \"-ui\" to open the control panel just like the original game. \nWhen you run successfully for the first time, if there is no \"-ui\", the next time this will automatically start the last game. \nYou can also create a shortcut for each module that opens the corresponding module and uses your configuration without having to launch through the Control Center.\n\nBecause the launcher can't judge whether the game version is Origin or Steam, for compatibility, we created Steam_appid.txt in the directory, so that the Steam version can start normally.";
            plugin_title[i] = "Plugins";
            plugin_activate[i] = "Enable";
            plugin_deactivate[i] = "Disable";
            plugin_dll[i] = "Dynamic Link Library Hook";
            plugin_txt[i] = "Dynamic Memory Data Inject";
            plugin_del[i] = "Delete";
            plugin_download[i] = "Download New Plugins";
            plugin_delete_confirm[i] = "You Really want to delete this file?";
            plugin_choose[i] = "Please select a plugin from the left";

            i++;
            //CS
            con_title[i] = "命令与征服：红色警戒3模组管理器";
            btn_information[i] = "介绍";
            btn_modfolder[i] = "数据目录";
            btn_ra3ui[i] = "控制中心";
            btn_saveoption[i] = "保存配置";
            btn_startgame[i] = "开始游戏";
            btn_website[i] = "模组网站";
            cb_customresolution[i] = "自定义分辨率";
            cb_media[i] = "多媒体";
            cb_windowed[i] = "窗口化";
            in_author[i] = "红色警戒3模组管理器 作者：Randerion(HaoJun0823) 来自中国 版本：" + Config.exeVersion;
            in_error[i] = "错误：";
            in_execption[i] = "异常：";
            in_game[i] = "命令与征服：红色警戒3";
            in_game_dlc[i] = "起义时刻";
            in_information[i] = "信息：";
            in_noinf[i] = "这个模组没有任何介绍资料。";
            in_notfound[i] = "请将此运行程序移动至红色警戒3的游戏目录中。错误：没有找到游戏文件：";
            lb_game[i] = "游戏：";
            lb_version[i] = "版本：";
            lb_height[i] = "高度：";
            lb_width[i] = "宽度：";
            in_running[i] = "正在运行，不要开启第二个。";
            cb_bfs[i] = "无边框窗口化（全屏）";
            set_lang_title[i] = "语言选择器";
            btn_map[i] = "地图";
            btn_document[i] = "录像";
            in_notDir[i] = "目录不存在：";
            btn_shortcut[i] = "创建快捷方式";
            cb_mouse_locked[i] = "（无边框窗口模式）鼠标锁定窗口？";
            cb_dynamic_mouse[i] = "（无边框窗口模式）鼠标边缘移动？";
            btn_extra[i] = "额外";
            btn_author[i] = "工具主页";
            info_first[i] = "感谢你使用这个工具！（又或者是它发生了问题恢复了）\n这个工具是为了分享《命令与征服》系列游戏制作出来的，让更多人喜欢这款经典巨作。\n时至今日，世界上仍然有大量玩家和Modder用自己的方式丰富这个游戏，地图、模型、视频、音乐，各种创意……\n如果你有任何才华或者想法，请大胆地与其他人分享，来创作出更多的乐趣！当然，我也会把我们当前遇到的问题写在这个软件里，如果你愿意帮助我，请通过邮箱与我联系: modder@haojun0823.xyz\n享受游戏！\nRanderion(HaoJun0823)\nblog.haojun0823.xyz";
            dat_desc[i] = "该文件由RA3 ModManager生成，用于记录相关配置。 如果无法打开该程序，则可以手动删除该文件。";
            open_page[i] = "从浏览器打开网页？";
            open_extra_page[i] = "打开Mod的内置网页吗？\n警告！请保证该Mod是可信的！因为网页可能包含危险内容！\n（该功能纪念原版游戏的“指挥官新闻”）";
            open_extra_page_title[i] = "指挥官新闻";
            open_extra_page_cb[i] = "好的";
            open_extra_page_btn[i] = "不要再显示这个面板";
            open_extra_page_always[i] = "注意！这位作者想弹出一个类似原版游戏的新闻板。\n因为这是用网页制作的，所以可能会植入恶意内容，你可以查看，或者取消并永远不看（但你仍然可以通过“额外”按钮查看）。";
            lang_label_title[i] = "选择你的语言：";
            lang_label_button[i] = "是它！";
            lang_label_text[i] = "This is Simplified Chinese,Example:\n和平来自力量！";
            lang_label_text_author[i] = "\n\n简体中文,来自 Randerion(HaoJun0823)";
            lang_label_message_title[i] = "啊咧咧？";
            lang_label_message_description[i] = "你需要选择一个语言才能继续！\n程序将会关闭，请重新打开……";
            check_vaild_description[i] = "无法找到配置中的Mod，请重新配置。";
            check_vaild_title[i] = "错误：";
            first_time_run_title[i] = "提示：";
            first_time_run_description[i] = "你可以像原版游戏一样添加“-ui”来打开控制面板。\n当你首次运行成功后，若没有“-ui”，下一次这会自动启动上次的游戏。\n你也可以为每一个模组创建一个快捷方式，这些快捷方式会分别打开对应的模组并使用你的配置，而不需要通过控制中心启动。\n\n因为启动器无法判断游戏版本是Origin还是Steam，为了兼容性,我们在目录下创建了Steam_appid.txt，让Steam版本可以正常启动。";
            plugin_title[i] = "插件";
            plugin_activate[i] = "启用";
            plugin_deactivate[i] = "禁用";
            plugin_dll[i] = "挂载动态链接";
            plugin_txt[i] = "注入动态内存";
            plugin_del[i] = "删除";
            plugin_download[i] = "下载新插件";
            plugin_delete_confirm[i] = "你真的要删掉这个文件？";
            plugin_choose[i] = "请从左侧选择一个插件";


            i++;
            //TS

            con_title[i] = "終極動員令：紅色警戒3模組管理器";
            btn_information[i] = "介紹";
            btn_modfolder[i] = "數據目錄";
            btn_ra3ui[i] = "控制中心";
            btn_saveoption[i] = "保存配置";
            btn_startgame[i] = "開始遊戲";
            btn_website[i] = "模組網站";
            cb_customresolution[i] = "自定義分辨率";
            cb_media[i] = "多媒體";
            cb_windowed[i] = "窗口化";
            in_author[i] = "紅色警戒3模組管理器 作者：Randerion(HaoJun0823) 來自中國 版本：" + Config.exeVersion;
            in_error[i] = "錯誤：";
            in_execption[i] = "異常：";
            in_game[i] = "終極動員令：紅色警戒3";
            in_game_dlc[i] = "起義時刻";
            in_information[i] = "信息：";
            in_noinf[i] = "這個模組沒有任何介紹資料。";
            in_notfound[i] = "請將此運行程序移動至紅色警戒3的遊戲目錄中。錯誤：沒有找到遊戲文件：";
            lb_game[i] = "遊戲：";
            lb_version[i] = "版本：";
            lb_height[i] = "高度：";
            lb_width[i] = "寬度：";
            in_running[i] = "正在運行，不要開啟第二個。";
            cb_bfs[i] = "無邊框窗口化（全屏）";
            set_lang_title[i] = "語言選擇器";
            btn_map[i] = "地圖";
            btn_document[i] = "錄像";
            in_notDir[i] = "目錄不存在：";
            btn_shortcut[i] = "創建快捷方式";
            cb_mouse_locked[i] = "（無邊框窗口模式）鼠標鎖定窗口？";
            cb_dynamic_mouse[i] = "（無邊框窗口模式）鼠標邊緣移動？";
            btn_author[i] = "工具主頁";
            btn_extra[i] = "額外";
            info_first[i] = "感謝妳使用這個工具！（又或者是它發生了問題恢復了）\n這個工具是為了分享《命令與征服》系列遊戲制作出來的，讓更多人喜歡這款經典巨作。\n時至今日，世界上仍然有大量玩家和Modder用自己的方式豐富這個遊戲，地圖、模型、視頻、音樂，各種創意……\n如果妳有任何才華或者想法，請大膽地與其他人分享，來創作出更多的樂趣！當然，我也會把我們當前遇到的問題寫在這個軟件裏，如果妳願意幫助我，請通過郵箱與我聯系: modder@haojun0823.xyz\n享受遊戲！\nRanderion(HaoJun0823)\nblog.haojun0823.xyz";
            dat_desc[i] = "該文件由RA3 ModManager生成，用於記錄相關配置。如果無法打開該程序，則可以手動刪除該文件。";
            open_page[i] = "從瀏覽器打開網頁？";
            open_extra_page[i] = "打開Mod的內置網頁嗎？\n警告！請保證該Mod是可信的！因為網頁可能包含危險內容！\n（該功能紀念原版遊戲的“指揮官新聞”）";
            open_extra_page_title[i] = "指揮官新聞";
            open_extra_page_cb[i] = "好的";
            open_extra_page_btn[i] = "不要再顯示這個面板";
            open_extra_page_always[i] = "註意！這位作者想彈出壹個類似原版遊戲的新聞板。\n因為這是用網頁制作的，所以可能會植入惡意內容，妳可以查看，或者取消並永遠不看（但妳仍然可以通過“額外”按鈕查看）。";
            lang_label_title[i] = "選擇妳的語言：";
            lang_label_button[i] = "是它！";
            lang_label_text[i] = "This is Traditional Chinese, Example:\n和平來自力量！";
            lang_label_text_author[i] = "\n\n繁體中文,來自 Randerion(HaoJun0823)";
            lang_label_message_title[i] = "啊咧咧？";
            lang_label_message_description[i] = "妳需要選擇壹個語言才能繼續！\n程序將會關閉，請重新打開……";
            check_vaild_description[i] = "無法找到配置中的Mod，請重新配置。";
            check_vaild_title[i] = "錯誤：";
            first_time_run_title[i] = "提示：";
            first_time_run_description[i] = "妳可以像原版遊戲壹樣添加“-ui”來打開控制面板。\n當妳首次運行成功後，若沒有“-ui”，下壹次這會自動啟動上次的遊戲。\n妳也可以為每壹個模組創建壹個快捷方式，這些快捷方式會分別打開對應的模組並使用妳的配置，而不需要通過控制中心啟動。\n\n因為啟動器無法判斷遊戲版本是Origin還是Steam，為了兼容性,我們在目錄下創建了Steam_appid.txt，讓Steam版本可以正常啟動。";
            plugin_title[i] = "插件";
            plugin_activate[i] = "啟用";
            plugin_deactivate[i] = "禁用";
            plugin_dll[i] = "掛載動態鏈接";
            plugin_txt[i] = "註入動態內存";
            plugin_del[i] = "刪除";
            plugin_download[i] = "下載新插件";
            plugin_delete_confirm[i] = "妳真的要刪掉這個文件？";
            plugin_choose[i] = "請從左側選擇壹個插件";

        }
    }
}
