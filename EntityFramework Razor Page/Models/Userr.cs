using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_Razor_Page.Models
{
    [Table("Userr")]
    public class Userr
    {
        /// <summary>
        /// userId
        /// </summary>
        [Key]
        public int userId { get; set; }

        /// <summary>
        /// userAccount
        /// </summary>
        public string userAccount { get; set; }

        /// <summary>
        /// userPassword
        /// </summary>
        public string userPassword { get; set; }

    }
}
