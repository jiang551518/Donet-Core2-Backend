using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    /// <summary>
    /// 角色类型
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// 缺省值
        /// </summary>
        [Description("")]
        None,
        /// <summary>
        /// 访客
        /// </summary>
        [Description("访客")]
        Visit,
        /// <summary>
        /// 员工
        /// </summary>
        [Description("员工")]
        Worker,
        /// <summary>
        /// 
        /// </summary>
        [Description("Admin")]
        Admin
    }
}
