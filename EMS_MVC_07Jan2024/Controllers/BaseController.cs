using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EMS_MVC_07Jan2024.Controllers
{
   public enum MessageType
    {
        success,error,warning,info
    }
    public class BaseController : Controller
    {
        public void Notification(string Title,string Message, MessageType messageType)
        {
            string _MessageType = string.Empty;
            switch (messageType)
            {
                case MessageType.success:
                    _MessageType = "success";
                    break;
                case MessageType.error:
                    _MessageType = "error";
                    break;
                case MessageType.warning:
                    _MessageType = "warning";
                    break;
                case MessageType.info:
                    _MessageType = "info";
                    break;
                default:
                    break;
            }
            var alertmessage = new
            {
                MessageType = _MessageType,
                Message = Message,
                Title = Title
            };
            var JSSerlizer = new JavaScriptSerializer();
            TempData["Message"] = JSSerlizer.Serialize(alertmessage);
        }
    }
}