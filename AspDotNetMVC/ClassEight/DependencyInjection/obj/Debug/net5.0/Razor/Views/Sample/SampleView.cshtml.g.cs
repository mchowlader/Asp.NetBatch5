#pragma checksum "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassEight\DependencyInjection\Views\Sample\SampleView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3443b68219ffb658be3e46ed3e49f5f016b91db5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sample_SampleView), @"mvc.1.0.view", @"/Views/Sample/SampleView.cshtml")]
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
#line 1 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassEight\DependencyInjection\Views\_ViewImports.cshtml"
using DependencyInjection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassEight\DependencyInjection\Views\_ViewImports.cshtml"
using DependencyInjection.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3443b68219ffb658be3e46ed3e49f5f016b91db5", @"/Views/Sample/SampleView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64580d9d491e525a41017fe420d08cccad123ad4", @"/Views/_ViewImports.cshtml")]
    public class Views_Sample_SampleView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SampleView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassEight\DependencyInjection\Views\Sample\SampleView.cshtml"
   
    Layout = "_Layout2";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p>");
#nullable restore
#line 7 "D:\DevSkill\dotNet\Code\Asp.NetBatch5\AspDotNetMVC\ClassEight\DependencyInjection\Views\Sample\SampleView.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
