
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace AspNetCore.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static void UseCustomizedRule(this IApplicationBuilder app)
        {
            using (StreamReader iisUrlRewriteStreamReader = File.OpenText("IISUrlRewrite.xml"))
            {
                var options = new RewriteOptions()
                    .AddIISUrlRewrite(iisUrlRewriteStreamReader);
                app.UseRewriter(options);
            }
        }
    }
}
