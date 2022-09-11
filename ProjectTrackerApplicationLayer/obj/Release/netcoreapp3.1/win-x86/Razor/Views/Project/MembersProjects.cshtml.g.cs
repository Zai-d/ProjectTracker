#pragma checksum "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2f2ff3ec14886bb87db2a9c4a07ba1ea31f9cca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_MembersProjects), @"mvc.1.0.view", @"/Views/Project/MembersProjects.cshtml")]
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
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2f2ff3ec14886bb87db2a9c4a07ba1ea31f9cca", @"/Views/Project/MembersProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_MembersProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Project>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<h1 class=""text-center"">My Projects</h1>
<br />
<hr />
<div class=""row justify-content-center"">
    <div class="" col-12"">
        <div class=""card shadow mx-3 mb-4"">

            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-hover cell-border"" id=""ProjectTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr class=""font-weight-bolder"">
                                <th>
                                    Project Title
                                </th>
                                <th>
                                    Team Leader
                                </th>
                                <th>
                                    Project Description
                                </th>
                                <th>
                                    Project Status
                                </th>
                     ");
            WriteLiteral(@"           <th>
                                    Deadline
                                </th>
                                <th>
                                    Sprints
                                </th>
                                <th>
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 46 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                              
                                foreach (var project in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td> ");
#nullable restore
#line 50 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                        Write(project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                          
                                            string teamLeader = "";
                                            foreach (var user in project.UsersProjects)
                                            {
                                                if (user.User.PositionID == 2)
                                                {
                                                    teamLeader = user.User.UserName;
                                                }
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td> ");
#nullable restore
#line 60 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                            Write(teamLeader);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                        <td>");
#nullable restore
#line 62 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                       Write(project.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 63 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                       Write(project.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td> ");
#nullable restore
#line 64 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                        Write(project.DeadLine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td>\r\n                                            <ul>\r\n");
#nullable restore
#line 68 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                                 foreach (var sprint in project.Sprints)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>");
#nullable restore
#line 70 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                                   Write(sprint.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n");
#nullable restore
#line 71 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"

                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </ul>\r\n                                        </td>\r\n");
#nullable restore
#line 75 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                         if (project.Sprints.Count != 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td><a class=\"btn bg-gradient-info text-white\"");
            BeginWriteAttribute("href", " href=\"", 3466, "\"", 3526, 2);
            WriteAttributeValue("", 3473, "/Sprint/AllSprintsMember?ProjectID=", 3473, 35, true);
#nullable restore
#line 77 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
WriteAttributeValue("", 3508, project.ProjectID, 3508, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View Sprints</a></td>\r\n");
#nullable restore
#line 78 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td><a class=\"btn bg-gradient-info text-white disabled\">No Sprints</a></td>\r\n");
#nullable restore
#line 82 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tr>\r\n");
#nullable restore
#line 84 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\Project\MembersProjects.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
