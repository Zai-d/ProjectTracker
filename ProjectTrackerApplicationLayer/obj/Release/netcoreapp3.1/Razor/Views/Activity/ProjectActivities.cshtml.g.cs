#pragma checksum "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6eeaa98e5878cc06af1290591798eae8e2ce7fa6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_ProjectActivities), @"mvc.1.0.view", @"/Views/Activity/ProjectActivities.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eeaa98e5878cc06af1290591798eae8e2ce7fa6", @"/Views/Activity/ProjectActivities.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_ProjectActivities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Activity>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<h1 class=""text-center"">Project Changes</h1>


<br />
<br />
<hr />
<div class=""row justify-content-center"">
    <div class="" col-12"">
        <div class=""card my-2 shadow mb-4"">

            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-hover cell-border"" id=""ActivityTables"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr class=""font-weight-bolder"">
                                <th>
                                    Project Name
                                </th>
                                <th>
                                    Project Description
                                </th>
                                <th>
                                    Status
                                </th>
                                <th>
                                    Date & Time
                                </th>
            ");
            WriteLiteral("                </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 37 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
                              
                                foreach (var activity in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td> ");
#nullable restore
#line 41 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
                                        Write(activity.ProjectTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td> ");
#nullable restore
#line 42 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
                                        Write(activity.ProjectDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td>");
#nullable restore
#line 44 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
                                       Write(activity.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td>");
#nullable restore
#line 46 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
                                       Write(activity.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 48 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Activity\ProjectActivities.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Activity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
