using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services.Calendar
{
    class CalendarEventsData
    {
        //Get token from the Authentication helper in App.

        static string token = "";

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

        public static ICalendarEventsCollectionPage GetEventsOutLookDataDummy()
        {
            try
            {
                var client = new GraphServiceClient(new DelegateAuthenticationProvider(async request =>
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                }));

                var data = client.Me.Calendar.Events.Request().GetAsync().Result;

                return data;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
