using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicStore.WebApp.ViewModel
{
    public class ComicStoreModelView
    {


        public int Id { get; set; }


        [Required]
        public string Location { get; set; }
    }
}
