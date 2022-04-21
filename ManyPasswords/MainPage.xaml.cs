﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ManyPasswords
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static List<OnePassword> BuildIn = null;

        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonForegroundColor = Colors.Black;
            titleBar.ButtonInactiveForegroundColor = Colors.Gray;

            ///将存储的账号读取出来
            ReadFile();

            ///在程序刚启动时加载好内置的账号
            BuildIn = new List<OnePassword> {
                new OnePassword("Apple", "苹果",
                                        "苹果公司（Apple Inc.）是美国的一家高科技公司，2007年由苹果电脑公司（Apple Computer, Inc.）更名而来，核心业务为电子科技产品，总部位于加利福尼亚州的库比蒂诺。（来自必应网典）",
                                        "https://www.apple.com/cn/",'P'),
                new OnePassword("iQIYI", "爱奇艺",
                                        "爱奇艺原名奇艺，是一个百度旗下的独立视频网站，于2010年1月创立，由美国私募股权投资公司普罗维登斯资本投资、龚宇博士担任公司首席执行官。汤兴博士担任公司首席技术官，马东担任公司首席内容官。 爱奇艺的内容以综艺娱乐为主。（来自必应网典）",
                                        "http://www.iqiyi.com/",'A'),
                new OnePassword("Baidu", "百度",
                                        "百度（Nasdaq：BIDU）是全球最大的中文搜索引擎，2000年1月由李彦宏、徐勇两人创立于北京中关村，百度致力于向人们提供“简单，可依赖”的信息获取方式。（来自必应网典）",
                                        "https://www.baidu.com/",'B'),
                new OnePassword("bilibili", "哔哩哔哩",
                                        "bilibili是中国大陆一个ACG相关的弹幕视频分享网站，也被称为哔哩哔哩、B站，其前身为视频分享网站Mikufans。该网站相比其他国内的视频网站最大的特点是悬浮于视频上方的实时评论功能。（来自必应网典）",
                                        "http://www.bilibili.com/",'B'),
                new OnePassword("DouYu", "斗鱼TV",
                                        "斗鱼TV是一家弹幕式直播分享网站，是国内直播分享网站中的一员。斗鱼TV的前身为ACFUN生放送直播，于2014年1月1日起正式更名为斗鱼TV。斗鱼TV以游戏直播为主，涵盖了体育、综艺、娱乐等多种直播内容。（来自必应网典）",
                                        "https://www.douyu.com/",'D'),
                new OnePassword("Facebook", "Facebook",
                                        "Facebook（原本称作thefacebook）是一家位于门洛帕克 (加利福尼亚州)的在线社交网络服务网站。其名称的灵感来自美国高中提供给学生包含照片和联系数据的通信录（或称花名册）昵称“face book”。（来自必应网典）",
                                        "https://www.facebook.com/",'F'),
                new OnePassword("GitHub", "GitHub",
                                        "GitHub是一个通过Git进行版本控制的软件源代码托管服务，由GitHub公司（曾称Logical Awesome）的开发者Chris Wanstrath、PJ Hyett和Tom Preston-Werner使用Ruby on Rails编写而成。（来自必应网典）",
                                        "https://github.com/",'G'),
                new OnePassword("Google", "谷歌",
                                        "Google公司，是一家美国的跨国科技企业，业务范围涵盖互联网搜索、云计算、广告技术等领域，开发并提供大量基于互联网的产品与服务，其主要利润来自于AdWords等广告服务。（来自必应网典）",
                                        "https://www.google.com.hk/",'G'),
                new OnePassword("Instagram", "Instagram",
                                        "Instnstagram是一个免费提供在线图片及短视频分享的社交应用，于2010年10月发布。Instagram的名称取自“即时”（英语：instant）与“电报”（英语：telegram）两个单词的结合。（来自必应网典）",
                                        "https://www.instagram.com/",'I'),
                new OnePassword("ITHome", "IT之家",
                                        "软媒的前身，是青岛乐购信息技术有限公司和北京掌秀无线互动娱乐有限公司，新软媒公司将北京和青岛的公司业务融为一体并重新业务整合，为互联网、PC电脑用户、手机用户、平板电脑用户提供我们所擅长的产品和服务。（来自必应网典）",
                                        "https://www.ithome.com/",'I'),
                new OnePassword("JD", "京东",
                                        "京东是中国最大的自营式电商企业，京东创始人刘强东担任京东集团CEO。2014年5月22日，京东在纳斯达克挂牌，是仅次于阿里巴巴、腾讯、百度的中国第四大互联网上市公司 。（来自必应网典）",
                                        "https://www.jd.com/",'J'),
                new OnePassword("Line", "Line",
                                        "Line由韩国互联网集团NHN的日本子公司NHN Japan推出。虽然是一个起步较晚的通讯应用，2011年6月才正式推向市场，但全球注册用户超过4亿。 即时通讯应用Line于2016年7月15日在东京上市，同时也在美国时间2016年7月14日在纽约上市。（来自必应网典）",
                                        " http://line.naver.jp/",'L'),
                new OnePassword("LinkedIn", "领英",
                                        "LinkedIn是全球最大的职业社交网站，是一家面向商业客户的社交网络（SNS），中文名为领英。LinkedIn成立于2002年12月并于2003年启动，于2011年5月20日在美上市，总部位于美国加利福尼亚州山景城。（来自必应网典）",
                                        "http://www.linkedin.com/",'L'),
                new OnePassword("Microsoft", "微软",
                                        "微软 (Microsoft)，是一家总部位于美国的跨国电脑科技公司，是世界PC机软件开发的先导，由比尔•盖茨与保罗•艾伦创始于1975年，公司总部设立在华盛顿州的雷德蒙德市。（来自必应网典）",
                                        "https://www.microsoft.com/zh-cn",'W'),
                new OnePassword("Naver", "Naver",
                                        "NAVER（네이버）是Naver公司旗下韩国著名入口／搜索引擎网站，其Logo为一顶草帽，于1999年6月正式投入使用。它使用独有的搜索引擎，并且在韩文搜寻服务中独占鳌头。（来自必应网典）",
                                        "https://www.naver.com/",'N'),
                new OnePassword("NetEase", "网易",
                                        "网易（NASDAQ：NTES）是一家中国的互联网技术公司。目前提供网络游戏、门户网站、移动新闻客户端、移动财经客户端、电子邮件、电子商务、搜索引擎、博客、相册、社交平台、互联网教育等服务。（来自必应网典）",
                                        "http://www.163.com/",'W'),
                new OnePassword("Pinterest", "Pinterest",
                                        "Pinterest，是一个网络与手机的应用程序，可以让用户利用其平台作为个人创意及项目工作所需的视觉探索工具，同时也有人把它视为一个图片分享类的社交网站，用户可以按主题分类添加和管理自己的图片收藏，并与好友分享。（来自必应网典）",
                                        "https://www.pinterest.com/",'P'),
                new OnePassword("pixiv", "pixiv",
                                        "Pixiv是一个主要由日本艺术家所组成的虚拟社群，主体为由pixiv股份有限公司所运营的为插画艺术特化的社交网络服务网站。Pixiv目的是提供一个能让艺术家发表他们的插图，并透过评级系统反应其他用户意见之处。（来自必应网典）",
                                        "https://www.pixiv.net/",'P'),
                new OnePassword("SnapChat", "SnapChat",
                                        "Snapchat是一款由斯坦福大学学生开发的图片分享（英语：Photo sharing）软件应用。利用该应用程序，用户可以拍照、录制影片、写文字和图画，并发送到自己在该应用上的好友列表。（来自必应网典）",
                                        "https://www.snapchat.com",'S'),
                new OnePassword("Spotify","Spotify",
                                        "Spotify是一个起源于瑞典的音乐流服务，是全球最大的流音乐服务商，提供包括Sony Music、EMI、Warner Music Group和Universal四大唱片公司及众多独立厂牌所授权、由数字版权管理（DRM）保护的音乐，使用用户在2016年6月已经达到1亿以上。(来自必应网典)",
                                        "https://www.spotify.com/",'S'),
                new OnePassword("Steam", "Steam",
                                        "Steam平台是Valve公司聘请的BitTorrent协议(BT下载)发明者Bram·Cohen亲自开发设计的全球最大的综合性数字游戏软件发行平台。玩家可以在该平台购买游戏、软件、下载、讨论、上传、分享。（来自必应网典）",
                                        "http://store.steampowered.com/",'S'),
                new OnePassword("Taobao", "淘宝",
                                        "淘宝网是亚太地区较大的网络零售、商圈，由阿里巴巴集团在2003年5月创立。目前已经成为世界范围的电子商务交易平台之一。（来自必应网典）",
                                        "https://www.taobao.com/",'T'),
                new OnePassword("Tencent", "腾讯QQ",
                                        "腾讯公司成立于1998年11月， 是目前中国最大的互联网综合服务提供商之一，也是中国服务用户最多的互联网企业之一。成立10多年以来，腾讯一直秉承一切以用户价值为依归的经营理念，始终处于稳健、高速发展的状态。（来自必应网典）",
                                        "http://www.qq.com/",'T'),
                new OnePassword("Twitter", "Twitter",
                                        "Twitter是一个社交网络（Social Network Service）及微博客服务的网站，是全球互联网上访问量最大的十个网站之一。是微博客的典型应用。它允许用户将自己的最新动态和想法以短信形式发送给手机和个性化网站群，而不仅仅是发送给个人。（来自必应网典）",
                                        "https://twitter.com/",'T'),
                new OnePassword("twitch", "twitch",
                                        "Twitch是游戏软件影音流平台，2011年6月从Justin.tv分区成立。提供平台供游戏玩家进行游戏过程的实况，或供游戏赛事的转播。也提供聊天室，让观众间进行简单的交互。（来自必应网典）",
                                        "https://www.twitch.tv/",'T'),
                new OnePassword("WeChat", "微信",
                                        "微信（官方英文：WeChat）是腾讯公司于2011年1月21日推出的一款即时通信软件， 市场研究公司On Device调查显示，微信在中国大陆的市场渗透率达93%。截至2015年6月，微信于全球拥有超过约6亿活跃用户。（来自必应网典）",
                                        "http://weixin.qq.com/",'W'),
                new OnePassword("Weibo", "微博",
                                        "微博 是一个由新浪网推出，提供微型博客服务类的社交网站。3月27日新浪微博正式更名为“微博”拿掉“新浪”两个字之后的“微博”在架构上成为独立公司，与新浪网一起构成新浪公司的重要两级，于2014年4月17日在美国纳斯达克正式挂牌上市。（来自必应网典）",
                                        "http://www.weibo.com/",'W'),
                new OnePassword("Whatsapp", "WhatsApp",
                                        "WhatsApp Messenger，简称WhatsApp ，是一款用于智能手机的跨平台加密即时通信客户端专有软件。2014年2月被Facebook以约193亿美元收购。到2016年2月为止，WhatsApp的用户群超过10亿，使其成为当时最流行的消息应用程序。（来自必应网典）",
                                        "https://www.whatsapp.com/",'W'),
                new OnePassword("Yahoo", "雅虎",
                                        "雅虎公司（英语：Yahoo! Inc.，NASDAQ：YHOO）是美国一间跨国发展的信息技术公司，主要业务为门户网站经营及广告服务，并提供一系列产品包括：搜索引擎、电子邮箱、社交以及新闻聚合等服务。（来自必应网典）",
                                        "https://www.yahoo.com/",'Y'),
                new OnePassword("Alipay", "支付宝",
                                        "支付宝，是蚂蚁金服旗下的第三方支付平台，2004年12月由中国阿里巴巴集团于杭州创办，原本隶属于阿里巴巴集团，现在为阿里巴巴集团的关联公司，隶属于浙江蚂蚁金服。（来自必应网典）",
                                        "https://www.alipay.com/",'Z'),
                new OnePassword("Zhihu", "知乎",
                                        "知乎，中文互联网最大的知识社交平台，吉祥物是刘看山。一个人大脑中从未分享过的知识、经验、见解和判断力，总是另一群人非常想知道的东西。知乎的使命是把人们大脑里的知识经验和见解搬上互联网，让彼此更好地连接。（来自必应网典）",
                                        "https://www.zhihu.com/",'Z'),
                new OnePassword("BattleNet", "战网",
                                        "战网（Battle.net）是暴雪娱乐为旗下游戏提供的多人在线游戏服务，自1996年11月30日推出暗黑破坏神后运营。战网启动器于2017年3月24日更名为暴雪游戏平台（Blizzard App）。（来自必应网典）",
                                        "http://www.battlenet.com.cn/zh/",'Z')
                };
            if (App.AppSettingContainer.Values["Password"] == null)
            {
                MainFrame.Navigate(typeof(HomePage));
                MainFrame.Navigate(typeof(HomePage));
            }
            else
            {
                MainFrame.Navigate(typeof(HomePage));
                MainFrame.Navigate(typeof(LoginPage));
            }
        }

        public async void ReadFile()
        {
            await PasswordHelper.GetData();
        }
    }
}
