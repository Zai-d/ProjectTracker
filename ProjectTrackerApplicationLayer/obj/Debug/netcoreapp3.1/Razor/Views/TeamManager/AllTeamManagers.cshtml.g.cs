#pragma checksum "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3d2ef9bafe4e952d4c0ea4773f95c82e20b7341"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TeamManager_AllTeamManagers), @"mvc.1.0.view", @"/Views/TeamManager/AllTeamManagers.cshtml")]
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
#line 1 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3d2ef9bafe4e952d4c0ea4773f95c82e20b7341", @"/Views/TeamManager/AllTeamManagers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_TeamManager_AllTeamManagers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TeamManager>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1 class=""text-center"">All Team Managers</h1>
<br />
<hr />

<div class=""row mx-3"">

<a class=""btn bg-gradient-primary text-white"" href=""/TeamManager/NewTeamManagerForm"">Add New Team Manager</a>
</div>
<br />
<div class=""row justify-content-center"">
    <div class="" col-12 "">
        <div class=""card shadow mx-3 mb-4"">
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-hover cell-border"" id=""UsersTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr>
                                <th>
                                    First Name
                                </th>
                                <th>
                                    Last Name
                                </th>
                                <th>
                                    Date Of Birth
                                    (dd/MM/yyy)
                      ");
            WriteLiteral(@"          </th>
                                <th>
                                    Email
                                </th>
                                <th>
                                    Phone Number
                                </th>
                                <th>
                                    Projects
                                </th>
                                <th>
                                    User Status
                                </th>
                                <th style=""width:200px"">
                                    Actions
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 49 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                              
                                foreach (var manager in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 53 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                       Write(manager.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 54 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                       Write(manager.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 55 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                          
                                            string dateOnly = String.Format("{0:dd/MM/yyyy}", @manager.DateOfBirth);
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>");
#nullable restore
#line 58 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                       Write(dateOnly);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 59 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                       Write(manager.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 60 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                       Write(manager.PhoneNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <ul>\r\n");
#nullable restore
#line 63 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                                 foreach (var project in manager.UsersProjects)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>");
#nullable restore
#line 65 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                                   Write(project.Project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 66 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </ul>\r\n                                        </td>\r\n");
#nullable restore
#line 69 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                         if (manager.EmailConfirmed == true)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>Active</td>\r\n");
#nullable restore
#line 72 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>Disabled</td>\r\n");
#nullable restore
#line 76 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>\r\n                                          \r\n                                            <a class=\"btn btn-outline-info mb-1\"");
            BeginWriteAttribute("href", " href=\"", 3627, "\"", 3684, 2);
            WriteAttributeValue("", 3634, "/TeamManager/EditManagerForm?ManagerID=", 3634, 39, true);
#nullable restore
#line 79 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
WriteAttributeValue("", 3673, manager.Id, 3673, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n                                            &nbsp;\r\n\r\n                                            <a class=\"btn btn-outline-info mb-1\"");
            BeginWriteAttribute("href", "  href=\"", 3830, "\"", 3891, 2);
            WriteAttributeValue("", 3838, "/TeamManager/ChangePasswordForm?ManagerID=", 3838, 42, true);
#nullable restore
#line 82 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
WriteAttributeValue("", 3880, manager.Id, 3880, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Change Password</a>\r\n                                            <hr>\r\n\r\n");
#nullable restore
#line 85 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                             if (manager.EmailConfirmed == true)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a class=\"btn bg-gradient-danger text-white mb-1\"");
            BeginWriteAttribute("href", " href=\"", 4188, "\"", 4244, 2);
            WriteAttributeValue("", 4195, "/TeamManager/DisableManager?managerID=", 4195, 38, true);
#nullable restore
#line 87 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
WriteAttributeValue("", 4233, manager.Id, 4233, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Disable</a>\r\n");
#nullable restore
#line 88 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"btn bg-gradient-success text-white mb-1\"");
            BeginWriteAttribute("href", " href=\"", 4501, "\"", 4556, 2);
            WriteAttributeValue("", 4508, "/TeamManager/EnableManager?managerID=", 4508, 37, true);
#nullable restore
#line 91 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
WriteAttributeValue("", 4545, manager.Id, 4545, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Enable</a>\r\n");
#nullable restore
#line 92 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 95 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\TeamManager\AllTeamManagers.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TeamManager>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591