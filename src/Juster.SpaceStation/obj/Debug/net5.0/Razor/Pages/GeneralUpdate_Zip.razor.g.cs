#pragma checksum "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\Pages\GeneralUpdate_Zip.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ee8a1181bb4d2ce745a20542106deb3c8a9fe76"
// <auto-generated/>
#pragma warning disable 1591
namespace Juster.SpaceStation.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Juster.SpaceStation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using Juster.SpaceStation.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using BootstrapBlazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\_Imports.razor"
using BootstrapBlazor.Localization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/generalupdate_zip")]
    public partial class GeneralUpdate_Zip : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>GeneralUpdate.Zip</h3>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.OpenComponent<BootstrapBlazor.Components.Tab>(2);
            __builder.AddAttribute(3, "IsBorderCard", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 5 "F:\博客相关资料\blazor\JusterSpaceStation\src\Juster.SpaceStation\Pages\GeneralUpdate_Zip.razor"
                       true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<BootstrapBlazor.Components.TabItem>(5);
                __builder2.AddAttribute(6, "Text", "Tab1");
                __builder2.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(8, "<div><h1>Tab1</h1></div>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(9, "\r\n        ");
                __builder2.OpenComponent<BootstrapBlazor.Components.TabItem>(10);
                __builder2.AddAttribute(11, "Text", "Tab2");
                __builder2.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(13, "<div><h1>Tab2</h1></div>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(14, "\r\n        ");
                __builder2.OpenComponent<BootstrapBlazor.Components.TabItem>(15);
                __builder2.AddAttribute(16, "Text", "Tab3");
                __builder2.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(18, "<div><h1>Tab3</h1></div>");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591