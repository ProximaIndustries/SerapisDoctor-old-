using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services.Calendar
{
    class CalendarEventsData
    {
        //Get token from the Authentication helper in App.

        static string token = "EwCYA8l6BAAUO9chh8cJscQLmU+LSWpbnr0vmwwAAWuuN3ik9Z1TElxQBWid9NNmqNusq37JrPT1vnkHbVYcxYXIHYmNLIeuUSlREi6/Qz7z17xQYHlHXfPcNvmY/FtlOcF7/4eHK5GqfsaaYODI9tTazW04KfqMBikzliMRbuO72ps4CUV+Ejv+LOvONSZvpO1iSWYZnQ5+AxhCFEpQ4e6DQwh0pDHgWsbNgGJTg1Poh+TREdzxvfAywwtS5/MNxSVdg1YnOhZ8LhFrIOBMdsgXCHhRj5pI2lekGIZDJHULKweA40b6mCUunimOLKpyllDyWA+zNC1ZgQ/Sm2ZwtClw7XvluHJIssBKEMK/iYEAwcP7mkryMrV35a4gjRMDZgAACJylRMxN4WVZaALKMUuigPpzpplqzxf46+4npZn8RWvw6qof2tMwh1DBWBVBtgTx4FpIGof0KBumLQTFaJAqWivyYl6Gi8Pc/0J3QogFmrbd25Me/dDTrV++B8X01Xx/UPZ1dZYqAGBqj9R8B4TA5UWae16eOE+G7iP0gTCdP/bHAt4W6/YbmQpQ9vJvg4UaURmG2QunO4f5rvGkTVXewK0bVfjFnvX4Ys8wxz2Cnhj84R3YC6llRVO6fN93hVzQJq+ULi48c7dNd0KP/lnavQqzltVTMV6KVs0AF9j9z+ZncomDc0acaoJ3/GI1FbmuIAA8ECze3F2murqbjGhrRqZ96fvZcpp7A2k6RmFfpLqQ9cvLgdouIl60fJILifsliRLC6vadjBXlrWACwUBjKl0eutzkEADfzjAp9klp2jKBF7IBYVywNbNjwJb/V+a4XgsoofVzlLxeQ4/gsoCN4CIWXJb22txyG7SB1b7GtwNJFXCmIc5KAI2dmUYF37q+IlonX5+wNwg3lR6/ywBe5nx1coO+dS93QxUyxvo9O+mdzvxzFlTzqVf1h+i99UDxAHUWoCXZKgOE2Zz/7XPh5VOK6YOLZJprOuGWCoojcIApFDBP78iGizPKyNdKkuM9Vpe8mYwFSaJMzz4d/4pn2r0OlKSW96nFEYSk8oyOZ1nnUrEA8FxzMdwaRLtMpE80xTrtt94b+vAq8dw1Jkwy7M9G7Lf5eRTZPk4F+E6PVxucdteGQAQ5oYvXkWm7L1fyRB73u3GZMDcQpkB9G6P8BZqbq9kmwvimpT+5VNHvrqNa9Jsr7xD7l1cRr3MwAsmM7RihowI=";

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
