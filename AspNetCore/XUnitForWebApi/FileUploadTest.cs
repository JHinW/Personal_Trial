
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FileUploadWebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using Xunit;

namespace XUnitForWebApi
{
    public class FileUploadTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public FileUploadTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task File_PDF_Upload_Test()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            var multiContent = new MultipartFormDataContent();

            FileStream fileStream = new FileStream("1.pdf", FileMode.Open);
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                var fileStreamContent = new StreamContent(memoryStream);
                multiContent.Add(fileStreamContent, "File", "12.pdf");
                multiContent.Add(new StringContent("123"), "Size");
                multiContent.Add(new StringContent("test Extension"), "Extension");
                var response = await _client.PostAsync("/api/Upload", multiContent);



                // Assert
                Assert.Equal("BadRequest",
                response.StatusCode.ToString());


            }

        }
    }
}
