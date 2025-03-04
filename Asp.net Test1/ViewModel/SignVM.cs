using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    public class SignVM
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Realname { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleType RoleType { get; set; }

        /// <summary>
        /// excel导出加密密码
        /// </summary>
        public string ExcelPasswd { get; set; }
    }
}
