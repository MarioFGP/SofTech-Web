using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ObjectResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; } = "";
        public Object Object { get; set; } = new Object();
        public List<Object> Objects = new();


        public ObjectResponse(Object @object)
        {
            Error = false;
            this.Object = @object;
        }

        public ObjectResponse()
        {

        }

        public ObjectResponse(string message)
        {
            this.Message = message;
            Error = true;
        }

        public ObjectResponse(List<Object> objects)
        {
            Error = false;
            Objects = objects;
        }

        
    }
}
