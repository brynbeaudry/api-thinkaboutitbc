using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api_thinkaboutitbc.Models
{
    [NotMapped]
    public class GooglePersonInfo
    {
        /// <summary>
        /// The Issuer Identifier for the Issuer of the response. Always https://accounts.google.com or accounts.google.com for Google ID tokens.
        /// </summary>
        public GooglePersonInfo(string kind, string etag, string objectType, string id, JArray emails, JObject name, JObject image, string displayName, string url, bool isPlusUser, string circledByCount, string verified)
        {
            this.kind = kind;
            this.etag = etag;
            this.objectType = objectType;
            this.id = id;
            this.emails = emails;
            this.name = name;
            this.image = image;
            this.displayName = displayName;
            this.url = url;
            this.isPlusUser = isPlusUser;
            this.circledByCount = circledByCount;
            this.verified = verified;

        }
        public string kind { get; set; }

        /// <summary>
        /// Access token hash. Provides validation that the access token is tied to the identity token. If the ID token is issued with an access token in the server flow, this is always
        /// included. This can be used as an alternate mechanism to protect against cross-site request forgery attacks, but if you follow Step 1 and Step 3 it is not necessary to verify the 
        /// access token.
        /// </summary>
        public string etag { get; set; }


        public string objectType { get; set; }

        /// <summary>
        /// True if the user's e-mail address has been verified; otherwise false.
        /// </summary>
        public string id { get; set; }

        public JArray emails { get; set; }

        public JObject name { get; set; }

        public JObject image { get; set; }

        public string language { get; set;}

        /// <summary>
        /// The client_id of the authorized presenter. This claim is only needed when the party requesting the ID token is not the same as the audience of the ID token. This may be the
        /// case at Google for hybrid apps where a web application and Android app have a different client_id but share the same project.
        /// </summary>
        public string displayName { get; set; }

        /// <summary>
        /// The time the ID token was issued, represented in Unix time (integer seconds).
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// The user's full name, in a displayable form. Might be provided when:
        /// The request scope included the string "profile"
        /// The ID token is returned from a token refresh
        /// When name claims are present, you can use them to update your app's user records. Note that this claim is never guaranteed to be present.
        /// </summary>
        public bool isPlusUser { get; set; }

        /// <summary>
        /// The URL of the user's profile picture. Might be provided when:
        /// The request scope included the string "profile"
        /// The ID token is returned from a token refresh
        /// When picture claims are present, you can use them to update your app's user records. Note that this claim is never guaranteed to be present.
        /// </summary>
        public string circledByCount { get; set; }

        public string verified { get; set; }
    }
}