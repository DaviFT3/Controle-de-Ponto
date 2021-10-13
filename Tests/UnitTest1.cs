using APIControleDePonto;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private readonly HttpClient _httpClient;

        public UnitTest1()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var server = new TestServer(new WebHostBuilder()
                 .UseConfiguration(configuration)
                 .UseStartup<Startup>());

            _httpClient = server.CreateClient();
            

        }
        [Theory]
        [InlineData("POST")]
        public async  Task TestAuthentication(string method)
        {
            var login = new Login();
            login.email = "davi@gmail.com";
            login.password = "12345";
            var loginJson = JsonConvert.SerializeObject(login);
            var stringContent = new StringContent(loginJson, UnicodeEncoding.UTF8, "application/json"); 
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/Collaborator/login");

            var response = await _httpClient.PostAsync("https://localhost:44320/api/Collaborator/login",stringContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public void AuthomaticLogin()
        {
            var  driver = new ChromeDriver("C:\\Users\\davit\\Desktop");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("http://localhost:4200/#/login");
            driver.FindElement(By.XPath("//input[@type='email']")).Click();
            driver.FindElement(By.XPath("//input[@type='email']")).Clear();
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("davi@gmail.com");
            driver.FindElement(By.XPath("//input[@type='password']")).Clear();
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("12345");
            driver.FindElement(By.CssSelector(".ng-valid")).Submit();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Matenha-me conectado'])[1]/following::button[1]")).Click();


        }

    }
}
