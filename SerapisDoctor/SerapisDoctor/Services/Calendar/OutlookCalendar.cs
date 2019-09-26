using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace SerapisDoctor.Services.Calendar
{
    public class OutlookCalendar
    {
        //Get token from the Authentication helper in App.

        static string httpRequest = "https://graph.microsoft.com/v1.0/me/events?$select=subject,body,bodyPreview,organizer,attendees,start,end,location";

        public static async Task GetEventsOutLookData(string token)
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, httpRequest);

            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            HttpResponseMessage response = await client.SendAsync(message);

            string responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                //Send data to the viewmodel to send to the view for the calendar
            }
            else
            {
                //send error mesage
            }
        }
    }
}
