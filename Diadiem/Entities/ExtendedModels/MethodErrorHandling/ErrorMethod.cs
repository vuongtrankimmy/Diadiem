using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entities.ExtendedModels.MethodErrorHandling
{
    public class Response
    {
        public int StatusCode { get; set; } = 200;
        public string Error { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public object Data { get; set; }
    }

    public class Data
    {
        public string _id { get; set; }
        public string Message { get; set; }
    }

    //return Ok(); // Http status code 200
    //return Created(); // Http status code 201
    //return NoContent(); // Http status code 204
    //return BadRequest(); // Http status code 400
    //return Unauthorized(); // Http status code 401
    //return Forbid(); // Http status code 403
    //return NotFound(); // Http status code 404
}
