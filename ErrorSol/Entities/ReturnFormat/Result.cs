using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Entities.ReturnFormat
{
    public class Result<T>
    {
        [Required(ErrorMessage = "Result message is required")]
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
