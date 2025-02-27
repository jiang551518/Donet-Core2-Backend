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
        public string RoleTypeStr { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleType RoleType { get; set; }

        /// <summary>
        /// 登录token
        /// </summary>
        public string JwtToken { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public string DeletedTime { get; set; }

        /// <summary>
        /// 最后删除用户id
        /// </summary>
        public Guid? DeleterUserId { get; set; }

        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public string LastModificationTime { get; set; }

        /// <summary>
        /// 最后编辑时间用户id
        /// </summary>
        public Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LoginNowTime { get; set; }

        /// <summary>
        /// excel导出加密密码
        /// </summary>
        public string ExcelPasswd { get; set; }

    }
}