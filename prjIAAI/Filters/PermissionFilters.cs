using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using prjIAAI.Models;

namespace prjIAAI.Filters
{
    public class PermissionFilters : ActionFilterAttribute
    {
        public string Module { get; set; }
        private Model db = new Model();
        private string _controllerName = "";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Controller.ViewBag.side = "";
                return;
            }
            //取得UserData
            //string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            //Customers customers = JsonConvert.DeserializeObject<Customers>(strUserData);

            //側邊欄亮起
            _controllerName = string.IsNullOrEmpty(Module) ? filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString() : Module;
            //string current = controllerName.IndexOf(permission.url) > -1 ? "current" : "";

            var permissions = db.Permissions.ToList();
            StringBuilder sb = new StringBuilder("<ul class='nav'>");
            sb.Append("");
            sb.Append(GetSideBar(permissions.Where(x => x.pid == null).ToList()));
            sb.Append("</ul>");
            filterContext.Controller.ViewBag.side = sb.ToString();
        }

        private string GetSideBar(ICollection<Permission> listist)
        {
            //取得UserData
            string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            Member member = JsonConvert.DeserializeObject<Member>(strUserData);

            //取得User所屬角色的權限字串，並將所有權限字串合併
            StringBuilder role = new StringBuilder("");
            var Rolelist = member.Roles.Select(x => x.Permission);
            foreach (var item in Rolelist)
            {
                role.Append(item);
                role.Append(",");
            }
            string RolePermission = role.ToString();

            //開始處理遞迴組字串
            StringBuilder sb = new StringBuilder();
            foreach (Permission permission in listist)
            {
                //側邊欄亮起，幫側邊欄class加上current代表目前被點選，open代表子選單保持伸展
                string current = permission.ControlName.IndexOf(_controllerName) > -1 ? "current open" : "";

                //確認使用者權限
                if (RolePermission.IndexOf(permission.pvalue) > -1)
                {
                    //判斷是否有子層
                    if (permission.permissions.Count() > 0)
                    {

                        sb.Append($"<li class='submenu {current}'>");
                        //sb.Append($"<li class='submenu'>");
                        sb.Append("<a href='#'>");
                        sb.Append($"<i class='fas {permission.icon}'></i>");
                        sb.Append($"{permission.Subject}");
                        sb.Append("<span class='caret pull - right'></span>");
                        sb.Append("</a>");
                        sb.Append("<ul>");
                        sb.Append(GetSideBar(permission.permissions));
                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append($"<li class='{current}'>");
                        //sb.Append($"<li class=''>");
                        sb.Append($"<a href='{permission.url}'>");
                        sb.Append($"<i class='fas {permission.icon}'>");
                        sb.Append("</i>");
                        sb.Append($"{permission.Subject}");
                        sb.Append("</a></li>");
                    }
                }
            }
            return sb.ToString();
        }
    }
}