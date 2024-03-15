using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class Пользователи
    {
        [Key]

        public int код_пользователя { get; set; }
        public string никнейм { get; set; }
        public string аватар { get; set; }
    }
}
