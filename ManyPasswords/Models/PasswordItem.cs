using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyPasswords.Models
{
    public class PasswordItem : ViewModel.ViewModelBase
    {
        /// <summary>
        /// 账号
        /// </summary>
        private string _sAccount;
        public string sAccount
        {
            get { return _sAccount; }
            set { Set("sAccount", ref _sAccount, value); }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _sPassword;
        public string sPassword
        {
            get { return _sPassword; }
            set { Set("sPassword", ref _sPassword, value); }
        }

        /// <summary>
        /// 名字的首字母
        /// </summary>
        private char _sFirstLetter;
        public char sFirstLetter
        {
            get { return _sFirstLetter; }
            set { Set("sFirstLetter", ref _sFirstLetter, value); }
        }

        /// <summary>
        /// 名字
        /// </summary>
        private string _sName;
        public string sName
        {
            get { return _sName; }
            set { Set("sName", ref _sName, value); }
        }

        /// <summary>
        /// 添加日期
        /// </summary>
        private string _sDate;
        public string sDate
        {
            get { return _sDate; }
            set { Set("sDate", ref _sDate, value); }
        }

        /// <summary>
        /// 最近一次修改日期
        /// </summary>
        private string _sEditDate;
        public string sEditDate
        {
            get { return _sEditDate; }
            set { Set("sEditDate", ref _sEditDate, value); }
        }

        /// <summary>
        /// 头像
        /// </summary>
        private string _sPicture;
        public string sPicture
        {
            get { return _sPicture; }
            set { Set("sPicture", ref _sPicture, value); }
        }

        /// <summary>
        /// 网址
        /// </summary>
        private string _sWebsite;
        public string sWebsite
        {
            get { return _sWebsite; }
            set { Set("sWebsite", ref _sWebsite, value); }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string _sNote;
        public string sNote
        {
            get { return _sNote; }
            set { Set("sNote", ref _sNote, value); }
        }

        /// <summary>
        /// 收藏
        /// </summary>
        private bool _bFavorite;
        public bool bFavorite
        {
            get { return _bFavorite; }
            set { Set("bFavorite", ref _bFavorite, value); }
        }

        /// <summary>
        /// 完整信息后的账户
        /// </summary>
        public PasswordItem(string account, string password, string name, string picture, string website, string note, bool favorite)
        {
            try
            {
                this.sAccount = account;
                this.sPassword = password;
                this.sName = name;
                this.sDate = "创建于 " + DateTime.Now.ToLongDateString().ToString();
                this.sEditDate = string.Empty;
                this.sPicture = picture;
                this.sWebsite = website;
                this.sNote = note;
                this.bFavorite = favorite;
            }
            catch { }
        }

        // 用于复制账号信息
        public PasswordItem(PasswordItem item)
        {
            try
            {
                this.sAccount = item.sAccount;
                this.sPassword = item.sPassword;
                this.sName = item.sName;
                this.sDate = item.sDate;
                this.sEditDate = item.sEditDate;
                this.sPicture = item.sPicture;
                this.sWebsite = item.sWebsite;
                this.sNote = item.sNote;
                this.bFavorite = item.bFavorite;
                this.sFirstLetter = item.sFirstLetter;
            }
            catch { }
        }


        /// <summary>
        /// 默认构造函数，用于Json解析，其他勿用
        /// </summary>
        public PasswordItem() { }
    }
}
