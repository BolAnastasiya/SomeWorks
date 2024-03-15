using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class Отметки_на_фото
    {
        [Key]
        public int код_фотографии { get; set; }
        public int код_пользователя { get; set; }
        public string область_на_фото { get; set; }
    }
}

