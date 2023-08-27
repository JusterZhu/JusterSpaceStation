using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataAnnotations
{
    public class EmployeeModel
    {
        /// <summary>
        /// 员工id
        /// </summary>
        [Range(0,int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// 员工名称
        /// </summary>
        [DeniedValues("president")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Range(0, 150)]
        public int Age { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="邮件字段内容异常请检查！")]
        public string Email { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [AllowedValues("HR", "Develop")]
        public string Department { get; set; }

        /// <summary>
        /// 下属id
        /// </summary>
        [Length(1, 10)]
        public int[] Underlings { get; set; }

        [Base64String]
        public string Token { get; set; }
    }
}
