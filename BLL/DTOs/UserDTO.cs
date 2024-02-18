using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pass { get; set; }
        public int Ps_id { get; set; }
        public int H_id { get; set; }
        public Nullable<int> fs_id { get; set; }
        public Nullable<int> a_id { get; set; }
        public Nullable<int> t_id { get; set; }
        public Nullable<int> cg_id { get; set; }
        public Nullable<int> bd_id { get; set; }
    }
}
