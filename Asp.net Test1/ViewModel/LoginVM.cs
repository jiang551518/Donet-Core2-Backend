using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.net_Test1
{
    public class LoginVM
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

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
        /// 创建时间
        /// </summary>
        public DateTime Creationtime { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// 登录token
        /// </summary>
        public string JwtToken { get; set; }

    }
}