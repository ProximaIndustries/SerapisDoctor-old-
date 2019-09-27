using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Graph;
using System.Net.Http.Headers;

namespace SerapisDoctor.Services.Calendar
{
    public class OutlookCalendar
    {
        //Get token from the Authentication helper in App.

        static string token = "EwCQA8l6BAAUO9chh8cJscQLmU+LSWpbnr0vmwwAAdSgu/NAHC7SliokT8HL74N78j0WD2JhrBclZ4mPzvSl8zBEQfB/kLCPthm417YNiDx9ixmlL2eER87ZlwoMP11UJTLML2AlcFLvT7FCIRIYRBNvftAbzJARjiow8N5HDIFUnrmUHCGWv6MWgchhuLIQ21XMRhKEbf8g9xiPpMH0g0KSYswUPmxEXCRZNse+eaaNVfvNVAZXhcOUZU5YxhBbalJa2804PyAS23BXefGp0gHmsmzaYRp5Aw30HPtPolKbUFUYFCsvCHsliAJY5TuO0oi4rOvnGwEvs/QS2dTxDcgbaOh4dag34i62LUd3DNFD/ayeMn9FjdZpJjPXepYDZgAACHu9VnMGea9gYAIZThI75I+2NXXk+8Fcglrx+mbsnYR3b5wyoQBLSPMMlujiZ5EM56WKHm722KiVXwI7d3YZ9grhutU3FqMdHYUtq6kQGkeLP8xDG8NnNANb8zHhcPy/RiwFwXeC/YSIODJWj/aVn53L5BbBSZ5oeOt2bPhVShKGvbe+a/t6o+GuMEl737yr7TCefBemJ5x/mNZKWGEhAiiVT8RbeNdHSPLdDFk+9dR/XsUg/SC182coLYZ/WoHLBQ63g+7oaA9CW63bN29fWtoqacEkGMf5daRWbpUh7JiWIj0keTu7fXdOM1F7KChkAOo5pJiUyETC9lLUZELToWezIVgr0En+paCnczMoQ0Sw4zumj+luleCV6ZJZInWbKnWAFW5HjU+ZBfU0MuO7Sko3tW5EsZaBkEi1nsT6CwlkvPYbbf8KAyNErKuq+r/hYEoDJ6YcBBgj9Ov/J2MHUa0qCX0MBDHt5ACgTj1pgL6TKoOezU+yZtR8NjQt5cD5rMQIwsp5Zpvp6qEJyM4JVMJPgW/wTUsvY/aJf5Qgi7FZVrhZ7tZC9zb0keDkp9ORz4u58wCivUysraUzdzarhHp8MeYkYH+S5winU1T4uYK6hR3MFBElrC6pmsM/INjuvvKryNCubNeRh8YjEeoaM/zxDAZnpkrNg4P/KH8LmADBAiFHDqRCA4k1KGd6w7YPlkyzao9Opm+WWDd8nY0kCplm5zbrorpbX0HXLl29hPiWUlk1up2/o14nDv9bQ5+zeuBseBqw49VOOFpEoqOokV0yWIvZH59SfHgd2oKxhf2+YEV0xV1slLxHSbUC";

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
