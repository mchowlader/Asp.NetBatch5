#pragma checksum "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassNine\HtmlTag\HtmlAndTagHelper\Views\Sample\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "537c2f6b5b59884b81d3cf790e6524064ebbf6d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sample_Index), @"mvc.1.0.view", @"/Views/Sample/Index.cshtml")]
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
#line 1 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassNine\HtmlTag\HtmlAndTagHelper\Views\_ViewImports.cshtml"
using HtmlAndTagHelper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassNine\HtmlTag\HtmlAndTagHelper\Views\_ViewImports.cshtml"
using HtmlAndTagHelper.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"537c2f6b5b59884b81d3cf790e6524064ebbf6d9", @"/Views/Sample/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f5906d22f49181bfceebccd29a466efbbb3475c", @"/Views/_ViewImports.cshtml")]
    public class Views_Sample_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SampleView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n        h1 {\r\n            color: rebeccapurple\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n<h1>");
#nullable restore
#line 18 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassNine\HtmlTag\HtmlAndTagHelper\Views\Sample\Index.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        alert(\"Hello!\")\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SampleView> Html { get; private set; }
    }
}
#pragma warning restore 1591
