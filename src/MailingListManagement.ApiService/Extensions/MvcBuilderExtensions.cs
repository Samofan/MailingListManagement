using System;
using MailingListManagement.ApiService.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace MailingListManagement.ApiService.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddOData(this IMvcBuilder builder)
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntityType<MailingList>();

        builder.AddOData( // Fick Odata. Das will ich alles nicht mehr
            options =>
            {
                options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
                "odata/v{version}",
                modelBuilder.GetEdmModel());
            });

        return builder;
    } 
}
