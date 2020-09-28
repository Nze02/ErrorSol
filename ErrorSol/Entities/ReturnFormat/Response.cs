using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Entities.ReturnFormat
{
    public class Response<T>
    {
        [Required(ErrorMessage = "Results cannot be empty")]
        public Result<T> Result { get; set; }

        [Required(ErrorMessage = "Errors must be present")]
        public IEnumerable<Exception> Errors { get; set; }
    }
}
