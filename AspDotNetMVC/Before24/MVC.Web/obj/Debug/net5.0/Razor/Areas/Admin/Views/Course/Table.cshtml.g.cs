#pragma checksum "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Before24\MVC.Web\Areas\Admin\Views\Course\Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b81e2707f487b89a8f9f4fb1fd1d25265131eb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Course_Table), @"mvc.1.0.view", @"/Areas/Admin/Views/Course/Table.cshtml")]
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
#line 1 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Before24\MVC.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MVC.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Before24\MVC.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MVC.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\Before24\MVC.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MVC.Web.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b81e2707f487b89a8f9f4fb1fd1d25265131eb4", @"/Areas/Admin/Views/Course/Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07059c8949087e6b1204c286fbfb08db89745434", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Course_Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CourseListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <!-- DataTables -->\r\n    <link rel=\"stylesheet\" href=\"/Admin/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css\">\r\n");
            }
            );
            WriteLiteral(@"<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>DataTables</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                    <li class=""breadcrumb-item active"">DataTables</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">DataTable with minimal features & hover style</h3>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <table id=""");
            WriteLiteral(@"Course"" class=""table table-bordered table-hover"">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Fees</th>
                                    <th>Start Date</th>
                                    <th>ID</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>Title</th>
                                    <th>Fees</th>
                                    <th>Start Date</th>
                                    <th>ID</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <!-- DataTables  & Plugins -->
    <script src=""/Admin/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/Admin/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script>
        $(function () {
            $('#Course').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                ""ajax"": ""/Admin/Course/GetCourse""
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CourseListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
