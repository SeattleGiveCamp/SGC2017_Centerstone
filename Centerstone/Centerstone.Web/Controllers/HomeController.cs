using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Centerstone.Web.Models;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security;

namespace Centerstone.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private const string TenantIdClaimType = "http://schemas.microsoft.com/identity/claims/tenantid";
        private static string resourceId = ConfigurationManager.AppSettings["cs:ResourceId"];
        private static string apiBaseAddress = ConfigurationManager.AppSettings["cs:ApiBase"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["ida:AppKey"];
        private static string adAuthority = ConfigurationManager.AppSettings["ida:Authority"];

        public async Task<IActionResult> Index()
        {
            AuthenticationResult authresult = null;
            try
            {
                string userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
                AuthenticationContext authContext = new AuthenticationContext(adAuthority);
                ClientCredential credential = new ClientCredential(clientId, appKey);
                authresult = await authContext.AcquireTokenSilentAsync(resourceId, credential, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiBaseAddress + "/api/todolist");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authresult.AccessToken);
                HttpResponseMessage response = await client.SendAsync(request);
                return View(response.Content);
            }
            catch (AdalException ee)
            {
                return View("Authorization Required, please log out and back in");
            }
            return View("Error!");
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
