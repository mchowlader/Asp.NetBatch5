#pragma checksum "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Assignment\Assignment_3\SocialNetwork\SocialNetwork.Web\Areas\Netizen\Views\Shared\Partial\_MainSidebarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "619d6949f5156396e15559b227f2b9fde9c91166"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Netizen_Views_Shared_Partial__MainSidebarPartial), @"mvc.1.0.view", @"/Areas/Netizen/Views/Shared/Partial/_MainSidebarPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Assignment\Assignment_3\SocialNetwork\SocialNetwork.Web\Areas\Netizen\Views\_ViewImports.cshtml"
using SocialNetwork.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Assignment\Assignment_3\SocialNetwork\SocialNetwork.Web\Areas\Netizen\Views\_ViewImports.cshtml"
using SocialNetwork.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Assignment\Assignment_3\SocialNetwork\SocialNetwork.Web\Areas\Netizen\Views\_ViewImports.cshtml"
using SocialNetwork.Web.Areas.Netizen.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"619d6949f5156396e15559b227f2b9fde9c91166", @"/Areas/Netizen/Views/Shared/Partial/_MainSidebarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6a824e9fb4b3dbeaa8e24b622e6ab9ccf627414", @"/Areas/Netizen/Views/_ViewImports.cshtml")]
    public class Areas_Netizen_Views_Shared_Partial__MainSidebarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""index3.html"" class=""brand-link"">
        <img src=""/Netizen/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">Admin Panel</span>
    </a>

    <!-- Sidebar -->
    <div class=""sidebar"">
        <!-- Sidebar user panel (optional) -->
        <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
            <div class=""image"">
                <img src=""/Netizen/img/avatar4.png"" class=""img-circle elevation-2"" alt=""User Image"">
            </div>
            <div class=""info"">
                <a href=""#"" class=""d-block"">MCH</a>
            </div>
        </div>

        <!-- SidebarSearch Form -->
        <div class=""form-inline"">
            <div class=""input-group"" data-widget=""sidebar-search"">
                <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" a");
            WriteLiteral(@"ria-label=""Search"">
                <div class=""input-group-append"">
                    <button class=""btn btn-sidebar"">
                        <i class=""fas fa-search fa-fw""></i>
                    </button>
                </div>
            </div>
        </div>

        <!-- Sidebar Menu -->
        <nav class=""mt-2"">
            <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
                <!-- Add icons to the links using the .nav-icon class
                     with font-awesome or any other icon font library -->
                <li class=""nav-item menu-open"">
                    <a href=""#"" class=""nav-link active"">
                        <i class=""nav-icon fas fa-tachometer-alt""></i>
                        <p>
                            Dashboard
                            <i class=""right fas fa-angle-left""></i>
                        </p>
                    </a>
                    <ul>
                    ");
            WriteLiteral(@"    <li class=""nav-item"">
                            <a href=""#"" class=""nav-link"">
                                <i class=""nav-icon fas fa-edit""></i>
                                <p>
                                    Forms
                                    <i class=""fas fa-angle-left right""></i>
                                </p>
                            </a>
                            <ul class=""nav nav-treeview"">
                                <li class=""nav-item"">
                                    <a href=""/Netizen/Member/create"" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""></i>
                                        <p>Add Member</p>
                                    </a>
                                </li>
                                <li class=""nav-item"">
                                    <a href=""/Netizen/Photo/create"" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""><");
            WriteLiteral(@"/i>
                                        <p>Add Photo</p>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class=""nav-item"">
                            <a href=""#"" class=""nav-link"">
                                <i class=""nav-icon fas fa-table""></i>
                                <p>
                                    Tables
                                    <i class=""fas fa-angle-left right""></i>
                                </p>
                            </a>
                            <ul class=""nav nav-treeview"">
                                <li class=""nav-item"">
                                    <a href=""/Netizen/Member/data"" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""></i>
                                        <p>Member List</p>
                                    </a>
                         ");
            WriteLiteral(@"       </li>
                                <li class=""nav-item"">
                                    <a href=""/Netizen/Photo/data"" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""></i>
                                        <p>Photo List</p>
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </nav>
        <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
</aside>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
